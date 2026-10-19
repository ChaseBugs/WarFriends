// Uses NVIDIA PhysX 3.4; see ../../THIRD_PARTY_NOTICES/PhysX.txt.
#include "PxPhysicsAPI.h"
#include <atomic>
#include <cmath>
#include <cstdint>
#include <limits>
#include <map>
#include <memory>
#include <mutex>
#include <vector>

#ifdef _WIN32
#define ROPE_API extern "C" __declspec(dllexport)
#else
#define ROPE_API extern "C" __attribute__((visibility("default")))
#endif

using namespace physx;

namespace
{
    constexpr int MaximumBodies = 128;
    constexpr int MaximumRopes = 64;
    constexpr int PoseSize = 7;
    constexpr int HeaderSize = 14;
    constexpr int MotionSize = 13;
    constexpr float FixedDelta = 0.02f;
    constexpr int AbiVersion = 1;
    constexpr int Success = 0;
    constexpr int InvalidInput = 1;
    constexpr int CapacityExceeded = 2;
    constexpr int PhysicsFailure = 3;

    class PhysicsErrors : public PxErrorCallback
    {
    public:
        std::atomic<bool> hasFailed{false};
        PxDefaultErrorCallback diagnostics;

        void reportError(PxErrorCode::Enum code, const char* message, const char* file, int line) override
        {
            const int failureMask = PxErrorCode::eINVALID_PARAMETER | PxErrorCode::eINVALID_OPERATION |
                PxErrorCode::eOUT_OF_MEMORY | PxErrorCode::eINTERNAL_ERROR | PxErrorCode::eABORT;
            if (code & failureMask)
            {
                hasFailed.store(true);
            }
            diagnostics.reportError(code, message, file, line);
        }
    };

    struct Rope
    {
        PxScene* scene = nullptr;
        PxRigidDynamic* aircraft = nullptr;
        std::vector<PxRigidDynamic*> bodies;
        std::vector<PxJoint*> joints;

        ~Rope()
        {
            for (PxJoint* joint : joints)
            {
                joint->release();
            }
            for (PxRigidDynamic* body : bodies)
            {
                body->release();
            }
            if (aircraft)
            {
                aircraft->release();
            }
            if (scene)
            {
                scene->release();
            }
        }
    };

    struct Runtime
    {
        PxDefaultAllocator allocator;
        PhysicsErrors errors;
        PxFoundation* foundation = nullptr;
        PxPhysics* physics = nullptr;
        PxDefaultCpuDispatcher* dispatcher = nullptr;
        bool extensionsReady = false;
        std::map<uintptr_t, std::unique_ptr<Rope>> ropes;
        uintptr_t nextHandle = 1;
        std::mutex gate;

        Runtime()
        {
            foundation = PxCreateFoundation(PX_FOUNDATION_VERSION, allocator, errors);
            if (!foundation)
            {
                return;
            }
            physics = PxCreatePhysics(PX_PHYSICS_VERSION, *foundation, PxTolerancesScale(), false, nullptr);
            if (!physics)
            {
                return;
            }
            extensionsReady = PxInitExtensions(*physics, nullptr);
            dispatcher = PxDefaultCpuDispatcherCreate(1);
        }

        ~Runtime()
        {
            ropes.clear();
            if (dispatcher)
            {
                dispatcher->release();
            }
            if (extensionsReady)
            {
                PxCloseExtensions();
            }
            if (physics)
            {
                physics->release();
            }
            if (foundation)
            {
                foundation->release();
            }
        }
    };

    Runtime& GetRuntime()
    {
        static Runtime runtime;
        return runtime;
    }

    PxTransform ReadPose(const float* values)
    {
        return PxTransform(PxVec3(values[0], values[1], values[2]),
            PxQuat(values[3], values[4], values[5], values[6]));
    }

    bool ValidateInput(const float* values, int length, int bodyCount)
    {
        if (!values || bodyCount < 2 || bodyCount > MaximumBodies || length != HeaderSize + bodyCount * PoseSize)
        {
            return false;
        }
        for (int index = 0; index < length; index++)
        {
            if (!std::isfinite(values[index]) || std::abs(values[index]) > 10000.0f)
            {
                return false;
            }
        }
        if (!ReadPose(values).isValid() || !PxQuat(values[7], values[8], values[9], values[10]).isUnit())
        {
            return false;
        }
        for (int index = 0; index < bodyCount; index++)
        {
            if (!ReadPose(values + HeaderSize + index * PoseSize).isValid())
            {
                return false;
            }
        }
        return true;
    }

    PxRigidDynamic* CreateBody(Runtime& runtime, Rope& rope, const PxTransform& pose)
    {
        PxRigidDynamic* body = runtime.physics->createRigidDynamic(pose);
        if (!body)
        {
            throw std::bad_alloc();
        }
        body->setMass(1.0f);
        body->setMassSpaceInertiaTensor(PxVec3(1.0f));
        body->setLinearDamping(0.2f);
        body->setAngularDamping(0.05f);
        body->setMaxAngularVelocity(7.0f);
        body->setSleepThreshold(0.005f);
        body->setSolverIterationCounts(1, 1);
        rope.scene->addActor(*body);
        return body;
    }

