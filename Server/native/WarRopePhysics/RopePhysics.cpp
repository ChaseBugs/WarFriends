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
    constexpr int AbiVersion = 4;
    constexpr float RagdollDelta = 0.004f;
    constexpr float MaximumCoordinate = 10000.0f;
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
            if (!std::isfinite(values[index]) || std::abs(values[index]) > MaximumCoordinate)
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

    struct ReleasePhysicsObject
    {
        template<class T> void operator()(T* object) const
        {
            if (object)
            {
                object->release();
            }
        }
    };

    using OwnedBody = std::unique_ptr<PxRigidDynamic, ReleasePhysicsObject>;
    using OwnedJoint = std::unique_ptr<PxJoint, ReleasePhysicsObject>;

    PxD6Joint* CreateLink(Runtime& runtime, PxRigidDynamic* first, PxRigidDynamic* second,
        const PxTransform& connectedFrame)
    {
        PxD6Joint* joint = PxD6JointCreate(*runtime.physics, first, PxTransform(PxIdentity), second, connectedFrame);
        if (!joint)
        {
            throw std::bad_alloc();
        }
        const float radians = PxPi / 180.0f;
        joint->setMotion(PxD6Axis::eTWIST, PxD6Motion::eLIMITED);
        joint->setMotion(PxD6Axis::eSWING1, PxD6Motion::eLIMITED);
        joint->setMotion(PxD6Axis::eSWING2, PxD6Motion::eLIMITED);
        joint->setTwistLimit(PxJointAngularLimitPair(-60 * radians, 60 * radians, 0));
        joint->setSwingLimit(PxJointLimitCone(35 * radians, 35 * radians, 0));
        return joint;
    }

    int ExtendRope(Runtime& runtime, Rope& rope, const float* values, int length)
    {
        bool shouldInsert = length == 10;
        if (shouldInsert && rope.bodies.size() == MaximumBodies)
        {
            return CapacityExceeded;
        }
        rope.bodies.reserve(rope.bodies.size() + 1);
        rope.joints.reserve(rope.joints.size() + 1);
        PxRigidDynamic* first = rope.bodies[1];
        PxTransform moved(PxVec3(values[0], values[1], values[2]), first->getGlobalPose().q);
        OwnedBody inserted;
        OwnedJoint insertedLink;
        if (shouldInsert)
        {
            inserted.reset(CreateBody(runtime, rope, ReadPose(values + 3)));
            // AddConfigJoint implicitly adds a default Rigidbody; ExtendRope never applies the initial drag=0.2.
            inserted->setLinearDamping(0.0f);
            insertedLink.reset(CreateLink(runtime, inserted.get(), first,
                moved.transformInv(inserted->getGlobalPose())));
        }
        PxRigidDynamic* newHead = shouldInsert ? inserted.get() : first;
        PxTransform newHeadPose = shouldInsert ? inserted->getGlobalPose() : moved;
        PxTransform connectedFrame = newHeadPose.transformInv(rope.bodies[0]->getGlobalPose());
        if (runtime.errors.hasFailed.load())
        {
            return PhysicsFailure;
        }
        // Retain the root constraint identity, as connectedBody reassignment does in the source.
        PxJoint* headJoint = rope.joints[1];
        headJoint->setActors(rope.bodies[0], nullptr);
        first->setRigidBodyFlag(PxRigidBodyFlag::eKINEMATIC, true);
        first->setGlobalPose(moved);
        first->setRigidBodyFlag(PxRigidBodyFlag::eKINEMATIC, false);
        headJoint->setLocalPose(PxJointActorIndex::eACTOR1, connectedFrame);
        headJoint->setActors(rope.bodies[0], newHead);
        if (shouldInsert)
        {
            rope.bodies.insert(rope.bodies.begin() + 1, inserted.release());
            rope.joints.insert(rope.joints.begin() + 2, insertedLink.release());
        }
        return runtime.errors.hasFailed.load() ? PhysicsFailure : Success;
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
        for (int index = 0; index < bodyCount - 1; index++)
        {
            PxTransform connected = rope->bodies[index + 1]->getGlobalPose().transformInv(
                rope->bodies[index]->getGlobalPose());
            PxD6Joint* joint = CreateLink(runtime, rope->bodies[index], rope->bodies[index + 1], connected);
            rope->joints.push_back(joint);
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

ROPE_API int war_rope_set_aircraft_transform(uintptr_t handle, const float* values, int length)
{
    if (!values || length != PoseSize)
    {
        return InvalidInput;
    }
    for (int index = 0; index < length; index++)
    {
        if (!std::isfinite(values[index]) || std::abs(values[index]) > MaximumCoordinate)
        {
            return InvalidInput;
        }
    }
    PxTransform target = ReadPose(values);
    if (!target.isValid())
    {
        return InvalidInput;
    }
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
        Rope& rope = *found->second;
        PxTransform previousAircraft = rope.aircraft->getGlobalPose();
        // QuickRope2 leaves generated middle bodies unparented; only root and ropeEnd inherit aircraft transforms.
        PxRigidDynamic* children[] = { rope.bodies.front(), rope.bodies.back() };
        PxTransform poses[2];
        for (int index = 0; index < 2; index++)
        {
            PxTransform localPose = previousAircraft.transformInv(children[index]->getGlobalPose());
            poses[index] = target.transform(localPose);
            PxVec3 position = poses[index].p;
            if (!poses[index].isValid() || std::abs(position.x) > MaximumCoordinate ||
                std::abs(position.y) > MaximumCoordinate || std::abs(position.z) > MaximumCoordinate)
            {
                return InvalidInput;
            }
        }
        // Helicopter.Update writes Transform directly. Kinematic targets would invent motion-derived velocity.
        rope.aircraft->setGlobalPose(target);
        for (int index = 0; index < 2; index++)
        {
            children[index]->setGlobalPose(poses[index]);
        }
        return runtime.errors.hasFailed.load() ? PhysicsFailure : Success;
    }
    catch (...)
    {
        return PhysicsFailure;
    }
}

ROPE_API int war_rope_extend(uintptr_t handle, const float* values, int length, int expectedBodyCount)
{
    if (!values || (length != 3 && length != 10))
    {
        return InvalidInput;
    }
    for (int index = 0; index < length; index++)
    {
        if (!std::isfinite(values[index]) || std::abs(values[index]) > MaximumCoordinate)
        {
            return InvalidInput;
        }
    }
    if (length == 10 && !ReadPose(values + 3).isValid())
    {
        return InvalidInput;
    }
    try
    {
        Runtime& runtime = GetRuntime();
        std::lock_guard<std::mutex> lock(runtime.gate);
        auto found = runtime.ropes.find(handle);
        if (found == runtime.ropes.end() || expectedBodyCount < 3 ||
            found->second->bodies.size() != expectedBodyCount) return InvalidInput;
        if (runtime.errors.hasFailed.load())
        {
            return PhysicsFailure;
        }
        return ExtendRope(runtime, *found->second, values, length);
    }
    catch (...)
    {
        return PhysicsFailure;
    }
}

ROPE_API int war_rope_step(uintptr_t handle, float deltaTime)
{
    if (!std::isfinite(deltaTime) || (deltaTime != FixedDelta && deltaTime != RagdollDelta))
    {
        return InvalidInput;
    }
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
        found->second->scene->simulate(deltaTime);
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
