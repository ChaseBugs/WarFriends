using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Read-only export of mesh triangles referenced by the recovered co-op scenes.
/// Install this file in Assets/Editor of a disposable Unity 2018 project.
/// No scene, prefab, or mesh asset is saved.
/// </summary>
public static class CoopMeshGeometryExport
{
    public static void Run()
    {
        string manifestPath = Environment.GetEnvironmentVariable(
            "WAR_COOP_COLLIDER_MANIFEST");
        string outputPath = Environment.GetEnvironmentVariable(
            "WAR_COOP_MESH_OUTPUT");
        if (string.IsNullOrEmpty(manifestPath) ||
            string.IsNullOrEmpty(outputPath))
            throw new InvalidOperationException(
                "Set WAR_COOP_COLLIDER_MANIFEST and WAR_COOP_MESH_OUTPUT.");

        var root = JObject.Parse(File.ReadAllText(manifestPath));
        if ((int)root["version"] != 1)
            throw new InvalidOperationException("Unknown co-op collider manifest.");
        var requested = new SortedSet<string>(StringComparer.Ordinal);
        foreach (JToken map in root["maps"])
        foreach (JToken collider in map["colliders"])
        {
            if ((string)collider["componentType"] != "MeshCollider")
                continue;
            JToken shape = collider["shape"];
            if ((int)shape["meshFileId"] == 0)
                continue;
            if ((int)shape["meshFileId"] != 4300000)
                throw new InvalidOperationException("Unknown mesh local file ID.");
            requested.Add((string)shape["meshGuid"]);
        }
        if (requested.Count != 147)
            throw new InvalidOperationException("Co-op source mesh set changed.");

        var meshes = new List<object>();
        foreach (string guid in requested)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (string.IsNullOrEmpty(path) ||
                !path.StartsWith("Assets/Mesh/", StringComparison.Ordinal) ||
                !path.EndsWith(".asset", StringComparison.Ordinal))
                throw new InvalidOperationException("Unresolved co-op mesh " + guid);
            Mesh mesh = AssetDatabase.LoadAssetAtPath<Mesh>(path);
            if (mesh == null)
                throw new InvalidOperationException("Missing co-op mesh " + path);
            string verifiedGuid;
            long fileId;
            if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(
                    mesh, out verifiedGuid, out fileId) ||
                verifiedGuid != guid || fileId != 4300000)
                throw new InvalidOperationException("Co-op mesh identity changed: " + path);
            Vector3[] vertices = mesh.vertices;
            int[] triangles = mesh.triangles;
            if (vertices.Length == 0 || triangles.Length == 0 ||
                triangles.Length % 3 != 0 ||
                triangles.Any(index => index < 0 || index >= vertices.Length))
                throw new InvalidOperationException("Empty or damaged co-op mesh: " + path);
            meshes.Add(new
            {
                guid,
                fileId,
                source = path,
                sourceSha256 = Sha256(path),
                vertices = vertices.Select(Vector).ToArray(),
                triangles
            });
        }

        Directory.CreateDirectory(Path.GetDirectoryName(
            Path.GetFullPath(outputPath)));
        File.WriteAllText(outputPath, JsonConvert.SerializeObject(new
        {
            version = 1,
            client = "1.4.0",
            unity = Application.unityVersion,
            colliderSourceSha256 = Sha256(manifestPath),
            meshes
        }, Formatting.Indented));
        Debug.Log("COOP_MESH_GEOMETRY_EXPORTED meshes=" + meshes.Count +
            " output=" + outputPath);
    }

    private static float[] Vector(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static string Sha256(string path)
    {
        using (var digest = SHA256.Create())
            return BitConverter.ToString(digest.ComputeHash(
                File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
    }
}
