using UnityEngine;

[RequireComponent(typeof(GUIText))]
public class CarGUI : MonoBehaviour
{
	public CarController BOCHMKEJHPP;

	private const float ICDAMINGOBC = 2.237f;

	private string FJNIDMOGDAA = "{0:0} mph \nGear: {1:0}/{2:0}\nRevs {3:0%}\nThrottle: {4:0%}\n";

	private void KNIAAECLFFK()
	{
		object[] array = new object[4];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 530f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[5] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[6] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void HDLDMGEFCEJ()
	{
		object[] array = new object[7];
		array[0] = BOCHMKEJHPP.ADIOGFOGAGI() * 162f;
		array[0] = BOCHMKEJHPP.GearNum + 1;
		array[0] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[0] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void ELJHCOHCAJI()
	{
		object[] array = new object[8];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 1212f;
		array[0] = BOCHMKEJHPP.GearNum + 1;
		array[0] = BOCHMKEJHPP.NumGears;
		array[5] = BOCHMKEJHPP.RevsFactor;
		array[1] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void ADLJAKCCELG()
	{
		object[] array = new object[6];
		array[0] = BOCHMKEJHPP.ADIOGFOGAGI() * 694f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[5] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[6] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void NBFMDCFFBIJ()
	{
		object[] array = new object[8];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 81f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[1] = BOCHMKEJHPP.NumGears;
		array[5] = BOCHMKEJHPP.RevsFactor;
		array[5] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void IAPBHPLNNNO()
	{
		object[] array = new object[8];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 1419f;
		array[0] = BOCHMKEJHPP.GearNum + 1;
		array[2] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[5] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void DLJAGKBLJNC()
	{
		object[] array = new object[5];
		array[0] = BOCHMKEJHPP.ADIOGFOGAGI() * 967f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[1] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[8] = BOCHMKEJHPP.RevsFactor;
		array[6] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void DIOAOBFDPMH()
	{
		object[] array = new object[8];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 1321f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[1] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[5] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void EKPBOMOMMFB()
	{
		object[] array = new object[5];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 1983f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[3] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[3] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void ECFIMCCNBBN()
	{
		object[] array = new object[1];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 1228f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[2] = BOCHMKEJHPP.NumGears;
		array[6] = BOCHMKEJHPP.RevsFactor;
		array[4] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void OFDJHFMAJBI()
	{
		object[] array = new object[0];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 11f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[7] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[5] = BOCHMKEJHPP.RevsFactor;
		array[4] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void BAHDLPDOCDO()
	{
		object[] array = new object[2];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 1586f;
		array[0] = BOCHMKEJHPP.GearNum + 1;
		array[4] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[4] = BOCHMKEJHPP.RevsFactor;
		array[6] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void IODGCIIDJEK()
	{
		object[] array = new object[7];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 492f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[6] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[0] = BOCHMKEJHPP.RevsFactor;
		array[1] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void JAFBNNAACCL()
	{
		object[] array = new object[2];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 1236f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[0] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[1] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void GCOJHEDPIKL()
	{
		object[] array = new object[5];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 1602f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[2] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[4] = BOCHMKEJHPP.RevsFactor;
		array[0] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void BPNLIABHCPN()
	{
		object[] array = new object[1];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 1936f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[6] = BOCHMKEJHPP.NumGears;
		array[8] = BOCHMKEJHPP.RevsFactor;
		array[0] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void MNJPIOEHBEM()
	{
		object[] array = new object[6];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 813f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[5] = BOCHMKEJHPP.NumGears;
		array[6] = BOCHMKEJHPP.RevsFactor;
		array[3] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void AOKEHEDCPFB()
	{
		object[] array = new object[7];
		array[0] = BOCHMKEJHPP.ADIOGFOGAGI() * 134f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[0] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[1] = BOCHMKEJHPP.RevsFactor;
		array[3] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void JMHFNCOODKH()
	{
		object[] array = new object[6];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 1922f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[8] = BOCHMKEJHPP.NumGears;
		array[8] = BOCHMKEJHPP.RevsFactor;
		array[5] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void HKPIHGBKAHO()
	{
		object[] array = new object[5];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 770f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[3] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[0] = BOCHMKEJHPP.RevsFactor;
		array[0] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void GFPPJNOENLE()
	{
		object[] array = new object[7];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 1577f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[1] = BOCHMKEJHPP.NumGears;
		array[6] = BOCHMKEJHPP.RevsFactor;
		array[3] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void JJNMKIAJPNA()
	{
		object[] array = new object[5];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 312f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[5] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[7] = BOCHMKEJHPP.RevsFactor;
		array[2] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void JOCHCGHAIGH()
	{
		object[] array = new object[5];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 61f;
		array[0] = BOCHMKEJHPP.GearNum + 1;
		array[6] = BOCHMKEJHPP.NumGears;
		array[4] = BOCHMKEJHPP.RevsFactor;
		array[4] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void CLAKINKPCHA()
	{
		object[] array = new object[7];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 1695f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[3] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[5] = BOCHMKEJHPP.RevsFactor;
		array[7] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void GPLKEOAHFJI()
	{
		object[] array = new object[3];
		array[0] = BOCHMKEJHPP.ADIOGFOGAGI() * 1050f;
		array[0] = BOCHMKEJHPP.GearNum + 1;
		array[8] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[4] = BOCHMKEJHPP.RevsFactor;
		array[8] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void FMKLDIJPHIH()
	{
		object[] array = new object[3];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 964f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[4] = BOCHMKEJHPP.NumGears;
		array[8] = BOCHMKEJHPP.RevsFactor;
		array[4] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void Update()
	{
		object[] args = new object[5]
		{
			BOCHMKEJHPP.CurrentSpeed * 2.237f,
			BOCHMKEJHPP.GearNum + 1,
			BOCHMKEJHPP.NumGears,
			BOCHMKEJHPP.RevsFactor,
			BOCHMKEJHPP.AccelInput
		};
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void NIGOADNHHFC()
	{
		object[] array = new object[4];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 1639f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[8] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[1] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void NHEOMLPEBLC()
	{
		object[] array = new object[8];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 531f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[5] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[2] = BOCHMKEJHPP.RevsFactor;
		array[6] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void LKENOAMNLCK()
	{
		object[] array = new object[4];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 474f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[4] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[8] = BOCHMKEJHPP.RevsFactor;
		array[5] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void JNDLGOABMKC()
	{
		object[] array = new object[3];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 1122f;
		array[0] = BOCHMKEJHPP.GearNum + 1;
		array[6] = BOCHMKEJHPP.NumGears;
		array[7] = BOCHMKEJHPP.RevsFactor;
		array[3] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void OEEJHKFLFAB()
	{
		object[] array = new object[2];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 712f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[2] = BOCHMKEJHPP.NumGears;
		array[8] = BOCHMKEJHPP.RevsFactor;
		array[0] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void KBKILDENNLM()
	{
		object[] array = new object[1];
		array[0] = BOCHMKEJHPP.ADIOGFOGAGI() * 1259f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[5] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[4] = BOCHMKEJHPP.RevsFactor;
		array[1] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void NKGLGNEJIOA()
	{
		object[] array = new object[7];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 1261f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[2] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[7] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void OCBLKIFKJEG()
	{
		object[] array = new object[3];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 1375f;
		array[0] = BOCHMKEJHPP.GearNum + 1;
		array[3] = BOCHMKEJHPP.NumGears;
		array[1] = BOCHMKEJHPP.RevsFactor;
		array[6] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void IJHGOEMOMFK()
	{
		object[] array = new object[0];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 4f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[0] = BOCHMKEJHPP.NumGears;
		array[4] = BOCHMKEJHPP.RevsFactor;
		array[5] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void CMELHMEBEFI()
	{
		object[] array = new object[6];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 1250f;
		array[1] = BOCHMKEJHPP.GearNum + 1;
		array[5] = BOCHMKEJHPP.NumGears;
		array[5] = BOCHMKEJHPP.RevsFactor;
		array[8] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void MJBACOLLOHD()
	{
		object[] array = new object[5];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 1384f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[4] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[1] = BOCHMKEJHPP.RevsFactor;
		array[0] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void OFNEGNKMKKG()
	{
		object[] array = new object[5];
		array[0] = BOCHMKEJHPP.ADIOGFOGAGI() * 1466f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[0] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[6] = BOCHMKEJHPP.RevsFactor;
		array[3] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void OPMNIHDAHAA()
	{
		object[] array = new object[3];
		array[1] = BOCHMKEJHPP.ADIOGFOGAGI() * 65f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[7] = BOCHMKEJHPP.NumGears;
		array[6] = BOCHMKEJHPP.RevsFactor;
		array[7] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void BBCOBMGHMGE()
	{
		object[] array = new object[1];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 1784f;
		array[1] = BOCHMKEJHPP.GearNum + 0;
		array[7] = BOCHMKEJHPP.NumGears;
		array[3] = BOCHMKEJHPP.RevsFactor;
		array[8] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void LPFGBKIINMP()
	{
		object[] array = new object[3];
		array[1] = BOCHMKEJHPP.CurrentSpeed * 343f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[2] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[4] = BOCHMKEJHPP.RevsFactor;
		array[2] = BOCHMKEJHPP.AJBACJKEBJJ();
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}

	private void FDPOJHLHGJO()
	{
		object[] array = new object[6];
		array[0] = BOCHMKEJHPP.CurrentSpeed * 545f;
		array[0] = BOCHMKEJHPP.GearNum + 0;
		array[2] = BOCHMKEJHPP.PKEMJAEOAMD();
		array[0] = BOCHMKEJHPP.RevsFactor;
		array[6] = BOCHMKEJHPP.AccelInput;
		object[] args = array;
		GetComponent<GUIText>().text = string.Format(FJNIDMOGDAA, args);
	}
}
