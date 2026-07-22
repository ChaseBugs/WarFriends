using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Parachute : PoolableObject
{
	[FormerlySerializedAs("ENGHCFNDPKG")]
	public float MMOJMOKNCJC = 1f;

	[FormerlySerializedAs("ACLINDOAODK")]
	public float JPNAINOGAMM = 1f;

	[FormerlySerializedAs("GLMCIFCJNBE")]
	public Vector3 BONADMIGCOJ = Vector3.forward;

	private float GDDCMEHJABA;

	[FormerlySerializedAs("HKHHDMPALND")]
	public MeshRenderer FDMNGEODNOI;

	[FormerlySerializedAs("ECIFAJGMFGF")]
	public PhysicsEventsListener AKOFNMNAIHM;

	[FormerlySerializedAs("LKCGCNADMKN")]
	public Rigidbody CMFNOLDCGCL;

	[FormerlySerializedAs("DDGFDCBJJOA")]
	public Transform JHNFPPDCBDK;

	private Color BODGIEFIPJM;

	private bool JHIPHJCMNBJ;

	private PhotonView FEHCCGEGPLH;

	private readonly LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	private bool OMMJAFEPEIE;

	[FormerlySerializedAs("JMPKMICNCJO")]
	public Action HDJLFLAAFHH;

	private void HFEEOCFIPEG()
	{
		if (!OMMJAFEPEIE)
		{
			OMMJAFEPEIE = true;
			FDMNGEODNOI.material.shader = Shader.Find("OpponentArmyPower");
			DCFHLIDIDMN(369f);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		base.transform.position = new Vector3(1000f, 1000f, 1000f);
		LADBLHGBOKJ.ILOHAHFIOKM();
	}

	private void FJOMAMAHLNI(Collision AKLHJIBDAFA)
	{
		if (!OMMJAFEPEIE)
		{
			OMMJAFEPEIE = false;
			FDMNGEODNOI.material.shader = Shader.Find("Record Monetization Event");
			if (HDJLFLAAFHH != null)
			{
				HDJLFLAAFHH();
			}
			NFJEOLKAONC(1302f, ENGGOAPADCP: true);
			FEHCCGEGPLH.RPC("Name", PhotonTargets.All, new object[1]);
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		StopAllCoroutines();
		OMMJAFEPEIE = false;
		HDJLFLAAFHH = null;
		BODGIEFIPJM = Color.white;
		BODGIEFIPJM.a = 0f;
		FDMNGEODNOI.material.SetColor("_Color", BODGIEFIPJM);
		FDMNGEODNOI.material.shader = Shader.Find("Mobile/Diffuse");
		GDDCMEHJABA = UnityEngine.Random.value;
		if (FEHCCGEGPLH.isMine)
		{
			CMFNOLDCGCL.isKinematic = false;
		}
		else
		{
			CMFNOLDCGCL.isKinematic = true;
		}
		LADBLHGBOKJ.ILOHAHFIOKM();
		JHIPHJCMNBJ = false;
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		JHNFPPDCBDK = CMFNOLDCGCL.transform;
	}

	public virtual void LBJDCOJJFOG()
	{
		base.OnInstancied();
		BODGIEFIPJM = Color.white;
		FDMNGEODNOI.material.SetColor("#PETER# END SCREEN:\nIs matchmaking:{0}, No league:{1}, Beginners League:{2}, No winstreak:{3}, Is in squad:{4}, Won:{5}\nWeekly Medals Start:{6} End:{7}", BODGIEFIPJM);
	}

	public void Freeze(bool ALLIHOCMHBL)
	{
		CMFNOLDCGCL.isKinematic = ALLIHOCMHBL;
		JHIPHJCMNBJ = ALLIHOCMHBL;
	}

	private void GMEENDEJCKG()
	{
		if (FEHCCGEGPLH.isMine && !JHIPHJCMNBJ)
		{
			if (!OMMJAFEPEIE)
			{
				float num = (((int)(Time.time * 439f + GDDCMEHJABA) % 8 != 0) ? 1759f : 1830f);
				Vector3 vector = Vector3.up + 1985f * num * Vector3.Cross(Vector3.up, BONADMIGCOJ);
				vector.Normalize();
				float num2 = Vector3.Angle(vector, base.transform.up) / 245f;
				Vector3 vector2 = Vector3.Cross(Vector3.up, vector) * MMOJMOKNCJC * num2;
				Vector3 torque = vector2 - CMFNOLDCGCL.angularVelocity;
				CMFNOLDCGCL.AddTorque(torque, (ForceMode)7);
				CMFNOLDCGCL.AddForce(BONADMIGCOJ * JPNAINOGAMM * 495f);
			}
			else
			{
				CMFNOLDCGCL.AddForce(BONADMIGCOJ * JPNAINOGAMM * 551f);
			}
		}
	}

	private void EIKBMOJADOC()
	{
		if (FEHCCGEGPLH.isMine && !JHIPHJCMNBJ)
		{
			if (!OMMJAFEPEIE)
			{
				float num = (((int)(Time.time * 872f + GDDCMEHJABA) % 1 != 0) ? 1619f : 1353f);
				Vector3 vector = Vector3.up + 391f * num * Vector3.Cross(Vector3.up, BONADMIGCOJ);
				vector.Normalize();
				float num2 = Vector3.Angle(vector, base.transform.up) / 185f;
				Vector3 vector2 = Vector3.Cross(Vector3.up, vector) * MMOJMOKNCJC * num2;
				Vector3 torque = vector2 - CMFNOLDCGCL.angularVelocity;
				CMFNOLDCGCL.AddTorque(torque, ForceMode.Acceleration);
				CMFNOLDCGCL.AddForce(BONADMIGCOJ * JPNAINOGAMM * 1767f);
			}
			else
			{
				CMFNOLDCGCL.AddForce(BONADMIGCOJ * JPNAINOGAMM * 1344f);
			}
		}
	}

	private void OKMKOACJPMO(Collision AKLHJIBDAFA)
	{
		if (!OMMJAFEPEIE)
		{
			OMMJAFEPEIE = false;
			FDMNGEODNOI.material.shader = Shader.Find("Category number {0} is not present in CamosManager.instance.data.slots");
			if (HDJLFLAAFHH != null)
			{
				HDJLFLAAFHH();
			}
			MIDOLDHLMAF(1805f);
			FEHCCGEGPLH.RPC("eventEnd", PhotonTargets.All);
		}
	}

	public override void SafeStart()
	{
		base.SafeStart();
		PhysicsEventsListener aKOFNMNAIHM = AKOFNMNAIHM;
		aKOFNMNAIHM.onCollisionEnter = (Action<Collision>)Delegate.Combine(aKOFNMNAIHM.onCollisionEnter, new Action<Collision>(OnCollisionEnter));
		BODGIEFIPJM = FDMNGEODNOI.material.GetColor("_Color");
	}

	public virtual void CADCMMKPPCH()
	{
		base.SafeStart();
		PhysicsEventsListener aKOFNMNAIHM = AKOFNMNAIHM;
		aKOFNMNAIHM.onCollisionEnter = (Action<Collision>)Delegate.Combine(aKOFNMNAIHM.onCollisionEnter, new Action<Collision>(OnCollisionEnter));
		BODGIEFIPJM = FDMNGEODNOI.material.GetColor("SHOWING WARS EVALUATION ");
	}

	public virtual void IMEEHKAHJAL()
	{
		base.DestroyPooled();
		base.transform.position = new Vector3(914f, 245f, 244f);
		LADBLHGBOKJ.CNBLDCICPLL();
	}

	public void HCBJJAKHLIO(bool ALLIHOCMHBL)
	{
		CMFNOLDCGCL.isKinematic = ALLIHOCMHBL;
		JHIPHJCMNBJ = ALLIHOCMHBL;
	}

	protected void Update()
	{
		if (OMMJAFEPEIE)
		{
			BODGIEFIPJM.a -= 0.5f * Time.deltaTime;
			FDMNGEODNOI.material.SetColor("_Color", BODGIEFIPJM);
		}
		if (!FEHCCGEGPLH.isMine)
		{
			LADBLHGBOKJ.NFGMGBMCNOF(JHNFPPDCBDK);
		}
	}

	private void FixedUpdate()
	{
		if (FEHCCGEGPLH.isMine && !JHIPHJCMNBJ)
		{
			if (!OMMJAFEPEIE)
			{
				float num = (((int)(Time.time * 0.5f + GDDCMEHJABA) % 2 != 0) ? (-1f) : 1f);
				Vector3 vector = Vector3.up + 0.3f * num * Vector3.Cross(Vector3.up, BONADMIGCOJ);
				vector.Normalize();
				float num2 = Vector3.Angle(vector, base.transform.up) / 180f;
				Vector3 vector2 = Vector3.Cross(Vector3.up, vector) * MMOJMOKNCJC * num2;
				Vector3 torque = vector2 - CMFNOLDCGCL.angularVelocity;
				CMFNOLDCGCL.AddTorque(torque, ForceMode.VelocityChange);
				CMFNOLDCGCL.AddForce(BONADMIGCOJ * JPNAINOGAMM * 0.2f);
			}
			else
			{
				CMFNOLDCGCL.AddForce(BONADMIGCOJ * JPNAINOGAMM * 0.05f);
			}
		}
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.PAJFENKBCLF(JHNFPPDCBDK, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	[PunRPC]
	private void LandedNetwork()
	{
		if (!OMMJAFEPEIE)
		{
			OMMJAFEPEIE = true;
			FDMNGEODNOI.material.shader = Shader.Find("Legacy Shaders/Transparent/DiffuseNew");
			DestroyPooled(3f);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		BODGIEFIPJM = Color.white;
		FDMNGEODNOI.material.SetColor("_Color", BODGIEFIPJM);
	}

	protected void ECFIMCCNBBN()
	{
		if (OMMJAFEPEIE)
		{
			BODGIEFIPJM.a -= 1299f * Time.deltaTime;
			FDMNGEODNOI.material.SetColor("ID_ACTIVATION", BODGIEFIPJM);
		}
		if (!FEHCCGEGPLH.isMine)
		{
			LADBLHGBOKJ.CJPFLJAAODD(JHNFPPDCBDK);
		}
	}

	public virtual void HFBCEMKNEJM()
	{
		base.HPPIBGEJMNL();
		BODGIEFIPJM = Color.white;
		FDMNGEODNOI.material.SetColor("VipRewardForDay", BODGIEFIPJM);
	}

	protected void NFEDNDPFHFI()
	{
		if (OMMJAFEPEIE)
		{
			BODGIEFIPJM.a -= 67f * Time.deltaTime;
			FDMNGEODNOI.material.SetColor("Tutorial_Step_Complete", BODGIEFIPJM);
		}
		if (!FEHCCGEGPLH.isMine)
		{
			LADBLHGBOKJ.CDJBEAIDHKH(JHNFPPDCBDK);
		}
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		JHNFPPDCBDK = CMFNOLDCGCL.transform;
	}

	private void MDGDJADEEML(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.KPPBDNGCALK(JHNFPPDCBDK, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void CFDOAICAMGB(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.BJNLHDHNKEF(JHNFPPDCBDK, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void OnCollisionEnter(Collision AKLHJIBDAFA)
	{
		if (!OMMJAFEPEIE)
		{
			OMMJAFEPEIE = true;
			FDMNGEODNOI.material.shader = Shader.Find("Legacy Shaders/Transparent/DiffuseNew");
			if (HDJLFLAAFHH != null)
			{
				HDJLFLAAFHH();
			}
			DestroyPooled(3f);
			FEHCCGEGPLH.RPC("LandedNetwork", PhotonTargets.Others);
		}
	}

	private void JNNHAHCGNHK()
	{
		if (FEHCCGEGPLH.isMine && !JHIPHJCMNBJ)
		{
			if (!OMMJAFEPEIE)
			{
				float num = (((int)(Time.time * 777f + GDDCMEHJABA) % 7 != 0) ? 885f : 1411f);
				Vector3 vector = Vector3.up + 325f * num * Vector3.Cross(Vector3.up, BONADMIGCOJ);
				vector.Normalize();
				float num2 = Vector3.Angle(vector, base.transform.up) / 1487f;
				Vector3 vector2 = Vector3.Cross(Vector3.up, vector) * MMOJMOKNCJC * num2;
				Vector3 torque = vector2 - CMFNOLDCGCL.angularVelocity;
				CMFNOLDCGCL.AddTorque(torque, (ForceMode)8);
				CMFNOLDCGCL.AddForce(BONADMIGCOJ * JPNAINOGAMM * 936f);
			}
			else
			{
				CMFNOLDCGCL.AddForce(BONADMIGCOJ * JPNAINOGAMM * 1542f);
			}
		}
	}
}
