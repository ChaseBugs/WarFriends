using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Copy into an empty Unity 2018.3 project's Assets/Editor and invoke
// -executeMethod UnityMinigunnerSortAudit.Run. This is the exact comparison
// form used by SoldierBehaviourMinigunner.PickSpawnPoint with nonzero ranges.
public static class UnityMinigunnerSortAudit
{
    public static void Run()
    {
        for (int count = 2; count <= 3; count++)
        {
            for (int parity = 0; parity < 2; parity++)
            {
                var list = new List<int>();
                for (int i = 0; i < count; i++) list.Add(i);
                int currentParity = parity;
                list.Sort((a, b) =>
                {
                    float value = a + 1;
                    if (currentParity == 0) value = 0f;
                    float other = b + 1;
                    if (currentParity != 0) other = 0f;
                    return other.CompareTo(value);
                });
                int expected = parity == 0 ? count - 1 : 0;
                if (list[0] != expected)
                    throw new InvalidOperationException("Minigunner sort changed for " + count +
                        " points, parity " + parity + ": " + list[0]);
                Debug.Log("MINIGUNNER_SORT " + count + " " + parity + " " + list[0]);
            }
        }
        Debug.Log("MINIGUNNER_SORT PASS");
        EditorApplication.Exit(0);
    }
}
