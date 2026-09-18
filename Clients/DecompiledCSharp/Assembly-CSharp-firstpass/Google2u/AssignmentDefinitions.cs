using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u;

public class AssignmentDefinitions : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		ID_0,
		ID_1,
		ID_2,
		ID_3,
		ID_4,
		ID_5,
		ID_6,
		ID_7,
		ID_8,
		ID_9,
		ID_10,
		ID_11,
		ID_12,
		ID_13,
		ID_14,
		ID_15,
		ID_16
	}

	public string[] rowNames = new string[17]
	{
		"ID_0", "ID_1", "ID_2", "ID_3", "ID_4", "ID_5", "ID_6", "ID_7", "ID_8", "ID_9",
		"ID_10", "ID_11", "ID_12", "ID_13", "ID_14", "ID_15", "ID_16"
	};

	public List<AssignmentDefinitionsRow> Rows = new List<AssignmentDefinitionsRow>();

	public override void AddRowGeneric(List<string> input)
	{
		Rows.Add(new AssignmentDefinitionsRow(input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11], input[12], input[13], input[14], input[15], input[16], input[17], input[18], input[19], input[20], input[21], input[22], input[23]));
	}

	public override void Clear()
	{
		Rows.Clear();
	}

	public IGoogle2uRow GetGenRow(string in_RowString)
	{
		IGoogle2uRow result = null;
		try
		{
			result = Rows[(int)Enum.Parse(typeof(rowIds), in_RowString)];
		}
		catch (ArgumentException)
		{
			Debug.LogError(in_RowString + " is not a member of the rowIds enumeration.");
		}
		return result;
	}

	public IGoogle2uRow GetGenRow(rowIds in_RowID)
	{
		IGoogle2uRow result = null;
		try
		{
			result = Rows[(int)in_RowID];
		}
		catch (KeyNotFoundException ex)
		{
			Debug.LogError(string.Concat(in_RowID, " not found: ", ex.Message));
		}
		return result;
	}

	public AssignmentDefinitionsRow GetRow(rowIds in_RowID)
	{
		AssignmentDefinitionsRow result = null;
		try
		{
			result = Rows[(int)in_RowID];
		}
		catch (KeyNotFoundException ex)
		{
			Debug.LogError(string.Concat(in_RowID, " not found: ", ex.Message));
		}
		return result;
	}

	public AssignmentDefinitionsRow GetRow(string in_RowString)
	{
		AssignmentDefinitionsRow result = null;
		try
		{
			result = Rows[(int)Enum.Parse(typeof(rowIds), in_RowString)];
		}
		catch (ArgumentException)
		{
			Debug.LogError(in_RowString + " is not a member of the rowIds enumeration.");
		}
		return result;
	}
}
