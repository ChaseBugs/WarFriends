using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u
{
	public class Google2uComponentBase : MonoBehaviour
	{
		protected IList mRows;

		private Dictionary<string, PropertyInfo> mRowProperties = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);

		public virtual bool haveDictionary
		{
			get
			{
				return false;
			}
		}

		public virtual int getColumnCount
		{
			get
			{
				return -1;
			}
		}

		public IEnumerable<string> columnNames
		{
			get
			{
				if (mRowProperties.Count == 0)
				{
					object row = GetRow(0);
					GetAllPropInfos(row);
				}
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, PropertyInfo> mRowProperty in mRowProperties)
				{
					if (mRowProperty.Value != null)
					{
						list.Add(mRowProperty.Key);
					}
				}
				return list;
			}
		}

		public IList RowsGeneric
		{
			get
			{
				if (mRows == null)
				{
					Type type = GetType();
					mRows = (IList)type.GetField("Rows").GetValue(this);
				}
				if (mRows != null)
				{
					return mRows;
				}
				return null;
			}
		}

		public virtual void AddRowGeneric(List<string> input)
		{
		}

		public virtual int AddRowGenericRealyAdd(List<string> input)
		{
			return -2;
		}

		public virtual int AddBlanckRowGeneric(string rowId)
		{
			return -2;
		}

		public virtual void CheckRows(List<string> rowIds)
		{
		}

		public virtual void Clear()
		{
		}

		public bool HasColumn(string fieldName)
		{
			object row = GetRow(0);
			Type type = row.GetType();
			PropertyInfo value;
			if (!mRowProperties.TryGetValue(fieldName, out value))
			{
				value = type.GetProperty("Get_" + fieldName.ToUpper());
				mRowProperties[fieldName] = value;
			}
			return value != null;
		}

		public virtual int GetRowIndex(string rowID)
		{
			return -2;
		}

		public object GetValue(int rowIndex, string valueName)
		{
			object row = GetRow(rowIndex);
			if (row != null)
			{
				return CheckObscured(GetPropInfo(row, valueName).GetValue(row, null));
			}
			return null;
		}

		public object GetValue(string rowName, string valueName)
		{
			int rowIndex = GetRowIndex(rowName);
			if (rowIndex >= 0)
			{
				object row = GetRow(rowIndex);
				if (row != null)
				{
					return CheckObscured(GetPropInfo(row, valueName).GetValue(row, null));
				}
			}
			return null;
		}

		private static object CheckObscured(object input)
		{
			if (input is ObscuredInt)
			{
				return (int)(ObscuredInt)input;
			}
			if (input is ObscuredFloat)
			{
				return (float)(ObscuredFloat)input;
			}
			return input;
		}

		private static object ConvertTypes(object value, Type resType)
		{
			object obj = null;
			if (resType == typeof(ObscuredFloat))
			{
				float num = (float)Convert.ChangeType(value, typeof(float));
				ObscuredFloat obscuredFloat = default(ObscuredFloat);
				obscuredFloat = num;
				return obscuredFloat;
			}
			if (resType == typeof(ObscuredInt))
			{
				int num2 = (int)Convert.ChangeType(value, typeof(int));
				ObscuredInt obscuredInt = default(ObscuredInt);
				obscuredInt = num2;
				return obscuredInt;
			}
			return Convert.ChangeType(value, resType);
		}

		public void SetValue(int rowIndex, string columnName, string value)
		{
			object row = GetRow(rowIndex);
			if (row != null)
			{
				PropertyInfo propInfo = GetPropInfo(row, columnName);
				if (propInfo == null)
				{
					return;
				}
				try
				{
					object value2 = ConvertTypes(value, propInfo.PropertyType);
					propInfo.SetValue(row, value2, null);
					return;
				}
				catch (Exception)
				{
					if (!string.IsNullOrEmpty(value))
					{
						Debug.LogError(string.Format("Can not convert {0} for column {1} to type {2} in sheet {3}", value, columnName, propInfo.PropertyType, GetType()));
					}
					return;
				}
			}
			Debug.LogError("no row to save");
		}

		private static object CreateTest<TRowType>(Func<TRowType, object> invoke, object param)
		{
			return invoke((TRowType)param);
		}

		protected PropertyInfo GetPropInfo(object row, string fieldName)
		{
			Type type = row.GetType();
			PropertyInfo value;
			if (!mRowProperties.TryGetValue(fieldName, out value))
			{
				value = type.GetProperty("Get_" + fieldName.ToUpper());
				mRowProperties[fieldName] = value;
			}
			if (value == null)
			{
				Debug.LogError("Field " + fieldName + " doesnt exist for: " + GetType());
			}
			return value;
		}

		protected void GetAllPropInfos(object row)
		{
			Type type = row.GetType();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				string text = propertyInfo.Name;
				string key = text.Replace("Get_", string.Empty);
				mRowProperties[key] = propertyInfo;
			}
		}

		private object GetRow(int index)
		{
			if (mRows == null)
			{
				Type type = GetType();
				mRows = (IList)type.GetField("Rows").GetValue(this);
			}
			if (mRows != null)
			{
				if (index >= 0 && index < mRows.Count)
				{
					return mRows[index];
				}
				Debug.LogError(string.Format("Row index {0} out of range for sheet {1} {2}", index, base.gameObject.name, GetType()));
			}
			return null;
		}
	}
}
