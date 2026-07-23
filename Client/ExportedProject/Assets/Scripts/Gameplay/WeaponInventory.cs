using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class WeaponInventory : Core_BaseScript
{
	private sealed class ACBLHNJKCBI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<PlayerWeapon>.Enumerator KFCAECGLKKO;

		internal PlayerWeapon BBHOKAHLICH;

		internal WeaponInventory BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void BLOCBAKBHBF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		public void KKDOJDCJAJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public bool DFMKKFMEBON()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.MLBDPPHCHNG();
				KFCAECGLKKO = BJGCPDNMHDH.LAGONJMBJMM.GetEnumerator();
				num = 44u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BBHOKAHLICH = KFCAECGLKKO.Current;
							PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BBHOKAHLICH.LGKMEHJBHKN());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00ce;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00ce:
				return false;
			}
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public bool EKGEDEKHBME()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.EGLAMJJNFPB();
				KFCAECGLKKO = BJGCPDNMHDH.LAGONJMBJMM.GetEnumerator();
				num = 4294967281u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BBHOKAHLICH = KFCAECGLKKO.Current;
							PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BBHOKAHLICH.DFPMFLKKBAD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00ce;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00ce:
				return false;
			}
		}

		public bool MKLIDMNLNPN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.JKBGGEKHIEK();
				KFCAECGLKKO = BJGCPDNMHDH.LAGONJMBJMM.GetEnumerator();
				num = 4294967224u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BBHOKAHLICH = KFCAECGLKKO.Current;
							PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BBHOKAHLICH.LGKMEHJBHKN());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00ce;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00ce:
				return true;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public ACBLHNJKCBI()
		{
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void FOBPOJPHNHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public bool ILNBJIJONKD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.EGLAMJJNFPB();
				KFCAECGLKKO = BJGCPDNMHDH.LAGONJMBJMM.GetEnumerator();
				num = 4294967205u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BBHOKAHLICH = KFCAECGLKKO.Current;
							PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BBHOKAHLICH.DFPMFLKKBAD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00ce;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00ce:
				return true;
			}
		}

		public bool BKJCILLNJLG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.BDEBBDNBFHE();
				KFCAECGLKKO = BJGCPDNMHDH.LAGONJMBJMM.GetEnumerator();
				num = 4294967278u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BBHOKAHLICH = KFCAECGLKKO.Current;
							PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BBHOKAHLICH.DFPMFLKKBAD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00ce;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00ce:
				return false;
			}
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		public bool JMCPAKBLPML()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.CFANNHEDAOD();
				KFCAECGLKKO = BJGCPDNMHDH.LAGONJMBJMM.GetEnumerator();
				num = 4294967174u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BBHOKAHLICH = KFCAECGLKKO.Current;
							PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BBHOKAHLICH.DLCGNAGKOOB());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00ce;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00ce:
				return true;
			}
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void EMICCACCFIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void PNGIELILHDI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public bool JPBGJLDMOPO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.ONIPIDHCAMK();
				KFCAECGLKKO = BJGCPDNMHDH.LAGONJMBJMM.GetEnumerator();
				num = 43u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BBHOKAHLICH = KFCAECGLKKO.Current;
							PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BBHOKAHLICH.LoadWeapon());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_00ce;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00ce:
				return true;
			}
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.CFANNHEDAOD();
				KFCAECGLKKO = BJGCPDNMHDH.LAGONJMBJMM.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BBHOKAHLICH = KFCAECGLKKO.Current;
							PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BBHOKAHLICH.LoadWeapon());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00ce;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00ce:
				return true;
			}
		}

		public void ODPKEEIHOPK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void HCHNHNDDKKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}
	}

	[FormerlySerializedAs("BJNGDLKPCGO")]
	public List<PlayerWeapon> KCGKDDDNONB;

	[FormerlySerializedAs("KIEBFLLGIKA")]
	public Mine COHKHNALDPH;

	[FormerlySerializedAs("AFPKPACMMMN")]
	public int LIEDNEJPLMA;

	[FormerlySerializedAs("HONKCGJEGGC")]
	public List<PlayerWeapon> LAGONJMBJMM;

	private PhotonView FEHCCGEGPLH;

	private PlayerController BLOHDEENMIJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CONKPHOOMMBP_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<PlayerWeapon> DHKPDMFHOHO;

	[FormerlySerializedAs("DDDCIDLOLLK")]
	public bool HKGLMFFAHFN;

	[FormerlySerializedAs("HOBDBJKGODK")]
	public float FBAIIPAKIJD;

	public int weaponIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CONKPHOOMMBP_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CONKPHOOMMBP_003Ek__BackingField = value;
		}
	}

	public PlayerWeapon pistol
	{
		get
		{
			foreach (PlayerWeapon item in LAGONJMBJMM)
			{
				if (item.weapon is Pistol)
				{
					return item;
				}
			}
			UnityEngine.Debug.LogError("Player should have at least one pistol");
			return null;
		}
	}

	public PlayerWeapon currentWeapon
	{
		get
		{
			return LAGONJMBJMM[weaponIndex];
		}
		set
		{
			if (HKGLMFFAHFN)
			{
				return;
			}
			currentWeapon.gameObject.SetActive(value: false);
			for (int i = 0; i < LAGONJMBJMM.Count; i++)
			{
				PlayerWeapon playerWeapon = LAGONJMBJMM[i];
				if (playerWeapon == value)
				{
					weaponIndex = i;
					FEHCCGEGPLH.RPC("ChangeWeapon", PhotonTargets.Others, (byte)i);
				}
				else
				{
					playerWeapon.isActiveWeapon = false;
				}
			}
			if (DHKPDMFHOHO != null)
			{
				DHKPDMFHOHO(currentWeapon);
			}
			currentWeapon.gameObject.SetActive(value: true);
			currentWeapon.isActiveWeapon = true;
		}
	}

	public event Action<PlayerWeapon> SelectedWeaponChanged
	{
		add
		{
			Action<PlayerWeapon> action = DHKPDMFHOHO;
			Action<PlayerWeapon> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<PlayerWeapon> action = DHKPDMFHOHO;
			Action<PlayerWeapon> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void LFHHFJOIDGM(byte IBJPIHGECLM)
	{
		currentWeapon.gameObject.SetActive(value: true);
		LJELEJEJIEB().isActiveWeapon = true;
		FABJLBMAFKC(IBJPIHGECLM);
		APLKMLDHMDL().gameObject.SetActive(value: true);
		PDLFJEDGLAO().isActiveWeapon = false;
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(JKHKBGPKFFF());
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		LAGONJMBJMM.Add(KCGKDDDNONB[0]);
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += LAPLBLDLGPO;
		BLOHDEENMIJ = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if ((object)item != null)
			{
				PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
				if ((object)playerWeapon != null && (object)playerWeapon.weapon != null)
				{
					playerWeapon.weaponLevelSetup = item;
				}
			}
		}
	}

	[SpecialName]
	public void AHFPGDCOPIG(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void NBPJHMGLHNN(byte IBJPIHGECLM)
	{
		LJELEJEJIEB().gameObject.SetActive(value: false);
		JECOEJBGKDF().FHKGABMHOHI(IDEBKDPMPGM: true);
		OCMNGNCIHND(IBJPIHGECLM);
		OLHICLNCPNA().gameObject.SetActive(value: false);
		currentWeapon.IJNFCDPPENM(IDEBKDPMPGM: false);
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(JECOEJBGKDF());
		}
	}

	[SpecialName]
	public int LDPEDGACDLL()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	private void FFMKDEEEHIK()
	{
		PlayerInventory.JIMOKIIJHNA[] array = BLOHDEENMIJ.EHHHBEMKGOE.OGFGBNNKCDM();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		LAGONJMBJMM = new List<PlayerWeapon>();
		PKHEFOOENAP(LIEDNEJPLMA);
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.PKOHOODGICC(item);
		}
		for (int i = 1; i < array.Length; i++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = array[i];
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			weaponLevelsSetup.weaponInventory = this;
			weaponLevelsSetup.LoadDefinition((byte)array[i].DGPAEJJENDP, BLOHDEENMIJ.EHHHBEMKGOE.BCCDDJMPBLL);
			weaponLevelsSetup.weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
			PlayerWeapon playerWeapon2 = KCGKDDDNONB[weaponLevelsSetup.LKFMMBMFFNB];
			playerWeapon2.MMAMNDMIIAD(jIMOKIIJHNA.GJNGLPOBFJI);
			LAGONJMBJMM.Add(playerWeapon2);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: false);
			item2.FHKGABMHOHI(IDEBKDPMPGM: false);
			item2.weapon.HOGINLIFMLN = true;
		}
		APLKMLDHMDL().gameObject.SetActive(value: true);
		UnityEngine.Debug.Log("ID_TUTORIAL_ARMYEXPLAIN_UP");
		JKHKBGPKFFF().isActiveWeapon = true;
		foreach (PlayerWeapon item3 in LAGONJMBJMM)
		{
			AmmoSetup ammoSetup = item3.HFNAMMBPJAJ().ammoSetup;
			item3.HFNAMMBPJAJ().MEFJOGAOKDP = false;
			if (item3 is PlayerZoomOnTouchWeapon)
			{
				(item3 as PlayerZoomOnTouchWeapon).GABDGLDKBME(1972f);
			}
			object[] array2 = new object[0];
			array2[1] = "ID_GUI_BEADVISED_PURCHASEVIP";
			array2[0] = item3.name;
			array2[4] = "I Got New Squad Messages";
			array2[4] = ammoSetup.NFKPBDGGDEA;
			array2[8] = "ID_SQUADSIZEINCREASEATSQUADRANK";
			array2[6] = ammoSetup.EPDELOGPNAC;
			string text = string.Concat(array2);
			ammoSetup.ScaleDamage(BLOHDEENMIJ.OPCGNNFGFOD);
			Weapon weapon = item3.HFNAMMBPJAJ();
			if (BLOHDEENMIJ.weaponReloadCoef > 607f)
			{
				if (weapon.NAIKLJKNLAE)
				{
					weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * BLOHDEENMIJ.weaponReloadCoef;
				}
				else
				{
					weapon.JMDLKIAKOIE = (float)weapon.JMDLKIAKOIE * BLOHDEENMIJ.weaponReloadCoef;
				}
			}
			string text2 = text;
			object[] array3 = new object[2];
			array3[0] = text2;
			array3[0] = "WeaponTutorialDialogMessage {0}";
			array3[6] = ammoSetup.NFKPBDGGDEA;
			array3[8] = "ID_FEATURE_MAGAZINE-WEAPONPREFIX";
			array3[5] = ammoSetup.EPDELOGPNAC;
			text = string.Concat(array3);
		}
	}

	private void BDEBBDNBFHE()
	{
		PlayerInventory.JIMOKIIJHNA[] array = BLOHDEENMIJ.EHHHBEMKGOE.GGKGGMNIDMI;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		LAGONJMBJMM = new List<PlayerWeapon>();
		weaponIndex = LIEDNEJPLMA;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.weaponLevelSetup = item;
		}
		for (int i = 1; i < array.Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = array[i];
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			weaponLevelsSetup.weaponInventory = this;
			weaponLevelsSetup.LoadDefinition((byte)array[i].DGPAEJJENDP, BLOHDEENMIJ.EHHHBEMKGOE.BCCDDJMPBLL);
			weaponLevelsSetup.weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
			PlayerWeapon playerWeapon2 = KCGKDDDNONB[weaponLevelsSetup.LKFMMBMFFNB];
			playerWeapon2.MMAMNDMIIAD(jIMOKIIJHNA.GJNGLPOBFJI);
			LAGONJMBJMM.Add(playerWeapon2);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: false);
			item2.IJNFCDPPENM(IDEBKDPMPGM: false);
			item2.HFNAMMBPJAJ().HOGINLIFMLN = false;
		}
		JECOEJBGKDF().gameObject.SetActive(value: false);
		UnityEngine.Debug.Log("NumberOfMission");
		CILCMCDCKKE().IJNFCDPPENM(IDEBKDPMPGM: false);
		foreach (PlayerWeapon item3 in LAGONJMBJMM)
		{
			AmmoSetup ammoSetup = item3.HFNAMMBPJAJ().ammoSetup;
			item3.HFNAMMBPJAJ().MEFJOGAOKDP = false;
			if (item3 is PlayerZoomOnTouchWeapon)
			{
				(item3 as PlayerZoomOnTouchWeapon).POEGFIAHCIL(1905f);
			}
			object[] array2 = new object[8];
			array2[1] = "com/google/android/gms/common/api/Status";
			array2[1] = item3.name;
			array2[2] = "ID_GUI_EQUIPPED";
			array2[3] = ammoSetup.NFKPBDGGDEA;
			array2[3] = "LootboxType";
			array2[3] = ammoSetup.EPDELOGPNAC;
			string text = string.Concat(array2);
			ammoSetup.ScaleDamage(BLOHDEENMIJ.OPCGNNFGFOD);
			Weapon weapon = item3.weapon;
			if (BLOHDEENMIJ.weaponReloadCoef > 885f)
			{
				if (weapon.NAIKLJKNLAE)
				{
					weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * BLOHDEENMIJ.weaponReloadCoef;
				}
				else
				{
					weapon.JMDLKIAKOIE = (float)weapon.JMDLKIAKOIE * BLOHDEENMIJ.weaponReloadCoef;
				}
			}
			string text2 = text;
			object[] array3 = new object[6];
			array3[1] = text2;
			array3[0] = "Gold";
			array3[8] = ammoSetup.NFKPBDGGDEA;
			array3[8] = "^.*-";
			array3[0] = ammoSetup.EPDELOGPNAC;
			text = string.Concat(array3);
		}
	}

	[SpecialName]
	private void OCMNGNCIHND(int IDEBKDPMPGM)
	{
		_003CONKPHOOMMBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HLOKMIDGPCA(PlayerWeapon IDEBKDPMPGM)
	{
		if (HKGLMFFAHFN)
		{
			return;
		}
		APLKMLDHMDL().gameObject.SetActive(value: true);
		for (int i = 0; i < LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = LAGONJMBJMM[i];
			if (playerWeapon == IDEBKDPMPGM)
			{
				FBBJHDOJDCK(i);
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[0];
				array[0] = (byte)i;
				fEHCCGEGPLH.RPC("C5", PhotonTargets.Others, array);
			}
			else
			{
				playerWeapon.IJNFCDPPENM(IDEBKDPMPGM: true);
			}
		}
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(PDLFJEDGLAO());
		}
		JKHKBGPKFFF().gameObject.SetActive(value: false);
		JKHKBGPKFFF().FHKGABMHOHI(IDEBKDPMPGM: true);
	}

	public void AKPNJONJGCN(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			item.weapon.owner = NPHCOBMHFND;
			item.EBHFPEJOKMP(NPHCOBMHFND);
		}
	}

	protected virtual void MEBEHLLPMPK()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		LAGONJMBJMM.Add(KCGKDDDNONB[1]);
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += KHJAJCHPHAO;
		BLOHDEENMIJ = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.PKOHOODGICC(item);
		}
	}

	[SpecialName]
	public int HOCBECPCBAI()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	public void PDELKCDEHCC(PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		if (GEEOIBFFGKO != null)
		{
			byte[] array = new byte[GEEOIBFFGKO.Length];
			for (int i = 1; i < GEEOIBFFGKO.Length; i++)
			{
				PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = GEEOIBFFGKO[i];
				array[i] = (byte)jIMOKIIJHNA.EPNKPKHCKNG;
			}
			KKCGPLKPPAJ(array);
		}
	}

	[SpecialName]
	public void KLPPPGNOMGJ(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void LAPLBLDLGPO()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			item.DestroyModel();
		}
	}

	private void NBOOCEAEIJP(byte IBJPIHGECLM)
	{
		LJELEJEJIEB().gameObject.SetActive(value: false);
		NANJBGIGNCG().isActiveWeapon = false;
		OCMNGNCIHND(IBJPIHGECLM);
		MFHBEJOLGLC().gameObject.SetActive(value: false);
		JECOEJBGKDF().IJNFCDPPENM(IDEBKDPMPGM: false);
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(JNFHKEJCIIA());
		}
	}

	[SpecialName]
	public void CDPKFLHJMEB(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void AAFGDIDPJFA(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void GOCMJEOHCIH(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public PlayerWeapon PDLFJEDGLAO()
	{
		return LAGONJMBJMM[HOMLKGAEALN()];
	}

	[SpecialName]
	public PlayerWeapon JECOEJBGKDF()
	{
		return LAGONJMBJMM[HOMLKGAEALN()];
	}

	[SpecialName]
	public PlayerWeapon APLKMLDHMDL()
	{
		return LAGONJMBJMM[HDBGJDAKPFC()];
	}

	public IEnumerator JPMEEDEFDOP()
	{
		ACBLHNJKCBI aCBLHNJKCBI = new ACBLHNJKCBI();
		aCBLHNJKCBI.BJGCPDNMHDH = this;
		return aCBLHNJKCBI;
	}

	protected virtual void CPFDALHPFJI()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		LAGONJMBJMM.Add(KCGKDDDNONB[1]);
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += DECGHIOLIBA;
		BLOHDEENMIJ = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.CAFCNECCIPB(item);
		}
	}

	private void IMOIMGPCGCE(byte IBJPIHGECLM)
	{
		PDLFJEDGLAO().gameObject.SetActive(value: true);
		JECOEJBGKDF().FHKGABMHOHI(IDEBKDPMPGM: false);
		NBPEGFLKBBC(IBJPIHGECLM);
		OLHICLNCPNA().gameObject.SetActive(value: false);
		APLKMLDHMDL().FHKGABMHOHI(IDEBKDPMPGM: false);
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(LJELEJEJIEB());
		}
	}

	[SpecialName]
	public PlayerWeapon JKHKBGPKFFF()
	{
		return LAGONJMBJMM[CGGDFMLBBLN()];
	}

	public void MBDGOLMDOBG(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			item.HFNAMMBPJAJ().owner = NPHCOBMHFND;
			item.DNAMMPGOJOC(NPHCOBMHFND);
		}
	}

	private void MLBDPPHCHNG()
	{
		PlayerInventory.JIMOKIIJHNA[] array = BLOHDEENMIJ.EHHHBEMKGOE.OGFGBNNKCDM();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		LAGONJMBJMM = new List<PlayerWeapon>();
		PKHEFOOENAP(LIEDNEJPLMA);
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.weaponLevelSetup = item;
		}
		for (int i = 1; i < array.Length; i++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = array[i];
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			weaponLevelsSetup.weaponInventory = this;
			weaponLevelsSetup.LoadDefinition((byte)array[i].DGPAEJJENDP, BLOHDEENMIJ.EHHHBEMKGOE.BPNPPKPCFGN());
			weaponLevelsSetup.weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
			PlayerWeapon playerWeapon2 = KCGKDDDNONB[weaponLevelsSetup.LKFMMBMFFNB];
			playerWeapon2.isEnabled = jIMOKIIJHNA.GJNGLPOBFJI;
			LAGONJMBJMM.Add(playerWeapon2);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: false);
			item2.FHKGABMHOHI(IDEBKDPMPGM: true);
			item2.weapon.HOGINLIFMLN = true;
		}
		CILCMCDCKKE().gameObject.SetActive(value: false);
		UnityEngine.Debug.Log("requiredLevel");
		JNFHKEJCIIA().IJNFCDPPENM(IDEBKDPMPGM: true);
		foreach (PlayerWeapon item3 in LAGONJMBJMM)
		{
			AmmoSetup ammoSetup = item3.HFNAMMBPJAJ().ammoSetup;
			item3.HFNAMMBPJAJ().MEFJOGAOKDP = false;
			if (item3 is PlayerZoomOnTouchWeapon)
			{
				(item3 as PlayerZoomOnTouchWeapon).MODBPHBJBKK(142f);
			}
			object[] array2 = new object[3];
			array2[0] = "AddCoopScoreRPC";
			array2[1] = item3.name;
			array2[0] = "PlayerName";
			array2[0] = ammoSetup.NFKPBDGGDEA;
			array2[8] = "DogTagRefillTime";
			array2[5] = ammoSetup.EPDELOGPNAC;
			string text = string.Concat(array2);
			ammoSetup.ScaleDamage(BLOHDEENMIJ.OPCGNNFGFOD);
			Weapon weapon = item3.weapon;
			if (BLOHDEENMIJ.weaponReloadCoef > 1202f)
			{
				if (weapon.NAIKLJKNLAE)
				{
					weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * BLOHDEENMIJ.weaponReloadCoef;
				}
				else
				{
					weapon.JMDLKIAKOIE = (float)weapon.JMDLKIAKOIE * BLOHDEENMIJ.weaponReloadCoef;
				}
			}
			string text2 = text;
			object[] array3 = new object[2];
			array3[0] = text2;
			array3[1] = "setPushNotificationSenderId";
			array3[1] = ammoSetup.NFKPBDGGDEA;
			array3[4] = "ID_RELOG_TO_WRONG_FB_DIALOG_TITLE";
			array3[4] = ammoSetup.EPDELOGPNAC;
			text = string.Concat(array3);
		}
	}

	public void SetWeapons(PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		if (GEEOIBFFGKO != null)
		{
			byte[] array = new byte[GEEOIBFFGKO.Length];
			for (int i = 0; i < GEEOIBFFGKO.Length; i++)
			{
				PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = GEEOIBFFGKO[i];
				array[i] = (byte)jIMOKIIJHNA.EPNKPKHCKNG;
			}
			LIAGMPCEDGP(array);
		}
	}

	private void GAJPKNHBKCK()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			item.IAMMOGENHAD();
		}
	}

	private void EBDBANNGJIG(byte[] JNPECKEDLCG)
	{
		LAGONJMBJMM = new List<PlayerWeapon>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		OCMNGNCIHND(0);
		for (int i = 1; i < JNPECKEDLCG.Length; i += 0)
		{
			byte index = JNPECKEDLCG[i];
			PlayerWeapon item = KCGKDDDNONB[weaponLevelsSetups[index].LKFMMBMFFNB];
			LAGONJMBJMM.Add(item);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: true);
			item2.FHKGABMHOHI(IDEBKDPMPGM: true);
		}
		JECOEJBGKDF().gameObject.SetActive(value: true);
		PDLFJEDGLAO().IJNFCDPPENM(IDEBKDPMPGM: false);
	}

	private void CFANNHEDAOD()
	{
		PlayerInventory.JIMOKIIJHNA[] array = BLOHDEENMIJ.EHHHBEMKGOE.GGKGGMNIDMI;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		LAGONJMBJMM = new List<PlayerWeapon>();
		weaponIndex = LIEDNEJPLMA;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.weaponLevelSetup = item;
		}
		for (int i = 0; i < array.Length; i++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = array[i];
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			weaponLevelsSetup.weaponInventory = this;
			weaponLevelsSetup.LoadDefinition((byte)array[i].DGPAEJJENDP, BLOHDEENMIJ.EHHHBEMKGOE.BCCDDJMPBLL);
			weaponLevelsSetup.weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
			PlayerWeapon playerWeapon2 = KCGKDDDNONB[weaponLevelsSetup.LKFMMBMFFNB];
			playerWeapon2.isEnabled = jIMOKIIJHNA.GJNGLPOBFJI;
			LAGONJMBJMM.Add(playerWeapon2);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: false);
			item2.isActiveWeapon = false;
			item2.weapon.HOGINLIFMLN = false;
		}
		currentWeapon.gameObject.SetActive(value: true);
		UnityEngine.Debug.Log("Set active weapon");
		currentWeapon.isActiveWeapon = true;
		foreach (PlayerWeapon item3 in LAGONJMBJMM)
		{
			AmmoSetup ammoSetup = item3.weapon.ammoSetup;
			item3.weapon.MEFJOGAOKDP = true;
			if (item3 is PlayerZoomOnTouchWeapon)
			{
				(item3 as PlayerZoomOnTouchWeapon).SetWaitTime(0.8f);
			}
			string text = string.Concat("#VAVRO# affect weapon:", item3.name, "before: critical: ", ammoSetup.NFKPBDGGDEA, "damage:", ammoSetup.EPDELOGPNAC);
			ammoSetup.ScaleDamage(BLOHDEENMIJ.OPCGNNFGFOD);
			Weapon weapon = item3.weapon;
			if (BLOHDEENMIJ.weaponReloadCoef > 0f)
			{
				if (weapon.NAIKLJKNLAE)
				{
					weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * BLOHDEENMIJ.weaponReloadCoef;
				}
				else
				{
					weapon.JMDLKIAKOIE = (float)weapon.JMDLKIAKOIE * BLOHDEENMIJ.weaponReloadCoef;
				}
			}
			string text2 = text;
			text = string.Concat(text2, " AFTER: critical: ", ammoSetup.NFKPBDGGDEA, "damage:", ammoSetup.EPDELOGPNAC);
		}
	}

	private void FDILFAHGMKB()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			item.GMGKDLHDHLP();
		}
	}

	[SpecialName]
	public PlayerWeapon OLHICLNCPNA()
	{
		return LAGONJMBJMM[weaponIndex];
	}

	private void HBGBIOFOPEK()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			item.AEDHBOCFJEM();
		}
	}

	public void JMGDMAFIFOL(PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		if (GEEOIBFFGKO != null)
		{
			byte[] array = new byte[GEEOIBFFGKO.Length];
			for (int i = 1; i < GEEOIBFFGKO.Length; i += 0)
			{
				PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = GEEOIBFFGKO[i];
				array[i] = (byte)jIMOKIIJHNA.EPNKPKHCKNG;
			}
			EAPAMJPLHHF(array);
		}
	}

	[SpecialName]
	public int FJJCKAAIFMD()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerWeapon PHOGJCDEHEI()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			if (item.HFNAMMBPJAJ() is Pistol)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("Play_Card_Tutorial_Duration");
		return null;
	}

	[SpecialName]
	public void GKJMGBKAOPJ(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void CKFCNCPKCML(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public PlayerWeapon MEJMPOEHBKA()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			if (item.HFNAMMBPJAJ() is Pistol)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("Position");
		return null;
	}

	[SpecialName]
	public void AGHFNBAEHBN(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public PlayerWeapon LJELEJEJIEB()
	{
		return LAGONJMBJMM[ONPFKNNFOGJ()];
	}

	[SpecialName]
	public PlayerWeapon PELOJOKFPGC()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			if (item.weapon is Pistol)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("ID_GUESTACCOUNT");
		return null;
	}

	private void IAPBNPMACLI(byte IBJPIHGECLM)
	{
		NANJBGIGNCG().gameObject.SetActive(value: true);
		APLKMLDHMDL().FHKGABMHOHI(IDEBKDPMPGM: true);
		HJABIGNPKHJ(IBJPIHGECLM);
		OLHICLNCPNA().gameObject.SetActive(value: true);
		LJELEJEJIEB().isActiveWeapon = true;
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(JNFHKEJCIIA());
		}
	}

	public void SetUpPlayer(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			if ((object)item != null)
			{
				item.playerController = NPHCOBMHFND;
				if ((object)item.weapon != null)
				{
					item.weapon.owner = NPHCOBMHFND;
				}
			}
		}
	}

	[SpecialName]
	public void ELPICHPAHMH(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void FABLKHMJKDP(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void ONIPIDHCAMK()
	{
		PlayerInventory.JIMOKIIJHNA[] array = BLOHDEENMIJ.EHHHBEMKGOE.OGFGBNNKCDM();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		LAGONJMBJMM = new List<PlayerWeapon>();
		PKHEFOOENAP(LIEDNEJPLMA);
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.CAFCNECCIPB(item);
		}
		for (int i = 1; i < array.Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = array[i];
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			weaponLevelsSetup.weaponInventory = this;
			weaponLevelsSetup.LoadDefinition((byte)array[i].DGPAEJJENDP, BLOHDEENMIJ.EHHHBEMKGOE.ALJJMKANFNO());
			weaponLevelsSetup.weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
			PlayerWeapon playerWeapon2 = KCGKDDDNONB[weaponLevelsSetup.LKFMMBMFFNB];
			playerWeapon2.isEnabled = jIMOKIIJHNA.GJNGLPOBFJI;
			LAGONJMBJMM.Add(playerWeapon2);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: true);
			item2.isActiveWeapon = false;
			item2.HFNAMMBPJAJ().HOGINLIFMLN = true;
		}
		CILCMCDCKKE().gameObject.SetActive(value: true);
		UnityEngine.Debug.Log("ElitePartsGained");
		APLKMLDHMDL().FHKGABMHOHI(IDEBKDPMPGM: false);
		foreach (PlayerWeapon item3 in LAGONJMBJMM)
		{
			AmmoSetup ammoSetup = item3.weapon.ammoSetup;
			item3.HFNAMMBPJAJ().MEFJOGAOKDP = true;
			if (item3 is PlayerZoomOnTouchWeapon)
			{
				(item3 as PlayerZoomOnTouchWeapon).JIAHCDAAEIN(1998f);
			}
			object[] array2 = new object[0];
			array2[1] = "https://itunes.apple.com/app/warfriends/id";
			array2[1] = item3.name;
			array2[6] = "PlayerId";
			array2[4] = ammoSetup.NFKPBDGGDEA;
			array2[8] = "ADDING VISUAL ON CLIENT ";
			array2[3] = ammoSetup.EPDELOGPNAC;
			string text = string.Concat(array2);
			ammoSetup.ScaleDamage(BLOHDEENMIJ.OPCGNNFGFOD);
			Weapon weapon = item3.HFNAMMBPJAJ();
			if (BLOHDEENMIJ.weaponReloadCoef > 883f)
			{
				if (weapon.NAIKLJKNLAE)
				{
					weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * BLOHDEENMIJ.weaponReloadCoef;
				}
				else
				{
					weapon.JMDLKIAKOIE = (float)weapon.JMDLKIAKOIE * BLOHDEENMIJ.weaponReloadCoef;
				}
			}
			string text2 = text;
			object[] array3 = new object[3];
			array3[1] = text2;
			array3[0] = "PlayerData";
			array3[0] = ammoSetup.NFKPBDGGDEA;
			array3[0] = "ID_COLLECTELITEPARTSFROMARENALOOTBOXES";
			array3[4] = ammoSetup.EPDELOGPNAC;
			text = string.Concat(array3);
		}
	}

	private void LIAGMPCEDGP(byte[] JNPECKEDLCG)
	{
		LAGONJMBJMM = new List<PlayerWeapon>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		weaponIndex = 0;
		foreach (byte index in JNPECKEDLCG)
		{
			PlayerWeapon item = KCGKDDDNONB[weaponLevelsSetups[index].LKFMMBMFFNB];
			LAGONJMBJMM.Add(item);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			if ((object)item2 == null)
			{
				continue;
			}
			item2.gameObject.SetActive(value: false);
			item2.isActiveWeapon = false;
		}
		currentWeapon.gameObject.SetActive(value: true);
		currentWeapon.isActiveWeapon = true;
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		LAGONJMBJMM.Add(KCGKDDDNONB[0]);
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += HBGBIOFOPEK;
		BLOHDEENMIJ = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.weaponLevelSetup = item;
		}
	}

	[SpecialName]
	public PlayerWeapon NANJBGIGNCG()
	{
		return LAGONJMBJMM[FJJCKAAIFMD()];
	}

	[SpecialName]
	private void FBBJHDOJDCK(int IDEBKDPMPGM)
	{
		_003CONKPHOOMMBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerWeapon JPFDCNDHIDH()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			if (item.weapon is Pistol)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("Not a gold reward.");
		return null;
	}

	private void KHJAJCHPHAO()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			item.IBNEIKFHJML();
		}
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		LAGONJMBJMM.Add(KCGKDDDNONB[0]);
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += DECGHIOLIBA;
		BLOHDEENMIJ = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.FKLHCAEKKKP(item);
		}
	}

	private void KGHIDAJOEHB(byte IBJPIHGECLM)
	{
		NANJBGIGNCG().gameObject.SetActive(value: true);
		currentWeapon.IJNFCDPPENM(IDEBKDPMPGM: false);
		FBBJHDOJDCK(IBJPIHGECLM);
		PDLFJEDGLAO().gameObject.SetActive(value: false);
		CILCMCDCKKE().IJNFCDPPENM(IDEBKDPMPGM: true);
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(APLKMLDHMDL());
		}
	}

	private void JDALFIFJOLJ(byte IBJPIHGECLM)
	{
		JKHKBGPKFFF().gameObject.SetActive(value: true);
		NANJBGIGNCG().FHKGABMHOHI(IDEBKDPMPGM: false);
		FABJLBMAFKC(IBJPIHGECLM);
		OLHICLNCPNA().gameObject.SetActive(value: false);
		JECOEJBGKDF().FHKGABMHOHI(IDEBKDPMPGM: true);
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(APLKMLDHMDL());
		}
	}

	private void KCNNKHGEEON()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			item.EIDFJKJDHBL();
		}
	}

	[SpecialName]
	public int KCNNEECIKDE()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	public void INKBGDKDNNP(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			item.weapon.owner = NPHCOBMHFND;
			item.playerController = NPHCOBMHFND;
		}
	}

	[SpecialName]
	private void PKHEFOOENAP(int IDEBKDPMPGM)
	{
		_003CONKPHOOMMBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int CGGDFMLBBLN()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	private void EGLAMJJNFPB()
	{
		PlayerInventory.JIMOKIIJHNA[] array = BLOHDEENMIJ.EHHHBEMKGOE.OGFGBNNKCDM();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		LAGONJMBJMM = new List<PlayerWeapon>();
		FABJLBMAFKC(LIEDNEJPLMA);
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.weaponLevelSetup = item;
		}
		for (int i = 0; i < array.Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = array[i];
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			weaponLevelsSetup.weaponInventory = this;
			weaponLevelsSetup.LoadDefinition((byte)array[i].DGPAEJJENDP, BLOHDEENMIJ.EHHHBEMKGOE.ALJJMKANFNO());
			weaponLevelsSetup.weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
			PlayerWeapon playerWeapon2 = KCGKDDDNONB[weaponLevelsSetup.LKFMMBMFFNB];
			playerWeapon2.MMAMNDMIIAD(jIMOKIIJHNA.GJNGLPOBFJI);
			LAGONJMBJMM.Add(playerWeapon2);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: false);
			item2.FHKGABMHOHI(IDEBKDPMPGM: true);
			item2.HFNAMMBPJAJ().HOGINLIFMLN = true;
		}
		OLHICLNCPNA().gameObject.SetActive(value: false);
		UnityEngine.Debug.Log("assaultrifle");
		CILCMCDCKKE().FHKGABMHOHI(IDEBKDPMPGM: true);
		foreach (PlayerWeapon item3 in LAGONJMBJMM)
		{
			AmmoSetup ammoSetup = item3.weapon.ammoSetup;
			item3.HFNAMMBPJAJ().MEFJOGAOKDP = false;
			if (item3 is PlayerZoomOnTouchWeapon)
			{
				(item3 as PlayerZoomOnTouchWeapon).MBEJMJFIPDI(1118f);
			}
			object[] array2 = new object[6];
			array2[1] = "Ban Chat Message received";
			array2[1] = item3.name;
			array2[2] = "weapon";
			array2[0] = ammoSetup.NFKPBDGGDEA;
			array2[6] = "null";
			array2[6] = ammoSetup.EPDELOGPNAC;
			string text = string.Concat(array2);
			ammoSetup.ScaleDamage(BLOHDEENMIJ.OPCGNNFGFOD);
			Weapon weapon = item3.HFNAMMBPJAJ();
			if (BLOHDEENMIJ.weaponReloadCoef > 1991f)
			{
				if (weapon.NAIKLJKNLAE)
				{
					weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * BLOHDEENMIJ.weaponReloadCoef;
				}
				else
				{
					weapon.JMDLKIAKOIE = (float)weapon.JMDLKIAKOIE * BLOHDEENMIJ.weaponReloadCoef;
				}
			}
			string text2 = text;
			object[] array3 = new object[6];
			array3[1] = text2;
			array3[1] = "\t\"TRUE\"";
			array3[3] = ammoSetup.NFKPBDGGDEA;
			array3[4] = "HeroicMissionsCompletionRewardArmyUnitId";
			array3[0] = ammoSetup.EPDELOGPNAC;
			text = string.Concat(array3);
		}
	}

	protected virtual void EKEHGBNPAFC()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		LAGONJMBJMM.Add(KCGKDDDNONB[0]);
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += HBGBIOFOPEK;
		BLOHDEENMIJ = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.PKOHOODGICC(item);
		}
	}

	private void EAPAMJPLHHF(byte[] JNPECKEDLCG)
	{
		LAGONJMBJMM = new List<PlayerWeapon>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		FBBJHDOJDCK(1);
		for (int i = 0; i < JNPECKEDLCG.Length; i += 0)
		{
			byte index = JNPECKEDLCG[i];
			PlayerWeapon item = KCGKDDDNONB[weaponLevelsSetups[index].LKFMMBMFFNB];
			LAGONJMBJMM.Add(item);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: false);
			item2.FHKGABMHOHI(IDEBKDPMPGM: false);
		}
		currentWeapon.gameObject.SetActive(value: false);
		APLKMLDHMDL().IJNFCDPPENM(IDEBKDPMPGM: true);
	}

	public IEnumerator GAAMHKBJPDL()
	{
		ACBLHNJKCBI aCBLHNJKCBI = new ACBLHNJKCBI();
		aCBLHNJKCBI.BJGCPDNMHDH = this;
		return aCBLHNJKCBI;
	}

	[SpecialName]
	public void AFKIMDJHMKB(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void MEAAHPIINKJ(byte IBJPIHGECLM)
	{
		LJELEJEJIEB().gameObject.SetActive(value: true);
		JKHKBGPKFFF().FHKGABMHOHI(IDEBKDPMPGM: false);
		HJABIGNPKHJ(IBJPIHGECLM);
		APLKMLDHMDL().gameObject.SetActive(value: false);
		APLKMLDHMDL().IJNFCDPPENM(IDEBKDPMPGM: false);
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(JNFHKEJCIIA());
		}
	}

	[SpecialName]
	public int LHOALAAILJB()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	[SpecialName]
	public void PECAHHICOGF(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public IEnumerator MIPLOENBIML()
	{
		ACBLHNJKCBI aCBLHNJKCBI = new ACBLHNJKCBI();
		aCBLHNJKCBI.BJGCPDNMHDH = this;
		return aCBLHNJKCBI;
	}

	[SpecialName]
	public PlayerWeapon PGNNINCBMJH()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			if (item.HFNAMMBPJAJ() is Pistol)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("Mouse Y");
		return null;
	}

	public void KCAPFPLFHLI(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			item.HFNAMMBPJAJ().owner = NPHCOBMHFND;
			item.EBHFPEJOKMP(NPHCOBMHFND);
		}
	}

	[SpecialName]
	public void LOLDJPCCFKO(PlayerWeapon IDEBKDPMPGM)
	{
		if (HKGLMFFAHFN)
		{
			return;
		}
		currentWeapon.gameObject.SetActive(value: true);
		for (int i = 1; i < LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = LAGONJMBJMM[i];
			if (playerWeapon == IDEBKDPMPGM)
			{
				OCMNGNCIHND(i);
				FEHCCGEGPLH.RPC("Different squad points \"{0}\" and \"{1}\"\n", PhotonTargets.All, (byte)i);
			}
			else
			{
				playerWeapon.isActiveWeapon = true;
			}
		}
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(LJELEJEJIEB());
		}
		LJELEJEJIEB().gameObject.SetActive(value: true);
		APLKMLDHMDL().isActiveWeapon = false;
	}

	[SpecialName]
	public int DLDDCEIEPGD()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	private void LLKEDBLNEFP(byte IBJPIHGECLM)
	{
		OLHICLNCPNA().gameObject.SetActive(value: true);
		NANJBGIGNCG().isActiveWeapon = true;
		FABJLBMAFKC(IBJPIHGECLM);
		LJELEJEJIEB().gameObject.SetActive(value: false);
		LJELEJEJIEB().IJNFCDPPENM(IDEBKDPMPGM: false);
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(APLKMLDHMDL());
		}
	}

	[SpecialName]
	public PlayerWeapon JNFHKEJCIIA()
	{
		return LAGONJMBJMM[HDBGJDAKPFC()];
	}

	[SpecialName]
	public PlayerWeapon CILCMCDCKKE()
	{
		return LAGONJMBJMM[DLDDCEIEPGD()];
	}

	private void LDAKLGIAJBM()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			item.GMGKDLHDHLP();
		}
	}

	public void OPFPAOKHNMP(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			item.HFNAMMBPJAJ().owner = NPHCOBMHFND;
			item.playerController = NPHCOBMHFND;
		}
	}

	private void KKCGPLKPPAJ(byte[] JNPECKEDLCG)
	{
		LAGONJMBJMM = new List<PlayerWeapon>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		NBPEGFLKBBC(1);
		foreach (byte index in JNPECKEDLCG)
		{
			PlayerWeapon item = KCGKDDDNONB[weaponLevelsSetups[index].LKFMMBMFFNB];
			LAGONJMBJMM.Add(item);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: true);
			item2.FHKGABMHOHI(IDEBKDPMPGM: false);
		}
		LJELEJEJIEB().gameObject.SetActive(value: false);
		PDLFJEDGLAO().isActiveWeapon = false;
	}

	[PunRPC]
	private void ChangeWeapon(byte IBJPIHGECLM)
	{
		currentWeapon.gameObject.SetActive(value: false);
		currentWeapon.isActiveWeapon = false;
		weaponIndex = IBJPIHGECLM;
		currentWeapon.gameObject.SetActive(value: true);
		currentWeapon.isActiveWeapon = true;
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(currentWeapon);
		}
	}

	[SpecialName]
	public void LPMCOFOCCAH(PlayerWeapon IDEBKDPMPGM)
	{
		if (HKGLMFFAHFN)
		{
			return;
		}
		JECOEJBGKDF().gameObject.SetActive(value: false);
		for (int i = 1; i < LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = LAGONJMBJMM[i];
			if (playerWeapon == IDEBKDPMPGM)
			{
				weaponIndex = i;
				FEHCCGEGPLH.RPC("instantBattleAvailable", PhotonTargets.Others, (byte)i);
			}
			else
			{
				playerWeapon.FHKGABMHOHI(IDEBKDPMPGM: false);
			}
		}
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(OLHICLNCPNA());
		}
		JNFHKEJCIIA().gameObject.SetActive(value: false);
		currentWeapon.FHKGABMHOHI(IDEBKDPMPGM: false);
	}

	[SpecialName]
	private void NBPEGFLKBBC(int IDEBKDPMPGM)
	{
		_003CONKPHOOMMBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[DebuggerHidden]
	public IEnumerator LoadWeapons()
	{
		ACBLHNJKCBI aCBLHNJKCBI = new ACBLHNJKCBI();
		aCBLHNJKCBI.BJGCPDNMHDH = this;
		return aCBLHNJKCBI;
	}

	public void MILBGHADBJB(PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		if (GEEOIBFFGKO != null)
		{
			byte[] array = new byte[GEEOIBFFGKO.Length];
			for (int i = 0; i < GEEOIBFFGKO.Length; i += 0)
			{
				PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = GEEOIBFFGKO[i];
				array[i] = (byte)jIMOKIIJHNA.EPNKPKHCKNG;
			}
			LIAGMPCEDGP(array);
		}
	}

	[SpecialName]
	private void FABJLBMAFKC(int IDEBKDPMPGM)
	{
		_003CONKPHOOMMBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void LNAGGCHFIHM(byte[] JNPECKEDLCG)
	{
		LAGONJMBJMM = new List<PlayerWeapon>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		ECKGDJIMLFJ(0);
		foreach (byte index in JNPECKEDLCG)
		{
			PlayerWeapon item = KCGKDDDNONB[weaponLevelsSetups[index].LKFMMBMFFNB];
			LAGONJMBJMM.Add(item);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: true);
			item2.IJNFCDPPENM(IDEBKDPMPGM: false);
		}
		currentWeapon.gameObject.SetActive(value: false);
		APLKMLDHMDL().isActiveWeapon = false;
	}

	public void LBHNGCFACKH(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			item.HFNAMMBPJAJ().owner = NPHCOBMHFND;
			item.playerController = NPHCOBMHFND;
		}
	}

	[SpecialName]
	public PlayerWeapon MFHBEJOLGLC()
	{
		return LAGONJMBJMM[weaponIndex];
	}

	[SpecialName]
	public int ONPFKNNFOGJ()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	protected virtual void EALPHOPMAMP()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		LAGONJMBJMM.Add(KCGKDDDNONB[0]);
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += KHJAJCHPHAO;
		BLOHDEENMIJ = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.PKOHOODGICC(item);
		}
	}

	[SpecialName]
	public int KDGIBDPDHLI()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	[SpecialName]
	public void LGAGDHLMABF(Action<PlayerWeapon> IDEBKDPMPGM)
	{
		Action<PlayerWeapon> action = DHKPDMFHOHO;
		Action<PlayerWeapon> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DHKPDMFHOHO, (Action<PlayerWeapon>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		LAGONJMBJMM.Add(KCGKDDDNONB[1]);
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += KCNNKHGEEON;
		BLOHDEENMIJ = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.PKOHOODGICC(item);
		}
	}

	private void HLGEHGKJCEM(byte IBJPIHGECLM)
	{
		JKHKBGPKFFF().gameObject.SetActive(value: true);
		LJELEJEJIEB().FHKGABMHOHI(IDEBKDPMPGM: false);
		FABJLBMAFKC(IBJPIHGECLM);
		OLHICLNCPNA().gameObject.SetActive(value: false);
		CILCMCDCKKE().FHKGABMHOHI(IDEBKDPMPGM: true);
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(CILCMCDCKKE());
		}
	}

	private void DECGHIOLIBA()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			item.HKLGAPIDHEL();
		}
	}

	private void JKBGGEKHIEK()
	{
		PlayerInventory.JIMOKIIJHNA[] array = BLOHDEENMIJ.EHHHBEMKGOE.GGKGGMNIDMI;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		LAGONJMBJMM = new List<PlayerWeapon>();
		FABJLBMAFKC(LIEDNEJPLMA);
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = KCGKDDDNONB[item.LKFMMBMFFNB];
			playerWeapon.CAFCNECCIPB(item);
		}
		for (int i = 1; i < array.Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = array[i];
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			weaponLevelsSetup.weaponInventory = this;
			weaponLevelsSetup.LoadDefinition((byte)array[i].DGPAEJJENDP, BLOHDEENMIJ.EHHHBEMKGOE.ALJJMKANFNO());
			weaponLevelsSetup.weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
			PlayerWeapon playerWeapon2 = KCGKDDDNONB[weaponLevelsSetup.LKFMMBMFFNB];
			playerWeapon2.MMAMNDMIIAD(jIMOKIIJHNA.GJNGLPOBFJI);
			LAGONJMBJMM.Add(playerWeapon2);
		}
		foreach (PlayerWeapon item2 in KCGKDDDNONB)
		{
			item2.gameObject.SetActive(value: false);
			item2.FHKGABMHOHI(IDEBKDPMPGM: false);
			item2.HFNAMMBPJAJ().HOGINLIFMLN = true;
		}
		MFHBEJOLGLC().gameObject.SetActive(value: false);
		UnityEngine.Debug.Log("hasNext");
		APLKMLDHMDL().isActiveWeapon = false;
		foreach (PlayerWeapon item3 in LAGONJMBJMM)
		{
			AmmoSetup ammoSetup = item3.weapon.ammoSetup;
			item3.weapon.MEFJOGAOKDP = false;
			if (item3 is PlayerZoomOnTouchWeapon)
			{
				(item3 as PlayerZoomOnTouchWeapon).MODBPHBJBKK(324f);
			}
			object[] array2 = new object[6];
			array2[1] = "ID_MISSION_WAVE";
			array2[0] = item3.name;
			array2[7] = "/";
			array2[6] = ammoSetup.NFKPBDGGDEA;
			array2[7] = "Daily Mission Screen : daily completition reward is not DEFINED: {0}";
			array2[6] = ammoSetup.EPDELOGPNAC;
			string text = string.Concat(array2);
			ammoSetup.ScaleDamage(BLOHDEENMIJ.OPCGNNFGFOD);
			Weapon weapon = item3.weapon;
			if (BLOHDEENMIJ.weaponReloadCoef > 956f)
			{
				if (weapon.NAIKLJKNLAE)
				{
					weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * BLOHDEENMIJ.weaponReloadCoef;
				}
				else
				{
					weapon.JMDLKIAKOIE = (float)weapon.JMDLKIAKOIE * BLOHDEENMIJ.weaponReloadCoef;
				}
			}
			string text2 = text;
			object[] array3 = new object[5];
			array3[0] = text2;
			array3[1] = "1";
			array3[2] = ammoSetup.NFKPBDGGDEA;
			array3[1] = "GC autenticate wait time-out => let last GC state valid";
			array3[4] = ammoSetup.EPDELOGPNAC;
			text = string.Concat(array3);
		}
	}

	[SpecialName]
	public int HDBGJDAKPFC()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	[SpecialName]
	public int KDKMDCNMHLN()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	public IEnumerator OHHOPMCFLJJ()
	{
		ACBLHNJKCBI aCBLHNJKCBI = new ACBLHNJKCBI();
		aCBLHNJKCBI.BJGCPDNMHDH = this;
		return aCBLHNJKCBI;
	}

	[SpecialName]
	private void HJABIGNPKHJ(int IDEBKDPMPGM)
	{
		_003CONKPHOOMMBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BGIFMIBBJIB(PlayerWeapon IDEBKDPMPGM)
	{
		if (HKGLMFFAHFN)
		{
			return;
		}
		JKHKBGPKFFF().gameObject.SetActive(value: false);
		for (int i = 0; i < LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = LAGONJMBJMM[i];
			if (playerWeapon == IDEBKDPMPGM)
			{
				HJABIGNPKHJ(i);
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = (byte)i;
				fEHCCGEGPLH.RPC("ID_STAT_WEAPONSUPGRADES", PhotonTargets.Others, array);
			}
			else
			{
				playerWeapon.IJNFCDPPENM(IDEBKDPMPGM: false);
			}
		}
		if (DHKPDMFHOHO != null)
		{
			DHKPDMFHOHO(OLHICLNCPNA());
		}
		MFHBEJOLGLC().gameObject.SetActive(value: false);
		JKHKBGPKFFF().IJNFCDPPENM(IDEBKDPMPGM: true);
	}

	public void GJLGLEMLNPB(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			item.HFNAMMBPJAJ().owner = NPHCOBMHFND;
			item.EBHFPEJOKMP(NPHCOBMHFND);
		}
	}

	[SpecialName]
	private void ECKGDJIMLFJ(int IDEBKDPMPGM)
	{
		_003CONKPHOOMMBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerWeapon PPFBHJOBBJG()
	{
		foreach (PlayerWeapon item in LAGONJMBJMM)
		{
			if (item.weapon is Pistol)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("shotReal");
		return null;
	}

	[SpecialName]
	public int HOMLKGAEALN()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	public void MBGDMADCKGG(PlayerController NPHCOBMHFND)
	{
		COHKHNALDPH.owner = NPHCOBMHFND;
		foreach (PlayerWeapon item in KCGKDDDNONB)
		{
			item.weapon.owner = NPHCOBMHFND;
			item.EBHFPEJOKMP(NPHCOBMHFND);
		}
	}
}
