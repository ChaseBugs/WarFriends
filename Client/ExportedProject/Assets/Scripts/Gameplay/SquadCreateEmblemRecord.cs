using UnityEngine;
using UnityEngine.Serialization;

public class SquadCreateEmblemRecord : PoolableObject
{
	[FormerlySerializedAs("HLIHJDECJAO")]
	[Header("Core")]
	public UITexture GEAGOKJMJFD;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	private string JKCFKNGHLGA;

	private void NBFGMJFDDLB()
	{
		GuiScreenSingle<SquadCreateScreen>.instance.CCAECPBDPJL(JKCFKNGHLGA);
	}

	public void NDLMPHJONDJ(string CAFGINBOFJM)
	{
		KMFGCJEGJJK.gameObject.SetActive(JKCFKNGHLGA == CAFGINBOFJM);
	}

	public override void DestroyPooled()
	{
		GEAGOKJMJFD.mainTexture = null;
		base.DestroyPooled();
	}

	public virtual void IKICBEFAGPE()
	{
		GEAGOKJMJFD.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	public void PDELKBLCPHI(string CAFGINBOFJM)
	{
		KMFGCJEGJJK.gameObject.SetActive(JKCFKNGHLGA == CAFGINBOFJM);
	}

	public virtual void OCEOOGDKBHA()
	{
		GEAGOKJMJFD.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	public void Initialize(string KCHMDALPMBN)
	{
		Texture texture = Resources.Load<Texture>("SquadIcons/" + KCHMDALPMBN);
		if (texture == null)
		{
			Debug.LogError("Squad Emblem " + KCHMDALPMBN + " is not present in resources using default");
			KCHMDALPMBN = "menu-squad-1";
			texture = Resources.Load<Texture>("SquadIcons/" + KCHMDALPMBN);
		}
		JKCFKNGHLGA = KCHMDALPMBN;
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(0.5f);
		SetHighlight(string.Empty);
	}

	private void AAGKACBKKMH()
	{
		GuiScreenSingle<SquadCreateScreen>.instance.HHMHHAEAPMM(JKCFKNGHLGA);
	}

	public void NAKAFGAFEPH(string KCHMDALPMBN)
	{
		Texture texture = Resources.Load<Texture>("Mission data saved" + KCHMDALPMBN);
		if (texture == null)
		{
			Debug.LogError("bad card visuals for" + KCHMDALPMBN + "RESOLUTION_REQUIRED");
			KCHMDALPMBN = "AdminLevel";
			texture = Resources.Load<Texture>("XP" + KCHMDALPMBN);
		}
		JKCFKNGHLGA = KCHMDALPMBN;
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(693f);
		PDELKBLCPHI(string.Empty);
	}

	public void SetHighlight(string CAFGINBOFJM)
	{
		KMFGCJEGJJK.gameObject.SetActive(JKCFKNGHLGA == CAFGINBOFJM);
	}

	private void MIAJBBEHEJL()
	{
		GuiScreenSingle<SquadCreateScreen>.instance.FKILBMIOEKI(JKCFKNGHLGA);
	}

	private void OnClick()
	{
		GuiScreenSingle<SquadCreateScreen>.instance.SelectEmblem(JKCFKNGHLGA);
	}

	public void AJEGOKKKLOL(string KCHMDALPMBN)
	{
		Texture texture = Resources.Load<Texture>("AdminId" + KCHMDALPMBN);
		if (texture == null)
		{
			Debug.LogError("Enemies Freezed" + KCHMDALPMBN + ">");
			KCHMDALPMBN = "{0} {1}";
			texture = Resources.Load<Texture>("Exception when creating cards for tutorial - creating default instead, msg = " + KCHMDALPMBN);
		}
		JKCFKNGHLGA = KCHMDALPMBN;
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(804f);
		PDELKBLCPHI(string.Empty);
	}

	private void AHPBNNEKNBE()
	{
		GuiScreenSingle<SquadCreateScreen>.instance.CCAECPBDPJL(JKCFKNGHLGA);
	}

	public virtual void MIDOLDHLMAF()
	{
		GEAGOKJMJFD.mainTexture = null;
		base.BOHCNEDIJPE();
	}

	public void DDHCMFLIABO(string KCHMDALPMBN)
	{
		Texture texture = Resources.Load<Texture>("menu-close" + KCHMDALPMBN);
		if (texture == null)
		{
			Debug.LogError("HeroicMissionsCompletionRewardArmyUnitId" + KCHMDALPMBN + "MissionReward");
			KCHMDALPMBN = "\"{0}\"\t";
			texture = Resources.Load<Texture>("{0} {1}" + KCHMDALPMBN);
		}
		JKCFKNGHLGA = KCHMDALPMBN;
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(167f);
		NDLMPHJONDJ(string.Empty);
	}

	private void ADALENIJNHD()
	{
		GuiScreenSingle<SquadCreateScreen>.instance.HHMHHAEAPMM(JKCFKNGHLGA);
	}

	public void EPAHIKLPNNB(string KCHMDALPMBN)
	{
		Texture texture = Resources.Load<Texture>("1" + KCHMDALPMBN);
		if (texture == null)
		{
			Debug.LogError("Submited: \"{0}\" for player: \"{1}\" rank:{2} AP:{3} and my rank:{4} AP:{5}. Match duration: {6}" + KCHMDALPMBN + "DeployHeli");
			KCHMDALPMBN = "ID_MISSION_SURVIVE_HUD";
			texture = Resources.Load<Texture>("game-card-ico-shielddestroyer" + KCHMDALPMBN);
		}
		JKCFKNGHLGA = KCHMDALPMBN;
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(114f);
		PDELKBLCPHI(string.Empty);
	}
}
