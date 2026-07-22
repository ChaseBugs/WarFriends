using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMinigunWeaponMotor : MonoBehaviour
{
	private enum JLANLLEABDC
	{
		Stopped,
		Starting,
		Looping,
		Stopping
	}

	[FormerlySerializedAs("GOPCBOLEBIK")]
	public AudioSource COLIBDBBBEI;

	[FormerlySerializedAs("MOACPNMGNOP")]
	public AudioClip DPIPDFNFPGC;

	[FormerlySerializedAs("GFAJLKCGMLG")]
	public AudioClip FAGEDJLLGEB;

	[FormerlySerializedAs("NOOFBNEKPCJ")]
	public AudioClip CHMOALEHEHB;

	private JLANLLEABDC DAHCKIBAPFP;

	public void ILKMEABFMFA()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)5)
		{
			DAHCKIBAPFP = (JLANLLEABDC)7;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void GBEDFIAHCDH()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Looping;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void CPGEEOLCIDI()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == (JLANLLEABDC)5)
		{
			DAHCKIBAPFP = (JLANLLEABDC)8;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void PPAEELEJNEA()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)4)
		{
			DAHCKIBAPFP = JLANLLEABDC.Starting;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void OJJDAHPODCM()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == (JLANLLEABDC)4)
		{
			DAHCKIBAPFP = (JLANLLEABDC)7;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void HMLDFHLNLOA()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Starting)
		{
			DAHCKIBAPFP = (JLANLLEABDC)7;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void LKENOAMNLCK()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void AKMGJDNMINM()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)5)
		{
			DAHCKIBAPFP = (JLANLLEABDC)8;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void IBECLBJHNMK()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = true;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void KGHCCBJDFMF()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)4)
		{
			DAHCKIBAPFP = (JLANLLEABDC)4;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void JMHFNCOODKH()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)6;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void FBNOGAFKNLF()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)7)
		{
			DAHCKIBAPFP = JLANLLEABDC.Stopping;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void BHIABNNGKFO()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopping;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	private void OOCJOBIIKAH()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	private void CFLALBENGJN()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)4;
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void IENMEJJHBHK()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == (JLANLLEABDC)8)
		{
			DAHCKIBAPFP = (JLANLLEABDC)8;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void DEBGBGGOCEN()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)5;
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	private void EMFLLHFPOOB()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void IKOFFMLADDF()
	{
		DAHCKIBAPFP = JLANLLEABDC.Stopped;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void JHKLGINCKLA()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = true;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void CMAFIGDAAMP()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Stopping)
		{
			DAHCKIBAPFP = JLANLLEABDC.Stopped;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void OCDCKLEABBL()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	private void BOEMHLPLOGA()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)6;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void BDMFMABNMGM()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == (JLANLLEABDC)6)
		{
			DAHCKIBAPFP = (JLANLLEABDC)7;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void COHCBKJKODF()
	{
		DAHCKIBAPFP = JLANLLEABDC.Stopped;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void FGHICIGMJLC()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)7)
		{
			DAHCKIBAPFP = (JLANLLEABDC)4;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void DKCBEMFHECB()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	private void CHHKMBGOMJJ()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void OAMHNMNBHJP()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)8)
		{
			DAHCKIBAPFP = JLANLLEABDC.Stopped;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void DGBEDIMLHOL()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void OIGMCHHEDCP()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)8)
		{
			DAHCKIBAPFP = (JLANLLEABDC)8;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void DFBPBGDJKOG()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)5;
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void JBINIJKODEP()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Looping)
		{
			DAHCKIBAPFP = JLANLLEABDC.Starting;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void FBFFLKAJOOI()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == (JLANLLEABDC)7)
		{
			DAHCKIBAPFP = JLANLLEABDC.Looping;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void NFEDNDPFHFI()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void HKCNCBALALA()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Stopping)
		{
			DAHCKIBAPFP = JLANLLEABDC.Starting;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void KDEEEHEECNG()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void IOKCCAMBIIJ()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = true;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void BEDIMDNIAKE()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void ANPADJGNJMD()
	{
		DAHCKIBAPFP = JLANLLEABDC.Stopped;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	private void CMELHMEBEFI()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)7;
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	private void IJHGOEMOMFK()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)7;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void BLLMEEEMIKB()
	{
		DAHCKIBAPFP = JLANLLEABDC.Stopped;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void LKJDDFFBILK()
	{
		DAHCKIBAPFP = JLANLLEABDC.Stopped;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void MEBPNHAKEGG()
	{
		DAHCKIBAPFP = JLANLLEABDC.Stopped;
		COLIBDBBBEI.loop = true;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void EHIMIMINNAG()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == JLANLLEABDC.Stopping)
		{
			DAHCKIBAPFP = JLANLLEABDC.Looping;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void HPPIOJEHNPN()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)7)
		{
			DAHCKIBAPFP = (JLANLLEABDC)7;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void DEAOABDOHDC()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)4;
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void AFDDNOHEEFE()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Stopping)
		{
			DAHCKIBAPFP = (JLANLLEABDC)5;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void GIHHCAHBHGG()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void IECINBCJDBO()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = true;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void HGLMMMNDMHN()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = true;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void EDBMIMOIFKK()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Stopping)
		{
			DAHCKIBAPFP = (JLANLLEABDC)4;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void CLAKINKPCHA()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)5;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	private void PKPIMPKNFJJ()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)8;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	private void PMOIOADCKPO()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)7;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void BBHBLODFPDL()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = true;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	private void FGECFIBLFMD()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = (JLANLLEABDC)8;
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void StopMotor()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Looping)
		{
			DAHCKIBAPFP = JLANLLEABDC.Stopping;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void LLCNHAPEMBF()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == (JLANLLEABDC)8)
		{
			DAHCKIBAPFP = (JLANLLEABDC)8;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void HDOAKJKDBIK()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == (JLANLLEABDC)8)
		{
			DAHCKIBAPFP = JLANLLEABDC.Stopping;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void DLJAGKBLJNC()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Starting;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void EFLMPEIPBCG()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)7)
		{
			DAHCKIBAPFP = (JLANLLEABDC)4;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void LAMKGOLNCJL()
	{
		DAHCKIBAPFP = JLANLLEABDC.Stopped;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void MPCOHBCBFPN()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)5)
		{
			DAHCKIBAPFP = (JLANLLEABDC)4;
			COLIBDBBBEI.loop = true;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void KJPDGBNDOEF()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = true;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void EHNCMECPGGI()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)7)
		{
			DAHCKIBAPFP = (JLANLLEABDC)8;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void JPAGPGNOOHG()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Looping)
		{
			DAHCKIBAPFP = JLANLLEABDC.Stopping;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void FPAGPLLJHCD()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Starting || DAHCKIBAPFP == JLANLLEABDC.Looping)
		{
			DAHCKIBAPFP = JLANLLEABDC.Looping;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	public void StartMotor()
	{
		DAHCKIBAPFP = JLANLLEABDC.Starting;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}

	public void HJMNFGHOPBM()
	{
		if (DAHCKIBAPFP == JLANLLEABDC.Stopped || DAHCKIBAPFP == (JLANLLEABDC)5)
		{
			DAHCKIBAPFP = JLANLLEABDC.Looping;
			COLIBDBBBEI.loop = false;
			COLIBDBBBEI.clip = CHMOALEHEHB;
			COLIBDBBBEI.Play();
		}
	}

	private void Update()
	{
		switch (DAHCKIBAPFP)
		{
		case JLANLLEABDC.Stopped:
			break;
		case JLANLLEABDC.Starting:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Looping;
				COLIBDBBBEI.loop = true;
				COLIBDBBBEI.clip = FAGEDJLLGEB;
				COLIBDBBBEI.Play();
			}
			break;
		case JLANLLEABDC.Looping:
			break;
		case JLANLLEABDC.Stopping:
			if (!COLIBDBBBEI.isPlaying)
			{
				DAHCKIBAPFP = JLANLLEABDC.Stopped;
				COLIBDBBBEI.Stop();
				COLIBDBBBEI.loop = false;
				COLIBDBBBEI.clip = null;
			}
			break;
		}
	}

	public void BBHKPMJMJMJ()
	{
		DAHCKIBAPFP = JLANLLEABDC.Stopped;
		COLIBDBBBEI.loop = false;
		COLIBDBBBEI.clip = DPIPDFNFPGC;
		COLIBDBBBEI.Play();
	}
}
