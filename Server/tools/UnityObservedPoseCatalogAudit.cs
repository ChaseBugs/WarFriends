using System;
using Google.Protobuf;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks the installed portable pose resource on Unity's Mono runtime without starting gameplay.</summary>
public static class UnityObservedPoseCatalogAudit
{
    /// <summary>Validates every embedded sample reference and isolated protobuf copy on the installed SDK.</summary>
    public static void Run()
    {
        try
        {
            ObservedInfantryPoseCatalogData catalog = ObservedInfantryPoseCatalogData.BuiltIn;
            ObservedInfantryPoseCatalog source = catalog.Snapshot();
            int checks = 0;
            foreach (ObservedInfantryPoseSample expected in source.Samples)
            {
                var reference = new BattleInfantryObservedPoseReference
                {
                    CatalogRevision = catalog.Revision, SampleId = expected.Id
                };
                reference = BattleInfantryObservedPoseReference.Parser.ParseFrom(reference.ToByteArray());
                ObservedInfantryPoseSample sample = catalog.GetSample(reference);
                if (!sample.Equals(expected))
                {
                    throw new InvalidOperationException("The installed SDK changed a source pose sample.");
                }
                sample.Clips.Clear();
                if (catalog.GetSample(reference).Clips.Count == 0)
                {
                    throw new InvalidOperationException("A copied sample changed the installed source catalog.");
                }
                checks++;
            }
            Debug.Log("PASS: " + checks + " installed Unity portable pose catalog checks; no rendered gameplay.");
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }
}