    std::unique_ptr<Rope> CreateRope(Runtime& runtime, const float* values, int bodyCount)
    {
        std::unique_ptr<Rope> rope(new Rope());
        rope->bodies.reserve(bodyCount);
        rope->joints.reserve(bodyCount);
        PxSceneDesc description(runtime.physics->getTolerancesScale());
        description.gravity = PxVec3(0, -9.81f, 0);
        description.cpuDispatcher = runtime.dispatcher;
        description.filterShader = PxDefaultSimulationFilterShader;
        rope->scene = runtime.physics->createScene(description);
        if (!rope->scene)
        {
            throw std::bad_alloc();
        }
        rope->aircraft = CreateBody(runtime, *rope, ReadPose(values));
        rope->aircraft->setRigidBodyFlag(PxRigidBodyFlag::eKINEMATIC, true);
        for (int index = 0; index < bodyCount; index++)
        {
            rope->bodies.push_back(CreateBody(runtime, *rope, ReadPose(values + HeaderSize + index * PoseSize)));
        }
        PxTransform attachment(PxVec3(values[11], values[12], values[13]),
            PxQuat(values[7], values[8], values[9], values[10]));
        PxJoint* fixed = PxFixedJointCreate(*runtime.physics, rope->bodies[0], PxTransform(PxIdentity),
            rope->aircraft, attachment);
        if (!fixed)
        {
            throw std::bad_alloc();
        }
        rope->joints.push_back(fixed);
        const float radians = PxPi / 180.0f;
        for (int index = 0; index < bodyCount - 1; index++)
        {
            PxTransform connected = rope->bodies[index + 1]->getGlobalPose().transformInv(
                rope->bodies[index]->getGlobalPose());
            PxD6Joint* joint = PxD6JointCreate(*runtime.physics, rope->bodies[index], PxTransform(PxIdentity),
                rope->bodies[index + 1], connected);
            if (!joint)
            {
                throw std::bad_alloc();
            }
            rope->joints.push_back(joint);
            joint->setMotion(PxD6Axis::eTWIST, PxD6Motion::eLIMITED);
            joint->setMotion(PxD6Axis::eSWING1, PxD6Motion::eLIMITED);
            joint->setMotion(PxD6Axis::eSWING2, PxD6Motion::eLIMITED);
            joint->setTwistLimit(PxJointAngularLimitPair(-60 * radians, 60 * radians, 0));
            joint->setSwingLimit(PxJointLimitCone(35 * radians, 35 * radians, 0));
        }
        return rope;
    }
}

ROPE_API int war_rope_abi_version()
{
    return AbiVersion;
}

ROPE_API int war_rope_create(const float* values, int length, int bodyCount, uintptr_t* handle)
{
    if (!handle)
    {
        return InvalidInput;
    }
    *handle = 0;
    if (!ValidateInput(values, length, bodyCount))
    {
        return InvalidInput;
    }
    try
    {
        Runtime& runtime = GetRuntime();
        std::lock_guard<std::mutex> lock(runtime.gate);
        if (!runtime.physics || !runtime.dispatcher || !runtime.extensionsReady || runtime.errors.hasFailed.load())
        {
            return PhysicsFailure;
        }
        if (runtime.ropes.size() >= MaximumRopes || runtime.nextHandle == std::numeric_limits<uintptr_t>::max())
        {
            return CapacityExceeded;
        }
        uintptr_t identity = runtime.nextHandle++;
        std::unique_ptr<Rope> rope = CreateRope(runtime, values, bodyCount);
        if (runtime.errors.hasFailed.load())
        {
            return PhysicsFailure;
        }
        runtime.ropes.emplace(identity, std::move(rope));
        *handle = identity;
        return Success;
    }
    catch (...)
    {
        return PhysicsFailure;
    }
}

ROPE_API int war_rope_step(uintptr_t handle)
{
    try
    {
        Runtime& runtime = GetRuntime();
        std::lock_guard<std::mutex> lock(runtime.gate);
        auto found = runtime.ropes.find(handle);
        if (found == runtime.ropes.end())
        {
            return InvalidInput;
        }
        if (runtime.errors.hasFailed.load())
        {
            return PhysicsFailure;
        }
        found->second->scene->simulate(FixedDelta);
        bool completed = found->second->scene->fetchResults(true);
        return completed && !runtime.errors.hasFailed.load() ? Success : PhysicsFailure;
    }
    catch (...)
    {
        return PhysicsFailure;
    }
}

ROPE_API int war_rope_snapshot(uintptr_t handle, float* output, int length)
{
    try
    {
        Runtime& runtime = GetRuntime();
        std::lock_guard<std::mutex> lock(runtime.gate);
        auto found = runtime.ropes.find(handle);
        if (runtime.errors.hasFailed.load())
        {
            return PhysicsFailure;
        }
        if (found == runtime.ropes.end() || !output || length != found->second->bodies.size() * MotionSize)
        {
            return InvalidInput;
        }
        int offset = 0;
        for (PxRigidDynamic* body : found->second->bodies)
        {
            PxTransform pose = body->getGlobalPose();
            PxVec3 velocity = body->getLinearVelocity(), angular = body->getAngularVelocity();
            const float row[] = { pose.p.x, pose.p.y, pose.p.z, pose.q.x, pose.q.y, pose.q.z, pose.q.w,
                velocity.x, velocity.y, velocity.z, angular.x, angular.y, angular.z };
            for (float value : row)
            {
                output[offset++] = value;
            }
        }
        return Success;
    }
    catch (...)
    {
        return PhysicsFailure;
    }
}

ROPE_API int war_rope_destroy(uintptr_t handle)
{
    try
    {
        Runtime& runtime = GetRuntime();
        std::lock_guard<std::mutex> lock(runtime.gate);
        return runtime.ropes.erase(handle) == 1 ? Success : InvalidInput;
    }
    catch (...)
    {
        return PhysicsFailure;
    }
}
