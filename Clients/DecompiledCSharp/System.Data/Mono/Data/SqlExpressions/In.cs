using System;
using System.Collections;
using System.Data;

namespace Mono.Data.SqlExpressions;

internal class In : UnaryExpression
{
	private IList set;

	public In(IExpression e, IList set)
		: base(e)
	{
		this.set = set;
	}

	public override bool Equals(object obj)
	{
		if (!base.Equals(obj))
		{
			return false;
		}
		if (!(obj is In))
		{
			return false;
		}
		In obj2 = (In)obj;
		if (obj2.set.Count != set.Count)
		{
			return false;
		}
		int i = 0;
		for (int count = set.Count; i < count; i++)
		{
			object obj3 = set[i];
			object obj4 = obj2.set[i];
			if (obj3 == null && obj4 != null)
			{
				return false;
			}
			if (!obj3.Equals(obj4))
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = base.GetHashCode();
		int i = 0;
		for (int count = set.Count; i < count; i++)
		{
			object obj = set[i];
			if (obj != null)
			{
				num ^= obj.GetHashCode();
			}
		}
		return num;
	}

	public override object Eval(DataRow row)
	{
		object obj = expr.Eval(row);
		if (obj == DBNull.Value)
		{
			return obj;
		}
		if (!(obj is IComparable o))
		{
			return false;
		}
		foreach (IExpression item in set)
		{
			IComparable comparable = (IComparable)item.Eval(row);
			if (comparable == null || Comparison.Compare(o, comparable, row.Table.CaseSensitive) != 0)
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public override bool EvalBoolean(DataRow row)
	{
		return (bool)Eval(row);
	}
}
