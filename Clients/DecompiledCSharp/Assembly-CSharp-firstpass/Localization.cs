using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Internal/Localization")]
public class Localization : MonoBehaviour
{
	private static Localization mInstance;

	public UIFont mainFont;

	private Dictionary<string, string> mDictionary = new Dictionary<string, string>();

	private string mLanguage;

	private static Dictionary<string, float> languageMultiplier = new Dictionary<string, float>
	{
		{ "en", 1f },
		{ "fr", 1f },
		{ "it", 1f },
		{ "de", 1f },
		{ "es", 1f },
		{ "br", 1f },
		{ "pt", 1f },
		{ "ru", 1f },
		{ "jp", 1f },
		{ "cn", 1f },
		{ "tc", 1f },
		{ "kr", 1f }
	};

	private static Dictionary<SystemLanguage, string> systemLanguageConverter = new Dictionary<SystemLanguage, string>
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

	public static bool isActive => mInstance != null;

	public static Localization instance
	{
		get
		{
			if (mInstance == null)
			{
				mInstance = UnityEngine.Object.FindObjectOfType(typeof(Localization)) as Localization;
			}
			return mInstance;
		}
	}

	public string currentLanguage
	{
		get
		{
			return mLanguage;
		}
		set
		{
			if (!(mLanguage != value))
			{
				return;
			}
			if (!string.IsNullOrEmpty(value))
			{
				TextAsset assetForLanguage = GetAssetForLanguage(value);
				if (assetForLanguage != null)
				{
					Load(assetForLanguage);
					return;
				}
				TextAsset textAsset = Resources.Load(value, typeof(TextAsset)) as TextAsset;
				if (textAsset != null)
				{
					Load(textAsset);
					return;
				}
			}
			mDictionary.Clear();
			PlayerPrefs.DeleteKey("Language");
		}
	}

	public string nextLanguage
	{
		get
		{
			return PlayerPrefs.GetString("NextLanguage", deviceLanguage);
		}
		set
		{
			string text = value;
			TextAsset assetForLanguage = GetAssetForLanguage(text);
			if (assetForLanguage == null)
			{
				text = "en";
			}
			PlayerPrefs.SetString("NextLanguage", text);
		}
	}

	private string deviceLanguage
	{
		get
		{
			Debug.Log($"Device Language - android: {Application.systemLanguage}");
			return (!systemLanguageConverter.ContainsKey(Application.systemLanguage)) ? "en" : systemLanguageConverter[Application.systemLanguage];
		}
	}

	public static bool isEnglish => instance.mLanguage.ToLower() == "en";

	public static float languageConstant => (!(instance == null) && languageMultiplier != null && !string.IsNullOrEmpty(instance.currentLanguage) && languageMultiplier.ContainsKey(instance.currentLanguage)) ? languageMultiplier[instance.currentLanguage] : 1f;

	private TextAsset GetAssetForLanguage(string language)
	{
		TextAsset textAsset = Resources.Load<TextAsset>("Localizations/" + language);
		if (textAsset == null)
		{
			Debug.LogError($"Can not find text asset for {language}");
		}
		return textAsset;
	}

