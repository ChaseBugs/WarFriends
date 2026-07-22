using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MagneticObject : Core_BaseScript
{
	[FormerlySerializedAs("IGKNEGNKMPG")]
	public DropPoint OCOILNELFFK;

	[FormerlySerializedAs("LDLIGKOJAKO")]
	public PhysicsEventsListener JBFJDKJGBCP;

	private bool GOKBOHHNKDJ = true;

	[FormerlySerializedAs("HMILJDEOJKM")]
	public bool PMOIABIGMLO;

	[FormerlySerializedAs("AIBOJEHFMNB")]
	public Transform CIPJHCFDLLJ;

	private PhotonView FEHCCGEGPLH;

	public void JDCANBPHCIJ()
	{
		GOKBOHHNKDJ = false;
	}

	private void KJBNAPPJNIE(Vector3 MDOPFNNFLFB, Quaternion NICKNMCOFGI)
	{
		base.transform.position = MDOPFNNFLFB;
		base.transform.rotation = NICKNMCOFGI;
	}

	private void LECFMBFEFPP(Collision AKLHJIBDAFA)
	{
		if (TagsAndLayers.KHKNLLDEBMA(AKLHJIBDAFA.collider.gameObject))
		{
			GOKBOHHNKDJ = false;
			GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)1;
			InvokeAfter(MNBEEEOHGIM, 1756f);
		}
	}

	private void KMOOJGMCJEG(Vector3 MDOPFNNFLFB, Quaternion NICKNMCOFGI)
	{
		base.transform.position = MDOPFNNFLFB;
		base.transform.rotation = NICKNMCOFGI;
	}

	private void OnCollisionEnter(Collision AKLHJIBDAFA)
	{
		if (TagsAndLayers.IsStatic(AKLHJIBDAFA.collider.gameObject))
		{
			GOKBOHHNKDJ = true;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			InvokeAfter(PGNKCLIINBE, 0.4f);
		}
	}

	private void KIJIGNACDAE(Collision AKLHJIBDAFA)
	{
		if (TagsAndLayers.LKIJKDCGCMI(AKLHJIBDAFA.collider.gameObject))
		{
			GOKBOHHNKDJ = true;
			GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)1;
			InvokeAfter(MNBEEEOHGIM, 1813f);
		}
	}

	[PunRPC]
	private void Sync(Vector3 MDOPFNNFLFB, Quaternion NICKNMCOFGI)
	{
		base.transform.position = MDOPFNNFLFB;
		base.transform.rotation = NICKNMCOFGI;
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(KICOJBCAJJD));
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	protected virtual void NGGJHDCOLEC()
	{
		base.Awake();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(AEBKHJMGBLB));
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	private void ONEKPOGNCEI(Collider ENCEFOOPBMK)
	{
		if (!GOKBOHHNKDJ && TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.GetComponent<Collider>().gameObject))
		{
			DestroyableObject component = ENCEFOOPBMK.GetComponent<Collider>().gameObject.GetComponent<DestroyableObject>();
			if (component != null && component.destroyableByBonusBox)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 1269f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
					DBFIOEAHJFD = true
				});
			}
		}
	}

	public void FMMDIMOOCJP()
	{
		GOKBOHHNKDJ = true;
	}

	protected virtual void IBLPGJOHIAE()
	{
		base.Awake();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(KICOJBCAJJD));
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void IGNFPCKFFLD(DropPoint DELDHNBGJHB)
	{
		GetComponent<Rigidbody>().isKinematic = true;
		PMOIABIGMLO = true;
		DELDHNBGJHB.JKOGCJGMBEB = this;
		OCOILNELFFK = DELDHNBGJHB;
		GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)(-85);
	}

	public void Drop(DropPoint DELDHNBGJHB)
	{
		GetComponent<Rigidbody>().isKinematic = false;
		PMOIABIGMLO = false;
		DELDHNBGJHB.JKOGCJGMBEB = this;
		OCOILNELFFK = DELDHNBGJHB;
		GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)80;
	}

	private void LABABPLHFOC()
	{
		GetComponent<NavMeshObstacle>().enabled = true;
		GetComponent<Rigidbody>().isKinematic = true;
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[4];
			array[0] = base.transform.position;
			array[0] = base.transform.rotation;
			fEHCCGEGPLH.RPC("{0} / {1}", PhotonTargets.All, array);
		}
	}

	public void KCIMMIJLMEH()
	{
		GOKBOHHNKDJ = false;
	}

	private void IJIOJPLIOHO(Vector3 MDOPFNNFLFB, Quaternion NICKNMCOFGI)
	{
		base.transform.position = MDOPFNNFLFB;
		base.transform.rotation = NICKNMCOFGI;
	}

	public void AAAPKKLNMEL()
	{
		GOKBOHHNKDJ = false;
	}

	protected virtual void BAGCDJMLCPF()
	{
		base.Awake();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(EBFNGGOBPFF));
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void CMDPKJCOJID(Transform PLMMBKGLGAB)
	{
		GetComponent<NavMeshObstacle>().enabled = true;
		base.transform.rotation = PLMMBKGLGAB.transform.rotation;
		base.transform.position = CIPJHCFDLLJ.transform.position - base.transform.rotation * CIPJHCFDLLJ.transform.localPosition;
	}

	private void DCIFJCMJICP(Vector3 MDOPFNNFLFB, Quaternion NICKNMCOFGI)
	{
		base.transform.position = MDOPFNNFLFB;
		base.transform.rotation = NICKNMCOFGI;
	}

	public void IsUp()
	{
		GOKBOHHNKDJ = false;
	}

	public void CDNDKNCPILA()
	{
		GOKBOHHNKDJ = true;
	}

	public void JCMFEBHNIPD()
	{
		GOKBOHHNKDJ = false;
	}

	public void CNCDLHAGAMO(DropPoint DELDHNBGJHB)
	{
		GetComponent<Rigidbody>().isKinematic = false;
		PMOIABIGMLO = false;
		DELDHNBGJHB.JKOGCJGMBEB = this;
		OCOILNELFFK = DELDHNBGJHB;
		GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)(-56);
	}

	private void AEBKHJMGBLB(Collider ENCEFOOPBMK)
	{
		if (!GOKBOHHNKDJ && TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.GetComponent<Collider>().gameObject))
		{
			DestroyableObject component = ENCEFOOPBMK.GetComponent<Collider>().gameObject.GetComponent<DestroyableObject>();
			if (component != null && component.destroyableByBonusBox)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 1906f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = true,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
					DBFIOEAHJFD = false
				});
			}
		}
	}

	private void PGNKCLIINBE()
	{
		GetComponent<NavMeshObstacle>().enabled = true;
		GetComponent<Rigidbody>().isKinematic = true;
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Sync", PhotonTargets.Others, base.transform.position, base.transform.rotation);
		}
	}

	public void Pick(Transform PLMMBKGLGAB)
	{
		GetComponent<NavMeshObstacle>().enabled = false;
		base.transform.rotation = PLMMBKGLGAB.transform.rotation;
		base.transform.position = CIPJHCFDLLJ.transform.position - base.transform.rotation * CIPJHCFDLLJ.transform.localPosition;
	}

	private void MNBEEEOHGIM()
	{
		GetComponent<NavMeshObstacle>().enabled = false;
		GetComponent<Rigidbody>().isKinematic = false;
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("thumbnailLittle", PhotonTargets.All, base.transform.position, base.transform.rotation, null);
		}
	}

	private void KICOJBCAJJD(Collider ENCEFOOPBMK)
	{
		if (!GOKBOHHNKDJ && TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.GetComponent<Collider>().gameObject))
		{
			DestroyableObject component = ENCEFOOPBMK.GetComponent<Collider>().gameObject.GetComponent<DestroyableObject>();
			if (component != null && component.destroyableByBonusBox)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = 544f,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Immortal,
					DBFIOEAHJFD = true
				});
			}
		}
	}

	private void EBFNGGOBPFF(Collider ENCEFOOPBMK)
	{
		if (!GOKBOHHNKDJ && TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK.GetComponent<Collider>().gameObject))
		{
			DestroyableObject component = ENCEFOOPBMK.GetComponent<Collider>().gameObject.GetComponent<DestroyableObject>();
			if (component != null && component.destroyableByBonusBox)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = float.MaxValue,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Basic,
					DBFIOEAHJFD = true
				});
			}
		}
	}

	public void DLEOJNAMICH(DropPoint DELDHNBGJHB)
	{
		GetComponent<Rigidbody>().isKinematic = false;
		PMOIABIGMLO = true;
		DELDHNBGJHB.JKOGCJGMBEB = this;
		OCOILNELFFK = DELDHNBGJHB;
		GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)123;
	}

	protected override void Awake()
	{
		base.Awake();
		PhysicsEventsListener jBFJDKJGBCP = JBFJDKJGBCP;
		jBFJDKJGBCP.onTriggerEnter = (Action<Collider>)Delegate.Combine(jBFJDKJGBCP.onTriggerEnter, new Action<Collider>(EBFNGGOBPFF));
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}
}
