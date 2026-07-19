using System;
using System.Runtime.CompilerServices;
using Google2u;

public class LMMGHIFJBDC : HHFHFANGCEJ
{
	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	internal virtual Action MPIABHDKIEM(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.VipDogtags).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return IGKJJMDOBPB;
	}

	internal override Action ENNLMIGMBKJ(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-88)).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return LJAGGANKNLE;
	}

	private static void LJAGGANKNLE()
	{
		Singleton<Tweetmanager>.instance.HLEMJFBADJE();
	}

	private static void FGHKOPDODOH()
	{
		Singleton<Tweetmanager>.instance.HLEMJFBADJE();
	}

	internal virtual Action OGPPKOPMIOJ(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinLevelForSquadJoinOrCreateReminder).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return IIBCLAOHFIM;
	}

	public LMMGHIFJBDC()
		: base("FollowUsOnTwitter", NKHJBLBAAEB.FollowUsOnTwitter)
	{
	}

	private static void IGKJJMDOBPB()
	{
		Singleton<Tweetmanager>.instance.JFIEDDBNAMP();
	}

	internal virtual Action OBJIHCHMPHA(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.NotificationAllowReward).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return FLANJEHLMHL;
	}

	public virtual void PCJHCBIHFNF()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	public virtual void JEDGCOMDEKM()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	private static void IIBCLAOHFIM()
	{
		Singleton<Tweetmanager>.instance.HLEMJFBADJE();
	}

	public virtual void NBBAANHAAKK()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	private static void FLANJEHLMHL()
	{
		Singleton<Tweetmanager>.instance.FollowAs();
	}

	[CompilerGenerated]
	private static void JKIAEOLFEGC()
	{
		Singleton<Tweetmanager>.instance.FollowAs();
	}

	internal virtual Action LKKLMINBLKK(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-108)).FLOATVALUE;
		HDEGOGFCNAC.HOILHCOABIA(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return LJAGGANKNLE;
	}

	private static void CCPPBMANOGC()
	{
		Singleton<Tweetmanager>.instance.FollowAs();
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		int fGCHOCKNIDK = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).FLOATVALUE;
		HDEGOGFCNAC.SetAppearance_GenericGetFreeGoldWithSocial(HPGHHECHLAN, KJCKFGCLGLG, fGCHOCKNIDK);
		return delegate
		{
			Singleton<Tweetmanager>.instance.FollowAs();
		};
	}
}
