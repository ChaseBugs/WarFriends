using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardCriticalInsurance : Card
{
	[FormerlySerializedAs("BPKNHCGLPJK")]
	public float NMBINECHMGO = 5f;

	private const float IPEGHONOCOJ = 0.5f;

	private const string EJLCMBEKFFN = "game-card-ico-criticalinsurance";

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private PlayerController MBIAKMPDOPG;

	private List<float> CMDFFAJOAPE = new List<float>();

	public virtual void ODIBFAFGJBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 1050f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("Sessions", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BCBFENPIIMP()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 1; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1476f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("!!!ROTATED!!! ", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	public virtual void JGNBFCJFAHM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1354f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("Invite was already send, ignoring click.", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void MLOJPAEBLBL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 1382f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.EOEDEJKJKMN("Message", NABOFKMBMKH: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EOELDFKKJLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1607f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("ID_BRONZEPACK", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void IDLKDDEEALI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 1581f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("weaponDelivery", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void NGCHHKPHGJA()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 247f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.EOEDEJKJKMN("arenaLeaderboard", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
	}

	public virtual void GAGEHEGFGOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1677f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("Card_3_Played", NABOFKMBMKH: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void IGJJHCKMDBK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1438f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("NO", NABOFKMBMKH: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JLBEBADOINI()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 1; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1632f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("SquadWarsId", NABOFKMBMKH: true);
		}
	}

	protected void INHEEMEAIDJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1106f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.OODPJFJIMPI("HeartPrice", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void ANNHOLJMEEH()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1086f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("Lcom/google/android/gms/games/leaderboard/Leaderboards;", NABOFKMBMKH: false);
		}
	}

	protected void FGECFIBLFMD()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 627f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.CMGKLHJOLDD("RETRY", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void LEODNPHAEAE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1940f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.ONONEOAEOHL("ID_WARNING_MAINTENANCE", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void DMHDDHILDJK()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 1; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1135f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("GetSkuInfo succeeded but productId ", NABOFKMBMKH: false);
		}
	}

	protected void DLJAGKBLJNC()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 759f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("ID_WARSHOP_MEMBERSHIP", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1499f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("为下载关键的游戏数据，《战争之友》需要您的媒体存储信息的访问权限。请在随后出现的权限对话框中选择接受，我们绝不会将此权限用于任何其他目的。", NABOFKMBMKH: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void HHKFLIABFCA()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 943f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("ID_SILVERARENACROWN", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
	}

	protected void CFLALBENGJN()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1564f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("battlesLostInRow", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void GCOJHEDPIKL()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 735f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.EMOGLBGNDBD("Client", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void DGCEELPOEHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1326f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("Custom int = ", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void ACIOLBGILBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1806f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("#Google play# gpgs logout during tutorial - ignore", NABOFKMBMKH: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void CPALNIACCKB()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 377f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("()Landroid/os/Looper;", NABOFKMBMKH: true);
		}
	}

	public virtual void EKBAEHKJCHL()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1596f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("Connection_Fail", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	public virtual void JCHICJBOCFA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 1494f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("ID_CONFIRM_ERROR", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void ADLJAKCCELG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1075f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("]=", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void IJANEJIFIHG()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 524f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("ID_WARNING_DUPLICATEDVIDEOFEED", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	public virtual void AGMKIMGHPAL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 1684f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("reloadTime", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void AOKEHEDCPFB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1426f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.EMOGLBGNDBD("PlayerVisuals", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void BBCOBMGHMGE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1447f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.KPCGICBFFCO("ID_OFFERACTIVE", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void IKKEFBECFOD()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 1; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1674f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.Show("Gold", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
	}

	public virtual void JONIGCEPKLO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1307f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("menu-everyplay-ico", NABOFKMBMKH: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void HKPIHGBKAHO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 384f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.CMFDIDFKHPF("ADD special offer to show {0} {1} {2}", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void LOPOCGLOHLH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 770f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("ID_NOW", NABOFKMBMKH: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JBNMBMOJPAK()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 728f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("BotArmyPower", NABOFKMBMKH: false);
		}
	}

	protected void GEICOLPLFDL()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 876f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.CMGKLHJOLDD("squad", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void DFBPBGDJKOG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1057f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.KPCGICBFFCO("CardManagerData", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-criticalinsurance", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void CMELHMEBEFI()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1815f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.OODPJFJIMPI("ID_SLOTUPGRADE_DAMAGE", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void FLDCHPBPKND()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1217f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.EMOGLBGNDBD("Shots_Fired", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void JCCIPOFJBLE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1389f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.OODPJFJIMPI("add", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void FFONCENFPMH()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 989f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("MyArmyPower", NABOFKMBMKH: false);
		}
	}

	public virtual void EBOJNIKJKPG()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1859f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("C0", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
	}

	public virtual void PDBKDBLENIG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 929f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("SIM", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LEJJDMBMPKO()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1126f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("ID_CONFIRM_NOSQUADACTIONS_TITLE", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	public virtual void FHCCGCDJALN()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 1; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 500f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("{0} {1}", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	protected void CJBJGDCNLOG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1070f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.ONONEOAEOHL("ID_CONFIRM_ERROR", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void JGNCOJLCGFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 3f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("withAttribute4", NABOFKMBMKH: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void POLFFIJKMNA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 684f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("GLM: RegisterOrLogin -  2", NABOFKMBMKH: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void BAHDLPDOCDO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 50f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.CMFDIDFKHPF("ID_GC_LOGOUT_TEXT", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void FPBHDCLGABD()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 1; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 960f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("ID_ARENARULES_SLOWERRELOADING", NABOFKMBMKH: true);
		}
	}

	public virtual void JCIPDJMFFDB()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1492f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("SquadWarsId", NABOFKMBMKH: true);
		}
	}

	public virtual void HKFPNJECIJN()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 1; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 583f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.Show("ID_TUTORIAL_GRENADE_DOWN", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 1205f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("fire", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void NBFMDCFFBIJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1930f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.BBCGKKJPIIN("ID_YES", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void LMNEMMGCEFP()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 861f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.EMOGLBGNDBD("IosTransactionId", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void MHKIELKLIHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 730f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("ID_GUI_EQUIP", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void NFEDNDPFHFI()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 900f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("S", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void CDJBEAIDHKH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1620f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("{0} {1}/[-] {2}", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void LGGHLEDKKAC()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 1; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 1878f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = ", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
	}

	protected void EKPBOMOMMFB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 628f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.ONONEOAEOHL("'elitepack'0", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 0.5f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-criticalinsurance", NABOFKMBMKH: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void IDPOHKDKDNL()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1099f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("armyPower", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void BOPGJFGMNJM()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 233f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("ID_GPGS_LOGIN_TUTORIAL_TEXT", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void FMKLDIJPHIH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 519f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.OODPJFJIMPI("country-norway", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public override void DisconnectEvents()
	{
		if (NNDMKIACBBM)
		{
			for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-criticalinsurance", NABOFKMBMKH: false);
		}
	}

	public virtual void DPELJDNCGHG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 206f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("myLobby", NABOFKMBMKH: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = 375f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.OFPAGLLFPPK("AU", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void BOEMHLPLOGA()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 877f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.LAJPOLNEDAD("https://itunes.apple.com/app/warfriends/id", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void HAMDMFGNIKD()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1873f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("audio/menu", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	public virtual void GDEHLDBGNHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = 500f;
		}
		BHABHIDDBLH = NMBINECHMGO;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("Action ", NABOFKMBMKH: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void PKPIMPKNFJJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1057f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.BBCGKKJPIIN("game-card-ico-mineyourstep-full", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}

	protected void BHIABNNGKFO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1380f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.CMGKLHJOLDD("ID_ATTACK", BHABHIDDBLH / NMBINECHMGO);
			}
			else
			{
				DisconnectEvents();
			}
		}
	}
}
