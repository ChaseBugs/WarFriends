#include "PxPhysicsAPI.h"
#include <fstream>
#include <iomanip>
#include <iostream>
#include <vector>

using namespace physx;

namespace
{
    constexpr float FixedDelta = 0.02f;
    const float RadiansPerDegree = PxPi / 180.0f;
    constexpr int BodyCount = 4;
    constexpr int StepCount = 10;

    PxVec3 ReadVector(std::istream& input)
    {
        float x = 0, y = 0, z = 0;
        input >> x >> y >> z;
        return PxVec3(x, y, z);
    }

    PxQuat ReadRotation(std::istream& input)
    {
        float x = 0, y = 0, z = 0, w = 0;
        input >> x >> y >> z >> w;
        return PxQuat(x, y, z, w);
    }

    PxTransform ReadPose(std::istream& input)
    {
        PxVec3 position = ReadVector(input);
        PxQuat rotation = ReadRotation(input);
        return PxTransform(position, rotation);
    }

    PxRigidDynamic* CreateBody(PxPhysics& physics, PxScene& scene, const PxTransform& pose)
    {
        PxRigidDynamic* body = physics.createRigidDynamic(pose);
        body->setMass(1.0f);
        body->setMassSpaceInertiaTensor(PxVec3(1.0f));
        body->setLinearDamping(0.2f);
        body->setAngularDamping(0.05f);
        body->setMaxAngularVelocity(7.0f);
        body->setSleepThreshold(0.005f);
        body->setSolverIterationCounts(1, 1);
        scene.addActor(*body);
        return body;
    }

    void WriteBody(int step, int scenario, int index, const PxRigidDynamic& body)
    {
        PxTransform pose = body.getGlobalPose();
        PxVec3 velocity = body.getLinearVelocity();
        PxVec3 angular = body.getAngularVelocity();
        std::cout << step << ',' << scenario << ',' << index << ','
            << pose.p.x << ',' << pose.p.y << ',' << pose.p.z << ','
            << pose.q.x << ',' << pose.q.y << ',' << pose.q.z << ',' << pose.q.w << ','
            << velocity.x << ',' << velocity.y << ',' << velocity.z << ','
            << angular.x << ',' << angular.y << ',' << angular.z << '\n';
    }
}

int main(int argumentCount, char** arguments)
{
    if (argumentCount != 2)
    {
        std::cerr << "Usage: NativeRopeProbe input.txt\n";
        return 1;
    }
    std::ifstream input(arguments[1]);
    int scenarioCount = 0;
    input >> scenarioCount;
    if (!input || scenarioCount < 1 || scenarioCount > 16)
    {
        return 2;
    }
    PxDefaultAllocator allocator;
    PxDefaultErrorCallback errors;
    PxFoundation* foundation = PxCreateFoundation(PX_FOUNDATION_VERSION, allocator, errors);
    PxPhysics* physics = PxCreatePhysics(PX_PHYSICS_VERSION, *foundation, PxTolerancesScale(), true, nullptr);
    PxInitExtensions(*physics, nullptr);
    PxDefaultCpuDispatcher* dispatcher = PxDefaultCpuDispatcherCreate(1);
    PxSceneDesc description(physics->getTolerancesScale());
    description.gravity = PxVec3(0, -9.81f, 0);
    description.cpuDispatcher = dispatcher;
    description.filterShader = PxDefaultSimulationFilterShader;
    PxScene* scene = physics->createScene(description);
    std::vector<std::vector<PxRigidDynamic*>> ropes;
    for (int scenario = 0; scenario < scenarioCount; scenario++)
    {
        PxTransform aircraftPose = ReadPose(input);
        PxQuat attachmentRest = ReadRotation(input);
        PxVec3 attachmentAnchor = ReadVector(input);
        PxTransform initial[BodyCount];
        for (int index = 0; index < BodyCount; index++)
        {
            initial[index] = ReadPose(input);
        }
        bool posesAreValid = aircraftPose.isValid() && attachmentRest.isUnit() && attachmentAnchor.isFinite();
        for (const PxTransform& pose : initial)
        {
            posesAreValid = posesAreValid && pose.isValid();
        }
        if (!input || !posesAreValid)
        {
            return 3;
        }
        PxRigidDynamic* aircraft = CreateBody(*physics, *scene, aircraftPose);
        aircraft->setRigidBodyFlag(PxRigidBodyFlag::eKINEMATIC, true);
        std::vector<PxRigidDynamic*> bodies;
        for (int index = 0; index < BodyCount; index++)
        {
            bodies.push_back(CreateBody(*physics, *scene, initial[index]));
        }
        PxFixedJointCreate(*physics, bodies[0], PxTransform(PxIdentity), aircraft,
            PxTransform(attachmentAnchor, attachmentRest));
        for (int index = 0; index < BodyCount - 1; index++)
        {
            PxTransform connected = initial[index + 1].transformInv(initial[index]);
            PxD6Joint* joint = PxD6JointCreate(*physics, bodies[index], PxTransform(PxIdentity),
                bodies[index + 1], connected);
            joint->setMotion(PxD6Axis::eTWIST, PxD6Motion::eLIMITED);
            joint->setMotion(PxD6Axis::eSWING1, PxD6Motion::eLIMITED);
            joint->setMotion(PxD6Axis::eSWING2, PxD6Motion::eLIMITED);
            joint->setTwistLimit(PxJointAngularLimitPair(-60 * RadiansPerDegree, 60 * RadiansPerDegree, 0));
            joint->setSwingLimit(PxJointLimitCone(35 * RadiansPerDegree, 35 * RadiansPerDegree, 0));
        }
        ropes.push_back(bodies);
    }
    std::cout << std::setprecision(9);
    for (int step = 1; step <= StepCount; step++)
    {
        scene->simulate(FixedDelta);
        scene->fetchResults(true);
        for (int scenario = 0; scenario < scenarioCount; scenario++)
        {
            for (int index = 0; index < BodyCount; index++)
            {
                WriteBody(step, scenario, index, *ropes[scenario][index]);
            }
        }
    }
    scene->release();
    dispatcher->release();
    PxCloseExtensions();
    physics->release();
    foundation->release();
    return 0;
}
