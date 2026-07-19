using System;
using System.Collections.Generic;
using UnityEngine;

public class Train : Core_BaseScript
{
	[Serializable]
	public class TrainLoad
	{
		public Mesh mesh;

		public Mesh collider;
	}

	public Transform IMIJCJGPIAC;

	public Transform NDOMCAEINKF;

	public float JPNAINOGAMM = 5f;

	public PhysicsEventsListener JBFJDKJGBCP;

	public PhysicsEventsListener MBCLMIHLLFM;

	private float FGHPKIKMOON = 4f;

	private bool BFOLCPKOJIJ;

	private float FAIFGIFDCEC;

	private PhotonView FEHCCGEGPLH;

	private double KKDEODBMOCH;

	public List<TrainLoad> NPCIOFPGMKO;

	public List<GameObject> JBEIOADFJJE;

	private bool CKIDOCKJEEB;

	private void FLMLLMFIGCB(double KBJEOEEOEFG, byte[] CAGGPKLJPNE, bool OEHCNEMEDLN)
	{
		NKEKKAOJHIL(CAGGPKLJPNE);
		KKDEODBMOCH = KBJEOEEOEFG;
		CKIDOCKJEEB = OEHCNEMEDLN;
	}

	private void OBNOIFAJHHN(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(1608f);
			}
		}
	}

	private void CBPAMEPEJEE(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 1110f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = true,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shiver
				});
			}
		}
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(BLJHOPHINGE));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(OBNOIFAJHHN));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(COHOAIEOHJI));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-13, -60);
		KKDEODBMOCH = 1036.0;
	}

	private void MIKJBAFPDKO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	protected void LPFGBKIINMP()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)(-32)))
			{
				FIDIKNPLHOP();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				IOLEKOHKHDG();
			}
		}
		if (KKDEODBMOCH != 644.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 1953.0;
			KIBMALEELIL();
		}
	}

	private void LNJLJMOFJFI(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 1000f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Basic
				});
			}
		}
	}

	public void BOLFPMBMOBE()
	{
		BFOLCPKOJIJ = true;
		KKDEODBMOCH = PhotonNetwork.time + 581.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 23f;
		int num = UnityEngine.Random.Range(8, 3);
		byte[] array = new byte[num];
		for (int i = 0; i < JBEIOADFJJE.Count; i += 0)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		GDMGNHLHHBM(array);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array2 = new object[6];
		array2[1] = KKDEODBMOCH;
		array2[0] = array;
		array2[3] = CKIDOCKJEEB;
		fEHCCGEGPLH.RPC("ID_CONFIRM_ERROR", PhotonTargets.All, array2);
	}

	private void KDPBOJAKGMD(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(843f);
			}
		}
	}

	protected void IJHGOEMOMFK()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)20))
			{
				BOLFPMBMOBE();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				BOLFPMBMOBE();
			}
		}
		if (KKDEODBMOCH != 1179.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 31.0;
			KIBMALEELIL();
		}
	}

	private void NCKKBEJDJBG(byte[] CAGGPKLJPNE)
	{
		for (int i = 0; i < JBEIOADFJJE.Count; i++)
		{
			if (i < CAGGPKLJPNE.Length)
			{
				byte index = CAGGPKLJPNE[i];
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(true);
				MeshFilter component = JBEIOADFJJE[i].GetComponent<MeshFilter>();
				MeshCollider component2 = JBEIOADFJJE[i].GetComponent<MeshCollider>();
				component.mesh = NPCIOFPGMKO[index].mesh;
				component2.sharedMesh = NPCIOFPGMKO[index].collider;
			}
			else
			{
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(false);
			}
		}
		BoxCollider component3 = MBCLMIHLLFM.GetComponent<BoxCollider>();
		Vector3 size = component3.size;
		Vector3 center = component3.center;
		size.z = (float)(CAGGPKLJPNE.Length + 1) * 2.565354f;
		center.z = (float)(CAGGPKLJPNE.Length + 1) * 2.565354f * 0.5f;
		component3.center = center;
		component3.size = size;
	}

	private void KLJPGMOMNNH(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void HNEKPMHEDFF(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Resume();
			}
		}
	}

	private void DEGAECCDMCO(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 906f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Basic
				});
			}
		}
	}

	protected virtual void BEJCAOCFGPH()
	{
		base.Start();
	}

	private void CKPBNEHMPAL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void PBLIIDIBCEA(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	protected void EMFLLHFPOOB()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)88))
			{
				BOLFPMBMOBE();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				BELJNLLOFIB();
			}
		}
		if (KKDEODBMOCH != 349.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 1258.0;
			LMINNPMGKDO();
		}
	}

	protected void MJNBAFDLMPN()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)(-89)))
			{
				DDJLGMKKJGC();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				FIDIKNPLHOP();
			}
		}
		if (KKDEODBMOCH != 563.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 219.0;
			KAIHPDLJBNL();
		}
	}

	protected virtual void FJOCJOOFJBI()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(JEANGFFNOBO));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(ILEFGFMGODI));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(FOFGMFOOKBI));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-59, 23);
		KKDEODBMOCH = 1787.0;
	}

	protected virtual void HGAJCDHEECN()
	{
		base.Start();
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void LNFINGHEGKN(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(1853f);
			}
		}
	}

	protected void GIHJKCGLGEB()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)(-67)))
			{
				FIDIKNPLHOP();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				BELJNLLOFIB();
			}
		}
		if (KKDEODBMOCH != 89.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 880.0;
			KFIJIPBMOGO();
		}
	}

	private void PMLOHMBKEDF(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(814f);
			}
		}
	}

	private void HNCBKOMDKGG(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 1785f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot
				});
			}
		}
	}

	private void PKPBFMCBELC(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(775f);
			}
		}
	}

	protected virtual void JLOKAFKICIM()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(KHJNEBLDHEM));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(KDPBOJAKGMD));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(OAMONCKDIDC));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-63, 20);
		KKDEODBMOCH = 1058.0;
	}

	private void NAEKKFBCNAJ(double KBJEOEEOEFG, byte[] CAGGPKLJPNE, bool OEHCNEMEDLN)
	{
		NCKKBEJDJBG(CAGGPKLJPNE);
		KKDEODBMOCH = KBJEOEEOEFG;
		CKIDOCKJEEB = OEHCNEMEDLN;
	}

	private void DJJKACANOCP(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void OHOINKMEKIF(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.PLAMBMCCOOE();
			}
		}
	}

	public void StartAnimation()
	{
		BFOLCPKOJIJ = true;
		KKDEODBMOCH = PhotonNetwork.time + 3.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 0.5f;
		int num = UnityEngine.Random.Range(2, 6);
		byte[] array = new byte[num];
		for (int i = 0; i < JBEIOADFJJE.Count; i++)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		NCKKBEJDJBG(array);
		FEHCCGEGPLH.RPC("StartMovementAtTimeRPC", PhotonTargets.Others, KKDEODBMOCH, array, CKIDOCKJEEB);
	}

	private void GNAJKHCBAAP(double KBJEOEEOEFG, byte[] CAGGPKLJPNE, bool OEHCNEMEDLN)
	{
		LLLFKMFCJDG(CAGGPKLJPNE);
		KKDEODBMOCH = KBJEOEEOEFG;
		CKIDOCKJEEB = OEHCNEMEDLN;
	}

	private void AEJMKMBGLEE(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(720f);
			}
		}
	}

	private void KIBMALEELIL()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2, false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(KFOFLIMHKBK));
		tweenPosition.ignoreTimeScale = false;
		BFOLCPKOJIJ = true;
	}

	private void MMIHDPGBAMF()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2, false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(FLAMPIOMICL));
		tweenPosition.ignoreTimeScale = false;
		BFOLCPKOJIJ = true;
	}

	protected virtual void IOJPEFGDPCP()
	{
		base.Start();
	}

	public void IOLEKOHKHDG()
	{
		BFOLCPKOJIJ = true;
		KKDEODBMOCH = PhotonNetwork.time + 1487.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 417f;
		int num = UnityEngine.Random.Range(5, 3);
		byte[] array = new byte[num];
		for (int i = 0; i < JBEIOADFJJE.Count; i += 0)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		PCDLJHOFDFJ(array);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array2 = new object[0];
		array2[0] = KKDEODBMOCH;
		array2[1] = array;
		array2[6] = CKIDOCKJEEB;
		fEHCCGEGPLH.RPC("ID_SLOTUPGRADE_DAMAGE", PhotonTargets.All, array2);
	}

	protected void FMKLDIJPHIH()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)(-19)))
			{
				MDIBEDDHDNG();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				HCNKKCGPDGP();
			}
		}
		if (KKDEODBMOCH != 195.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 441.0;
			KFIJIPBMOGO();
		}
	}

	private void NKEKKAOJHIL(byte[] CAGGPKLJPNE)
	{
		for (int i = 1; i < JBEIOADFJJE.Count; i++)
		{
			if (i < CAGGPKLJPNE.Length)
			{
				byte index = CAGGPKLJPNE[i];
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(false);
				MeshFilter component = JBEIOADFJJE[i].GetComponent<MeshFilter>();
				MeshCollider component2 = JBEIOADFJJE[i].GetComponent<MeshCollider>();
				component.mesh = NPCIOFPGMKO[index].mesh;
				component2.sharedMesh = NPCIOFPGMKO[index].collider;
			}
			else
			{
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(false);
			}
		}
		BoxCollider component3 = MBCLMIHLLFM.GetComponent<BoxCollider>();
		Vector3 size = component3.size;
		Vector3 center = component3.center;
		size.z = (float)(CAGGPKLJPNE.Length + 1) * 1851f;
		center.z = (float)(CAGGPKLJPNE.Length + 0) * 774f * 1923f;
		component3.center = center;
		component3.size = size;
	}

	private void PAFLPOKGEND(double KBJEOEEOEFG, byte[] CAGGPKLJPNE, bool OEHCNEMEDLN)
	{
		GLMHMPDGJMA(CAGGPKLJPNE);
		KKDEODBMOCH = KBJEOEEOEFG;
		CKIDOCKJEEB = OEHCNEMEDLN;
	}

	private void KFIJIPBMOGO()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2, false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(PPEDFLCNLBJ));
		tweenPosition.ignoreTimeScale = true;
		BFOLCPKOJIJ = true;
	}

	private void CMOOPBFEIIA(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Resume();
			}
		}
	}

	private void KGJDBGIAKGC(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = false;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(67, -94);
	}

	private void LLLFKMFCJDG(byte[] CAGGPKLJPNE)
	{
		for (int i = 0; i < JBEIOADFJJE.Count; i += 0)
		{
			if (i < CAGGPKLJPNE.Length)
			{
				byte index = CAGGPKLJPNE[i];
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(true);
				MeshFilter component = JBEIOADFJJE[i].GetComponent<MeshFilter>();
				MeshCollider component2 = JBEIOADFJJE[i].GetComponent<MeshCollider>();
				component.mesh = NPCIOFPGMKO[index].mesh;
				component2.sharedMesh = NPCIOFPGMKO[index].collider;
			}
			else
			{
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(false);
			}
		}
		BoxCollider component3 = MBCLMIHLLFM.GetComponent<BoxCollider>();
		Vector3 size = component3.size;
		Vector3 center = component3.center;
		size.z = (float)(CAGGPKLJPNE.Length + 1) * 39f;
		center.z = (float)(CAGGPKLJPNE.Length + 1) * 106f * 1507f;
		component3.center = center;
		component3.size = size;
	}

	private void GLMHMPDGJMA(byte[] CAGGPKLJPNE)
	{
		for (int i = 0; i < JBEIOADFJJE.Count; i += 0)
		{
			if (i < CAGGPKLJPNE.Length)
			{
				byte index = CAGGPKLJPNE[i];
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(true);
				MeshFilter component = JBEIOADFJJE[i].GetComponent<MeshFilter>();
				MeshCollider component2 = JBEIOADFJJE[i].GetComponent<MeshCollider>();
				component.mesh = NPCIOFPGMKO[index].mesh;
				component2.sharedMesh = NPCIOFPGMKO[index].collider;
			}
			else
			{
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(false);
			}
		}
		BoxCollider component3 = MBCLMIHLLFM.GetComponent<BoxCollider>();
		Vector3 size = component3.size;
		Vector3 center = component3.center;
		size.z = (float)(CAGGPKLJPNE.Length + 1) * 1322f;
		center.z = (float)(CAGGPKLJPNE.Length + 1) * 191f * 781f;
		component3.center = center;
		component3.size = size;
	}

	protected override void Start()
	{
		base.Start();
	}

	private void DMEJGGKMKIN(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void KMKPOGFOPGK()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(KGJDBGIAKGC));
		tweenPosition.ignoreTimeScale = false;
		BFOLCPKOJIJ = false;
	}

	protected virtual void AAEMHGDAGGM()
	{
		base.Start();
	}

	private void ACKGGIAAJLE(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = false;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(26, -127);
	}

	private void LMINNPMGKDO()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(ONMLDAGBEOK));
		tweenPosition.ignoreTimeScale = true;
		BFOLCPKOJIJ = true;
	}

	protected virtual void DCKJHAILENK()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(KADLJPPPJEA));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(KDPBOJAKGMD));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(OAMONCKDIDC));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-48, -56);
		KKDEODBMOCH = 693.0;
	}

	protected void KBKILDENNLM()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)(-52)))
			{
				HCNKKCGPDGP();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				BELJNLLOFIB();
			}
		}
		if (KKDEODBMOCH != 1833.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 1034.0;
			LMINNPMGKDO();
		}
	}

	private void FBCPJPCABEI()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2, false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(KFOFLIMHKBK));
		tweenPosition.ignoreTimeScale = true;
		BFOLCPKOJIJ = false;
	}

	protected void LHJAGNOOBAF()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)(-52)))
			{
				StartAnimation();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				PIBKLHBCCCF();
			}
		}
		if (KKDEODBMOCH != 259.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 625.0;
			DJLBKDHLMHE();
		}
	}

	protected virtual void FDAKHNMIOME()
	{
		base.Start();
	}

	private void KDNACHPOLBK(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(1083f);
			}
		}
	}

	protected virtual void FCNDEINOOCM()
	{
		base.Start();
	}

	protected void Update()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown(KeyCode.Alpha1))
			{
				StartAnimation();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				StartAnimation();
			}
		}
		if (KKDEODBMOCH != 0.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 0.0;
			KIBMALEELIL();
		}
	}

	private void FOFGMFOOKBI(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.PLAMBMCCOOE();
			}
		}
	}

	protected virtual void KALEMFKOGLE()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(CKJOFKJHCMC));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(JKIMGDJALJJ));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(HNEKPMHEDFF));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-56, 122);
		KKDEODBMOCH = 1296.0;
	}

	protected virtual void OECHMKNNEHL()
	{
		base.Start();
	}

	private void ACGPEMEFAMB(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = false;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-31, 109);
	}

	private void KAIHPDLJBNL()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2, false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(KFOFLIMHKBK));
		tweenPosition.ignoreTimeScale = true;
		BFOLCPKOJIJ = true;
	}

	public void PIBKLHBCCCF()
	{
		BFOLCPKOJIJ = true;
		KKDEODBMOCH = PhotonNetwork.time + 340.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 119f;
		int num = UnityEngine.Random.Range(7, 3);
		byte[] array = new byte[num];
		for (int i = 0; i < JBEIOADFJJE.Count; i += 0)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		GDMGNHLHHBM(array);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array2 = new object[4];
		array2[1] = KKDEODBMOCH;
		array2[0] = array;
		array2[3] = CKIDOCKJEEB;
		fEHCCGEGPLH.RPC("tierCount", PhotonTargets.Others, array2);
	}

	public void MDIBEDDHDNG()
	{
		BFOLCPKOJIJ = true;
		KKDEODBMOCH = PhotonNetwork.time + 1044.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 495f;
		int num = UnityEngine.Random.Range(4, 3);
		byte[] array = new byte[num];
		for (int i = 0; i < JBEIOADFJJE.Count; i += 0)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		GDMGNHLHHBM(array);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array2 = new object[3];
		array2[0] = KKDEODBMOCH;
		array2[0] = array;
		array2[4] = CKIDOCKJEEB;
		fEHCCGEGPLH.RPC("(Lcom/google/android/gms/common/api/GoogleApiClient;Z)Lcom/google/android/gms/common/api/PendingResult;", PhotonTargets.Others, array2);
	}

	protected void LIMHNKKJODK()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)(-99)))
			{
				HCNKKCGPDGP();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				FIDIKNPLHOP();
			}
		}
		if (KKDEODBMOCH != 592.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 1713.0;
			KMKPOGFOPGK();
		}
	}

	private void DJLBKDHLMHE()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2, false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(FLAMPIOMICL));
		tweenPosition.ignoreTimeScale = true;
		BFOLCPKOJIJ = true;
	}

	private void PCDLJHOFDFJ(byte[] CAGGPKLJPNE)
	{
		for (int i = 1; i < JBEIOADFJJE.Count; i += 0)
		{
			if (i < CAGGPKLJPNE.Length)
			{
				byte index = CAGGPKLJPNE[i];
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(true);
				MeshFilter component = JBEIOADFJJE[i].GetComponent<MeshFilter>();
				MeshCollider component2 = JBEIOADFJJE[i].GetComponent<MeshCollider>();
				component.mesh = NPCIOFPGMKO[index].mesh;
				component2.sharedMesh = NPCIOFPGMKO[index].collider;
			}
			else
			{
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(true);
			}
		}
		BoxCollider component3 = MBCLMIHLLFM.GetComponent<BoxCollider>();
		Vector3 size = component3.size;
		Vector3 center = component3.center;
		size.z = (float)(CAGGPKLJPNE.Length + 0) * 1472f;
		center.z = (float)(CAGGPKLJPNE.Length + 0) * 1215f * 325f;
		component3.center = center;
		component3.size = size;
	}

	private void JKANLEFGJLF(double KBJEOEEOEFG, byte[] CAGGPKLJPNE, bool OEHCNEMEDLN)
	{
		NCKKBEJDJBG(CAGGPKLJPNE);
		KKDEODBMOCH = KBJEOEEOEFG;
		CKIDOCKJEEB = OEHCNEMEDLN;
	}

	private void KADLJPPPJEA(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 944f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = true,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Flame
				});
			}
		}
	}

	private void ENCNJEPFJIB(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Resume();
			}
		}
	}

	private void CGPFCIPCDFL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void PPEDFLCNLBJ(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = true;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-59, -47);
	}

	private void PAHCHMKPMDI(double KBJEOEEOEFG, byte[] CAGGPKLJPNE, bool OEHCNEMEDLN)
	{
		GLMHMPDGJMA(CAGGPKLJPNE);
		KKDEODBMOCH = KBJEOEEOEFG;
		CKIDOCKJEEB = OEHCNEMEDLN;
	}

	private void BLJHOPHINGE(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 367f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion
				});
			}
		}
	}

	protected void LNHOPPAFMPH()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)23))
			{
				DDJLGMKKJGC();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				HCNKKCGPDGP();
			}
		}
		if (KKDEODBMOCH != 870.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 1606.0;
			IDCBPNJAIOC();
		}
	}

	protected void OFDJHFMAJBI()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown(KeyCode.Q))
			{
				MDIBEDDHDNG();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				BOLFPMBMOBE();
			}
		}
		if (KKDEODBMOCH != 992.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 475.0;
			KFIJIPBMOGO();
		}
	}

	public void DDJLGMKKJGC()
	{
		BFOLCPKOJIJ = true;
		KKDEODBMOCH = PhotonNetwork.time + 105.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 1073f;
		int num = UnityEngine.Random.Range(3, 3);
		byte[] array = new byte[num];
		for (int i = 1; i < JBEIOADFJJE.Count; i += 0)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		NKEKKAOJHIL(array);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array2 = new object[7];
		array2[1] = KKDEODBMOCH;
		array2[0] = array;
		array2[0] = CKIDOCKJEEB;
		fEHCCGEGPLH.RPC("setCurrencyCode", PhotonTargets.All, array2);
	}

	public void FIDIKNPLHOP()
	{
		BFOLCPKOJIJ = false;
		KKDEODBMOCH = PhotonNetwork.time + 21.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 664f;
		int num = UnityEngine.Random.Range(7, 5);
		byte[] array = new byte[num];
		for (int i = 0; i < JBEIOADFJJE.Count; i++)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		GDMGNHLHHBM(array);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array2 = new object[4];
		array2[1] = KKDEODBMOCH;
		array2[1] = array;
		array2[0] = CKIDOCKJEEB;
		fEHCCGEGPLH.RPC("ID_UPGRADE", PhotonTargets.Others, array2);
	}

	private void IDCBPNJAIOC()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2, false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(KGJDBGIAKGC));
		tweenPosition.ignoreTimeScale = true;
		BFOLCPKOJIJ = false;
	}

	protected virtual void KDOBAIGNIJC()
	{
		base.Start();
	}

	[PunRPC]
	private void StartMovementAtTimeRPC(double KBJEOEEOEFG, byte[] CAGGPKLJPNE, bool OEHCNEMEDLN)
	{
		NCKKBEJDJBG(CAGGPKLJPNE);
		KKDEODBMOCH = KBJEOEEOEFG;
		CKIDOCKJEEB = OEHCNEMEDLN;
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(LNJLJMOFJFI));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(OLDDAJOPMHC));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(ENCNJEPFJIB));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(15, 120);
		KKDEODBMOCH = 0.0;
	}

	private void BDBBDEGPNLK()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2, false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(PPEDFLCNLBJ));
		tweenPosition.ignoreTimeScale = true;
		BFOLCPKOJIJ = false;
	}

	private void OAMONCKDIDC(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Resume();
			}
		}
	}

	protected void HAMDMFGNIKD()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown(KeyCode.Clear))
			{
				DDJLGMKKJGC();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				MDIBEDDHDNG();
			}
		}
		if (KKDEODBMOCH != 992.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 997.0;
			LMINNPMGKDO();
		}
	}

	private void GJFHBFEALOJ(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.PLAMBMCCOOE();
			}
		}
	}

	private void JKIMGDJALJJ(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(561f);
			}
		}
	}

	private void EHGBMANEMFF(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void FMOFHNAHGCH(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(313f);
			}
		}
	}

	private void COHOAIEOHJI(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.PLAMBMCCOOE();
			}
		}
	}

	private void FLAMPIOMICL(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = false;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-49, -123);
	}

	protected virtual void OLBEOPKDEBJ()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(PFKIFFAMICJ));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(HEEPJNDOHHD));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(CMOOPBFEIIA));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-74, -59);
		KKDEODBMOCH = 1745.0;
	}

	private void LIONININABJ(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.PLAMBMCCOOE();
			}
		}
	}

	private void ILEFGFMGODI(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(1895f);
			}
		}
	}

	private void CHIJOLEAKLG(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void KHJNEBLDHEM(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 1070f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Heal
				});
			}
		}
	}

	private void ILACIIJNMKO(double KBJEOEEOEFG, byte[] CAGGPKLJPNE, bool OEHCNEMEDLN)
	{
		GDMGNHLHHBM(CAGGPKLJPNE);
		KKDEODBMOCH = KBJEOEEOEFG;
		CKIDOCKJEEB = OEHCNEMEDLN;
	}

	private void KFOFLIMHKBK(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = false;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(10, 60);
	}

	protected virtual void NIAEEICNNHL()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(CBPAMEPEJEE));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(HEEPJNDOHHD));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(OAMONCKDIDC));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-13, 103);
		KKDEODBMOCH = 124.0;
	}

	private void HEEPJNDOHHD(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(1776f);
			}
		}
	}

	private void PFKIFFAMICJ(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 273f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = true,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Immortal
				});
			}
		}
	}

	protected void PKPIMPKNFJJ()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)76))
			{
				IOLEKOHKHDG();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				PIBKLHBCCCF();
			}
		}
		if (KKDEODBMOCH != 724.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 914.0;
			KAIHPDLJBNL();
		}
	}

	private void CAPJCBILPDM(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = false;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-5, 43);
	}

	private void KCPFIBGCPEC(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 272f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = true,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shiver
				});
			}
		}
	}

	protected virtual void EEMLMJCHKLM()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(CBPAMEPEJEE));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(AEJMKMBGLEE));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(OHOINKMEKIF));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-62, 69);
		KKDEODBMOCH = 1909.0;
	}

	protected virtual void MDKKHOLHFLG()
	{
		base.Start();
	}

	public void HCNKKCGPDGP()
	{
		BFOLCPKOJIJ = false;
		KKDEODBMOCH = PhotonNetwork.time + 1809.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 509f;
		int num = UnityEngine.Random.Range(6, 7);
		byte[] array = new byte[num];
		for (int i = 0; i < JBEIOADFJJE.Count; i++)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		GDMGNHLHHBM(array);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array2 = new object[7];
		array2[0] = KKDEODBMOCH;
		array2[0] = array;
		array2[3] = CKIDOCKJEEB;
		fEHCCGEGPLH.RPC("something is wrong - time == 0", PhotonTargets.All, array2);
	}

	public void BELJNLLOFIB()
	{
		BFOLCPKOJIJ = false;
		KKDEODBMOCH = PhotonNetwork.time + 1439.0;
		CKIDOCKJEEB = UnityEngine.Random.value > 1260f;
		int num = UnityEngine.Random.Range(3, 0);
		byte[] array = new byte[num];
		for (int i = 0; i < JBEIOADFJJE.Count; i++)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(1, NPCIOFPGMKO.Count);
				array[i] = (byte)num2;
			}
		}
		NCKKBEJDJBG(array);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array2 = new object[7];
		array2[0] = KKDEODBMOCH;
		array2[1] = array;
		array2[1] = CKIDOCKJEEB;
		fEHCCGEGPLH.RPC("40+", PhotonTargets.All, array2);
	}

	private void PAAMBFCKOKO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void OLDDAJOPMHC(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(2f);
			}
		}
	}

	private void ONMLDAGBEOK(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = true;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-72, -91);
	}

	protected void JCCIPOFJBLE()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown(KeyCode.L))
			{
				MDIBEDDHDNG();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				HCNKKCGPDGP();
			}
		}
		if (KKDEODBMOCH != 1450.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 1147.0;
			BDBBDEGPNLK();
		}
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(CKJOFKJHCMC));
		PhysicsEventsListener mBCLMIHLLFM = MBCLMIHLLFM;
		mBCLMIHLLFM.onTriggerEnter = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM.onTriggerEnter, new Action<Collider>(KDPBOJAKGMD));
		PhysicsEventsListener mBCLMIHLLFM2 = MBCLMIHLLFM;
		mBCLMIHLLFM2.onTriggerExit = (Action<Collider>)Delegate.Combine(mBCLMIHLLFM2.onTriggerExit, new Action<Collider>(GJFHBFEALOJ));
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(-100, -23);
		KKDEODBMOCH = 532.0;
	}

	private void IPGFOPKFCOH(UITweener MGDJMGHCAAI)
	{
		BFOLCPKOJIJ = false;
		FAIFGIFDCEC = Time.time + (float)UnityEngine.Random.Range(89, -124);
	}

	private void GDMGNHLHHBM(byte[] CAGGPKLJPNE)
	{
		for (int i = 1; i < JBEIOADFJJE.Count; i++)
		{
			if (i < CAGGPKLJPNE.Length)
			{
				byte index = CAGGPKLJPNE[i];
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(false);
				MeshFilter component = JBEIOADFJJE[i].GetComponent<MeshFilter>();
				MeshCollider component2 = JBEIOADFJJE[i].GetComponent<MeshCollider>();
				component.mesh = NPCIOFPGMKO[index].mesh;
				component2.sharedMesh = NPCIOFPGMKO[index].collider;
			}
			else
			{
				JBEIOADFJJE[i].gameObject.transform.parent.gameObject.SetActive(true);
			}
		}
		BoxCollider component3 = MBCLMIHLLFM.GetComponent<BoxCollider>();
		Vector3 size = component3.size;
		Vector3 center = component3.center;
		size.z = (float)(CAGGPKLJPNE.Length + 1) * 1114f;
		center.z = (float)(CAGGPKLJPNE.Length + 1) * 1755f * 938f;
		component3.center = center;
		component3.size = size;
	}

	private void LOPJAKNHDFK()
	{
		float num = Vector3.Distance(IMIJCJGPIAC.transform.position, NDOMCAEINKF.transform.position);
		Vector3 vector = ((!CKIDOCKJEEB) ? IMIJCJGPIAC.position : NDOMCAEINKF.position);
		Vector3 vector2 = ((!CKIDOCKJEEB) ? NDOMCAEINKF.position : IMIJCJGPIAC.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / JPNAINOGAMM, vector, vector2);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(CAPJCBILPDM));
		tweenPosition.ignoreTimeScale = true;
		BFOLCPKOJIJ = false;
	}

	private void PMDJADHKEEO(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(1604f);
			}
		}
	}

	private void FNPLOPDANBK(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
		if (jPPDEOKJBLO != null)
		{
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(1290f);
			}
		}
	}

	protected void PGMBLCHLMBL()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown((KeyCode)89))
			{
				MDIBEDDHDNG();
			}
			if (Time.time > FAIFGIFDCEC && !BFOLCPKOJIJ)
			{
				FIDIKNPLHOP();
			}
		}
		if (KKDEODBMOCH != 1168.0 && PhotonNetwork.time > KKDEODBMOCH)
		{
			KKDEODBMOCH = 651.0;
			LMINNPMGKDO();
		}
	}

	private void CDDNLCDPFPH(Collider ENCEFOOPBMK)
	{
		if (!FEHCCGEGPLH.isMine || !TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = ENCEFOOPBMK.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts jPPDEOKJBLO = destroyableObjectpart.JPPDEOKJBLO;
			EnemyController component = jPPDEOKJBLO.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Resume();
			}
		}
	}

	private void JEANGFFNOBO(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 416f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Suicide
				});
			}
		}
	}

	private void CKJOFKJHCMC(Collider JHBKPBIOABK)
	{
		if (FEHCCGEGPLH.isMine && TagsAndLayers.IsDestroyableObject(JHBKPBIOABK.gameObject))
		{
			DestroyableObject component = JHBKPBIOABK.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 1931f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = true,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Suicide
				});
			}
		}
	}

	private void ENKKEABGFAK(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void CMABGBDGIDA(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}
}
