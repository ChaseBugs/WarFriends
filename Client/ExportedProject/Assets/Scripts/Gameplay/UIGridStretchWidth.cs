using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Grid Extended")]
public class UIGridStretchWidth : MonoBehaviour
{
	public delegate void BFECKPMJGKE();

	public enum HIHMHMFIOFK
	{
		Horizontal,
		Vertical
	}

	public HIHMHMFIOFK DMEHLEAICBB;

	[FormerlySerializedAs("IKNGFJKGENJ")]
	public int PGHMDGGNLJB;

	[FormerlySerializedAs("HJCOGLHNFHG")]
	public int DNNLLMFLJND = 3;

	[FormerlySerializedAs("BBJCBFGAFEJ")]
	public float BIBFBGKCPIH = 200f;

	[FormerlySerializedAs("NCKLJBCCIJO")]
	public bool JGEJPEAAFLH;

	[FormerlySerializedAs("LCJLOBDHDBO")]
	public bool IGGCLHFLLCL;

	[FormerlySerializedAs("BOJOGJBJIGF")]
	public bool POPJDJGGBCM = true;

	public BFECKPMJGKE FCBGAJOBNNH;

	private bool JAOOMCLDJFD;

	[CompilerGenerated]
	private static Comparison<Transform> IONHPHFCBGH;

