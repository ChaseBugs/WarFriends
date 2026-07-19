using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class BatchedWeapon : Core_BaseScript
{
	public Weapon JMMJHCOKCGG;

	public float KPHGDDGHFCH = 1f;

	private BitVector32 ECOJGJHKPNE = new BitVector32(0);

	private byte OONPHPCNBJF;

	private PhotonView FEHCCGEGPLH;

	private bool LGDLOJLDJFJ;

	private int MJNENAGPCGF;

	private Ammo.ILIOELBBLDM OKHEHHEJIOB;

	private Vector3 GIJMLIOJPLH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action NNHLHDENDPM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<Vector3> MKBNLBHEKJD;

	public bool shooting { get; private set; }

	public event Action ShootEnded
	{
		add
		{
			Action action = NNHLHDENDPM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NNHLHDENDPM, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = NNHLHDENDPM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NNHLHDENDPM, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<Vector3> Shooted
	{
		add
		{
			Action<Vector3> action = MKBNLBHEKJD;
			Action<Vector3> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MKBNLBHEKJD, (Action<Vector3>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<Vector3> action = MKBNLBHEKJD;
			Action<Vector3> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MKBNLBHEKJD, (Action<Vector3>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	[SpecialName]
	public void HGGPCNOEEIN(Action<Vector3> IDEBKDPMPGM)
	{
		Action<Vector3> action = MKBNLBHEKJD;
		Action<Vector3> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MKBNLBHEKJD, (Action<Vector3>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool DPLDOKNAMCC()
	{
		return _003CONBLHPPKGAD_003Ek__BackingField;
	}

	private void BOMKEAKNJBB(Vector3 MPHCNMDIPAI, int NGIPEIHHFPB, bool GENEICFBKNC, byte EBNMDKAEJAH, byte COAEOPHBCOE)
	{
		MJNENAGPCGF = 0;
		ECOJGJHKPNE = new BitVector32(NGIPEIHHFPB);
		OONPHPCNBJF = COAEOPHBCOE;
		shooting = true;
		GIJMLIOJPLH = MPHCNMDIPAI;
		LGDLOJLDJFJ = GENEICFBKNC;
		OKHEHHEJIOB = (Ammo.ILIOELBBLDM)EBNMDKAEJAH;
	}

	[SpecialName]
	public void KLPEEIDMPHI(Action<Vector3> IDEBKDPMPGM)
	{
		Action<Vector3> action = MKBNLBHEKJD;
		Action<Vector3> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MKBNLBHEKJD, (Action<Vector3>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void IIHPJICMGJN(Action IDEBKDPMPGM)
	{
		Action action = NNHLHDENDPM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NNHLHDENDPM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void OHKLABJGMNL(Vector3 MPHCNMDIPAI, int NGIPEIHHFPB, bool GENEICFBKNC, byte EBNMDKAEJAH, byte COAEOPHBCOE)
	{
		MJNENAGPCGF = 0;
		ECOJGJHKPNE = new BitVector32(NGIPEIHHFPB);
		OONPHPCNBJF = COAEOPHBCOE;
		shooting = false;
		GIJMLIOJPLH = MPHCNMDIPAI;
		LGDLOJLDJFJ = GENEICFBKNC;
		OKHEHHEJIOB = (Ammo.ILIOELBBLDM)EBNMDKAEJAH;
	}

	[SpecialName]
	private void CBHIPABHGHC(bool IDEBKDPMPGM)
	{
		_003CONBLHPPKGAD_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void IODGCIIDJEK()
	{
		if (!DPLDOKNAMCC() || !JMMJHCOKCGG.willShoot)
		{
			return;
		}
		if (ECOJGJHKPNE[0 << (MJNENAGPCGF & -57)])
		{
			MDKABJDCKBI(GIJMLIOJPLH, false);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - GIJMLIOJPLH, Vector3.up).normalized * UnityEngine.Random.Range(1358f, 326f) * KPHGDDGHFCH;
			if ((double)UnityEngine.Random.value < 1192.0)
			{
				vector = -vector;
			}
			MDKABJDCKBI(GIJMLIOJPLH + vector + new Vector3(401f, 639f, 1706f) * KPHGDDGHFCH, true);
		}
		MJNENAGPCGF += 0;
		if (MJNENAGPCGF >= OONPHPCNBJF)
		{
			MJNENAGPCGF = 1;
			CBHIPABHGHC(false);
			if (NNHLHDENDPM != null)
			{
				NNHLHDENDPM();
			}
		}
	}

	public void OFPCMHCEMHA(GameShootableEntity.ShotTarget MKIPAEDAADL, Vector3 MPHCNMDIPAI, int COAEOPHBCOE, float MNLDFBEMEDC, Ammo.ILIOELBBLDM EBNMDKAEJAH)
	{
		OONPHPCNBJF = (byte)COAEOPHBCOE;
		ECOJGJHKPNE = new BitVector32(1);
		for (int i = 0; i < OONPHPCNBJF; i++)
		{
			ECOJGJHKPNE[0 << (i & 0x72)] = UnityEngine.Random.value < MNLDFBEMEDC;
		}
		MJNENAGPCGF = 0;
		shooting = false;
		GIJMLIOJPLH = MPHCNMDIPAI;
		OKHEHHEJIOB = EBNMDKAEJAH;
		LGDLOJLDJFJ = false;
		PlayerController playerController = MKIPAEDAADL.MDMGOJAPBAG().GEAMOMEEFKM() as PlayerController;
		if (playerController != null && !playerController.LAADDLGBFIG.isMine)
		{
			LGDLOJLDJFJ = false;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[4];
		array[0] = GIJMLIOJPLH;
		array[1] = ECOJGJHKPNE.Data;
		array[2] = LGDLOJLDJFJ;
		array[2] = (byte)OKHEHHEJIOB;
		array[4] = OONPHPCNBJF;
		fEHCCGEGPLH.RPC("Tickets", PhotonTargets.Others, array);
	}

	protected virtual void NGGJHDCOLEC()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	protected void CKFENMDKKPE()
	{
		if (!DPLDOKNAMCC() || !JMMJHCOKCGG.willShoot)
		{
			return;
		}
		if (ECOJGJHKPNE[1 << (MJNENAGPCGF & 0x77)])
		{
			MDKABJDCKBI(GIJMLIOJPLH, false);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - GIJMLIOJPLH, Vector3.up).normalized * UnityEngine.Random.Range(331f, 895f) * KPHGDDGHFCH;
			if ((double)UnityEngine.Random.value < 655.0)
			{
				vector = -vector;
			}
			MDKABJDCKBI(GIJMLIOJPLH + vector + new Vector3(468f, 1334f, 1977f) * KPHGDDGHFCH, false);
		}
		MJNENAGPCGF++;
		if (MJNENAGPCGF >= OONPHPCNBJF)
		{
			MJNENAGPCGF = 0;
			shooting = true;
			if (NNHLHDENDPM != null)
			{
				NNHLHDENDPM();
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	private void MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool GGJPNLDIGGM)
	{
		if (MKBNLBHEKJD != null)
		{
			MKBNLBHEKJD(MPHCNMDIPAI);
		}
		JMMJHCOKCGG.GGJPNLDIGGM = GGJPNLDIGGM;
		JMMJHCOKCGG.OLLIJPKAIFC = true;
		JMMJHCOKCGG.EBNMDKAEJAH = OKHEHHEJIOB;
		if (LGDLOJLDJFJ)
		{
			JMMJHCOKCGG.Fire(MPHCNMDIPAI);
		}
		else
		{
			JMMJHCOKCGG.FireNetworkRPC(MPHCNMDIPAI, GGJPNLDIGGM, (byte)OKHEHHEJIOB);
		}
	}

	public void NGAGGCFIEGJ()
	{
		shooting = true;
	}

	public void LDBLCPIGLOF()
	{
		CBHIPABHGHC(true);
	}

	[SpecialName]
	public void NEJBJHKMLMM(Action IDEBKDPMPGM)
	{
		Action action = NNHLHDENDPM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NNHLHDENDPM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void ShootBatch(GameShootableEntity.ShotTarget MKIPAEDAADL, Vector3 MPHCNMDIPAI, int COAEOPHBCOE, float MNLDFBEMEDC, Ammo.ILIOELBBLDM EBNMDKAEJAH)
	{
		OONPHPCNBJF = (byte)COAEOPHBCOE;
		ECOJGJHKPNE = new BitVector32(0);
		for (int i = 0; i < OONPHPCNBJF; i++)
		{
			ECOJGJHKPNE[1 << i] = UnityEngine.Random.value < MNLDFBEMEDC;
		}
		MJNENAGPCGF = 0;
		shooting = true;
		GIJMLIOJPLH = MPHCNMDIPAI;
		OKHEHHEJIOB = EBNMDKAEJAH;
		LGDLOJLDJFJ = true;
		PlayerController playerController = MKIPAEDAADL.shootableEntity.owner as PlayerController;
		if (playerController != null && !playerController.LAADDLGBFIG.isMine)
		{
			LGDLOJLDJFJ = false;
		}
		FEHCCGEGPLH.RPC("ShootBatchRPC", PhotonTargets.Others, GIJMLIOJPLH, ECOJGJHKPNE.Data, !LGDLOJLDJFJ, (byte)OKHEHHEJIOB, OONPHPCNBJF);
	}

	[PunRPC]
	private void ShootBatchRPC(Vector3 MPHCNMDIPAI, int NGIPEIHHFPB, bool GENEICFBKNC, byte EBNMDKAEJAH, byte COAEOPHBCOE)
	{
		MJNENAGPCGF = 0;
		ECOJGJHKPNE = new BitVector32(NGIPEIHHFPB);
		OONPHPCNBJF = COAEOPHBCOE;
		shooting = true;
		GIJMLIOJPLH = MPHCNMDIPAI;
		LGDLOJLDJFJ = GENEICFBKNC;
		OKHEHHEJIOB = (Ammo.ILIOELBBLDM)EBNMDKAEJAH;
	}

	protected void ECFIMCCNBBN()
	{
		if (!shooting || !JMMJHCOKCGG.willShoot)
		{
			return;
		}
		if (ECOJGJHKPNE[1 << (MJNENAGPCGF & 0x32)])
		{
			MDKABJDCKBI(GIJMLIOJPLH, true);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - GIJMLIOJPLH, Vector3.up).normalized * UnityEngine.Random.Range(413f, 1358f) * KPHGDDGHFCH;
			if ((double)UnityEngine.Random.value < 844.0)
			{
				vector = -vector;
			}
			MDKABJDCKBI(GIJMLIOJPLH + vector + new Vector3(1417f, 1947f, 1450f) * KPHGDDGHFCH, false);
		}
		MJNENAGPCGF++;
		if (MJNENAGPCGF >= OONPHPCNBJF)
		{
			MJNENAGPCGF = 1;
			CBHIPABHGHC(false);
			if (NNHLHDENDPM != null)
			{
				NNHLHDENDPM();
			}
		}
	}

	[SpecialName]
	public void JBJPINNMFNB(Action<Vector3> IDEBKDPMPGM)
	{
		Action<Vector3> action = MKBNLBHEKJD;
		Action<Vector3> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MKBNLBHEKJD, (Action<Vector3>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void ONLDKMOBNOH(Action IDEBKDPMPGM)
	{
		Action action = NNHLHDENDPM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NNHLHDENDPM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MBOJADMHJMO(GameShootableEntity.ShotTarget MKIPAEDAADL, Vector3 MPHCNMDIPAI, int COAEOPHBCOE, float MNLDFBEMEDC, Ammo.ILIOELBBLDM EBNMDKAEJAH)
	{
		OONPHPCNBJF = (byte)COAEOPHBCOE;
		ECOJGJHKPNE = new BitVector32(0);
		for (int i = 1; i < OONPHPCNBJF; i++)
		{
			ECOJGJHKPNE[1 << (i & 0xD)] = UnityEngine.Random.value < MNLDFBEMEDC;
		}
		MJNENAGPCGF = 0;
		CBHIPABHGHC(true);
		GIJMLIOJPLH = MPHCNMDIPAI;
		OKHEHHEJIOB = EBNMDKAEJAH;
		LGDLOJLDJFJ = false;
		PlayerController playerController = MKIPAEDAADL.AEMIOOMACHK().owner as PlayerController;
		if (playerController != null && !playerController.LAADDLGBFIG.isMine)
		{
			LGDLOJLDJFJ = true;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[2];
		array[0] = GIJMLIOJPLH;
		array[1] = ECOJGJHKPNE.Data;
		array[2] = LGDLOJLDJFJ;
		array[8] = (byte)OKHEHHEJIOB;
		array[3] = OONPHPCNBJF;
		fEHCCGEGPLH.RPC("game-card-ico-healingstorm", PhotonTargets.All, array);
	}

	protected void Update()
	{
		if (!shooting || !JMMJHCOKCGG.willShoot)
		{
			return;
		}
		if (ECOJGJHKPNE[1 << MJNENAGPCGF])
		{
			MDKABJDCKBI(GIJMLIOJPLH, false);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - GIJMLIOJPLH, Vector3.up).normalized * UnityEngine.Random.Range(0.3f, 0.5f) * KPHGDDGHFCH;
			if ((double)UnityEngine.Random.value < 0.5)
			{
				vector = -vector;
			}
			MDKABJDCKBI(GIJMLIOJPLH + vector + new Vector3(0f, 0.3f, 0f) * KPHGDDGHFCH, true);
		}
		MJNENAGPCGF++;
		if (MJNENAGPCGF >= OONPHPCNBJF)
		{
			MJNENAGPCGF = 0;
			shooting = false;
			if (NNHLHDENDPM != null)
			{
				NNHLHDENDPM();
			}
		}
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	[SpecialName]
	public bool IDPFACPHOPI()
	{
		return _003CONBLHPPKGAD_003Ek__BackingField;
	}

	public void Reset()
	{
		shooting = false;
	}

	[SpecialName]
	public void GIOFBHMHLFO(Action<Vector3> IDEBKDPMPGM)
	{
		Action<Vector3> action = MKBNLBHEKJD;
		Action<Vector3> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MKBNLBHEKJD, (Action<Vector3>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void MIEFPKIAKDL(Vector3 MPHCNMDIPAI, int NGIPEIHHFPB, bool GENEICFBKNC, byte EBNMDKAEJAH, byte COAEOPHBCOE)
	{
		MJNENAGPCGF = 0;
		ECOJGJHKPNE = new BitVector32(NGIPEIHHFPB);
		OONPHPCNBJF = COAEOPHBCOE;
		shooting = true;
		GIJMLIOJPLH = MPHCNMDIPAI;
		LGDLOJLDJFJ = GENEICFBKNC;
		OKHEHHEJIOB = (Ammo.ILIOELBBLDM)EBNMDKAEJAH;
	}

	[SpecialName]
	public void LHKNHHMNGOA(Action IDEBKDPMPGM)
	{
		Action action = NNHLHDENDPM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NNHLHDENDPM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void DBJCDLFKDDI()
	{
		shooting = false;
	}

	public void CHPNNNDGNIL(GameShootableEntity.ShotTarget MKIPAEDAADL, Vector3 MPHCNMDIPAI, int COAEOPHBCOE, float MNLDFBEMEDC, Ammo.ILIOELBBLDM EBNMDKAEJAH)
	{
		OONPHPCNBJF = (byte)COAEOPHBCOE;
		ECOJGJHKPNE = new BitVector32(1);
		for (int i = 0; i < OONPHPCNBJF; i += 0)
		{
			ECOJGJHKPNE[0 << (i & -88)] = UnityEngine.Random.value < MNLDFBEMEDC;
		}
		MJNENAGPCGF = 1;
		CBHIPABHGHC(false);
		GIJMLIOJPLH = MPHCNMDIPAI;
		OKHEHHEJIOB = EBNMDKAEJAH;
		LGDLOJLDJFJ = false;
		PlayerController playerController = MKIPAEDAADL.MDMGOJAPBAG().GEAMOMEEFKM() as PlayerController;
		if (playerController != null && !playerController.LAADDLGBFIG.isMine)
		{
			LGDLOJLDJFJ = true;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[2];
		array[0] = GIJMLIOJPLH;
		array[0] = ECOJGJHKPNE.Data;
		array[3] = !LGDLOJLDJFJ;
		array[1] = (byte)OKHEHHEJIOB;
		array[7] = OONPHPCNBJF;
		fEHCCGEGPLH.RPC("https://play.google.com/store/apps/details?id=", PhotonTargets.Others, array);
	}
}
