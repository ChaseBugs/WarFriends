using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class VideoFeedManager : Core_BaseScript
{
	public class VideoFeedData
	{
		public VideoFeed[] featuredVideos = new VideoFeed[30];

		public VideoFeed[] recentVideos = new VideoFeed[30];
	}

	public class VideoFeed
	{
		public string videoName;

		public string author;

		public string service;

		public string thumbnailHD;

		public string thumbnailSD;

		public string smallThumbnailHD;

		public string smallThumbnailSD;

		public string url;

		public string textureNameHD;

		public string textureNameSD;

		public string smallTextureNameHD;

		public string smallTextureNameSD;

		public string thumbnail
		{
			get
			{
				return (!Singleton<PerformanceManager>.instance.isHD) ? thumbnailSD : thumbnailHD;
			}
		}

		public string smallThumbnail
		{
			get
			{
				return (!Singleton<PerformanceManager>.instance.isHD) ? smallThumbnailSD : smallThumbnailHD;
			}
		}

		public string iconName
		{
			get
			{
				if (service.Equals("Mobcrush"))
				{
					return "menu-wftv-mobcrush-ico";
				}
				if (service.Equals("Twitch"))
				{
					return "menu-wftv-twitch-ico";
				}
				return "menu-wftv-youtube-ico";
			}
		}

		public string textureName
		{
			get
			{
				return (!Singleton<PerformanceManager>.instance.isHD) ? textureNameSD : textureNameHD;
			}
		}

		public string smallTextureName
		{
			get
			{
				return (!Singleton<PerformanceManager>.instance.isHD) ? smallTextureNameSD : smallTextureNameHD;
			}
		}

		public string debugString
		{
			get
			{
				return string.Format("Video {0} service {1} thumbnail {2}", videoName, service, thumbnail);
			}
		}
	}

	private static VideoFeedManager BJHPKLAEFCI;

	private int OMFIOHBBJKH;

	private int KFBHMAHIMCJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<string> NJOLDJBFLCM;

	public VideoFeedData videoFeeds { get; private set; }

	public static VideoFeedManager instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? ((VideoFeedManager)UnityEngine.Object.FindObjectsOfType(typeof(VideoFeedManager))[0]);
			return BJHPKLAEFCI;
		}
	}

	public bool showVideoFeedFeature
	{
		get
		{
			if (OMFIOHBBJKH != 0)
			{
				return OMFIOHBBJKH > 0;
			}
			if (videoFeeds.featuredVideos != null && videoFeeds.featuredVideos.Length > 0 && videoFeeds.featuredVideos[0] != null && videoFeeds.recentVideos != null && videoFeeds.recentVideos.Length > 0 && videoFeeds.recentVideos[0] != null)
			{
				OMFIOHBBJKH = 1;
				return true;
			}
			OMFIOHBBJKH = -1;
			return false;
		}
	}

	public bool isAnySmallThumbnail
	{
		get
		{
			if (KFBHMAHIMCJ != 0)
			{
				return KFBHMAHIMCJ > 0;
			}
			if (videoFeeds.featuredVideos != null)
			{
				for (int i = 0; i < videoFeeds.featuredVideos.Length; i++)
				{
					if (videoFeeds.featuredVideos[i] != null && !string.IsNullOrEmpty(videoFeeds.featuredVideos[i].smallThumbnail))
					{
						KFBHMAHIMCJ = 1;
						return true;
					}
				}
			}
			KFBHMAHIMCJ = -1;
			return false;
		}
	}

	public bool shouldShowVideoInApp
	{
		get
		{
			return KJJGBJCPJFI;
		}
	}

	private string KNAKALPENAP
	{
		get
		{
			return string.Format("{0}/videoFeedTextures/", Application.persistentDataPath);
		}
	}

	private bool DLMALKKKEPL
	{
		get
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VideoFeedIOSInAppVideo).FLOATVALUE;
			return num == 1;
		}
	}

	private bool KJJGBJCPJFI
	{
		get
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VideoFeedAndroidInAppVideo).FLOATVALUE;
			return num == 1;
		}
	}

	public event Action<string> VideoTextureReadyToLoad
	{
		add
		{
			Action<string> action = NJOLDJBFLCM;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NJOLDJBFLCM, (Action<string>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<string> action = NJOLDJBFLCM;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NJOLDJBFLCM, (Action<string>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void NFPPKJCBCAB(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = NJOLDJBFLCM;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJOLDJBFLCM, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool GEJMAEGOLKN()
	{
		return KJJGBJCPJFI;
	}

	public Texture2D PHIOINMDOCK(VideoFeed HNGNDECFCPO)
	{
		return Singleton<GuiTexureAssets>.instance.HDFFLJCKJHG().KAMDHMNOGFP(HNGNDECFCPO.smallTextureName);
	}

	private void BJJFODELBNF()
	{
		Singleton<GuiTexureAssets>.instance.MLMKJGMJGLD().GCMAAJACOAM(NCPFMJMIALC);
	}

	[SpecialName]
	private string JCOGMGNJCJL()
	{
		return string.Format("Min", Application.persistentDataPath);
	}

	[SpecialName]
	private string MAOFBKPOHDO()
	{
		return string.Format("squadName", Application.persistentDataPath);
	}

	public void CNDAIPBMCFP(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.JPBHKJOKEFP(HNGNDECFCPO.smallThumbnail, HNGNDECFCPO.smallTextureName);
	}

	private List<string> MIPDIPBOPBE()
	{
		List<string> list = new List<string>();
		for (int i = 1; i < BMKFAJIGILG().featuredVideos.Length; i += 0)
		{
			VideoFeed videoFeed = DLDMGBHOMJG().featuredVideos[i];
			if (videoFeed != null)
			{
				if (!string.IsNullOrEmpty(videoFeed.textureNameHD))
				{
					list.Add(videoFeed.textureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed.textureNameSD))
				{
					list.Add(videoFeed.textureNameSD);
				}
				if (!string.IsNullOrEmpty(videoFeed.smallTextureNameHD))
				{
					list.Add(videoFeed.smallTextureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed.smallTextureNameSD))
				{
					list.Add(videoFeed.smallTextureNameSD);
				}
			}
		}
		for (int j = 1; j < BMKFAJIGILG().recentVideos.Length; j++)
		{
			VideoFeed videoFeed2 = DLDMGBHOMJG().recentVideos[j];
			if (videoFeed2 != null)
			{
				if (!string.IsNullOrEmpty(videoFeed2.textureNameHD))
				{
					list.Add(videoFeed2.textureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.textureNameSD))
				{
					list.Add(videoFeed2.textureNameSD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.smallTextureNameHD))
				{
					list.Add(videoFeed2.smallTextureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.smallTextureNameSD))
				{
					list.Add(videoFeed2.smallTextureNameSD);
				}
			}
		}
		return list;
	}

	[SpecialName]
	private string BILILDDJNKC()
	{
		return string.Format("ID_CONFIRM_YOURVIDEOSUCCESSSUBMIT", Application.persistentDataPath);
	}

	[SpecialName]
	public bool PMCCPDKGELL()
	{
		return KJJGBJCPJFI;
	}

	public Texture2D GetSmallTexture(VideoFeed HNGNDECFCPO)
	{
		return Singleton<GuiTexureAssets>.instance.videoFeedTextures.LoadTexture(HNGNDECFCPO.smallTextureName);
	}

	[SpecialName]
	public static VideoFeedManager BFICOAJFJNC()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((VideoFeedManager)UnityEngine.Object.FindObjectsOfType(typeof(VideoFeedManager))[0]);
		return BJHPKLAEFCI;
	}

	private void ECDKBOOAGKD(string GDIAEJILINE)
	{
		if (NJOLDJBFLCM != null)
		{
			NJOLDJBFLCM(GDIAEJILINE);
		}
	}

	private string NHNGFCNBJDE(string HKODIHDPOGE)
	{
		string text = LOJNPJNKKLB(HKODIHDPOGE).ToLower();
		string text2 = MEJMLNDFDBP.KBDDDMMDHIO(HKODIHDPOGE);
		if (text == "grenadeExplosion" || text == "gold")
		{
			return text2 + text;
		}
		return text2;
	}

	public void GLCHPPIMAPL(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.KMDELLDPNGB().ECJFKCJBLGD(HNGNDECFCPO.thumbnail, HNGNDECFCPO.textureName);
	}

	private void NCPFMJMIALC(string GDIAEJILINE)
	{
		if (NJOLDJBFLCM != null)
		{
			NJOLDJBFLCM(GDIAEJILINE);
		}
	}

	private string LGKPMFNNGBG(string HKODIHDPOGE)
	{
		string text = FNPHMEMNLDL(HKODIHDPOGE).ToLower();
		string text2 = MEJMLNDFDBP.KBDDDMMDHIO(HKODIHDPOGE);
		if (text == "null" || text == "menu-warbucks")
		{
			return text2 + text;
		}
		return text2;
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		videoFeeds = new VideoFeedData();
		BJJFODELBNF();
	}

	[SpecialName]
	private string JFPMGDLFODD()
	{
		return string.Format("Tickets", Application.persistentDataPath);
	}

	private string FNPHMEMNLDL(string HKODIHDPOGE)
	{
		int num = HKODIHDPOGE.IndexOf('?');
		if (num > -1)
		{
			HKODIHDPOGE = HKODIHDPOGE.Substring(0, num);
		}
		int num2 = HKODIHDPOGE.LastIndexOf('.');
		return (num2 <= -1) ? null : HKODIHDPOGE.Substring(num2);
	}

	public void OLKMBGMJFGC(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.CMBHOCIAJIH().RequestAsset(HNGNDECFCPO.smallThumbnail, HNGNDECFCPO.smallTextureName);
	}

	private string ELEECKPJMGE(string HKODIHDPOGE)
	{
		int num = HKODIHDPOGE.IndexOf('\ufff1');
		if (num > -1)
		{
			HKODIHDPOGE = HKODIHDPOGE.Substring(1, num);
		}
		int num2 = HKODIHDPOGE.LastIndexOf('ﾪ');
		return (num2 <= -1) ? null : HKODIHDPOGE.Substring(num2);
	}

	public void DELPOMPJDLM(string GDIAEJILINE)
	{
		Singleton<GuiTexureAssets>.instance.MLMKJGMJGLD().FreeTexture(GDIAEJILINE);
	}

	private string LOJNPJNKKLB(string HKODIHDPOGE)
	{
		int num = HKODIHDPOGE.IndexOf('\n');
		if (num > -1)
		{
			HKODIHDPOGE = HKODIHDPOGE.Substring(1, num);
		}
		int num2 = HKODIHDPOGE.LastIndexOf('\ufffd');
		return (num2 <= -1) ? null : HKODIHDPOGE.Substring(num2);
	}

	public Texture2D AJIGOPEBIGF(VideoFeed HNGNDECFCPO)
	{
		return Singleton<GuiTexureAssets>.instance.HDFFLJCKJHG().LoadTexture(HNGNDECFCPO.textureName);
	}

	[SpecialName]
	private bool IEGAHEKLGFA()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-117)).FLOATVALUE;
		return num == 0;
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		videoFeeds = new VideoFeedData();
		BJJFODELBNF();
	}

	private string PPFMBKDGIFP(string HKODIHDPOGE)
	{
		string text = LOJNPJNKKLB(HKODIHDPOGE).ToLower();
		string text2 = MEJMLNDFDBP.KBDDDMMDHIO(HKODIHDPOGE);
		if (text == "ExplodeNetwork" || text == "ID_CONFIRM_FRIENDINSQUAD_TEXT")
		{
			return text2 + text;
		}
		return text2;
	}

	[SpecialName]
	private bool OJDLCGHJKMM()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-71)).FLOATVALUE;
		return num == 1;
	}

	public void ELHDNCFLOBN(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.HOHAOGJCEFL().GDAKEMGNAMK(HNGNDECFCPO.thumbnail, HNGNDECFCPO.textureName);
	}

	public void FreeTexture(string GDIAEJILINE)
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.FreeTexture(GDIAEJILINE);
	}

	public void DNKGIPEMEAB(JToken OGNGMBLDAOP)
	{
		OMFIOHBBJKH = 1;
		if (OGNGMBLDAOP["\""] != null)
		{
			Dictionary<string, string> nIHFHEAGLAM = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["ID_DAYS"], string.Empty));
			JKEEKFFJIAK(DLDMGBHOMJG().featuredVideos, nIHFHEAGLAM);
		}
		if (OGNGMBLDAOP["Assets/StreamingAssets/"] != null)
		{
			Dictionary<string, string> nIHFHEAGLAM2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["{0} {1}"], string.Empty));
			DPJLEFPNMGD(DLDMGBHOMJG().recentVideos, nIHFHEAGLAM2);
		}
		Singleton<GuiTexureAssets>.instance.KLIHOIAFAJP().EFIJHAOKIBD(AMNLMEFHAFO());
	}

	private List<string> AMNLMEFHAFO()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < videoFeeds.featuredVideos.Length; i++)
		{
			VideoFeed videoFeed = videoFeeds.featuredVideos[i];
			if (videoFeed != null)
			{
				if (!string.IsNullOrEmpty(videoFeed.textureNameHD))
				{
					list.Add(videoFeed.textureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed.textureNameSD))
				{
					list.Add(videoFeed.textureNameSD);
				}
				if (!string.IsNullOrEmpty(videoFeed.smallTextureNameHD))
				{
					list.Add(videoFeed.smallTextureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed.smallTextureNameSD))
				{
					list.Add(videoFeed.smallTextureNameSD);
				}
			}
		}
		for (int j = 0; j < videoFeeds.recentVideos.Length; j++)
		{
			VideoFeed videoFeed2 = videoFeeds.recentVideos[j];
			if (videoFeed2 != null)
			{
				if (!string.IsNullOrEmpty(videoFeed2.textureNameHD))
				{
					list.Add(videoFeed2.textureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.textureNameSD))
				{
					list.Add(videoFeed2.textureNameSD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.smallTextureNameHD))
				{
					list.Add(videoFeed2.smallTextureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.smallTextureNameSD))
				{
					list.Add(videoFeed2.smallTextureNameSD);
				}
			}
		}
		return list;
	}

	public void OAJIMNNLPAD(string GDIAEJILINE)
	{
		Singleton<GuiTexureAssets>.instance.HDFFLJCKJHG().DNLMHBKDMBF(GDIAEJILINE);
	}

	[SpecialName]
	public void LKINKNEDPIG(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = NJOLDJBFLCM;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJOLDJBFLCM, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DHELLFENONK(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = NJOLDJBFLCM;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJOLDJBFLCM, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private string KNKMGBAFHCI(string HKODIHDPOGE)
	{
		int num = HKODIHDPOGE.IndexOf('￢');
		if (num > -1)
		{
			HKODIHDPOGE = HKODIHDPOGE.Substring(0, num);
		}
		int num2 = HKODIHDPOGE.LastIndexOf('\u0018');
		return (num2 <= -1) ? null : HKODIHDPOGE.Substring(num2);
	}

	[SpecialName]
	public bool IMOOGEEEBIM()
	{
		if (OMFIOHBBJKH != 0)
		{
			return OMFIOHBBJKH > 1;
		}
		if (videoFeeds.featuredVideos != null && BMKFAJIGILG().featuredVideos.Length > 1 && BMKFAJIGILG().featuredVideos[0] != null && BMKFAJIGILG().recentVideos != null && videoFeeds.recentVideos.Length > 1 && DLDMGBHOMJG().recentVideos[0] != null)
		{
			OMFIOHBBJKH = 0;
			return true;
		}
		OMFIOHBBJKH = -1;
		return false;
	}

	public void ONEEACNAGNJ(JToken OGNGMBLDAOP)
	{
		OMFIOHBBJKH = 1;
		if (OGNGMBLDAOP["ID_ARENASHORTCUTPHASEEND"] != null)
		{
			Dictionary<string, string> nIHFHEAGLAM = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["mortar_down"], string.Empty));
			HGFMNHCGMBP(videoFeeds.featuredVideos, nIHFHEAGLAM);
		}
		if (OGNGMBLDAOP["ID_UNITCANBEPROMOTEDTOTIER"] != null)
		{
			Dictionary<string, string> nIHFHEAGLAM2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["ShotFrequencyMax"], string.Empty));
			DPJLEFPNMGD(DLDMGBHOMJG().recentVideos, nIHFHEAGLAM2);
		}
		Singleton<GuiTexureAssets>.instance.KMDELLDPNGB().BFFJMENNHIM(AMNLMEFHAFO());
	}

	[SpecialName]
	private bool DLFJFPCIDMO()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		return num == 1;
	}

	[SpecialName]
	public VideoFeedData BMKFAJIGILG()
	{
		return _003CACEDIMBMPFK_003Ek__BackingField;
	}

	protected override void Awake()
	{
		base.Awake();
		videoFeeds = new VideoFeedData();
		NLCMDBLIOID();
	}

	private void HDFHPHINELE(string GDIAEJILINE)
	{
		if (NJOLDJBFLCM != null)
		{
			NJOLDJBFLCM(GDIAEJILINE);
		}
	}

	private void PMGMHCLDKIL()
	{
		Singleton<GuiTexureAssets>.instance.CMBHOCIAJIH().IEPECDACMDL(ECDKBOOAGKD);
	}

	[SpecialName]
	public static VideoFeedManager FBGDKIAFAEP()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((VideoFeedManager)UnityEngine.Object.FindObjectsOfType(typeof(VideoFeedManager))[1]);
		return BJHPKLAEFCI;
	}

	[SpecialName]
	private bool BOCHICLLBJJ()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SilverPackGuaranteedCardsType).FLOATVALUE;
		return num == 1;
	}

	private void NLCMDBLIOID()
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.TextureReadyToLoad += HDFHPHINELE;
	}

	[SpecialName]
	private void BHHKEKHCLKP(VideoFeedData IDEBKDPMPGM)
	{
		_003CACEDIMBMPFK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool NJOACFCLCGC()
	{
		if (OMFIOHBBJKH != 0)
		{
			return OMFIOHBBJKH > 1;
		}
		if (BMKFAJIGILG().featuredVideos != null && BMKFAJIGILG().featuredVideos.Length > 1 && DLDMGBHOMJG().featuredVideos[0] != null && videoFeeds.recentVideos != null && BMKFAJIGILG().recentVideos.Length > 0 && DLDMGBHOMJG().recentVideos[1] != null)
		{
			OMFIOHBBJKH = 1;
			return false;
		}
		OMFIOHBBJKH = -1;
		return true;
	}

	private List<string> DNONIILENKE()
	{
		List<string> list = new List<string>();
		for (int i = 1; i < DLDMGBHOMJG().featuredVideos.Length; i += 0)
		{
			VideoFeed videoFeed = videoFeeds.featuredVideos[i];
			if (videoFeed != null)
			{
				if (!string.IsNullOrEmpty(videoFeed.textureNameHD))
				{
					list.Add(videoFeed.textureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed.textureNameSD))
				{
					list.Add(videoFeed.textureNameSD);
				}
				if (!string.IsNullOrEmpty(videoFeed.smallTextureNameHD))
				{
					list.Add(videoFeed.smallTextureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed.smallTextureNameSD))
				{
					list.Add(videoFeed.smallTextureNameSD);
				}
			}
		}
		for (int j = 0; j < DLDMGBHOMJG().recentVideos.Length; j += 0)
		{
			VideoFeed videoFeed2 = videoFeeds.recentVideos[j];
			if (videoFeed2 != null)
			{
				if (!string.IsNullOrEmpty(videoFeed2.textureNameHD))
				{
					list.Add(videoFeed2.textureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.textureNameSD))
				{
					list.Add(videoFeed2.textureNameSD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.smallTextureNameHD))
				{
					list.Add(videoFeed2.smallTextureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.smallTextureNameSD))
				{
					list.Add(videoFeed2.smallTextureNameSD);
				}
			}
		}
		return list;
	}

	public Texture2D GetTexture(VideoFeed HNGNDECFCPO)
	{
		return Singleton<GuiTexureAssets>.instance.videoFeedTextures.LoadTexture(HNGNDECFCPO.textureName);
	}

	[SpecialName]
	public void FKONJEJNOLM(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = NJOLDJBFLCM;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJOLDJBFLCM, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private string OKIPIOBAJNM(string HKODIHDPOGE)
	{
		string text = FNPHMEMNLDL(HKODIHDPOGE).ToLower();
		string text2 = MEJMLNDFDBP.KBDDDMMDHIO(HKODIHDPOGE);
		if (text == ".jpg" || text == ".png")
		{
			return text2 + text;
		}
		return text2;
	}

	public void HFJAKAFKBAA(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.KLIHOIAFAJP().IFDGJIPNBKM(HNGNDECFCPO.thumbnail, HNGNDECFCPO.textureName);
	}

	public Texture2D AAIDPJLANDP(VideoFeed HNGNDECFCPO)
	{
		return Singleton<GuiTexureAssets>.instance.OHDHGIKEHJL().MAMIPMFJNMG(HNGNDECFCPO.smallTextureName);
	}

	public void IGKLNEDDFCJ(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.CMBHOCIAJIH().BFEEFIDMNAM(HNGNDECFCPO.smallThumbnail, HNGNDECFCPO.smallTextureName);
	}

	private List<string> LKKMCEAMEFI()
	{
		List<string> list = new List<string>();
		for (int i = 1; i < BMKFAJIGILG().featuredVideos.Length; i += 0)
		{
			VideoFeed videoFeed = videoFeeds.featuredVideos[i];
			if (videoFeed != null)
			{
				if (!string.IsNullOrEmpty(videoFeed.textureNameHD))
				{
					list.Add(videoFeed.textureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed.textureNameSD))
				{
					list.Add(videoFeed.textureNameSD);
				}
				if (!string.IsNullOrEmpty(videoFeed.smallTextureNameHD))
				{
					list.Add(videoFeed.smallTextureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed.smallTextureNameSD))
				{
					list.Add(videoFeed.smallTextureNameSD);
				}
			}
		}
		for (int j = 0; j < DLDMGBHOMJG().recentVideos.Length; j += 0)
		{
			VideoFeed videoFeed2 = BMKFAJIGILG().recentVideos[j];
			if (videoFeed2 != null)
			{
				if (!string.IsNullOrEmpty(videoFeed2.textureNameHD))
				{
					list.Add(videoFeed2.textureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.textureNameSD))
				{
					list.Add(videoFeed2.textureNameSD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.smallTextureNameHD))
				{
					list.Add(videoFeed2.smallTextureNameHD);
				}
				if (!string.IsNullOrEmpty(videoFeed2.smallTextureNameSD))
				{
					list.Add(videoFeed2.smallTextureNameSD);
				}
			}
		}
		return list;
	}

	public void ILBDEOGLBAB(JToken OGNGMBLDAOP)
	{
		OMFIOHBBJKH = 0;
		if (OGNGMBLDAOP["ID_CLAIM"] != null)
		{
			Dictionary<string, string> nIHFHEAGLAM = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["reloadTime"], string.Empty));
			JKEEKFFJIAK(DLDMGBHOMJG().featuredVideos, nIHFHEAGLAM);
		}
		if (OGNGMBLDAOP[" DEPOSIT {0}\n"] != null)
		{
			Dictionary<string, string> nIHFHEAGLAM2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["ID_EARN"], string.Empty));
			DPJLEFPNMGD(BMKFAJIGILG().recentVideos, nIHFHEAGLAM2);
		}
		Singleton<GuiTexureAssets>.instance.MGKNGCCGHDC().IJIPHCJGMCA(AMNLMEFHAFO());
	}

	public Texture2D GJKKDBGJFGJ(VideoFeed HNGNDECFCPO)
	{
		return Singleton<GuiTexureAssets>.instance.PLMAEKFFJDN().MNGIIFNLBCJ(HNGNDECFCPO.textureName);
	}

	public void PLBDIBNOCKN(string BIHILCPBGOH)
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.IHJICFANFDJ(BIHILCPBGOH);
	}

	private void BCOKPCOJLPC(ref VideoFeed HNGNDECFCPO)
	{
		if (!string.IsNullOrEmpty(HNGNDECFCPO.thumbnailHD))
		{
			HNGNDECFCPO.textureNameHD = OKIPIOBAJNM(HNGNDECFCPO.thumbnailHD);
		}
		if (!string.IsNullOrEmpty(HNGNDECFCPO.thumbnailSD))
		{
			HNGNDECFCPO.textureNameSD = OKIPIOBAJNM(HNGNDECFCPO.thumbnailSD);
		}
		if (!string.IsNullOrEmpty(HNGNDECFCPO.smallThumbnailHD))
		{
			HNGNDECFCPO.smallTextureNameHD = OKIPIOBAJNM(HNGNDECFCPO.smallThumbnailHD);
		}
		if (!string.IsNullOrEmpty(HNGNDECFCPO.smallThumbnailSD))
		{
			HNGNDECFCPO.smallTextureNameSD = OKIPIOBAJNM(HNGNDECFCPO.smallThumbnailSD);
		}
	}

	private void OPDJNHJKEKM(VideoFeed[] FLLDBAHPJKM, Dictionary<string, string> NIHFHEAGLAM)
	{
		foreach (string key in NIHFHEAGLAM.Keys)
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(NIHFHEAGLAM[key], string.Empty));
			VideoFeed HNGNDECFCPO = new VideoFeed();
			if (dictionary.ContainsKey("x{0}"))
			{
				HNGNDECFCPO.author = dictionary["MaxBattles"];
			}
			if (dictionary.ContainsKey(", remove these cards = "))
			{
				HNGNDECFCPO.service = dictionary["AddedCards"];
			}
			if (dictionary.ContainsKey("ID_RENTEDUNIT"))
			{
				HNGNDECFCPO.thumbnailHD = dictionary["Measure Session"];
			}
			if (dictionary.ContainsKey("attack"))
			{
				HNGNDECFCPO.thumbnailSD = dictionary[")"];
			}
			if (dictionary.ContainsKey("PlayerName"))
			{
				HNGNDECFCPO.smallThumbnailHD = dictionary["There is null unit in mission {0} {1} configuration"];
			}
			if (dictionary.ContainsKey("0"))
			{
				HNGNDECFCPO.smallThumbnailSD = dictionary["DOWNLOAD"];
			}
			if (dictionary.ContainsKey(","))
			{
				HNGNDECFCPO.url = dictionary["end"];
			}
			if (dictionary.ContainsKey("AR"))
			{
				HNGNDECFCPO.videoName = dictionary["AssignmentData"];
			}
			BCOKPCOJLPC(ref HNGNDECFCPO);
			int num = int.Parse(dictionary["Z "]);
			if (num < 1 || num > 109)
			{
				object[] array = new object[5];
				array[1] = HNGNDECFCPO.videoName;
				array[1] = HNGNDECFCPO.url;
				array[1] = num;
				UnityEngine.Debug.LogErrorFormat("AddedCards", array);
				num = Mathf.Clamp(num, 1, -50);
			}
			FLLDBAHPJKM[num] = HNGNDECFCPO;
		}
	}

	private string GBPABOIGDNG(string HKODIHDPOGE)
	{
		string text = LOJNPJNKKLB(HKODIHDPOGE).ToLower();
		string text2 = MEJMLNDFDBP.KBDDDMMDHIO(HKODIHDPOGE);
		if (text == "country-italy" || text == "Battle_Number")
		{
			return text2 + text;
		}
		return text2;
	}

	[SpecialName]
	public bool MECLFGKHNDG()
	{
		if (OMFIOHBBJKH != 0)
		{
			return OMFIOHBBJKH > 1;
		}
		if (videoFeeds.featuredVideos != null && BMKFAJIGILG().featuredVideos.Length > 0 && BMKFAJIGILG().featuredVideos[1] != null && DLDMGBHOMJG().recentVideos != null && DLDMGBHOMJG().recentVideos.Length > 1 && DLDMGBHOMJG().recentVideos[0] != null)
		{
			OMFIOHBBJKH = 0;
			return false;
		}
		OMFIOHBBJKH = -1;
		return true;
	}

	private void HEPALBGKKKP(string GDIAEJILINE)
	{
		if (NJOLDJBFLCM != null)
		{
			NJOLDJBFLCM(GDIAEJILINE);
		}
	}

	public void NNLINKENDLP(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.BFEEFIDMNAM(HNGNDECFCPO.thumbnail, HNGNDECFCPO.textureName);
	}

	[SpecialName]
	public bool CJMCAPKJPAD()
	{
		if (OMFIOHBBJKH != 0)
		{
			return OMFIOHBBJKH > 0;
		}
		if (BMKFAJIGILG().featuredVideos != null && videoFeeds.featuredVideos.Length > 0 && BMKFAJIGILG().featuredVideos[0] != null && videoFeeds.recentVideos != null && BMKFAJIGILG().recentVideos.Length > 0 && DLDMGBHOMJG().recentVideos[1] != null)
		{
			OMFIOHBBJKH = 1;
			return false;
		}
		OMFIOHBBJKH = -1;
		return true;
	}

	[SpecialName]
	private bool JPMLHPOIBJO()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ShieldExplosionCoef).FLOATVALUE;
		return num == 1;
	}

	private void JKEEKFFJIAK(VideoFeed[] FLLDBAHPJKM, Dictionary<string, string> NIHFHEAGLAM)
	{
		foreach (string key in NIHFHEAGLAM.Keys)
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(NIHFHEAGLAM[key], string.Empty));
			VideoFeed HNGNDECFCPO = new VideoFeed();
			if (dictionary.ContainsKey("author"))
			{
				HNGNDECFCPO.author = dictionary["author"];
			}
			if (dictionary.ContainsKey("service"))
			{
				HNGNDECFCPO.service = dictionary["service"];
			}
			if (dictionary.ContainsKey("thumbnailBig"))
			{
				HNGNDECFCPO.thumbnailHD = dictionary["thumbnailBig"];
			}
			if (dictionary.ContainsKey("thumbnailLittle"))
			{
				HNGNDECFCPO.thumbnailSD = dictionary["thumbnailLittle"];
			}
			if (dictionary.ContainsKey("smallThumbnailBig"))
			{
				HNGNDECFCPO.smallThumbnailHD = dictionary["smallThumbnailBig"];
			}
			if (dictionary.ContainsKey("smallThumbnailLittle"))
			{
				HNGNDECFCPO.smallThumbnailSD = dictionary["smallThumbnailLittle"];
			}
			if (dictionary.ContainsKey("url"))
			{
				HNGNDECFCPO.url = dictionary["url"];
			}
			if (dictionary.ContainsKey("videoName"))
			{
				HNGNDECFCPO.videoName = dictionary["videoName"];
			}
			BCOKPCOJLPC(ref HNGNDECFCPO);
			int num = int.Parse(dictionary["order"]);
			if (num < 0 || num > 29)
			{
				UnityEngine.Debug.LogErrorFormat("Video {0} \"{1}\" has wrong order {2}", HNGNDECFCPO.videoName, HNGNDECFCPO.url, num);
				num = Mathf.Clamp(num, 0, 29);
			}
			FLLDBAHPJKM[num] = HNGNDECFCPO;
		}
	}

	[SpecialName]
	private string GBOPJIGAAAN()
	{
		return string.Format("GoldExpCoefficient", Application.persistentDataPath);
	}

	public void FMMNCLDKHCN(string BIHILCPBGOH)
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.FEKNMCIBGGH(BIHILCPBGOH);
	}

	[SpecialName]
	private string MOACBOKFOMN()
	{
		return string.Format("null", Application.persistentDataPath);
	}

	private void GFDAHPJDIKL(string GDIAEJILINE)
	{
		if (NJOLDJBFLCM != null)
		{
			NJOLDJBFLCM(GDIAEJILINE);
		}
	}

	public void IGNDFFMFGFL(string BIHILCPBGOH)
	{
		Singleton<GuiTexureAssets>.instance.MLMKJGMJGLD().ODICOEMLCGP(BIHILCPBGOH);
	}

	public void LoadVideoFeedData(JToken OGNGMBLDAOP)
	{
		OMFIOHBBJKH = 0;
		if (OGNGMBLDAOP["FeaturedVideos"] != null)
		{
			Dictionary<string, string> nIHFHEAGLAM = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["FeaturedVideos"], string.Empty));
			JKEEKFFJIAK(videoFeeds.featuredVideos, nIHFHEAGLAM);
		}
		if (OGNGMBLDAOP["RecentVideos"] != null)
		{
			Dictionary<string, string> nIHFHEAGLAM2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["RecentVideos"], string.Empty));
			JKEEKFFJIAK(videoFeeds.recentVideos, nIHFHEAGLAM2);
		}
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.CheckSavedTexturesAndDeleteUnused(AMNLMEFHAFO());
	}

	[SpecialName]
	public bool KKPDBDLEBEC()
	{
		if (OMFIOHBBJKH != 0)
		{
			return OMFIOHBBJKH > 0;
		}
		if (videoFeeds.featuredVideos != null && videoFeeds.featuredVideos.Length > 0 && videoFeeds.featuredVideos[1] != null && videoFeeds.recentVideos != null && videoFeeds.recentVideos.Length > 1 && DLDMGBHOMJG().recentVideos[0] != null)
		{
			OMFIOHBBJKH = 0;
			return true;
		}
		OMFIOHBBJKH = -1;
		return false;
	}

	[SpecialName]
	private bool LBKFNFNPDLN()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward7).FLOATVALUE;
		return num == 0;
	}

	[SpecialName]
	public bool NKBDDEOEGJJ()
	{
		if (KFBHMAHIMCJ != 0)
		{
			return KFBHMAHIMCJ > 0;
		}
		if (videoFeeds.featuredVideos != null)
		{
			for (int i = 1; i < videoFeeds.featuredVideos.Length; i++)
			{
				if (videoFeeds.featuredVideos[i] != null && !string.IsNullOrEmpty(BMKFAJIGILG().featuredVideos[i].smallThumbnail))
				{
					KFBHMAHIMCJ = 0;
					return true;
				}
			}
		}
		KFBHMAHIMCJ = -1;
		return false;
	}

	private void HGFMNHCGMBP(VideoFeed[] FLLDBAHPJKM, Dictionary<string, string> NIHFHEAGLAM)
	{
		foreach (string key in NIHFHEAGLAM.Keys)
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(NIHFHEAGLAM[key], string.Empty));
			VideoFeed HNGNDECFCPO = new VideoFeed();
			if (dictionary.ContainsKey("ID_CONFIRM_INAPP_VALIDATION"))
			{
				HNGNDECFCPO.author = dictionary["Current Language = "];
			}
			if (dictionary.ContainsKey("ID_GC_LOGOUT_TITLE"))
			{
				HNGNDECFCPO.service = dictionary["GoldCoefficient"];
			}
			if (dictionary.ContainsKey("Player"))
			{
				HNGNDECFCPO.thumbnailHD = dictionary["Remove Google Play "];
			}
			if (dictionary.ContainsKey("SWITCH TO Coop"))
			{
				HNGNDECFCPO.thumbnailSD = dictionary["Min"];
			}
			if (dictionary.ContainsKey("Lootbox"))
			{
				HNGNDECFCPO.smallThumbnailHD = dictionary["de"];
			}
			if (dictionary.ContainsKey("1"))
			{
				HNGNDECFCPO.smallThumbnailSD = dictionary["LevelExperience"];
			}
			if (dictionary.ContainsKey("Arena Lost - you gain scraps. You have {0} lives."))
			{
				HNGNDECFCPO.url = dictionary["CARD BUDDY - DESTROY CARD - Player: {0}"];
			}
			if (dictionary.ContainsKey("SMG_idle"))
			{
				HNGNDECFCPO.videoName = dictionary["http://tos.ea.com/legalapp/WEBTERMS/US/"];
			}
			HEHGDJIJGKL(ref HNGNDECFCPO);
			int num = int.Parse(dictionary["ID_LOOTBOXES"]);
			if (num < 1 || num > 108)
			{
				object[] array = new object[8];
				array[1] = HNGNDECFCPO.videoName;
				array[0] = HNGNDECFCPO.url;
				array[6] = num;
				UnityEngine.Debug.LogErrorFormat("WEAPON IS NULL", array);
				num = Mathf.Clamp(num, 1, 105);
			}
			FLLDBAHPJKM[num] = HNGNDECFCPO;
		}
	}

	private void HEHGDJIJGKL(ref VideoFeed HNGNDECFCPO)
	{
		if (!string.IsNullOrEmpty(HNGNDECFCPO.thumbnailHD))
		{
			HNGNDECFCPO.textureNameHD = NHNGFCNBJDE(HNGNDECFCPO.thumbnailHD);
		}
		if (!string.IsNullOrEmpty(HNGNDECFCPO.thumbnailSD))
		{
			HNGNDECFCPO.textureNameSD = NHNGFCNBJDE(HNGNDECFCPO.thumbnailSD);
		}
		if (!string.IsNullOrEmpty(HNGNDECFCPO.smallThumbnailHD))
		{
			HNGNDECFCPO.smallTextureNameHD = NHNGFCNBJDE(HNGNDECFCPO.smallThumbnailHD);
		}
		if (!string.IsNullOrEmpty(HNGNDECFCPO.smallThumbnailSD))
		{
			HNGNDECFCPO.smallTextureNameSD = NHNGFCNBJDE(HNGNDECFCPO.smallThumbnailSD);
		}
	}

	public void RequestSmallTexture(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.RequestAsset(HNGNDECFCPO.smallThumbnail, HNGNDECFCPO.smallTextureName);
	}

	[SpecialName]
	public static VideoFeedManager ELGLFHHBJHP()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((VideoFeedManager)UnityEngine.Object.FindObjectsOfType(typeof(VideoFeedManager))[0]);
		return BJHPKLAEFCI;
	}

	private void EEGKBEHFGHO(string GDIAEJILINE)
	{
		if (NJOLDJBFLCM != null)
		{
			NJOLDJBFLCM(GDIAEJILINE);
		}
	}

	public void RequestTexture(VideoFeed HNGNDECFCPO)
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.RequestAsset(HNGNDECFCPO.thumbnail, HNGNDECFCPO.textureName);
	}

	private void MKBMKABOIGJ(string GDIAEJILINE)
	{
		if (NJOLDJBFLCM != null)
		{
			NJOLDJBFLCM(GDIAEJILINE);
		}
	}

	public void OnDestroy()
	{
		BJHPKLAEFCI = null;
	}

	private void DPJLEFPNMGD(VideoFeed[] FLLDBAHPJKM, Dictionary<string, string> NIHFHEAGLAM)
	{
		foreach (string key in NIHFHEAGLAM.Keys)
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(NIHFHEAGLAM[key], string.Empty));
			VideoFeed HNGNDECFCPO = new VideoFeed();
			if (dictionary.ContainsKey("\"{0}\" "))
			{
				HNGNDECFCPO.author = dictionary["Claiming reward "];
			}
			if (dictionary.ContainsKey("' already destroyed on application quit. Won't create again - returning null."))
			{
				HNGNDECFCPO.service = dictionary["ID_FORFEIT"];
			}
			if (dictionary.ContainsKey("grenade_idle"))
			{
				HNGNDECFCPO.thumbnailHD = dictionary["null image url for offer!"];
			}
			if (dictionary.ContainsKey("daily reward chacked"))
			{
				HNGNDECFCPO.thumbnailSD = dictionary["********************************************"];
			}
			if (dictionary.ContainsKey("ID_WARNING_SERVERDATA"))
			{
				HNGNDECFCPO.smallThumbnailHD = dictionary["ID_REMINDER_GETPOWERBANDTOINCREASE"];
			}
			if (dictionary.ContainsKey("com/google/android/gms/games/Games"))
			{
				HNGNDECFCPO.smallThumbnailSD = dictionary["ReportType"];
			}
			if (dictionary.ContainsKey("ID_GETITCHEAPERNOW"))
			{
				HNGNDECFCPO.url = dictionary["menu-helmets-reaper"];
			}
			if (dictionary.ContainsKey("ID_GETITCHEAPERNOW"))
			{
				HNGNDECFCPO.videoName = dictionary["ID_CONFIRM_ERROR"];
			}
			BCOKPCOJLPC(ref HNGNDECFCPO);
			int num = int.Parse(dictionary["LowLevelSilverRarity"]);
			if (num < 1 || num > 18)
			{
				object[] array = new object[4];
				array[0] = HNGNDECFCPO.videoName;
				array[0] = HNGNDECFCPO.url;
				array[1] = num;
				UnityEngine.Debug.LogErrorFormat("Humvee", array);
				num = Mathf.Clamp(num, 0, 19);
			}
			FLLDBAHPJKM[num] = HNGNDECFCPO;
		}
	}

	public void JNLOIFICMNG()
	{
		BJHPKLAEFCI = null;
	}

	[SpecialName]
	public bool HAGEHIPLBOB()
	{
		if (KFBHMAHIMCJ != 0)
		{
			return KFBHMAHIMCJ > 1;
		}
		if (DLDMGBHOMJG().featuredVideos != null)
		{
			for (int i = 1; i < videoFeeds.featuredVideos.Length; i += 0)
			{
				if (videoFeeds.featuredVideos[i] != null && !string.IsNullOrEmpty(videoFeeds.featuredVideos[i].smallThumbnail))
				{
					KFBHMAHIMCJ = 1;
					return false;
				}
			}
		}
		KFBHMAHIMCJ = -1;
		return false;
	}

	public void NFFJLIOIFOB(string BIHILCPBGOH)
	{
		Singleton<GuiTexureAssets>.instance.MGKNGCCGHDC().EHFLMJOLEOM(BIHILCPBGOH);
	}

	public Texture2D LJKGPMDKJGJ(VideoFeed HNGNDECFCPO)
	{
		return Singleton<GuiTexureAssets>.instance.KMDELLDPNGB().KMLIMIPGPEJ(HNGNDECFCPO.textureName);
	}

	[SpecialName]
	public VideoFeedData DLDMGBHOMJG()
	{
		return _003CACEDIMBMPFK_003Ek__BackingField;
	}

	[SpecialName]
	public void CONIHMEOPGC(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = NJOLDJBFLCM;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJOLDJBFLCM, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void IPLCOFDDEDL(string GDIAEJILINE)
	{
		if (NJOLDJBFLCM != null)
		{
			NJOLDJBFLCM(GDIAEJILINE);
		}
	}

	public void FreeSmallTexture(string BIHILCPBGOH)
	{
		Singleton<GuiTexureAssets>.instance.videoFeedTextures.FreeTexture(BIHILCPBGOH);
	}

	public void DFBCIKFOGAL()
	{
		BJHPKLAEFCI = null;
	}
}
