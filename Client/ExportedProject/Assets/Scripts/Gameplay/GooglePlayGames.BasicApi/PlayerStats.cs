using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GooglePlayGames.BasicApi
{
	public class PlayerStats
	{
		private static float UNSET_VALUE = -1f;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool _003CValid_003Ek__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _003CNumberOfPurchases_003Ek__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _003CAvgSessonLength_003Ek__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _003CDaysSinceLastPlayed_003Ek__BackingField;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int _003CNumberOfSessions_003Ek__BackingField;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float _003CSessPercentile_003Ek__BackingField;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float _003CSpendPercentile_003Ek__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _003CSpendProbability_003Ek__BackingField;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float _003CChurnProbability_003Ek__BackingField;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private float _003CHighSpenderProbability_003Ek__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _003CTotalSpendNext28Days_003Ek__BackingField;

		public bool Valid
		{
			[CompilerGenerated]
			get
			{
				return _003CValid_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CValid_003Ek__BackingField = value;
			}
		}

		public int NumberOfPurchases
		{
			[CompilerGenerated]
			get
			{
				return _003CNumberOfPurchases_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CNumberOfPurchases_003Ek__BackingField = value;
			}
		}

		public float AvgSessonLength
		{
			[CompilerGenerated]
			get
			{
				return _003CAvgSessonLength_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CAvgSessonLength_003Ek__BackingField = value;
			}
		}

		public int DaysSinceLastPlayed
		{
			[CompilerGenerated]
			get
			{
				return _003CDaysSinceLastPlayed_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CDaysSinceLastPlayed_003Ek__BackingField = value;
			}
		}

		public int NumberOfSessions
		{
			[CompilerGenerated]
			get
			{
				return _003CNumberOfSessions_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CNumberOfSessions_003Ek__BackingField = value;
			}
		}

		public float SessPercentile
		{
			[CompilerGenerated]
			get
			{
				return _003CSessPercentile_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CSessPercentile_003Ek__BackingField = value;
			}
		}

		public float SpendPercentile
		{
			[CompilerGenerated]
			get
			{
				return _003CSpendPercentile_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CSpendPercentile_003Ek__BackingField = value;
			}
		}

		public float SpendProbability
		{
			[CompilerGenerated]
			get
			{
				return _003CSpendProbability_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CSpendProbability_003Ek__BackingField = value;
			}
		}

		public float ChurnProbability
		{
			[CompilerGenerated]
			get
			{
				return _003CChurnProbability_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CChurnProbability_003Ek__BackingField = value;
			}
		}

		public float HighSpenderProbability
		{
			[CompilerGenerated]
			get
			{
				return _003CHighSpenderProbability_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CHighSpenderProbability_003Ek__BackingField = value;
			}
		}

		public float TotalSpendNext28Days
		{
			[CompilerGenerated]
			get
			{
				return _003CTotalSpendNext28Days_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CTotalSpendNext28Days_003Ek__BackingField = value;
			}
		}

		public PlayerStats()
		{
			Valid = false;
		}

		public bool HasNumberOfPurchases()
		{
			return NumberOfPurchases != (int)UNSET_VALUE;
		}

		public bool HasAvgSessonLength()
		{
			return AvgSessonLength != UNSET_VALUE;
		}

		public bool HasDaysSinceLastPlayed()
		{
			return DaysSinceLastPlayed != (int)UNSET_VALUE;
		}

		public bool HasNumberOfSessions()
		{
			return NumberOfSessions != (int)UNSET_VALUE;
		}

		public bool HasSessPercentile()
		{
			return SessPercentile != UNSET_VALUE;
		}

		public bool HasSpendPercentile()
		{
			return SpendPercentile != UNSET_VALUE;
		}

		public bool HasChurnProbability()
		{
			return ChurnProbability != UNSET_VALUE;
		}

		public bool HasHighSpenderProbability()
		{
			return HighSpenderProbability != UNSET_VALUE;
		}

		public bool HasTotalSpendNext28Days()
		{
			return TotalSpendNext28Days != UNSET_VALUE;
		}
	}
}
