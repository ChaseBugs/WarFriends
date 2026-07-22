using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BHDAFNGBMHF
{
	public enum DIIIELOPEEO
	{
		Warbucks,
		Gold,
		Warcard,
		Cardpack,
		VIP,
		PowerBand,
		Customization,
		Unit,
		Weapon,
		Scraps,
		EliteParts,
		LoyaltyPoints,
		Tickets,
		Boosters,
		DoubleUpgrade,
		Shield
	}

	public enum EOLFJELFCJA
	{
		Warbucks,
		Gold,
		LoyaltyPoints,
		Packs
	}

	[Serializable]
	public class Content
	{
		public DIIIELOPEEO type;

		public int amount;

		public bool isFree;

		public CardManager.CardType warcardType;

		public HFOMMJIMIGN cardpackType;

		public LevelBehaviour unit;

		public WeaponLevelsSetup weapon;

		public BoosterManager.EBLCALOMCNP boosterType;

		public int boosterLevel;

		public int shieldId;

		private PlayerVisual mVisual;

		public PlayerVisual visual => null;

		public string debugString => null;

		public static Content MPEGJBFGJKE(int PLMCLHIECAJ, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content LAEHFDHPPKL(int PLMCLHIECAJ, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content NIKHAGEHAAD(int BPIBHINPLJO, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content GCCELDKOPGD(int DIADKLEHJFE, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content KEFHOEODPEN(BoosterManager.EBLCALOMCNP ALEJAIIFMJN, int DBMLGANKIOK, int CKFPFCJDBJK, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content LFBEEDNMGIN(int GNIGACIKDJD, int CKFPFCJDBJK, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content EDMBEBLLAEO(LevelBehaviour LLBKBMEEGNL, int APECCAGGEND, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content ENNJPBIGCHJ(CardManager.CardType GNNNEDJBMOH, int JPIPAIOGHFE, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content IJHGAFAHPAB(HFOMMJIMIGN FKAGEHAMODL, int JPIPAIOGHFE, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content ADDOHEGAPKA(int CGIFKNDNDOM, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content DPGMIIHMOOG(int CGIFKNDNDOM, PlayerVisual PMOEOKHDKKO, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content ABEPHBOMAMN(PlayerVisual EJJGNKNEGEE, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content LMMCLOCDCLE(LevelBehaviour LLBKBMEEGNL, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content HLBCOAFIFFB(WeaponLevelsSetup IADIKNEIGLE, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content INFFGBANJPI(int HIHMJECBMDC, bool KMEKAENPBLK)
		{
			return null;
		}

		public static Content INBANEDDDGC(int GPBNLAODMEB, bool KMEKAENPBLK)
		{
			return null;
		}
	}

	private sealed class NOJMEDLGCPO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public BHDAFNGBMHF HNNCIECPFEJ;

		public CardMenuOwerlay EHEINBGHGKO;

		private List<Card[]> LGIAOLEBGLJ;

		private int CMNODHACNOB;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public NOJMEDLGCPO(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public string FKFDONDIJLD;

	public string ECFLPOEFJCF;

	public string HLILLMPAEDB;

	public float OEMACIKGKJA;

	public Content[] JCCEMCAKOCM;

	public WeaponLevelsSetup AOCJPHPDIBP;

	public Color IMEKJBDDDLE;

	public string ONKDCBOFLEC;

	public int AAAEEBJOFDF;

	public EOLFJELFCJA FDDIAILOLHO;

	public OPGPFDFGCKE FJLIBGJJGBH;

	public float LMAIJHANECD;

	public bool ICIMNDFJMAH;

	private string LKLDFLBJHLO;

	public Tuple<float, string> PNDPMONGJPA => null;

	public string NKDGBBNNGJE => null;

	public string LEGNKFCNBGA => null;

	public string LLIJCJIBCFF => null;

	public static BHDAFNGBMHF FLJPGBBHHME(string HLILLMPAEDB, string GIFJELIGCEG, int OPKDLNFBNEO, LevelBehaviour NGEDOMFLLKI, int APECCAGGEND, int BPIBHINPLJO, int CIFLIEOJKDC)
	{
		return null;
	}

	public static BHDAFNGBMHF BJKMHENOONF(string HLILLMPAEDB)
	{
		return null;
	}

	public static BHDAFNGBMHF HHECJOLACMH(string HLILLMPAEDB, int OPKDLNFBNEO, int OEMACIKGKJA = -1)
	{
		return null;
	}

	public static BHDAFNGBMHF JDFOEKNIJBD(JToken BMIADLFBMEN, string PLCGDEHGHIO, OPGPFDFGCKE GHNHJOIBEIE, float LMAIJHANECD, float OEMACIKGKJA, int OPKDLNFBNEO)
	{
		return null;
	}

	private List<Card[]> GBFDKPMEBPL()
	{
		return null;
	}

	public IEnumerator BNNDNLJAJID(CardMenuOwerlay EHEINBGHGKO)
	{
		return null;
	}
}
