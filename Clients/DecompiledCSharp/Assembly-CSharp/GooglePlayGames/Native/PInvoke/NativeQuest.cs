using System;
using System.Runtime.InteropServices;
using System.Text;
using GooglePlayGames.BasicApi.Quests;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke;

internal class NativeQuest : BaseReferenceHolder, IQuest
{
	private volatile NativeQuestMilestone mCachedMilestone;

	public string Id => PInvokeUtilities.OutParamsToString((StringBuilder out_string, UIntPtr out_size) => Quest.Quest_Id(SelfPtr(), out_string, out_size));

	public string Name => PInvokeUtilities.OutParamsToString((StringBuilder out_string, UIntPtr out_size) => Quest.Quest_Name(SelfPtr(), out_string, out_size));

	public string Description => PInvokeUtilities.OutParamsToString((StringBuilder out_string, UIntPtr out_size) => Quest.Quest_Description(SelfPtr(), out_string, out_size));

	public string BannerUrl => PInvokeUtilities.OutParamsToString((StringBuilder out_string, UIntPtr out_size) => Quest.Quest_BannerUrl(SelfPtr(), out_string, out_size));

	public string IconUrl => PInvokeUtilities.OutParamsToString((StringBuilder out_string, UIntPtr out_size) => Quest.Quest_IconUrl(SelfPtr(), out_string, out_size));

	public DateTime StartTime => PInvokeUtilities.FromMillisSinceUnixEpoch(Quest.Quest_StartTime(SelfPtr()));

	public DateTime ExpirationTime => PInvokeUtilities.FromMillisSinceUnixEpoch(Quest.Quest_ExpirationTime(SelfPtr()));

	public DateTime? AcceptedTime
	{
		get
		{
			long num = Quest.Quest_AcceptedTime(SelfPtr());
			if (num == 0L)
			{
				return null;
			}
			return PInvokeUtilities.FromMillisSinceUnixEpoch(num);
		}
	}

	public IQuestMilestone Milestone
	{
		get
		{
			if (mCachedMilestone == null)
			{
				mCachedMilestone = NativeQuestMilestone.FromPointer(Quest.Quest_CurrentMilestone(SelfPtr()));
			}
			return mCachedMilestone;
		}
	}

	public QuestState State
	{
		get
		{
			Types.QuestState questState = Quest.Quest_State(SelfPtr());
			return questState switch
			{
				Types.QuestState.UPCOMING => QuestState.Upcoming, 
				Types.QuestState.OPEN => QuestState.Open, 
				Types.QuestState.ACCEPTED => QuestState.Accepted, 
				Types.QuestState.COMPLETED => QuestState.Completed, 
				Types.QuestState.EXPIRED => QuestState.Expired, 
				Types.QuestState.FAILED => QuestState.Failed, 
				_ => throw new InvalidOperationException("Unknown state: " + questState), 
			};
		}
	}

	internal NativeQuest(IntPtr selfPointer)
		: base(selfPointer)
	{
	}

	internal bool Valid()
	{
		return Quest.Quest_Valid(SelfPtr());
	}

	protected override void CallDispose(HandleRef selfPointer)
	{
		Quest.Quest_Dispose(selfPointer);
	}

	public override string ToString()
	{
		if (IsDisposed())
		{
			return "[NativeQuest: DELETED]";
		}
		return $"[NativeQuest: Id={Id}, Name={Name}, Description={Description}, BannerUrl={BannerUrl}, IconUrl={IconUrl}, State={State}, StartTime={StartTime}, ExpirationTime={ExpirationTime}, AcceptedTime={AcceptedTime}]";
	}

	internal static NativeQuest FromPointer(IntPtr pointer)
	{
		if (pointer.Equals(IntPtr.Zero))
		{
			return null;
		}
		return new NativeQuest(pointer);
	}
}
