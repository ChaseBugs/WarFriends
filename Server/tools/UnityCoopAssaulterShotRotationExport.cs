// Source-math reference for the first co-op Assaulter shot rotation.
// Run in a disposable Unity 2018 project; no scene or prefab is saved.
using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEngine;

public static class UnityCoopAssaulterShotRotationExport
{
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable(
            "WAR_COOP_SHOT_ROTATION_OUTPUT");
        if (string.IsNullOrEmpty(output))
            throw new InvalidOperationException(
                "Set WAR_COOP_SHOT_ROTATION_OUTPUT.");

        Vector3 enemy = Vector3.zero;
        Vector3 obstacleTarget = new Vector3(3f, 0f, 4f);
        Vector3 cornerDirection = Vector3.right;
        Vector3 rightTarget = new Vector3(0f, 0f, 4f);
        Vector3 leftTarget = new Vector3(0f, 0f, -4f);

        Quaternion obstacle = Quaternion.LookRotation(
            new Vector3(obstacleTarget.x - enemy.x, 0,
                obstacleTarget.z - enemy.z));
        object[] cases =
        {
            new { name = "obstacle", enemy = V(enemy),
                target = V(obstacleTarget), direction = V(Vector3.zero),
                signedAngle = 0f, rotation = Q(obstacle), tweenSeconds = 0.2f },
            Corner("corner-right", enemy, rightTarget, cornerDirection),
            Corner("corner-left", enemy, leftTarget, cornerDirection)
        };
        using (var sha = SHA256.Create())
        {
            string source = "Assets/Scripts/Assembly-CSharp/EnemyController.cs";
            string geometry =
                "Assets/Plugins/Assembly-CSharp-firstpass/GeometryTools.cs";
            File.WriteAllText(output, JsonConvert.SerializeObject(new
            {
                version = 1,
                unity = Application.unityVersion,
                enemyControllerSha256 = Hash(sha, source),
                geometryToolsSha256 = Hash(sha, geometry),
                cases
            }, Formatting.Indented));
        }
        Debug.Log("COOP_ASSAULTER_ROTATION_EXPORT_PASSED cases=3");
    }

    private static object Corner(string name, Vector3 enemy,
        Vector3 target, Vector3 direction)
    {
        Vector3 towardTarget = target - enemy;
        float sideAngle = GeometryTools.AngleSigned(
            -direction, towardTarget, Vector3.up);
        if (Mathf.Abs(sideAngle) < 10f ||
            (sideAngle > 0f) != (name == "corner-right"))
            throw new InvalidOperationException("Corner case is not exposed.");
        float rotationAngle = GeometryTools.AngleSigned(
            -towardTarget, -direction, Vector3.up);
        Quaternion rotation = Quaternion.LookRotation(-direction) *
            Quaternion.AngleAxis(-rotationAngle, Vector3.up);
        return new { name, enemy = V(enemy), target = V(target),
            direction = V(direction), signedAngle = rotationAngle,
            rotation = Q(rotation), tweenSeconds = 0.3f };
    }

    private static float[] V(Vector3 value) =>
        new[] { value.x, value.y, value.z };

    private static float[] Q(Quaternion value) =>
        new[] { value.x, value.y, value.z, value.w };

    private static string Hash(SHA256 sha, string path) =>
        BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
            .Replace("-", "").ToLowerInvariant();
}