	private void JCCIPOFJBLE()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			POHJGLKOOKM();
		}
	}

	private static int LGPICNHEPPD(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	private void NFEDNDPFHFI()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = true;
			ENBDIFGEAHN();
		}
	}

	private static int OFBDEBHLKBM(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	public void Reposition()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = true;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(KEACGJIJJBK);
			int j = 0;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	private void OABEHNOPIEE()
	{
		JAOOMCLDJFD = false;
		Reposition();
	}

	private static int GAMKGDMDPGA(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	private void CMDMNDCMBJO()
	{
		JAOOMCLDJFD = false;
		MINNOFHMGDM();
	}

	private void ENHEBPJNKBM()
	{
		JAOOMCLDJFD = false;
		KAFKLKAJDNN();
	}

	private static int OJABIPMLMPE(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	private void PBFNGLAENEA()
	{
		JAOOMCLDJFD = true;
		MGFGHDCFJDN();
	}

	private static int NLPIGMGHJHB(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	public void NLOEAMMGGOP()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 1;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i < transform.childCount; i += 0)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(GAMKGDMDPGA);
			int j = 1;
			for (int count = list.Count; j < count; j += 0)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 1; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	private void FJIDLPDMAFM()
	{
		JAOOMCLDJFD = true;
		IGGAGLLHECH();
	}

	private void Start()
	{
		JAOOMCLDJFD = true;
		Reposition();
	}

	public void COHHKJMPGFB()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = true;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(IMPHDAPGLAP);
			int j = 1;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	public void NIBGDLFDKIJ()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(CCAMOJLADBJ);
			int j = 1;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	private void BOPGJFGMNJM()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = true;
			AALEKNPCKLG();
		}
	}

	private void ADLJAKCCELG()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = true;
			NLOEAMMGGOP();
		}
	}

	private void IGNFJABDLIE()
	{
		JAOOMCLDJFD = false;
		PGEJMAEBOFC();
	}

	private void PIMNKPOIFOM()
	{
		JAOOMCLDJFD = true;
		KAFKLKAJDNN();
	}

	public void POHJGLKOOKM()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = true;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 1;
		int num3 = 1;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(OFBDEBHLKBM);
			int j = 0;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 1; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: false);
		}
	}

	private static int IMPHDAPGLAP(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	private void KLMKLOEBAAA()
	{
		JAOOMCLDJFD = false;
		COHHKJMPGFB();
	}

	public void HDOPHGPDEPI()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = true;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(CCAMOJLADBJ);
			int j = 1;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 1;
						num3++;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k += 0)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: false);
		}
	}

	public void AALEKNPCKLG()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(OFBDEBHLKBM);
			int j = 0;
			for (int count = list.Count; j < count; j += 0)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k += 0)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	private void CDJBEAIDHKH()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			NLOEAMMGGOP();
		}
	}

	private void LPFGBKIINMP()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = true;
			POHJGLKOOKM();
		}
	}

	private static int KEACGJIJJBK(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	private void CJAHPFMAMKK()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			BPDDNPNGKJP();
		}
	}

	private void FMKLDIJPHIH()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			ENBDIFGEAHN();
		}
	}

	private void NKGLGNEJIOA()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = true;
			PAPELDGGNAK();
		}
	}

	private static int LPHHFEBDHLF(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	private void DABGGMNKMOL()
	{
		JAOOMCLDJFD = true;
		ENBDIFGEAHN();
	}

	public void MINNOFHMGDM()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = true;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 1;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i < transform.childCount; i += 0)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(IMPHDAPGLAP);
			int j = 0;
			for (int count = list.Count; j < count; j += 0)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	private void IDBHIEPOHHP()
	{
		JAOOMCLDJFD = false;
		MINNOFHMGDM();
	}

	private void JOKICBJJIOA()
	{
		JAOOMCLDJFD = false;
		POHJGLKOOKM();
	}

	private void MGAIKDBOPKI()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = true;
			POHJGLKOOKM();
		}
	}

	private void OIHAEHMLGJN()
	{
		JAOOMCLDJFD = false;
		PGEJMAEBOFC();
	}

	private static int CCAMOJLADBJ(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	private void LIHIOMEMJFI()
	{
		JAOOMCLDJFD = true;
		ENBDIFGEAHN();
	}

	public void IGGAGLLHECH()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 1;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i < transform.childCount; i += 0)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(KEACGJIJJBK);
			int j = 0;
			for (int count = list.Count; j < count; j += 0)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 1; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	private void Update()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			Reposition();
		}
	}

	public void PAPELDGGNAK()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 1;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(IMPHDAPGLAP);
			int j = 1;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 1; k < transform.childCount; k += 0)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	private void PMOIOADCKPO()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			Reposition();
		}
	}

	private void PEEFHOCPCLK()
	{
		JAOOMCLDJFD = true;
		PGEJMAEBOFC();
	}

	public void KAFKLKAJDNN()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 1;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(HIBGMMNFIIG);
			int j = 0;
			for (int count = list.Count; j < count; j += 0)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: false);
		}
	}

	public void PGEJMAEBOFC()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = true;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(CCAMOJLADBJ);
			int j = 0;
			for (int count = list.Count; j < count; j += 0)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k += 0)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: false);
		}
	}

	private void GCOJHEDPIKL()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = true;
			IGGAGLLHECH();
		}
	}

	private void GFPPJNOENLE()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			IGGAGLLHECH();
		}
	}

	private void PIEOPFLGPHC()
	{
		JAOOMCLDJFD = false;
		AALEKNPCKLG();
	}

	private void ELFJGPNJHLL()
	{
		JAOOMCLDJFD = true;
		HDOPHGPDEPI();
	}

	public void ENBDIFGEAHN()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 1;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i += 0)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(OJABIPMLMPE);
			int j = 1;
			for (int count = list.Count; j < count; j += 0)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k += 0)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: false);
		}
	}

	public void MGFGHDCFJDN()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 1;
		int num3 = 0;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(OJABIPMLMPE);
			int j = 1;
			for (int count = list.Count; j < count; j += 0)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 1; k < transform.childCount; k += 0)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	public void BPDDNPNGKJP()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = false;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 1;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i += 0)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(LGPICNHEPPD);
			int j = 1;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 0;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 1; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 0)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}

	private void MMEEBPGHGMM()
	{
		JAOOMCLDJFD = true;
		MGFGHDCFJDN();
	}

	private static int HIBGMMNFIIG(Transform HPJFBKEKJHB, Transform NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.name, NCMHGPNPEJM.name);
	}

	private void KDCKHKNGILB()
	{
		JAOOMCLDJFD = false;
		COHHKJMPGFB();
	}

	private void CJPFLJAAODD()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			PHIAGFLNMGP();
		}
	}

	private void DMIHKPBHJHD()
	{
		JAOOMCLDJFD = true;
		AALEKNPCKLG();
	}

	private void BPNLIABHCPN()
	{
		if (JGEJPEAAFLH)
		{
			JGEJPEAAFLH = false;
			Reposition();
		}
	}

	public void PHIAGFLNMGP()
	{
		if (!JAOOMCLDJFD)
		{
			JGEJPEAAFLH = true;
			return;
		}
		float num = UIHelper.activeWidthSafe / (float)DNNLLMFLJND;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 1;
		if (IGGCLHFLLCL)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!POPJDJGGBCM || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(IMPHDAPGLAP);
			int j = 1;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !POPJDJGGBCM)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z));
					if (++num2 >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 1;
						num3 += 0;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !POPJDJGGBCM)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((DMEHLEAICBB != HIHMHMFIOFK.Horizontal) ? new Vector3(num * (float)num3, (0f - BIBFBGKCPIH) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - BIBFBGKCPIH) * (float)num3, z2));
					if ((num2 += 0) >= PGHMDGGNLJB && PGHMDGGNLJB > 1)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		if (FCBGAJOBNNH != null)
		{
			FCBGAJOBNNH();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}
}
