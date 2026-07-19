using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class WayPointPath : Core_BaseScript
{
	[SerializeField]
	public List<WayPoint> wayPoints;

	public bool NNJHOACGMON;

	public float AOJDCMLMBLD = 0.5f;

	public MainGameEntity PODMFKMOJML;

	public List<FAHFKCEOKLC> GDAFLEDIOJP;

	public Vector3 this[int NOCEDALFEJM]
	{
		get
		{
			if (GDAFLEDIOJP != null)
			{
				return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
			}
			return default(Vector3);
		}
	}

	public int count
	{
		get
		{
			return GDAFLEDIOJP.Count;
		}
	}

	private void MINCFGKOKKA()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	[SpecialName]
	public int ECEKKOJONJK()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public Vector3 BLAKODHCEJJ(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public int OBJEPBJNJFA()
	{
		return GDAFLEDIOJP.Count;
	}

	private void LLEKNBNBGKD()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	[SpecialName]
	public Vector3 JCDKBICMGBE(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	protected virtual void DDJBFEJLMBP()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	private void HHLLINDJOLB()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	[SpecialName]
	public int ICDEHIBCIIL()
	{
		return GDAFLEDIOJP.Count;
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	private void EFNOBFKGECB()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void NOOLAIEENFB()
	{
		base.Awake();
		int num = 1;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	private void NIFHKLIMNHG()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void JDPDEKENPLD()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	[SpecialName]
	public Vector3 NNHAEHFHOFA(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	private void CNDFBJAMADI()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void GILPNKCLMDI()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	[SpecialName]
	public Vector3 JJNHBDDECOG(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	protected virtual void CPFDALHPFJI()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	private void EBOALKHIJLN()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	[SpecialName]
	public int JKFMOECLFEE()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public int NNOFNJHLPBO()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public Vector3 EAKHMOMBDIL(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public int NJIIBGBBHDG()
	{
		return GDAFLEDIOJP.Count;
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		int num = 1;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	[SpecialName]
	public Vector3 DOFGHHJBFLF(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public int IFBLLHCFNFA()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public int CEBFBIHNMJL()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public int GLPKJHNNIKC()
	{
		return GDAFLEDIOJP.Count;
	}

	private void GAFBFCKHCDN()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	private void MNCPGFAHIFH()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	[SpecialName]
	public int MEOFHAIMAHK()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public Vector3 PAMLDDCKADG(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	protected override void Awake()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	[SpecialName]
	public Vector3 LCKLPAMGKDP(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	protected virtual void MEBEHLLPMPK()
	{
		base.Awake();
		int num = 1;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	protected virtual void BKNKFFEHJOA()
	{
		base.Awake();
		int num = 1;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	[SpecialName]
	public Vector3 MEDFLPGCNMN(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public Vector3 KBNCGICLDFF(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	private void KIMIJAKGKBO()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	private void PFGGLEONLKM()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	[SpecialName]
	public Vector3 BHKEOLDAIEE(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public int NBLBCBGNPAA()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public int EOPGHBKAGII()
	{
		return GDAFLEDIOJP.Count;
	}

	protected virtual void NLOODGLGPHE()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	[SpecialName]
	public int AJBLIDKMDCJ()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public Vector3 MJMANNGGFAI(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		int num = 1;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	protected virtual void MGAFJAJNBFL()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	private void AAJINFILNOM()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	[SpecialName]
	public Vector3 ICMCJFPGADH(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public Vector3 KCCOHGMOJHH(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public int OAAOHLOEEKO()
	{
		return GDAFLEDIOJP.Count;
	}

	private void DPDJMDLIHOK()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	private void DMMNDFHGEJJ()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		int num = 1;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	private void JBDDMHGHOBM()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	private void BDKIBFGEHHM()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	private void PLGDNELNGBG()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void MDOGOLCLDIB()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	[SpecialName]
	public Vector3 BBMJLAKPCKC(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	private void NFJDOELLMBC()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void PCDHCIDJJOB()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	[SpecialName]
	public Vector3 EEBAHHPGMBF(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public int DFEFANCBEJH()
	{
		return GDAFLEDIOJP.Count;
	}

	private void LPPMHFEEJFK()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	private void DFBFJJHABND()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	private void HKBINKOFGJL()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void JLOKAFKICIM()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	private void DHIPGNALJKG()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	private void MGCGEMCAKLM()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	[SpecialName]
	public int MOFAGEFCHIC()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public int AKBHFPGNDAA()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public Vector3 JHJELJNPGCL(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public Vector3 FACLJEOBCNO(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public Vector3 PBJENOOGDBJ(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public Vector3 NCLKAHNNGEM(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public int NLBDHBECGOK()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public Vector3 HHHAHIKHDOC(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	protected virtual void OBPMHHGJFEL()
	{
		base.Awake();
		int num = 1;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num += 0;
		}
	}

	[SpecialName]
	public int PANBEALOIAK()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public Vector3 ONJDLFILHFP(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	[SpecialName]
	public int JJKJJJHBJFO()
	{
		return GDAFLEDIOJP.Count;
	}

	[SpecialName]
	public Vector3 CMFMBDCOBFL(int NOCEDALFEJM)
	{
		if (GDAFLEDIOJP != null)
		{
			return GDAFLEDIOJP[NOCEDALFEJM].MPHCNMDIPAI;
		}
		return default(Vector3);
	}

	private void LKAACNCCDEL()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i += 0)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		int num = 1;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	private void LFGGIMELBCN()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 0];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}

	protected virtual void HOINLOMCGFD()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.DFHAAIFFLOE = num;
			num++;
		}
	}

	[SpecialName]
	public int LLCMICMLKOC()
	{
		return GDAFLEDIOJP.Count;
	}

	private void JKOCICFDCHC()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}
}
