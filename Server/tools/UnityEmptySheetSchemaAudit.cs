using System;
using System.Collections.Generic;
using Google2u;
using UnityEditor;
using UnityEngine;

/// <summary>Checks real empty-sheet metadata without adding invented game rows.</summary>
public static class UnityEmptySheetSchemaAudit
{
    private const int SampleLevel = 7;

    /// <summary>Checks empty and populated generated tables and keeps absent value reads invalid.</summary>
    public static void Run()
    {
        var root = new GameObject("EmptySheetSchemaProbe");
        root.SetActive(false);
        var sheet = root.AddComponent<Squads>();
        int errors = 0;
        Application.LogCallback observe = (condition, stack, type) =>
        {
            if (type == LogType.Error)
            {
                errors++;
            }
        };
        Application.logMessageReceived += observe;
        try
        {
            Require(sheet.Rows.Count == 0, "The probe must start without rows.");
            var expected = new HashSet<string> { "LEVEL", "SIZE", "NAME", "EXPERIENCE", "CARDPOOLSIZE" };
            Require(expected.SetEquals(sheet.columnNames), "Empty table schema differs from its generated columns.");
            Require(sheet.HasColumn("LEVEL") && sheet.HasColumn("name") &&
                !sheet.HasColumn("UNKNOWN") && !sheet.HasColumn("Length") && !sheet.HasColumn("Item"),
                "Metadata queries accepted structural properties or rejected declared columns.");
            Require(errors == 0 && sheet.Rows.Count == 0, "Schema discovery read or invented a data row.");
            Require(sheet.GetValue(0, "LEVEL") == null && errors == 1,
                "An absent value row stopped failing closed.");
            sheet.Rows.Add(new SquadsRow { LEVEL = SampleLevel });
            Require((int)sheet.GetValue(0, "LEVEL") == SampleLevel && expected.SetEquals(sheet.columnNames),
                "Populated-table value access or metadata changed.");
            Require(errors == 1 && sheet.Rows.Count == 1, "Metadata mutated the generated table.");
            Debug.Log("UNITY_EMPTY_SHEET_SCHEMA_PASSED emptyMetadata=True absentValueRejected=True populatedUnchanged=True");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            Application.logMessageReceived -= observe;
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
