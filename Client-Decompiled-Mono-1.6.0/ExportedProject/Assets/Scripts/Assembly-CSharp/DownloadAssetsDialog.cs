using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DownloadAssetsDialog : Core_BaseScript
{
	[Header("Labels")]
	public UILabel NNGGEEFLIPE;

	public UILabel LLILKCJKNPH;

	[Header("Buttons")]
	public UIButton DDLOCLPOFAK;

	public UILabel DEHKFKDHMJD;

	public UIButton JLEFFOGPFGE;

	public UILabel FBOBOOKDJLO;

	public bool? FBFJNHLKJEC;

	private static Dictionary<SystemLanguage, string> JCLCJIHIPFA = new Dictionary<SystemLanguage, string>
	{
		{
			SystemLanguage.English,
			"en"
		},
		{
			SystemLanguage.French,
			"fr"
		},
		{
			SystemLanguage.Italian,
			"it"
		},
		{
			SystemLanguage.German,
			"de"
		},
		{
			SystemLanguage.Spanish,
			"es"
		},
		{
			SystemLanguage.Portuguese,
			"pt"
		},
		{
			SystemLanguage.Russian,
			"ru"
		},
		{
			SystemLanguage.Japanese,
			"jp"
		},
		{
			SystemLanguage.Chinese,
			"cn"
		},
		{
			SystemLanguage.ChineseSimplified,
			"cn"
		},
		{
			SystemLanguage.ChineseTraditional,
			"tc"
		},
		{
			SystemLanguage.Korean,
			"kr"
		}
	};

	private string LNFNFGMCDDF = "en";

	private static Dictionary<string, string> HIINMLMEGKE = new Dictionary<string, string>
	{
		{ "CONFIRM", "CONFIRM" },
		{ "WarFriends", "WarFriends requires permission to access your media storage in order to download critical game data.Please accept the permission dialog which follows, we will never use this permission for any other purpose." },
		{ "OK", "OK" },
		{ "QUIT", "QUIT" },
		{ "DOWNLOAD", "WarFriends require to download approximately 190MB of extra data to run.\nDownload time may vary based on your network and location.\n\nDo you wish to proceed?" },
		{ "YES", "YES" },
		{ "NO", "NO" },
		{ "WENEEDTO", "WarFriends cannot function without downloading these additional data. Do you really wish to QUIT or would you like to download the data?" },
		{ "RETRY", "RETRY" },
		{ "RETRYPERM", "WarFriends requires permission to access your media storage in order to download critical game data.Without this permission the game cannot function and will be closed. Please retry or quit WarFriends." },
		{ "DOWNLOADBTN", "DOWNLOAD" }
	};

	private static Dictionary<string, string> CBJFDHOOGPM = new Dictionary<string, string>
	{
		{ "CONFIRM", "CONFIRMER" },
		{ "WarFriends", "WarFriends nécessite la permission d’accéder à ton espace de stockage afin de télécharger des données de jeu critiques.Accepte la permission suivante, nous n’utiliserons jamais cette permission pour autre chose." },
		{ "OK", "OK" },
		{ "QUIT", "QUITTER" },
		{ "DOWNLOAD", "WarFriends doit télécharger environ 190 Mo de données supplémentaires pour fonctionner.\nLa durée du téléchargement peut varier selon votre réseau et votre emplacement.\n\nVoulez-vous continuer ?" },
		{ "YES", "OUI" },
		{ "NO", "NON" },
		{ "WENEEDTO", "WarFriends ne peut pas fonctionner sans ces données supplémentaires. Voulez-vous vraiment QUITTER ou voulez-vous télécharger les données ?" },
		{ "RETRY", "RÉESSAYER" },
		{ "RETRYPERM", "WarFriends demande l'autorisation d'accéder à votre média de stockage afin de télécharger des données essentielles au jeu.Sans cette autorisation, le jeu ne pourra pas fonctionner et va fermer. Veuillez réessayer ou quitter WarFriends." },
		{ "DOWNLOADBTN", "TÉLÉCHARGER" }
	};

	private static Dictionary<string, string> GEHBDBGNHLJ = new Dictionary<string, string>
	{
		{ "CONFIRM", "CONFERMA" },
		{ "WarFriends", "WarFriends richiede l'autorizzazione alla memorizzazione multimediale per scaricare dati fondamentali per il gioco.Accetta la finestra di dialogo di autorizzazione che verrà visualizzata. Non useremo questa autorizzazione per altri scopi." },
		{ "OK", "OK" },
		{ "QUIT", "ESCI" },
		{ "DOWNLOAD", "Per funzionare, WarFriends deve scaricare circa 190MB di dati extra.\nIl tempo di download può variare in base alla tua rete e posizione.\n\nVuoi proseguire?" },
		{ "YES", "SÌ" },
		{ "NO", "NO" },
		{ "WENEEDTO", "WarFriends non può funzionare senza scaricare questi dati aggiuntivi. Vuoi davvero USCIRE o vuoi scaricare i dati?" },
		{ "RETRY", "RIPROVA" },
		{ "RETRYPERM", "WarFriends necessita di un permesso per accedere alla memoria e scaricare importanti dati di gioco.Senza questo permesso, il gioco non può funzionare e verrà chiuso. Riprova o esci da WarFriends." },
		{ "DOWNLOADBTN", "SCARICA" }
	};

	private static Dictionary<string, string> BBPNGCCDHLD = new Dictionary<string, string>
	{
		{ "CONFIRM", "BESTÄTIGEN" },
		{ "WarFriends", "WarFriends benötigt deine Genehmigung zum Zugriff auf deinen Medienspeicher, um wichtige Spieldaten herunterladen zu können.Bitte bestätige die folgende Genehmigungsanfrage. Wir werden diese Genehmigung nicht für andere Zwecke verwenden." },
		{ "OK", "OK" },
		{ "QUIT", "VERLASSEN" },
		{ "DOWNLOAD", "WarFriends muss circa 190 MB zusätzliche Daten herunterladen.\nDie Dauer des Downloads hängt von deinem Netzwerk und Standort ab.\n\nMöchtest du fortfahren?" },
		{ "YES", "JA" },
		{ "NO", "NEIN" },
		{ "WENEEDTO", "WarFriends funktioniert ohne diese zusätzlichen Daten nicht. Möchtest du WarFriends wirklich VERLASSEN oder möchtest du die Daten herunterladen?" },
		{ "RETRY", "ERNEUT VERSUCHEN" },
		{ "RETRYPERM", "WarFriends benötigt die Erlaubnis, auf deinen Medienspeicher zuzugreifen, um wichtige Spieldaten herunterladen zu können.Ohne diese Berechtigung läuft das Spiel nicht und wird geschlossen. Bitte versuche es erneut oder schließe WarFriends." },
		{ "DOWNLOADBTN", "HERUNTERLADEN" }
	};

	private static Dictionary<string, string> JELMOGJFGEE = new Dictionary<string, string>
	{
		{ "CONFIRM", "CONFIRMAR" },
		{ "WarFriends", "WarFriends necesita permiso para acceder a tu almacenamiento de medios para descargar datos esenciales del juego.Por favor, acepta el cuadro de solicitud de permisos que aparece a continuación; nunca utilizaremos este permiso para ningún otro fin." },
		{ "OK", "OK" },
		{ "QUIT", "SALIR" },
		{ "DOWNLOAD", "Para funcionar, WarFriends necesita descargar unos 190 MB de datos adicionales.\nEl tiempo de descarga puede variar, dependiendo de tu red y tu ubicación.\n\n¿Continuar?" },
		{ "YES", "SÍ" },
		{ "NO", "NO" },
		{ "WENEEDTO", "WarFriends no puede funcionar sin descargar estos datos adicionales. ¿Seguro que quieres SALIR o prefieres descargar los datos?" },
		{ "RETRY", "REINTENTAR" },
		{ "RETRYPERM", "WarFriends necesita permiso para acceder a tu almacenamiento de medios para descargar datos del juego esenciales.Sin este permiso, el juego no puede funcionar y se cerrará. Reinicia o sal de WarFriends." },
		{ "DOWNLOADBTN", "DESCARGAR" }
	};

	private static Dictionary<string, string> FFHIAJBPAKN = new Dictionary<string, string>
	{
		{ "CONFIRM", "CONFIRMAR" },
		{ "WarFriends", "WarFriends precisa da sua permissão para acessar sua mídia para carregar informações adicionais.Favor aceitar o diálogo de permissão a seguir, saiba que não será utilizada para nenhum outro propósito." },
		{ "OK", "OK" },
		{ "QUIT", "SAIR" },
		{ "DOWNLOAD", "WarFriends precisa baixar aproximadamente 190MB extra para rodar.\nO tempo de download pode variar dependendo da sua rede e localização.\n\nVocê gostaria de prosseguir?" },
		{ "YES", "SIM" },
		{ "NO", "NÃO" },
		{ "WENEEDTO", "WarFriends não funcionará se não baixar esses dados adicionais. Você realmente quer SAIR ou você gostaria de baixar os dados?" },
		{ "RETRY", "MAIS UMA" },
		{ "RETRYPERM", "WarFriends precisa de permissão para aceder seus arquivos de mídia para baixar dados críticos do jogo.Sem essa permissão o jogo não poderá funcionar e será encerrado. Por favor, tente novamente ou saia de WarFriends." },
		{ "DOWNLOADBTN", "BAIXAR" }
	};

	private static Dictionary<string, string> NAGJMMGLGOK = new Dictionary<string, string>
	{
		{ "CONFIRM", "CONFIRMAR" },
		{ "WarFriends", "O WarFriends necessita de autorização para aceder ao teu armazenamento media, a fim de transferir dados fundamentais para o jogo.Concede a seguinte autorização. Nunca utilizaremos esta autorização para qualquer outra finalidade." },
		{ "OK", "OK" },
		{ "QUIT", "DESISTIR" },
		{ "DOWNLOAD", "WarFriends precisa descarregar aproximadamente 190MB de dados extra para correr.\nO tempo de download pode variar dependendo da rede e da localização.\n\nDesejas continuar?" },
		{ "YES", "SIM" },
		{ "NO", "NÃO" },
		{ "WENEEDTO", "WarFriends não poderá funcionar sem descarregar os dados adicionais. Realmente desejas SAIR ou gostarias de descarregar os dados?" },
		{ "RETRY", "TENTAR NOVAMENTE" },
		{ "RETRYPERM", "WarFriends requer permissão para aceder aos ficheiros de armazenamento de media para descarregar dados críticos de jogo.Sem essa permissão o jogo não poderá funcionar adequadamente e será encerrado. Por favor, tente novamente ou encerre WarFriends." },
		{ "DOWNLOADBTN", "DESCARREGAR" }
	};

	private static Dictionary<string, string> GMBLKDOAELE = new Dictionary<string, string>
	{
		{ "CONFIRM", "ПОДТВЕРДИТЬ" },
		{ "WarFriends", "WarFriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Пожалуйста, подтверди разрешение в последующем диалоге. Мы никогда не воспользуемся эти разрешением для каких-либо других целей." },
		{ "OK", "OK" },
		{ "QUIT", "ВЫХОД" },
		{ "DOWNLOAD", "Для запуска WarFriends требуется загрузить приблизительно 190 МБ дополнительных данных.\nВремя загрузки может варьироваться в зависимости от вашей сети и местонахождения.\n\nНачать загрузку?" },
		{ "YES", "ДА" },
		{ "NO", "НЕТ" },
		{ "WENEEDTO", "WarFriends не может работать без загрузки этих дополнительных данных. Вы действительно хотите ВЫЙТИ или предпочитаете загрузить данные?" },
		{ "RETRY", "ЕЩЕ ПОПЫТКА" },
		{ "RETRYPERM", "Warfriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Ьез этого разрешения игра не может функционировать и будет закрыта. Пожалуйста, попробуй снова или выйди из WarFriends." },
		{ "DOWNLOADBTN", "ЗАГРУЗИТЬ" }
	};

	private static Dictionary<string, string> JOOOPNGDOPB = new Dictionary<string, string>
	{
		{ "CONFIRM", "確認" },
		{ "WarFriends", "WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。以下のダイアローグで許可を承諾してください。他の目的でこの権限が使用されることはありません。" },
		{ "OK", "OK" },
		{ "QUIT", "やめる" },
		{ "DOWNLOAD", "WarFriendsは追加データを実行するため、約190MBをダウンロードする必要があります。\nダウンロード時間はネットワークと現在位置によって異なります。\n\n続行してもよいですか？" },
		{ "YES", "はい" },
		{ "NO", "いいえ" },
		{ "WENEEDTO", "WarFriendsは、この追加データのダウンロードなしでは動作しません。やめてもよいですか？またはデータをダウンロードしますか？" },
		{ "RETRY", "リトライ" },
		{ "RETRYPERM", "WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。許可がないとゲームが機能できず、閉じてしまいます。再試行するか、WarFriendsをやめてください。" },
		{ "DOWNLOADBTN", "ダウンロード" }
	};

	private static Dictionary<string, string> LEIJMJHCJED = new Dictionary<string, string>
	{
		{ "CONFIRM", "确认" },
		{ "WarFriends", "为下载关键的游戏数据，《战争之友》需要您的媒体存储信息的访问权限。请在随后出现的权限对话框中选择接受，我们绝不会将此权限用于任何其他目的。" },
		{ "OK", "确定" },
		{ "QUIT", "退出" },
		{ "DOWNLOAD", "《战争之友》需要下载约 190MB 的额外数据才能运行。\n下载时间可能因您的网络和位置而异。\n\n是否希望继续？" },
		{ "YES", "是" },
		{ "NO", "不" },
		{ "WENEEDTO", "如不下载这些额外数据，《战争之友》将无法运行。您希望退出还是下载这些数据？" },
		{ "RETRY", "重试" },
		{ "RETRYPERM", "《战争之友》需要获得对你的媒体存储设备的访问权限，以便下载关键游戏数据。如果没有此权限，游戏无法运行并将关闭。请重新尝试或退出《战争之友》。" },
		{ "DOWNLOADBTN", "下载" }
	};

	private static Dictionary<string, string> IAINHHHNHIJ = new Dictionary<string, string>
	{
		{ "CONFIRM", "確認" },
		{ "WarFriends", "《WarFriends》需要權限才能存取你的媒體儲存檔以便下載關鍵資料。請接受以下所示的權限對話，我們絕不會將此權限使用在其他用途。" },
		{ "OK", "OK" },
		{ "QUIT", "退出" },
		{ "DOWNLOAD", "《WarFriends》需要再多下載大約190MB的資料才能運作。\n下載時間將依你的網路與所在位置有所不同。\n\n想要繼續嗎？" },
		{ "YES", "是" },
		{ "NO", "否" },
		{ "WENEEDTO", "若沒有下載這些額外資料，《WarFriends》就無法運作。確定想要退出，還是想要下載資料呢？" },
		{ "RETRY", "重試" },
		{ "RETRYPERM", "《WarFriends》需要權限存取你的媒體存儲才能下載關鍵的遊戲資料。缺少此權限，遊戲就無法運作並會關閉。請重試或退出《WarFriends》。" },
		{ "DOWNLOADBTN", "下載" }
	};

	private static Dictionary<string, string> AKGBCBHIIHM = new Dictionary<string, string>
	{
		{ "CONFIRM", "확인" },
		{ "WarFriends", "워프렌즈가 중요한 게임 데이터를 다운로드하려면 미디어 저장 장치에 대한 접근 권한이 필요합니다. 다음에 나오는 권한 설정을 수락해주세요. 이 권한 설정은 다른 목적으로는 사용되지 않습니다." },
		{ "OK", "확인" },
		{ "QUIT", "나가기" },
		{ "DOWNLOAD", "워프렌즈를 실행하려면 약 190MB의 추가 데이터를 다운로드 받아야 합니다.\n다운로드 시간은 네트워크 및 지역에 따라 달라질 수 있습니다.\n\n계속 진행하시겠습니까?" },
		{ "YES", "예" },
		{ "NO", "아니오" },
		{ "WENEEDTO", "워프렌즈는 이 추가 데이터를 다운로드 받지 않으면 실행할 수 없습니다. 정말 종료하시겠습니까? 아니면 데이터를 다운로드 받으시겠습니까?" },
		{ "RETRY", "재시도" },
		{ "RETRYPERM", "워프렌즈가 중요한 게임 데이터를 다운로드 받으려면 미디어 저장소에 대한 접근 권한이 필요합니다. 이 권한이 없으면, 게임이 정상적으로 작동되지 않고 종료됩니다. 다시 시도하거나 워프렌즈를 종료해주세요." },
		{ "DOWNLOADBTN", "다운로드" }
	};

	public string title
	{
		set
		{
			NNGGEEFLIPE.text = value;
		}
	}

	public string text
	{
		set
		{
			LLILKCJKNPH.text = value;
		}
	}

	public string yesButtonText
	{
		get
		{
			return DEHKFKDHMJD.text;
		}
		set
		{
			DEHKFKDHMJD.text = value;
		}
	}

	public string cancelButtonText
	{
		get
		{
			return FBOBOOKDJLO.text;
		}
		set
		{
			FBOBOOKDJLO.text = value;
		}
	}

	private string GEOFADIFALA
	{
		get
		{
			Debug.Log(string.Format("Device Language - android: {0}", Application.systemLanguage));
			return (!JCLCJIHIPFA.ContainsKey(Application.systemLanguage)) ? "en" : JCLCJIHIPFA[Application.systemLanguage];
		}
	}

	private void APIKLDFGKKC(GameObject KHAHPAKDIKE)
	{
		FBFJNHLKJEC = true;
		Hide();
	}

	private string CGJIDMBELPB(string INFLHPGMEOB)
	{
		if (LNFNFGMCDDF == "Id" && CBJFDHOOGPM.ContainsKey(INFLHPGMEOB))
		{
			return CBJFDHOOGPM[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "hashCode" && GEHBDBGNHLJ.ContainsKey(INFLHPGMEOB))
		{
			return GEHBDBGNHLJ[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "Client has newer config for: {0} Saved version {1} Client version {2}" && BBPNGCCDHLD.ContainsKey(INFLHPGMEOB))
		{
			return BBPNGCCDHLD[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "IsVip" && JELMOGJFGEE.ContainsKey(INFLHPGMEOB))
		{
			return JELMOGJFGEE[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "PlayerLevel" && FFHIAJBPAKN.ContainsKey(INFLHPGMEOB))
		{
			return FFHIAJBPAKN[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "OnAgeVerificationCriteriaMet" && NAGJMMGLGOK.ContainsKey(INFLHPGMEOB))
		{
			return NAGJMMGLGOK[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "ID_DOWNLOADINGFILES" && GMBLKDOAELE.ContainsKey(INFLHPGMEOB))
		{
			return GMBLKDOAELE[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "sc" && JOOOPNGDOPB.ContainsKey(INFLHPGMEOB))
		{
			return JOOOPNGDOPB[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "WarFriends" && LEIJMJHCJED.ContainsKey(INFLHPGMEOB))
		{
			return LEIJMJHCJED[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "Fuseboxx: Show offer for zone " && IAINHHHNHIJ.ContainsKey(INFLHPGMEOB))
		{
			return IAINHHHNHIJ[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "NewVisuals" && AKGBCBHIIHM.ContainsKey(INFLHPGMEOB))
		{
			return AKGBCBHIIHM[INFLHPGMEOB];
		}
		return (!HIINMLMEGKE.ContainsKey(INFLHPGMEOB)) ? INFLHPGMEOB : HIINMLMEGKE[INFLHPGMEOB];
	}

	public void BLJAIACCFCL()
	{
		title = NGIMHKLLOOG("Type");
		ILBPEOHGICC(FKOMDMIEOBB("워프렌즈는 이 추가 데이터를 다운로드 받지 않으면 실행할 수 없습니다. 정말 종료하시겠습니까? 아니면 데이터를 다운로드 받으시겠습니까?"));
		yesButtonText = NGIMHKLLOOG("ID_STARTERASSIGNMENTX");
		cancelButtonText = FKOMDMIEOBB("#DANIEL# Recording supported: ");
	}

	private void ININJGEEPIJ(GameObject KHAHPAKDIKE)
	{
		FBFJNHLKJEC = false;
		Hide();
	}

	[CompilerGenerated]
	private void GLJKNBDIEMJ(UITweener MGDJMGHCAAI)
	{
		base.gameObject.SetActive(true);
	}

	[SpecialName]
	public void ILBPEOHGICC(string IDEBKDPMPGM)
	{
		LLILKCJKNPH.text = IDEBKDPMPGM;
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IDCOKFKOFDI));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MCHAHCNOKPA));
		LNFNFGMCDDF = MFBAHECIOGF();
	}

	public void Show()
	{
		FBFJNHLKJEC = null;
		base.gameObject.SetActive(true);
		TweenAlpha.Begin(base.gameObject, 0.2f, 0f, 1f).onFinished = null;
	}

	[SpecialName]
	public void GHEOOODHPBH(string IDEBKDPMPGM)
	{
		FBOBOOKDJLO.text = IDEBKDPMPGM;
	}

	private string NGIMHKLLOOG(string INFLHPGMEOB)
	{
		if (LNFNFGMCDDF == "fr" && CBJFDHOOGPM.ContainsKey(INFLHPGMEOB))
		{
			return CBJFDHOOGPM[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "it" && GEHBDBGNHLJ.ContainsKey(INFLHPGMEOB))
		{
			return GEHBDBGNHLJ[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "de" && BBPNGCCDHLD.ContainsKey(INFLHPGMEOB))
		{
			return BBPNGCCDHLD[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "es" && JELMOGJFGEE.ContainsKey(INFLHPGMEOB))
		{
			return JELMOGJFGEE[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "br" && FFHIAJBPAKN.ContainsKey(INFLHPGMEOB))
		{
			return FFHIAJBPAKN[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "pt" && NAGJMMGLGOK.ContainsKey(INFLHPGMEOB))
		{
			return NAGJMMGLGOK[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "ru" && GMBLKDOAELE.ContainsKey(INFLHPGMEOB))
		{
			return GMBLKDOAELE[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "jp" && JOOOPNGDOPB.ContainsKey(INFLHPGMEOB))
		{
			return JOOOPNGDOPB[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "cn" && LEIJMJHCJED.ContainsKey(INFLHPGMEOB))
		{
			return LEIJMJHCJED[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "tc" && IAINHHHNHIJ.ContainsKey(INFLHPGMEOB))
		{
			return IAINHHHNHIJ[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "kr" && AKGBCBHIIHM.ContainsKey(INFLHPGMEOB))
		{
			return AKGBCBHIIHM[INFLHPGMEOB];
		}
		return (!HIINMLMEGKE.ContainsKey(INFLHPGMEOB)) ? INFLHPGMEOB : HIINMLMEGKE[INFLHPGMEOB];
	}

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(APIKLDFGKKC));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		LNFNFGMCDDF = GEOFADIFALA;
	}

	public void PEIFGGPNHMK()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(base.gameObject, 241f, 1123f, 244f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			base.gameObject.SetActive(true);
		});
	}

	public void SetRetryOrExitTexts()
	{
		title = NGIMHKLLOOG("CONFIRM");
		text = NGIMHKLLOOG("RETRYPERM");
		yesButtonText = NGIMHKLLOOG("RETRY");
		cancelButtonText = NGIMHKLLOOG("QUIT");
	}

	private void MCHAHCNOKPA(GameObject KHAHPAKDIKE)
	{
		FBFJNHLKJEC = false;
		PEIFGGPNHMK();
	}

	[SpecialName]
	public void GAIAKHCDCNM(string IDEBKDPMPGM)
	{
		LLILKCJKNPH.text = IDEBKDPMPGM;
	}

	public void PPAICMHHKOO()
	{
		title = FKOMDMIEOBB("menu-powerband-damage-ico");
		ILBPEOHGICC(CGJIDMBELPB("ID_SUBSCRIPTIONDETAILS"));
		BGMGLPNHFBO(NGIMHKLLOOG("shield_idle"));
		GHEOOODHPBH(NGIMHKLLOOG("shootAdditive"));
	}

	public void Hide()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(base.gameObject, 0.2f, 1f, 0f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			base.gameObject.SetActive(true);
		});
	}

	private void IDCOKFKOFDI(GameObject KHAHPAKDIKE)
	{
		FBFJNHLKJEC = false;
		Hide();
	}

	[SpecialName]
	public void BKEOKKMKFJN(string IDEBKDPMPGM)
	{
		NNGGEEFLIPE.text = IDEBKDPMPGM;
	}

	[SpecialName]
	private string ECFDFOLIAEJ()
	{
		Debug.Log(string.Format("SquadMembers", Application.systemLanguage));
		return (!JCLCJIHIPFA.ContainsKey(Application.systemLanguage)) ? "Total_Sessions" : JCLCJIHIPFA[Application.systemLanguage];
	}

	[SpecialName]
	public string EOKMBEJLJCA()
	{
		return DEHKFKDHMJD.text;
	}

	public void OFLIPLBGEGO()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(base.gameObject, 1452f, 1293f, 684f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			base.gameObject.SetActive(true);
		});
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IDCOKFKOFDI));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		LNFNFGMCDDF = GEOFADIFALA;
	}

	public void SetDownloadTexts()
	{
		title = NGIMHKLLOOG("CONFIRM");
		text = NGIMHKLLOOG("DOWNLOAD");
		yesButtonText = NGIMHKLLOOG("YES");
		cancelButtonText = NGIMHKLLOOG("NO");
	}

	private void MGGGIBOAIGC(GameObject KHAHPAKDIKE)
	{
		FBFJNHLKJEC = false;
		Hide();
	}

	[SpecialName]
	private string MFBAHECIOGF()
	{
		Debug.Log(string.Format("{0}{1}{2} {3}{4}", Application.systemLanguage));
		return (!JCLCJIHIPFA.ContainsKey(Application.systemLanguage)) ? "null" : JCLCJIHIPFA[Application.systemLanguage];
	}

	public void SetPermissionTexts()
	{
		title = NGIMHKLLOOG("CONFIRM");
		text = NGIMHKLLOOG("WarFriends");
		yesButtonText = NGIMHKLLOOG("OK");
		cancelButtonText = NGIMHKLLOOG("QUIT");
	}

	public void SetReallyDontDownloadTexts()
	{
		title = NGIMHKLLOOG("CONFIRM");
		text = NGIMHKLLOOG("WENEEDTO");
		yesButtonText = NGIMHKLLOOG("DOWNLOADBTN");
		cancelButtonText = NGIMHKLLOOG("QUIT");
	}

	public void KJLALGDJFHN()
	{
		BKEOKKMKFJN(NGIMHKLLOOG("Squad Entered Event"));
		GAIAKHCDCNM(NGIMHKLLOOG("country"));
		yesButtonText = CGJIDMBELPB("{0} {1}");
		GHEOOODHPBH(FKOMDMIEOBB(" "));
	}

	[SpecialName]
	public string JJMCFIDIBKH()
	{
		return DEHKFKDHMJD.text;
	}

	public void MAHCHHEBJDL()
	{
		OAHHMAAOADH(NGIMHKLLOOG("com/google/android/gms/common/ConnectionResult"));
		ILBPEOHGICC(CGJIDMBELPB("com/google/android/gms/common/ConnectionResult"));
		yesButtonText = NGIMHKLLOOG("offerMult");
		cancelButtonText = FKOMDMIEOBB("Enemy could not be spawned");
	}

	[SpecialName]
	public void OAHHMAAOADH(string IDEBKDPMPGM)
	{
		NNGGEEFLIPE.text = IDEBKDPMPGM;
	}

	[SpecialName]
	public string KKAIFKNPFII()
	{
		return DEHKFKDHMJD.text;
	}

	public void BPOEFALJCIH()
	{
		DOCFGADGKMC(FKOMDMIEOBB("Spawned by card:  progress:{0}, obj: {1},uu: {2} "));
		text = CGJIDMBELPB("MessageType");
		yesButtonText = CGJIDMBELPB("Player reconnected in CheckPlayersReconnectStates");
		GHEOOODHPBH(NGIMHKLLOOG("PlayerLevel"));
	}

	private void ADALNKMIALA(UITweener MGDJMGHCAAI)
	{
		base.gameObject.SetActive(true);
	}

	[SpecialName]
	public void DOCFGADGKMC(string IDEBKDPMPGM)
	{
		NNGGEEFLIPE.text = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BGMGLPNHFBO(string IDEBKDPMPGM)
	{
		DEHKFKDHMJD.text = IDEBKDPMPGM;
	}

	private string FKOMDMIEOBB(string INFLHPGMEOB)
	{
		if (LNFNFGMCDDF == "ERNEUT VERSUCHEN" && CBJFDHOOGPM.ContainsKey(INFLHPGMEOB))
		{
			return CBJFDHOOGPM[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "ID_FEATURE_RATE-FANCY" && GEHBDBGNHLJ.ContainsKey(INFLHPGMEOB))
		{
			return GEHBDBGNHLJ[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "Get player data: I SHOULD SEND PN DEVICET TOKEN" && BBPNGCCDHLD.ContainsKey(INFLHPGMEOB))
		{
			return BBPNGCCDHLD[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "N" && JELMOGJFGEE.ContainsKey(INFLHPGMEOB))
		{
			return JELMOGJFGEE[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "ChillingoSDK: Application is paused, closing session" && FFHIAJBPAKN.ContainsKey(INFLHPGMEOB))
		{
			return FFHIAJBPAKN[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "game-card-ico-backstab" && NAGJMMGLGOK.ContainsKey(INFLHPGMEOB))
		{
			return NAGJMMGLGOK[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "currentDogtags: " && GMBLKDOAELE.ContainsKey(INFLHPGMEOB))
		{
			return GMBLKDOAELE[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "GameController.LoadAndStartNewMap - InstantiatePooledObjects" && JOOOPNGDOPB.ContainsKey(INFLHPGMEOB))
		{
			return JOOOPNGDOPB[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "GameController.Start START" && LEIJMJHCJED.ContainsKey(INFLHPGMEOB))
		{
			return LEIJMJHCJED[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "ID_UPGRADEFORCHEAPER" && IAINHHHNHIJ.ContainsKey(INFLHPGMEOB))
		{
			return IAINHHHNHIJ[INFLHPGMEOB];
		}
		if (LNFNFGMCDDF == "ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT" && AKGBCBHIIHM.ContainsKey(INFLHPGMEOB))
		{
			return AKGBCBHIIHM[INFLHPGMEOB];
		}
		return (!HIINMLMEGKE.ContainsKey(INFLHPGMEOB)) ? INFLHPGMEOB : HIINMLMEGKE[INFLHPGMEOB];
	}
}
