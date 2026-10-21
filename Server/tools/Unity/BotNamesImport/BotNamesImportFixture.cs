using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>Minimal serialized row shape for observing Unity's YAML string import.</summary>
public sealed class BotNamesImportFixture : MonoBehaviour
{
    [SerializeField, FormerlySerializedAs("Rows")]
    private List<Row> _rows = new List<Row>();

    public string[] CopyNames()
    {
        var names = new string[_rows.Count];
        for (int index = 0; index < names.Length; index++)
        {
            names[index] = _rows[index].Name;
        }
        return names;
    }

    [Serializable]
    private sealed class Row
    {
        [SerializeField, FormerlySerializedAs("NAME")]
        private string _name;

        public string Name
        {
            get { return _name; }
        }
    }
}
