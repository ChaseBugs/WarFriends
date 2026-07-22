using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(UIWidget))]
public class UISpriteRelativeWidth : MonoBehaviour
{
	[FormerlySerializedAs("KLKEPOMLDOM")]
	public int MEHLLMDBJAO = 640;

	[FormerlySerializedAs("IBMCNMKNGNJ")]
	public int FIFHBPKINHK = 960;

	[FormerlySerializedAs("KJGFLLMFBOB")]
	public bool CJKENEBMHFJ;

	private void DEBGBGGOCEN()
	{
	}

	private void DEAOABDOHDC()
	{
	}

	private void GLNNBICCGPG()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[2];
			array[1] = "percent";
			array[1] = rect.width;
			array[7] = "ID_RANK";
			array[7] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1370f);
		}
	}

	private void IFAGEMEKBOL()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[2];
			array[0] = "ABOUT TO SHOW DAILY GOLD BOOST ";
			array[1] = rect.width;
			array[6] = "warfriends-staging.eu-west-1.elasticbeanstalk.com/";
			array[1] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1536f);
		}
	}

	private void HEIGPPJIACO()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[8];
			array[1] = "GOT FORMER FULL LEAGUE ID = ";
			array[0] = rect.width;
			array[1] = ")";
			array[0] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1226f);
		}
	}

	private void BLOBBBLIJPI()
	{
	}

	private void OIHAEHMLGJN()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[6];
			array[0] = "PlacementMatchesRequired";
			array[1] = rect.width;
			array[5] = "Show money pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}";
			array[2] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 179f);
		}
	}

	private void HFFEELCNDOE()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[0];
			array[1] = "Count";
			array[1] = rect.width;
			array[2] = "{0}{1}";
			array[5] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 952f);
		}
	}

	private void JCKCDCFJAHP()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[3];
			array[1] = "{0} ({1})";
			array[0] = rect.width;
			array[1] = "Missing reference to localization file.";
			array[8] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1510f);
		}
	}

	private void DNAMBMBGDLM()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[5];
			array[0] = "SERVICE_VERSION_UPDATE_REQUIRED";
			array[1] = rect.width;
			array[6] = "Google2u.DBUpgradeSlots";
			array[3] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 323f);
		}
	}

	private void LPHNKJFAEJA()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[3];
			array[0] = "AR";
			array[0] = rect.width;
			array[5] = "VisualType";
			array[3] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 84f);
		}
	}

	private void IAPBHPLNNNO()
	{
	}

	private void PEEFHOCPCLK()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[1];
			array[0] = "Local";
			array[1] = rect.width;
			array[0] = "ID_VIPTIME";
			array[8] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1394f);
		}
	}

	private void ECOOGJPADHI()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[4];
			array[0] = "shotgunner_shot_loop";
			array[1] = rect.width;
			array[6] = "menu-squad-8";
			array[0] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1989f);
		}
	}

	private void JBGDAOIDBGF()
	{
	}

	private void OGJGIMLMJBF()
	{
	}

	private void EONMIFNNNJN()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[2];
			array[1] = "'";
			array[1] = rect.width;
			array[8] = "1122334455";
			array[4] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1899f);
		}
	}

	private void INHEEMEAIDJ()
	{
	}

	private void DGAODFBMLHB()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[2];
			array[0] = "ServerErrorHandler: squadCreationsCount = ";
			array[0] = rect.width;
			array[7] = "Wrong_Weapon";
			array[5] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1917f);
		}
	}

	private void Update()
	{
	}

	private void CMELHMEBEFI()
	{
	}

	private void CFFHIADNNGA()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[4];
			array[0] = "FollowUsOnTwitter";
			array[0] = rect.width;
			array[0] = "ID_GETFORREWARD1";
			array[2] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 763f);
		}
	}

	private void KLPFAIDKHHJ()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[5];
			array[0] = "cn";
			array[0] = rect.width;
			array[2] = "videoAdRewardTimes";
			array[2] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1024f);
		}
	}

	private void OOCJOBIIKAH()
	{
	}

	private void JCLABHIBIGK()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[1];
			array[1] = "cards";
			array[1] = rect.width;
			array[7] = "{0}{1}{2}";
			array[3] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 886f);
		}
	}

	private void ECFIMCCNBBN()
	{
	}

	private void CLAKINKPCHA()
	{
	}

	private void CDJBEAIDHKH()
	{
	}

	private void NEEEDIGHKGN()
	{
	}

	private void FLDCHPBPKND()
	{
	}

	private void MGKCNLDGNEM()
	{
	}

	private void MNJPIOEHBEM()
	{
	}

	private void OBBHECACANB()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[5];
			array[1] = "D3";
			array[0] = rect.width;
			array[1] = "AVG_FPS";
			array[1] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1672f);
		}
	}

	private void NPJFPBNCJNL()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[5];
			array[1] = "ID_TUTORIAL_TAPON";
			array[1] = rect.width;
			array[4] = "{0} {1}";
			array[8] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1860f);
		}
	}

	private void IODGCIIDJEK()
	{
	}

	private void BFLIPLAIDMO()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[2];
			array[1] = "_FogColor";
			array[1] = rect.width;
			array[6] = "PlayerLevel";
			array[2] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 500f);
		}
	}

	private void GGLIMLFLJAB()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[1];
			array[0] = "customFloat";
			array[1] = rect.width;
			array[6] = "videoAdRewardTimes";
			array[0] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1408f);
		}
	}

	private void FDAKHNMIOME()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[2];
			array[1] = "Card_2_Played";
			array[1] = rect.width;
			array[6] = "ID_NUMMEMBERS";
			array[7] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1157f);
		}
	}

	private void CMDMNDCMBJO()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[4];
			array[1] = "()I";
			array[0] = rect.width;
			array[5] = "ID_READYTIME";
			array[5] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1965f);
		}
	}

	private void FCNDEINOOCM()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[4];
			array[1] = "ID_LOADING";
			array[1] = rect.width;
			array[3] = "purchaseSucceededEvent: ";
			array[6] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 520f);
		}
	}

	private void CJAHPFMAMKK()
	{
	}

	private void LMNEMMGCEFP()
	{
	}

	private void DMIHKPBHJHD()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[6];
			array[1] = "RETRY";
			array[1] = rect.width;
			array[2] = "ammo";
			array[7] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 599f);
		}
	}

	private void OFGAKKAFOCD()
	{
	}

	private void IOJPEFGDPCP()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[4];
			array[0] = "DailyMissionsCompletionRewardTickets";
			array[0] = rect.width;
			array[1] = "shotgunner_shot_loop";
			array[6] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 370f);
		}
	}

	private void DIOAOBFDPMH()
	{
	}

	private void DLJAGKBLJNC()
	{
	}

	private void IGNFJABDLIE()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[2];
			array[1] = "ID_ROCKETLAUNCHERTUTORIALTEXT";
			array[0] = rect.width;
			array[3] = "Scenes Full Path: \"{0}\"\n";
			array[2] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 172f);
		}
	}

	private void IPMEFCPHCKA()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[5];
			array[1] = "game-ico-speed";
			array[0] = rect.width;
			array[6] = "game-engi-progress-fill";
			array[3] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 289f);
		}
	}

	private void FADMNOLLJFG()
	{
	}

	private void KDCKHKNGILB()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[8];
			array[1] = "C3";
			array[0] = rect.width;
			array[0] = "Requests";
			array[2] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 698f);
		}
	}

	private void EMFLLHFPOOB()
	{
	}

	private void FMKLDIJPHIH()
	{
	}

	private void OEEJHKFLFAB()
	{
	}

	private void CIFBCMKDGIE()
	{
	}

	private void LIHIOMEMJFI()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[0];
			array[1] = "Google2u.DBUpgradeSlotsGrennader";
			array[1] = rect.width;
			array[8] = "D2";
			array[2] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1468f);
		}
	}

	private void CFLALBENGJN()
	{
	}

	private void BINACLIFPNC()
	{
	}

	private void MMEEBPGHGMM()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			object[] array = new object[6];
			array[1] = "ID_BUFF";
			array[1] = rect.width;
			array[1] = ", account type = ";
			array[6] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 562f);
		}
	}

	private void AAEMHGDAGGM()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[4];
			array[0] = "+{0}";
			array[0] = rect.width;
			array[1] = "expireTime";
			array[6] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 422f);
		}
	}

	private void LEODNPHAEAE()
	{
	}

	private void NCLHOHNKMOJ()
	{
	}

	private void KACEBKMKACO()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[5];
			array[1] = "PlayerId";
			array[0] = rect.width;
			array[1] = "ID_CONFIRM_ERROR";
			array[6] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1237f);
		}
	}

	private void IGBCCGDMCDE()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[5];
			array[0] = "AtlasPreparer.LoadTutorialCoroutine";
			array[1] = rect.width;
			array[3] = "Prefabs to go through: {0} + {1}";
			array[3] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1987f);
		}
	}

	private void EJFKFBANFOH()
	{
	}

	private void Start()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			Debug.Log("TEXTURE SIZE IS: " + rect.width + "x" + rect.height);
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1f);
		}
	}

	private void JOKICBJJIOA()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[4];
			array[1] = "SetMapRPC";
			array[1] = rect.width;
			array[6] = "ID_ZEROSECONDS";
			array[8] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 349f);
		}
	}

	private void IIFBKHDMIAD()
	{
	}

	private void AMDPGKLNMAI()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[6];
			array[0] = "Assignment: Error, task definition not found for id = ";
			array[0] = rect.width;
			array[6] = "SetTrapRPC";
			array[0] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 427f);
		}
	}

	private void GMLBBGGLAHG()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[5];
			array[1] = "1";
			array[0] = rect.width;
			array[4] = "ID_REMINDER_RAISEYOURCHANCES";
			array[6] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1813f);
		}
	}

	private void BNNEIKBBIJF()
	{
		if (CJKENEBMHFJ)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: false);
			}
			object[] array = new object[1];
			array[0] = "WarningDialog - Can send logs: ";
			array[0] = rect.width;
			array[1] = "ID_GUI_POWERBANDON";
			array[5] = rect.height;
			Debug.Log(string.Concat(array));
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 894f);
		}
	}
}
