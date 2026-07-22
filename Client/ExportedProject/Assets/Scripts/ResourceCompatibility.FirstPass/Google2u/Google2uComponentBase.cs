using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Google2u
{
	public class Google2uComponentBase : MonoBehaviour
	{
		protected IList mRows;

		private Dictionary<string, PropertyInfo> mRowProperties;

		public virtual bool haveDictionary => false;

		public virtual int getColumnCount => 0;

		public IEnumerable<string> columnNames => null;

		public IList RowsGeneric => null;

		public virtual void AddRowGeneric(List<string> input)
		{
		}

		public virtual int AddRowGenericRealyAdd(List<string> input)
		{
			return 0;
		}

		public virtual int AddBlanckRowGeneric(string rowId)
		{
			return 0;
		}

		public virtual void CheckRows(List<string> rowIds)
		{
		}

		public virtual void Clear()
		{
		}

		public bool HasColumn(string fieldName)
		{
			return false;
		}

		public virtual int GetRowIndex(string rowID)
		{
			return 0;
		}

		public object GetValue(int rowIndex, string valueName)
		{
			return null;
		}

		public object GetValue(string rowName, string valueName)
		{
			return null;
		}

		private static object CheckObscured(object input)
		{
			return null;
		}

		private static object ConvertTypes(object value, Type resType)
		{
			return null;
		}

		public void SetValue(int rowIndex, string columnName, string value)
		{
		}

		private static object CreateTest<TRowType>(Func<TRowType, object> invoke, object param)
		{
			return null;
		}

		protected PropertyInfo GetPropInfo(object row, string fieldName)
		{
			return null;
		}

		protected void GetAllPropInfos(object row)
		{
		}

		private object GetRow(int index)
		{
			return null;
		}
	}
}
