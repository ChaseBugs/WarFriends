using Newtonsoft.Json.Linq;
using UnityEngine;

public class WarArenaRule : ScriptableObject
{
	public enum JBIICBEMIAA
	{
		FulFill,
		DoesNotMeet,
		InfoRule,
		InfoText,
		EqualHint
	}

	public class HIBLLEGMMEM
	{
		public JBIICBEMIAA JFACCKJNHHC;

		public string BALEOFOKIOC;

		public string NNHNNPFNHCI;

		public string GMGMGBIAPIP;

		public string IMKHCJLBMFI => null;

		public HIBLLEGMMEM()
		{
		}

		public HIBLLEGMMEM(string IMEKNNJAOJH, JBIICBEMIAA FCKCLLNOKFO = JBIICBEMIAA.InfoRule)
		{
		}

		public HIBLLEGMMEM(string IMEKNNJAOJH, string HGIDMCDLMGD, string DBGJFKDKHEH, JBIICBEMIAA FCKCLLNOKFO)
		{
		}
	}

	public virtual bool UseRuntimeParameters => false;

	public HIBLLEGMMEM guiRule => null;

	public virtual string CDENDOMBCFJ()
	{
		return null;
	}

	public virtual RuleData AGIAIJCEAOK()
	{
		return null;
	}

	public virtual void IAGFCKIBMIA(JToken HHDCBKDKICG)
	{
	}

	public virtual void BMDEHIIDPEO()
	{
	}

	public virtual bool JPBAMFLFLFA()
	{
		return false;
	}

	public virtual void EJNLCODCGBA()
	{
	}

	public virtual object[] JBFIDDLDEJI()
	{
		return null;
	}

	public virtual void FMNGBDBPGPI(object[] OLEGNKELNEA)
	{
	}

	protected virtual HIBLLEGMMEM ENNBBKNEMBH()
	{
		return null;
	}

	public virtual void ECGLNFGFDHI(GameControllerWarArena DDEJOBGOOBF)
	{
	}
}