	private void Awake()
	{
		if (mInstance == null)
		{
			mInstance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			string text = nextLanguage;
			currentLanguage = text;
			if (string.IsNullOrEmpty(mLanguage))
			{
				currentLanguage = LanguageProperties.languages[0];
			}
			InitFont();
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void InitFont()
	{
		string empty = string.Empty;
		Debug.Log("Init font: " + currentLanguage);
		empty = ((currentLanguage == "kr") ? " !#%'()+,-./0123456789:<>?ABCDEFGHIKLMNOPQRSTUVWXY[]abcdefghiklmnopqrstuvwxy{}~ÇÊÑИЙКРСУ…中体文日本简繁語體가각간갈감갑갔강갖같갛개객갱거건걸검겁것겉게겟겠겨격견결경계고곤곧골곳공과관광괜괴교구국군굴궁권귀규균그극근글금급기길김깁까꺼께껴꼭꾸꿀꿈꿉꿔끄끊끕끝끼나낙난날남납낫났낮내낼냈냉냐냥너넌넣네넷녀녁노녹놀놈높놓놨뇌누눈눌눠뉩뉴느는늘능니닌님닙닛다닦단닫달답당대더던데도독돈돋돌돕동돼됐되된될됨됩두둑둘둠뒤듀드득든들듭등디딕딧따딱땀땅때땐떠떤떨떻또뛰뜨뜰뜻라락란랍랐랑래랩랫랭략량러런럼럿렇레렉렌렛려력련렬렴렸례로록론롭롯롱뢰료루류률르른를름릅리릭린릴림립릿마막만많말맙망맞맡매맨맵맷맹머먹먼멀멋메멤멧며면명몇모목몰몸못무묵문물미믿밀밍및바박밖반받발밝방밭배백밴밸버벅번벌범법벗베벤벨변별볍병보복본볼봇봐부분불붐붙브블비빅빈빛빠빨뽑뿔쁘사삭산살삼상새색생샷서석선설성세셔션셜소속손솔송쇄쇠숍수순술숨숫쉬쉽슈스슨슬습승시식신실싫심십싱싶싸써쏘쏴쓴쓸씩씬아악안않알암았애앱야약양어억언얻얼엄업없었에엔엘엠여역연열염영예오옥온올옮옵옷와완왔왠외요욕용우욱운울움웁웃워원월위윗유육율으은을음응의이익인일잃임입잇있잊자작잔잖잘잠잡장재쟁저적전절점접정제져졌조족존좀종좋좌죄죠주죽준줄줍중즈즉즐증지직진질집짓짧째쩔쪽차착찮찰참찼창찾채책챌챔처척천첨첩첫청체쳐쳤초총최추축출춥충취츠치친칠침카칵캐캡커컬컷케켓켜코콘쾌쿠크큰클큼키킬킵킷킹타탄탈탑태택탭탱터턱턴털테텐템토통퇴투튜트특튼티틱틴팀팅파판팔패팩팬팸팻팽퍼펀펍펑페펜편평폐포폭폼표푸풀품풍퓨프플피픽필하학한할함합항해핵했행향허험헤헬현혐협혔형혜호혹혼화확환활황회획횟효후훈훨훼희히힌힘힙" : ((currentLanguage == "jp") ? " !#%&()+,-./0123456789<>ABCDEFGHIJKLMNOPQRSTUVWXY[]abcdefghiklmnopqrstuvwxy{}ÇÊÑИЙКРСУ、。々「」あいうえおかがきぎくぐけげこごさざしじすずせぜそぞただちっつづてでとどなにねのはばぱびぴふへべほまみむめもゃやゆょよらりるれろわをんァアィイウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチッツテデトドナニネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョラリルレロワンヴ・ー一万上下不与世両中丸主久乱了予争事互交人今仕他付代以仲件任会位低体何作使供価侵便保信修俺倉個倍倒値偉停偽備催傷優元充先光児入全公共兵典内再処出分切初別利到制刺刻削前割力功加助効動務勝勢勧化北医半卑協単危即原参友反収取受口古可台右各合同名向君否含吹告周味命品員問善器回囲図圧在地型基報場増壊士変外多夜夢大太失奇契奪女奴好始威嬉子字存孤学宇守安完宗宙定実害家容寄寒寝察対専射尊導小少届屋属層嵐左己巻市希帰常広度庫延建弓引張強弾当影役彼径待後従得御復徴心必忍志忘応快怒怖急性恒悪悲情惑意愛感慈成我戦戻所手打承技投抜択押拒招拡拾持指挑掃掛採探接措提換揮援搬搭携撃支改攻放故敗教数敵文料断新方旅既日早昇明星春時暗暴更替最月有服望期未本来析枚果査栄核格案械棄検業極楽構様模権樽機次止正武歩死殊残殲殺毎毒民気求汗池決沈治況法注洗活流海消深混済減満準滅漠火炎点為烈無焦照爆物特状狙独猥獲率現理璧生用由甲申男画界留略番異疫病痛痺療癖発登的皆盗目直真眠眼着知短砂砲破硬確磨示票禁禄科秒秘移稼稿穴究空突立童端第筋答简箇管箱簡約納級素索細終組結絡続維緑緒編練縮績繁罠置罰羊美群習者耐耗耳聴肉背能脅脱腑自致般船良色苦荒華落葉薬虐蜂行術街表被装補複襲西要見規視親観角解言計討訓記設許訳証評試詳誉認誘語誠読誰課調請諾謝識警護象豪責貴買費賊購赤赦走起超足距身車軍転軽載輸辞辺込近迷追退送逃通速連週進遅運過道達違遠遣適遮選避邪部配酬重野量金録鏡長門閉開間関闘防降限除険陽隊隔際隠集離難雨雪雷電青非面響順領頭頻題願風飛食香騎驚體高髪鷲麻黙국어한！＆（）：？～" : ((currentLanguage == "cn") ? " #%()+,-./0123456789:<>?ABCDEFGHIJKLMNOPRSTUVWXYZ[]abcdefghiklnopqrstuvwxy{} ÇÊÑИЙКРСУ—“”、。《》一七万三上下不与丑专且世丛东丝丢两严丧个中丰为主丽举久么之乐九也乡买乱了予争事二于五些亡交产享亮人仅仇今仍从仔他付代以们仰件价任份众优伙会伞传伤伴但位低住体何作你佩佳使供侦侵便俗保信修倍候值假做停健偷傀储像僵儡儿允充先光克免入全八公六共关兴兵其具典兼内册再军冠冰冲决况冷冻准凉减几凯出击分切划列则刚创删利别到制前剩剪力功加务动助励势勇勋募包化匣区医匿十升午半协单占卡卫危即却厅历厚原去参又叉及友双反发取受变口古另只可台右各合同名后吐向吓吗否吧含启吸呀告员周命和品响哪唉售商喜喷嘉嘿器四回因团围固国图圣在地场圾均坏块坚坦垃型埋城基堆塔填境增墨士壮声处备复外多夜够大天太夫失头夺奇奖女她好如妙始姓威媒子字存学孩它守安完宗官定宝实客宣室害家容密察对寻导射将尉尊小少尔尖尘尚尝就尸尽尾局屏展山工左巧巨差己已巴巾币市布师希帐带帧帮常帽干平并广库应底店庞度康延建开弃式弓引张弹强当录形彩影彻往径待很得御微徽心必忍忘快态怎性总恢恨恭息恶悉悍悔您情惊惠惩想愉意感愿慢戏成我或战截戮戴户所手才打托扣执扩扰找技把抓投抗折护报披抱担拉拒拔拖招拥拦择括拳持指按挎挑挡捐损换据授掉排掠探接控推掩措掷提插援搜携摧播操支收改攻放效敌教数文斗料斡断斯新方施旅旋无日旦旧时昂明易星是昵显暂暇暴更最月有朋服望期未末本术机杀权杆村束杠条来松极构析林枚果枪架查柱标栈样核根格框梦械检棒榄榜槽模橄次欢欺款歉止正此步武死殊毁每毒比毫气水永求汇汉汗池汰沙没法注洁洗活派流测济海消液淘淫深混添清游源滑满漂漠漫潮激火灭灰炮炸点炼烈烦烧热焰然熄熊熟燃爆爱爽片版牌牙牛物牵特犯状狂狐狙独狼猎猛猪率王玩环现珍球理生用由甲申电男画界畏留略疑疗疫疯疾病痛痪瘟瘫登白百的益监盔盗目直相盾省看真眩眼着睛睡瞄瞧知短码破硬确碎磨示祖祝神禁福离私种科秒租积称移秽稀程稍空穿突窃窗立站竞章童端符笨第等筒答签简算管箭箱籍类粗粘精系索紧繁纠红级纪纳纵线练组细终经结给络绝统继绩绪续维绵绶绿编缠缩缴网罕罚罩置署羊美翻老者而耐耳聊职联肉肌肩胁背胖胜胡能脏脑脚脸自至致般舰船艇艰色节若英茄荒荣药获菜营落蓝藏虚蛇蛋蜂行衡衣补表被袭装西要见观规视角解触言誉語警计认让训议讯记许论设访评识诉词试话诞该详语误诱请诸诽谁调谢谤豹贝负责败质贬购贴贵费贼资赛赞赠赢走赶起超越趣足跃跑距跟踢踪蹄身躲车转轮轰轻载较辆辎输达迁迄过迎运近返还这进远违连迟迫迷退送适选透逐通速造逸遇道遭邀那邪部都配酒酷采里重野量金钟钩钮钱铃铜铠银销锁锋错键锯镜长门闭问间闹队阱防阳阵阻附际降限除险陷随隐难雄集雨雪雷需霰青非靠靡面音页顶项顺须顾领频题额风飞食饵馈首马驶驾验骑骗骚骤骷髅體高鱼鸡鸣鹰黄黑齐龙국어한！" : ((currentLanguage == "tc") ? " #%()+,-./0123456789:<>?ABCDEFGHIJKLMNOPRSTUVWXYZ[]abcdefghiklnopqrstuvwxy{} ÇÊÑИЙКРСУ—“”、。《》一七万三上下不与丑专且世丛东丝丢两严丧个中丰为主丽举久么之乐九也乡买乱了予争事二于五些亡交产享亮人仅仇今仍从仔他付代以们仰件价任份众优伙会伞传伤伴但位低住体何作你佩佳使供侦侵便俗保信修倍候值假做停健偷傀储像僵儡儿允充先光克免入全八公六共关兴兵其具典兼内册再军冠冰冲决况冷冻准凉减几凯出击分切划列则刚创删利别到制前剩剪力功加务动助励势勇勋募包化匣区医匿十升午半协单占卡卫危即却厅历厚原去参又叉及友双反发取受变口古另只可台右各合同名后吐向吓吗否吧含启吸呀告员周命和品响哪唉售商喜喷嘉嘿器四回因团围固国图圣在地场圾均坏块坚坦垃型埋城基堆塔填境增墨士壮声处备复外多夜够大天太夫失头夺奇奖女她好如妙始姓威媒子字存学孩它守安完宗官定宝实客宣室害家容密察对寻导射将尉尊小少尔尖尘尚尝就尸尽尾局屏展山工左巧巨差己已巴巾币市布师希帐带帧帮常帽干平并广库应底店庞度康延建开弃式弓引张弹强当录形彩影彻往径待很得御微徽心必忍忘快态怎性总恢恨恭息恶悉悍悔您情惊惠惩想愉意感愿慢戏成我或战截戮戴户所手才打托扣执扩扰找技把抓投抗折护报披抱担拉拒拔拖招拥拦择括拳持指按挎挑挡捐损换据授掉排掠探接控推掩措掷提插援搜携摧播操支收改攻放效敌教数文斗料斡断斯新方施旅旋无日旦旧时昂明易星是昵显暂暇暴更最月有朋服望期未末本术机杀权杆村束杠条来松极构析林枚果枪架查柱标栈样核根格框梦械检棒榄榜槽模橄次欢欺款歉止正此步武死殊毁每毒比毫气水永求汇汉汗池汰沙没法注洁洗活派流测济海消液淘淫深混添清游源滑满漂漠漫潮激火灭灰炮炸点炼烈烦烧热焰然熄熊熟燃爆爱爽片版牌牙牛物牵特犯状狂狐狙独狼猎猛猪率王玩环现珍球理生用由甲申电男画界畏留略疑疗疫疯疾病痛痪瘟瘫登白百的益监盔盗目直相盾省看真眩眼着睛睡瞄瞧知短码破硬确碎磨示祖祝神禁福离私种科秒租积称移秽稀程稍空穿突窃窗立站竞章童端符笨第等筒答签简算管箭箱籍类粗粘精系索紧繁纠红级纪纳纵线练组细终经结给络绝统继绩绪续维绵绶绿编缠缩缴网罕罚罩置署羊美翻老者而耐耳聊职联肉肌肩胁背胖胜胡能脏脑脚脸自至致般舰船艇艰色节若英茄荒荣药获菜营落蓝藏虚蛇蛋蜂行衡衣补表被袭装西要见观规视角解触言誉語警计认让训议讯记许论设访评识诉词试话诞该详语误诱请诸诽谁调谢谤豹贝负责败质贬购贴贵费贼资赛赞赠赢走赶起超越趣足跃跑距跟踢踪蹄身躲车转轮轰轻载较辆辎输达迁迄过迎运近返还这进远违连迟迫迷退送适选透逐通速造逸遇道遭邀那邪部都配酒酷采里重野量金钟钩钮钱铃铜铠银销锁锋错键锯镜长门闭问间闹队阱防阳阵阻附际降限除险陷随隐难雄集雨雪雷需霰青非靠靡面音页顶项顺须顾领频题额风飞食饵馈首马驶驾验骑骗骚骤骷髅體高鱼鸡鸣鹰黄黑齐龙국어한！" : ((currentLanguage == "ru") ? " !#%()+,-./0123456789:<>?ABCDEFGHIKLMNOPRSTUVWXY[]abcdefghiklmnopqrstuvwxy{}ÇÊÑАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюя—中体文日本简繁語體국어한" : ((currentLanguage == "it") ? " !#%'()+,-./0123456789:<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[]abcdefghijklmnopqrstuvwxyz{}ª°ºÀÇÈÉÊÌÑÙàèéìòùИЙКРСУ中体文日本简繁語體국어한" : ((currentLanguage == "fr") ? " !#%&'()+,-./0123456789:<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[]abcdefghijklmnopqrstuvwxyz{}\u0081 ÀÂÇÈÉÊÎÏÑÔÛàâçèéêëîïôùûœИЙКРСУ–’…中体文日本简繁語體국어한" : ((currentLanguage == "es") ? " !#%'()+,-./0123456789:;<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[]abcdefghijklmnopqrstuvwxyz{} ¡ªº¿ÁÇÉÊÍÑÓÚáéíñóúИЙКРСУ中体文日本简繁語體국어한" : ((currentLanguage == "de") ? " !#%&'()+,-./0123456789:;<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[]abcdefghijklmnopqrstuvwxyz{} ÄÇÊÑÖÜßäíöüИЙКРСУ…中体文日本简繁語體국어한" : ((currentLanguage == "br") ? " !#%&()+,-./0123456789:<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[]abcdefghijklmnopqrstuvwxyz{}ÀÁÂÃÇÉÊÍÑÓÔÕÚáâãçéêíóôõúИЙКРСУ中体文日本简繁語體국어한" : ((!(currentLanguage == "pt")) ? " !#%&'()+,-./0123456789:<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[]abcdefghijklmnopqrstuvwxyz{}ÇÊÑИЙКРСУ中体文日本简繁語體국어한" : " !#%(),-./0123456789:<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ[]abcdefghijklmnopqrstuvwxyz{}ªÀÁÂÃÇÉÊÍÑÓÔÕÚàáâãçéêíóôõúИЙКРСУ中体文日本简繁語體국어한")))))))))));
		mainFont.RequestCharacters(empty, 40);
		mainFont.RequestCharacters(empty, 80);
	}

	private void OnEnable()
	{
		if (mInstance == null)
		{
			mInstance = this;
		}
	}

	private void OnDestroy()
	{
		if (mInstance == this)
		{
			mInstance = null;
		}
	}

	private void Load(TextAsset asset)
	{
		mLanguage = asset.name;
		PlayerPrefs.SetString("Language", mLanguage);
		ByteReader byteReader = new ByteReader(asset);
		mDictionary = byteReader.ReadDictionary();
		UIRoot.Broadcast("OnLocalize", this);
	}

	public string Get(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return string.Empty;
		}
		string value;
		return (!mDictionary.TryGetValue(key, out value)) ? key : value;
	}

	public static string Localize(string key)
	{
		return (!(instance != null)) ? key : instance.Get(key);
	}

	public static string LocalizeFormat(string keyFormat, params object[] args)
	{
		if (instance == null)
		{
			return keyFormat;
		}
		string text = instance.Get(keyFormat);
		if (text == keyFormat)
		{
			Crittercism.LeaveBreadcrumb($"Localization do not exists or is the same as key: {keyFormat}");
			return keyFormat;
		}
		try
		{
			return string.Format(text, args);
		}
		catch (Exception e)
		{
			Crittercism.LeaveBreadcrumb($"Translation ID {keyFormat} contains errors ({text}).");
			Crittercism.LogHandledException(e);
			return keyFormat;
		}
	}
}
