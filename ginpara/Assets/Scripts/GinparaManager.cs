using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// さんご礁の出現場所
/// </summary>
public enum CORAL_POSITION
{
    LEFT,   // 左 
    CENTER, // 中央
    RIGHT   // 右
}

/// <summary>
/// 役割を多く担いすぎているので、分割すべき
/// </summary>
public class GinparaManager : MonoBehaviour
{
    public UITextureManager back = null;
	public UITextureManager lamp1 = null;
	public UITextureManager lamp6 = null;
	public UITextureManager lamp7 = null;
	public UITextureManager lamp8 = null;
	public UITextureManager pull11 = null;
	public UITextureManager lampCircle2 = null;
	public UITextureManager lampCircle3 = null;
	public Rail topRail = null;
	public Rail mediumRail = null;
	public Rail belowRail = null;
	public UIAnchor railAreaAnchor = null;
	public UITexture background = null;
	public UIAnchor backgroundAnchor = null;
	public Texture[] backgroundTexture = null;
	public UIAnchor bubbleNoticeAnchor = null;
	public UIAnchor shoalNoticeAnchor = null;
	public UIAnchor coralReefNoticeAnchor = null;
	public UIAnchor marinNoticeCallAnchor = null;
	public TextureAnimation marinNoticeCallAnime = null;
	public UIAnchor marinNoticeWinAnchor = null;
	public TextureAnimation marinNoticeWinAnime = null;
	public UIAnchor marinNoticeLoseAnchor = null;
	public TextureAnimation marinNoticeLoseAnime = null;
	public UIAnchor marinShakeHandAnchor = null;
	public TextureAnimation marinShakeHandAnime = null;
	public UIAnchor marinBrownAnchor = null;
	public TextureAnimation marinSBrownAnime = null;
	public UIAnchor loseBubbleAnchor = null;
	public TextureAnimation loseBubbleAnime = null;
	public UIAnchor lostStringAnchor = null;
	public TextureAnimation lostStringAnime = null;
	public TextureAnimation luckyStringAnime = null;
	public UIAnchor marinPeaceAnchor = null;
	public TextureAnimation marinPeaceAnime = null;
	public TextureAnimation rollBubble = null;
	public TextureAnimation bonusPicture = null;
	public UITexture bonusPictureNum = null;
	public GameObject bonusPictureBase = null;
	public UITexture bonusRound = null;
	public UITexture bonusRoundBase = null;
	public List<Texture> picture1 = null;
	public List<Texture> picture2 = null;
	public List<Texture> picture3 = null;
	public List<Texture> picture4 = null;
	public List<Texture> picture5 = null;
	public List<Texture> picture6 = null;
	public List<Texture> picture7 = null;
	public List<Texture> picture8 = null;
	public List<Texture> picture9 = null;
	public List<Texture> picture10 = null;
	public Texture[] roundtexture = null;
	public Texture[] numTexture = null;
	public TextureAnimation marinFinishAnime = null;
	public UIAnchor marinFinishAnchor = null;
	public GameObject bonusFinishBackground = null;
	public GameObject bonusFinishLabel = null;
    public GameObject WhiteScreen = null;
	private float deltaTime = 0;
#if UNITY_EDITOR
	private string orderCode = string.Empty;
#endif

    static GinparaManager _instance;

    /// <summary>
    /// インスタンス取得メソッド
    /// </summary>
    /// <returns>ギンパラマネージャー</returns>
    public static GinparaManager GetInstance()
    {
        return _instance;
    }

    public static GinparaManager Instance
    {
        get { return _instance; }
    }

	void Start()
    {
        _instance = this.gameObject.GetComponent<GinparaManager>();
	}
	
	void Update()
    {
		this.deltaTime = Time.deltaTime;

#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            if (this.orderCode.Length > 0)
            {
                this.orderCode = this.orderCode.Substring(0, this.orderCode.Length - 1);
            }
        }
		if(Input.GetKeyUp(KeyCode.Alpha0)){
			this.orderCode += "0";
		}
		if(Input.GetKeyUp(KeyCode.Alpha1)){
			this.orderCode += "1";
		}
		if(Input.GetKeyUp(KeyCode.Alpha2)){
			this.orderCode += "2";
		}
		if(Input.GetKeyUp(KeyCode.Alpha3)){
			this.orderCode += "3";
		}
		if(Input.GetKeyUp(KeyCode.Alpha4)){
			this.orderCode += "4";
		}
		if(Input.GetKeyUp(KeyCode.Alpha5)){
			this.orderCode += "5";
		}
		if(Input.GetKeyUp(KeyCode.Alpha6)){
			this.orderCode += "6";
		}
		if(Input.GetKeyUp(KeyCode.Alpha7)){
			this.orderCode += "7";
		}
		if(Input.GetKeyUp(KeyCode.Alpha8)){
			this.orderCode += "8";
		}
		if(Input.GetKeyUp(KeyCode.Alpha9)){
			this.orderCode += "9";
		}
		if(Input.GetKeyUp(KeyCode.Minus)){
			this.orderCode += "-";
		}
		if(Input.GetKeyUp(KeyCode.Return)){
			this.Order (this.orderCode);
			this.orderCode = string.Empty;
		}
#endif
	}

    struct SP
    {
        public int certainNum;
        public int lowNum;
    }

    // ダブルリーチ用
    Dictionary<string, SP> DoubleReach = new Dictionary<string, SP>()
    {
        // －１コマハズレ用
        {"8-61", new SP{ certainNum=35, lowNum=3}},
        {"8-62", new SP{ certainNum=36, lowNum=3}},
        {"8-63", new SP{ certainNum=37, lowNum=3}},
        {"8-64", new SP{ certainNum=38, lowNum=3}},
        {"8-65", new SP{ certainNum=39, lowNum=3}},
        {"8-66", new SP{ certainNum=40, lowNum=3}},
        {"8-67", new SP{ certainNum=41, lowNum=3}},
        {"8-68", new SP{ certainNum=42, lowNum=3}},
        {"8-69", new SP{ certainNum=43, lowNum=3}},
        {"8-70", new SP{ certainNum=44, lowNum=3}},
        {"8-71", new SP{ certainNum=45, lowNum=3}},
        {"8-72", new SP{ certainNum=46, lowNum=3}},
        {"8-73", new SP{ certainNum=27, lowNum=3}},
        {"8-74", new SP{ certainNum=28, lowNum=3}},
        {"8-75", new SP{ certainNum=29, lowNum=3}},
        {"8-76", new SP{ certainNum=30, lowNum=3}},
        {"8-77", new SP{ certainNum=31, lowNum=3}},
        {"8-78", new SP{ certainNum=32, lowNum=3}},
        {"8-79", new SP{ certainNum=33, lowNum=3}},
        {"8-80", new SP{ certainNum=34, lowNum=3}},

        // 前図柄大当り用
        {"8-81", new SP{ certainNum=36, lowNum=4}},
        {"8-82", new SP{ certainNum=37, lowNum=4}},
        {"8-83", new SP{ certainNum=38, lowNum=4}},
        {"8-84", new SP{ certainNum=39, lowNum=4}},
        {"8-85", new SP{ certainNum=40, lowNum=4}},
        {"8-86", new SP{ certainNum=41, lowNum=4}},
        {"8-87", new SP{ certainNum=42, lowNum=4}},
        {"8-88", new SP{ certainNum=43, lowNum=4}},
        {"8-89", new SP{ certainNum=44, lowNum=4}},
        {"8-90", new SP{ certainNum=45, lowNum=4}},
        {"8-91", new SP{ certainNum=46, lowNum=4}},
        {"8-92", new SP{ certainNum=47, lowNum=4}},
        {"8-93", new SP{ certainNum=28, lowNum=4}},
        {"8-94", new SP{ certainNum=29, lowNum=4}},
        {"8-95", new SP{ certainNum=30, lowNum=4}},
        {"8-96", new SP{ certainNum=31, lowNum=4}},
        {"8-97", new SP{ certainNum=32, lowNum=4}},
        {"8-98", new SP{ certainNum=33, lowNum=4}},
        {"8-99", new SP{ certainNum=34, lowNum=4}},
        {"8-100", new SP{ certainNum=35, lowNum=4}},
    
        // 前図柄+1コマハズレ用
        {"8-101", new SP{ certainNum=33, lowNum=5}},
        {"8-102", new SP{ certainNum=34, lowNum=5}},
        {"8-103", new SP{ certainNum=35, lowNum=5}},
        {"8-104", new SP{ certainNum=36, lowNum=5}},
        {"8-105", new SP{ certainNum=37, lowNum=5}},
        {"8-106", new SP{ certainNum=38, lowNum=5}},
        {"8-107", new SP{ certainNum=39, lowNum=5}},
        {"8-108", new SP{ certainNum=40, lowNum=5}},
        {"8-109", new SP{ certainNum=41, lowNum=5}},
        {"8-110", new SP{ certainNum=42, lowNum=5}},
        {"8-111", new SP{ certainNum=43, lowNum=5}},
        {"8-112", new SP{ certainNum=44, lowNum=5}},
        {"8-113", new SP{ certainNum=25, lowNum=5}},
        {"8-114", new SP{ certainNum=26, lowNum=5}},
        {"8-115", new SP{ certainNum=27, lowNum=5}},
        {"8-116", new SP{ certainNum=28, lowNum=5}},
        {"8-117", new SP{ certainNum=29, lowNum=5}},
        {"8-118", new SP{ certainNum=30, lowNum=5}},
        {"8-119", new SP{ certainNum=31, lowNum=5}},
        {"8-120", new SP{ certainNum=32, lowNum=5}},

        // 後ろ図柄大当り用
        {"8-121", new SP{ certainNum=34, lowNum=6}},
        {"8-122", new SP{ certainNum=35, lowNum=6}},
        {"8-123", new SP{ certainNum=36, lowNum=6}},
        {"8-124", new SP{ certainNum=37, lowNum=6}},
        {"8-125", new SP{ certainNum=38, lowNum=6}},
        {"8-126", new SP{ certainNum=39, lowNum=6}},
        {"8-127", new SP{ certainNum=40, lowNum=6}},
        {"8-128", new SP{ certainNum=41, lowNum=6}},
        {"8-129", new SP{ certainNum=42, lowNum=6}},
        {"8-130", new SP{ certainNum=43, lowNum=6}},
        {"8-131", new SP{ certainNum=44, lowNum=6}},
        {"8-132", new SP{ certainNum=45, lowNum=6}},
        {"8-133", new SP{ certainNum=26, lowNum=6}},
        {"8-134", new SP{ certainNum=27, lowNum=6}},
        {"8-135", new SP{ certainNum=28, lowNum=6}},
        {"8-136", new SP{ certainNum=29, lowNum=6}},
        {"8-137", new SP{ certainNum=30, lowNum=6}},
        {"8-138", new SP{ certainNum=31, lowNum=6}},
        {"8-139", new SP{ certainNum=32, lowNum=6}},
        {"8-140", new SP{ certainNum=33, lowNum=6}},

        // 後ろ図柄+1コマハズレ用
        {"8-141", new SP{ certainNum=31, lowNum=7}},
        {"8-142", new SP{ certainNum=32, lowNum=7}},
        {"8-143", new SP{ certainNum=33, lowNum=7}},
        {"8-144", new SP{ certainNum=34, lowNum=7}},
        {"8-145", new SP{ certainNum=35, lowNum=7}},
        {"8-146", new SP{ certainNum=36, lowNum=7}},
        {"8-147", new SP{ certainNum=37, lowNum=7}},
        {"8-148", new SP{ certainNum=38, lowNum=7}},
        {"8-149", new SP{ certainNum=39, lowNum=7}},
        {"8-150", new SP{ certainNum=40, lowNum=7}},
        {"8-151", new SP{ certainNum=41, lowNum=7}},
        {"8-152", new SP{ certainNum=42, lowNum=7}},
        {"8-153", new SP{ certainNum=23, lowNum=7}},
        {"8-154", new SP{ certainNum=24, lowNum=7}},
        {"8-155", new SP{ certainNum=25, lowNum=7}},
        {"8-156", new SP{ certainNum=26, lowNum=7}},
        {"8-157", new SP{ certainNum=27, lowNum=7}},
        {"8-158", new SP{ certainNum=28, lowNum=7}},
        {"8-159", new SP{ certainNum=29, lowNum=7}},
        {"8-160", new SP{ certainNum=30, lowNum=7}},
    };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="patternNo">実行するパターンNo</param>
    /// <param name="callback">実行完了後（またはループ開始時）に呼ばれるコールバック</param>
    /// <returns>発生したエラー内容を返します（普通は null が返ります）</returns>
    public string Order(string patternNo, System.Action callback = null)
    {
        var errorCode = null as string;
        var EnsyutuNo = -1;
        var SubNo = -1;

        if (patternNo.Contains("-"))
        {
            // サブNOあり
            var splitArray = patternNo.Split('-');
            EnsyutuNo = int.Parse(splitArray[0]);
            SubNo = int.Parse(splitArray[1]);
        }
        else
        {
            // サブNOなし
            EnsyutuNo = int.Parse(patternNo);
        }

        // ダブルリーチ用演出8-61～8-160
        if (EnsyutuNo == 8 && (61 <= SubNo) && (SubNo <= 160))
        {
            var dr = DoubleReach[patternNo];
            StartCoroutine(this.mediumRail.RailSuperReach(dr.certainNum, dr.lowNum, callback));
            return errorCode;
        }

        // 魚が喜ぶ演出 902-1 ～ 902-10
        if (EnsyutuNo == 902)
        {
            StartCoroutine(HappyFish(SubNo, callback));
            return errorCode;
        }

		switch (patternNo) {
		case "1":
			this.Order ("39-0");
			this.Order ("39-1");
			this.Order ("40-1");
			this.Order ("41-1");
			this.Order ("42-1");
			this.Order ("43-1");
			this.Order ("44-1");
			this.Order ("45-1");
			this.Order ("46-1");
			this.Order ("47-1");
			this.Order ("48-1");
			StartCoroutine(this.topRail.RailStart(() => {
				if(callback != null) callback();
			}));
			break;

		case "2":
			this.Order ("39-0");
			this.Order ("39-1");
			this.Order ("40-1");
			this.Order ("41-1");
			this.Order ("42-1");
			this.Order ("43-1");
			this.Order ("44-1");
			this.Order ("45-1");
			this.Order ("46-1");
			this.Order ("47-1");
			this.Order ("48-1");
			StartCoroutine(this.mediumRail.RailStart(() => {
				if(callback != null) callback();
			}));
			break;

		case "3":
			this.Order ("39-0");
			this.Order ("39-1");
			this.Order ("40-1");
			this.Order ("41-1");
			this.Order ("42-1");
			this.Order ("43-1");
			this.Order ("44-1");
			this.Order ("45-1");
			this.Order ("46-1");
			this.Order ("47-1");
			this.Order ("48-1");
			StartCoroutine(this.belowRail.RailStart(() => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-1":
			StartCoroutine (this.topRail.RailStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-2":
			StartCoroutine (this.topRail.RailStop (-10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-3":
			StartCoroutine (this.topRail.RailStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-4":
			StartCoroutine (this.topRail.RailStop (-9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-5":
			StartCoroutine (this.topRail.RailStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-6":
			StartCoroutine (this.topRail.RailStop (-8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-7":
			StartCoroutine (this.topRail.RailStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-8":
			StartCoroutine (this.topRail.RailStop (-7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-9":
			StartCoroutine (this.topRail.RailStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-10":
			StartCoroutine (this.topRail.RailStop (-6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-11":
			StartCoroutine (this.topRail.RailStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-12":
			StartCoroutine (this.topRail.RailStop (-5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-13":
			StartCoroutine (this.topRail.RailStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-14":
			StartCoroutine (this.topRail.RailStop (-4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-15":
			StartCoroutine (this.topRail.RailStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-16":
			StartCoroutine (this.topRail.RailStop (-3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-17":
			StartCoroutine (this.topRail.RailStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-18":
			StartCoroutine (this.topRail.RailStop (-2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-19":
			StartCoroutine (this.topRail.RailStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-20":
            StartCoroutine(this.topRail.RailStop(-1, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-1":
            StartCoroutine(this.mediumRail.StopAfter1Turn(1, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-2":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-1, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-3":
            StartCoroutine(this.mediumRail.StopAfter1Turn(2, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-4":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-2, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-5":
            StartCoroutine(this.mediumRail.StopAfter1Turn(3, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-6":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-3, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-7":
            StartCoroutine(this.mediumRail.StopAfter1Turn(4, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-8":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-4, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-9":
            StartCoroutine(this.mediumRail.StopAfter1Turn(5, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-10":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-5, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-11":
            StartCoroutine(this.mediumRail.StopAfter1Turn(6, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-12":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-6, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-13":
            StartCoroutine(this.mediumRail.StopAfter1Turn(7, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-14":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-7, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-15":
            StartCoroutine(this.mediumRail.StopAfter1Turn(8, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-16":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-8, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-17":
            StartCoroutine(this.mediumRail.StopAfter1Turn(9, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-18":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-9, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-19":
            StartCoroutine(this.mediumRail.StopAfter1Turn(10, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "5-20":
            StartCoroutine(this.mediumRail.StopAfter1Turn(-10, () =>
            {
				if(callback != null) callback();
			}));
			break;
			
		case "6-1":
			StartCoroutine (this.belowRail.RailStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-2":
			StartCoroutine (this.belowRail.RailStop (-1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-3":
			StartCoroutine (this.belowRail.RailStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-4":
			StartCoroutine (this.belowRail.RailStop (-2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-5":
			StartCoroutine (this.belowRail.RailStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-6":
			StartCoroutine (this.belowRail.RailStop (-3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-7":
			StartCoroutine (this.belowRail.RailStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-8":
			StartCoroutine (this.belowRail.RailStop (-4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-9":
			StartCoroutine (this.belowRail.RailStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-10":
			StartCoroutine (this.belowRail.RailStop (-5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-11":
			StartCoroutine (this.belowRail.RailStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-12":
			StartCoroutine (this.belowRail.RailStop (-6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-13":
			StartCoroutine (this.belowRail.RailStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-14":
			StartCoroutine (this.belowRail.RailStop (-7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-15":
			StartCoroutine (this.belowRail.RailStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-16":
			StartCoroutine (this.belowRail.RailStop (-8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-17":
			StartCoroutine (this.belowRail.RailStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-18":
			StartCoroutine (this.belowRail.RailStop (-9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-19":
			StartCoroutine (this.belowRail.RailStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-20":
			StartCoroutine (this.belowRail.RailStop (-10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-1":
			StartCoroutine (this.mediumRail.RailReach (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-2":
			StartCoroutine (this.mediumRail.RailReach (20, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-3":
			StartCoroutine (this.mediumRail.RailReach (21, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-4":
			StartCoroutine (this.mediumRail.RailReach (22, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-5":
			StartCoroutine (this.mediumRail.RailReach (23, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-6":
			StartCoroutine (this.mediumRail.RailReach (24, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-7":
			StartCoroutine (this.mediumRail.RailReach (25, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-8":
			StartCoroutine (this.mediumRail.RailReach (26, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-9":
			StartCoroutine (this.mediumRail.RailReach (27, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-10":
			StartCoroutine (this.mediumRail.RailReach (28, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-11":
			StartCoroutine (this.mediumRail.RailReach (29, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-12":
			StartCoroutine (this.mediumRail.RailReach (30, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-13":
			StartCoroutine (this.mediumRail.RailReach (31, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-14":
			StartCoroutine (this.mediumRail.RailReach (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-15":
			StartCoroutine (this.mediumRail.RailReach (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-16":
			StartCoroutine (this.mediumRail.RailReach (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-17":
			StartCoroutine (this.mediumRail.RailReach (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-18":
			StartCoroutine (this.mediumRail.RailReach (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-19":
			StartCoroutine (this.mediumRail.RailReach (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-20":
			StartCoroutine (this.mediumRail.RailReach (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-1":
			StartCoroutine (this.mediumRail.RailSuperReach (39, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-2":
			StartCoroutine (this.mediumRail.RailSuperReach (40, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-3":
			StartCoroutine (this.mediumRail.RailSuperReach (41, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-4":
			StartCoroutine (this.mediumRail.RailSuperReach (42, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-5":
			StartCoroutine (this.mediumRail.RailSuperReach (43, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-6":
			StartCoroutine (this.mediumRail.RailSuperReach (44, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-7":
			StartCoroutine (this.mediumRail.RailSuperReach (45, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-8":
			StartCoroutine (this.mediumRail.RailSuperReach (46, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-9":
			StartCoroutine (this.mediumRail.RailSuperReach (47, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-10":
			StartCoroutine (this.mediumRail.RailSuperReach (48, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-11":
			StartCoroutine (this.mediumRail.RailSuperReach (49, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-12":
			StartCoroutine (this.mediumRail.RailSuperReach (50, 1, () => {
				if(callback != null) callback();
			}));
			break;

		case "8-13":
			StartCoroutine (this.mediumRail.RailSuperReach (31, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-14":
			StartCoroutine (this.mediumRail.RailSuperReach (32, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-15":
			StartCoroutine (this.mediumRail.RailSuperReach (33, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-16":
			StartCoroutine (this.mediumRail.RailSuperReach (34, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-17":
			StartCoroutine (this.mediumRail.RailSuperReach (35, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-18":
			StartCoroutine (this.mediumRail.RailSuperReach (36, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-19":
			StartCoroutine (this.mediumRail.RailSuperReach (37, 1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-20":
			StartCoroutine (this.mediumRail.RailSuperReach (38, 1, () => {
				if(callback != null) callback();
			}));
			break;

		case "8-21":
			StartCoroutine (this.mediumRail.RailSuperReach (38, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-22":
			StartCoroutine (this.mediumRail.RailSuperReach (39, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-23":
			StartCoroutine (this.mediumRail.RailSuperReach (40, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-24":
			StartCoroutine (this.mediumRail.RailSuperReach (41, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-25":
			StartCoroutine (this.mediumRail.RailSuperReach (42, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-26":
			StartCoroutine (this.mediumRail.RailSuperReach (43, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-27":
			StartCoroutine (this.mediumRail.RailSuperReach (44, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-28":
			StartCoroutine (this.mediumRail.RailSuperReach (45, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-29":
			StartCoroutine (this.mediumRail.RailSuperReach (46, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-30":
			StartCoroutine (this.mediumRail.RailSuperReach (47, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-31":
			StartCoroutine (this.mediumRail.RailSuperReach (48, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-32":
			StartCoroutine (this.mediumRail.RailSuperReach (49, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-33":
			StartCoroutine (this.mediumRail.RailSuperReach (30, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-34":
			StartCoroutine (this.mediumRail.RailSuperReach (31, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-35":
			StartCoroutine (this.mediumRail.RailSuperReach (32, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-36":
			StartCoroutine (this.mediumRail.RailSuperReach (33, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-37":
			StartCoroutine (this.mediumRail.RailSuperReach (34, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-38":
			StartCoroutine (this.mediumRail.RailSuperReach (35, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-39":
			StartCoroutine (this.mediumRail.RailSuperReach (36, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-40":
			StartCoroutine (this.mediumRail.RailSuperReach (37, 2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-41":
			StartCoroutine (this.mediumRail.RailSuperReach (37, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-42":
			StartCoroutine (this.mediumRail.RailSuperReach (38, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-43":
			StartCoroutine (this.mediumRail.RailSuperReach (39, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-44":
			StartCoroutine (this.mediumRail.RailSuperReach (40, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-45":
			StartCoroutine (this.mediumRail.RailSuperReach (41, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-46":
			StartCoroutine (this.mediumRail.RailSuperReach (42, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-47":
			StartCoroutine (this.mediumRail.RailSuperReach (43, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-48":
			StartCoroutine (this.mediumRail.RailSuperReach (44, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-49":
			StartCoroutine (this.mediumRail.RailSuperReach (45, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-50":
			StartCoroutine (this.mediumRail.RailSuperReach (46, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-51":
			StartCoroutine (this.mediumRail.RailSuperReach (47, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-52":
			StartCoroutine (this.mediumRail.RailSuperReach (48, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-53":
			StartCoroutine (this.mediumRail.RailSuperReach (29, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-54":
			StartCoroutine (this.mediumRail.RailSuperReach (30, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-55":
			StartCoroutine (this.mediumRail.RailSuperReach (31, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-56":
			StartCoroutine (this.mediumRail.RailSuperReach (32, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-57":
			StartCoroutine (this.mediumRail.RailSuperReach (33, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-58":
			StartCoroutine (this.mediumRail.RailSuperReach (34, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-59":
			StartCoroutine (this.mediumRail.RailSuperReach (35, 3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-60":
			StartCoroutine (this.mediumRail.RailSuperReach (36, 3, () => {
				if(callback != null) callback();
			}));
			break;

        // ダブルリーチ用追加				

        // ダブルリーチ用追加				
	
		case "9-1":
			this.Order("7-2", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-2":
			this.Order ("7-3", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-3":
			this.Order ("7-4", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-4":
			this.Order ("7-5", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-5":
			this.Order ("7-6", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-6":
			this.Order ("7-7", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-7":
			this.Order ("7-8", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-8":
			this.Order ("7-9", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-9":
			this.Order ("7-10", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-10":
			this.Order ("7-11", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-11":
			this.Order ("7-12", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-12":
			this.Order ("7-13", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-13":
			this.Order ("7-14", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-14":
			this.Order ("7-15", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-15":
			this.Order ("7-16", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-16":
			this.Order ("7-17", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-17":
			this.Order ("7-18", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-18":
			this.Order ("7-19", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "9-19":
			this.Order ("7-20", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-1":
			this.Order ("7-3", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-2":
			this.Order ("7-4", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
					if(callback != null) callback();
				}));
				});
			break;
			
		case "10-3":
			this.Order ("7-5", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-4":
			this.Order ("7-6", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-5":
			this.Order ("7-7", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-6":
			this.Order ("7-8", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-7":
			this.Order ("7-9", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-8":
			this.Order ("7-10", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-9":
			this.Order ("7-11", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-10":
			this.Order ("7-12", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-11":
			this.Order ("7-13", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-12":
			this.Order ("7-14", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
					if(callback != null) callback();
				}));
			});	
			break;
			
		case "10-13":
			this.Order ("7-15", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-14":
			this.Order ("7-16", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-15":
			this.Order ("7-17", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-16":
			this.Order ("7-18", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-17":
			this.Order ("7-19", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-18":
			this.Order ("7-20", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "10-19":
			this.Order ("7-1", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-1":
			this.Order ("7-4", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-2":
			this.Order ("7-5", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-3":
			this.Order ("7-6", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-4":
			this.Order ("7-7", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-5":
			this.Order ("7-8", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-6":
			this.Order ("7-9", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-7":
			this.Order ("7-10", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-8":
			this.Order ("7-11", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-9":
			this.Order ("7-12", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-10":
			this.Order ("7-13", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-11":
			this.Order ("7-14", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-12":
			this.Order ("7-15", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-13":
			this.Order ("7-16", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-14":
			this.Order ("7-17", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-15":
			this.Order ("7-18", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-16":
			this.Order ("7-19", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-17":
			this.Order ("7-20", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-18":
			this.Order ("7-1", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "11-19":
			this.Order ("7-2", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-1":
			this.Order ("7-5", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-2":
			this.Order ("7-6", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-3":
			this.Order ("7-7", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-4":
			this.Order ("7-8", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-5":
			this.Order ("7-9", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-6":
			this.Order ("7-10", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-7":
			this.Order ("7-11", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-8":
			this.Order ("7-12", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-9":
			this.Order ("7-13", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-10":
			this.Order ("7-14", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-11":
			this.Order ("7-15", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-12":
			this.Order ("7-16", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-13":
			this.Order ("7-17", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-14":
			this.Order ("7-18", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-15":
			this.Order ("7-19", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-16":
			this.Order ("7-20", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-17":
			this.Order ("7-1", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-18":
			this.Order ("7-2", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "12-19":
			this.Order ("7-3", () => {
				StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
					if(callback != null) callback();
				}));
			});
			break;
			
		case "13-1":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-2":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-3":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-4":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-5":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-6":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-7":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-8":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-9":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-10":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-11":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-12":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-13":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-14":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-15":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-16":
			this.Order ("7-1", () => {
			this.mediumRail.ResetAnchor(3);
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-17":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-18":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "13-19":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-1":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-2":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-3":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-4":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-5":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-6":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-7":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-8":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-9":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-10":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-11":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-12":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-13":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-14":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-15":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-16":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-17":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-18":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "14-19":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-1":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-2":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-3":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-4":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-5":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-6":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-7":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-8":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-9":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-10":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-11":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-12":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-13":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-14":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-15":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-16":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-17":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-18":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "15-19":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-1":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-2":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-3":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-4":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-5":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-6":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-7":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-8":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-9":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-10":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-11":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-12":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-13":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-14":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-15":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-16":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-17":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-18":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "16-19":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-1":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-2":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-3":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-4":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-5":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-6":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-7":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-8":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-9":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-10":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-11":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-12":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-13":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-14":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-15":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-16":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-17":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-18":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "17-19":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-1":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-2":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-3":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-4":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-5":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-6":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-7":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-8":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-9":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-10":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-11":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-12":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-13":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-14":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-15":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-16":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-17":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-18":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "18-19":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-1":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-2":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-3":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-4":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-5":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-6":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-7":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-8":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-9":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-10":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-11":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-12":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-13":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-14":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-15":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-16":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-17":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-18":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "19-19":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-1":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-2":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-3":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-4":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-5":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-6":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-7":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-8":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-9":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-10":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-11":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-12":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-13":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-14":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-15":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-16":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-17":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-18":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "20-19":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-1":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-2":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-3":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-4":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-5":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-6":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-7":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-8":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-9":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-10":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-11":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-12":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-13":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-14":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-15":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-16":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-17":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-18":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "21-19":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-1":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-2":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-3":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-4":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-5":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-6":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-7":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-8":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-9":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-10":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-11":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-12":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-13":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-14":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-15":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-16":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-17":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-18":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "22-19":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-1":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-2":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-3":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-4":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-5":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-6":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-7":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-8":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-9":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-10":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-11":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-12":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-13":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-14":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-15":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-16":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-17":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-18":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "23-19":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-1":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-2":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-3":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-4":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-5":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-6":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-7":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-8":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-9":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-10":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-11":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-12":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-13":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-14":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-15":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-16":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-17":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-18":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "24-19":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-1":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-2":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-3":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-4":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-5":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-6":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-7":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-8":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-9":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-10":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-11":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-12":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-13":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-14":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-15":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-16":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-17":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-18":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "25-19":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-1":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-2":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-3":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-4":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-5":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-6":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-7":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-8":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-9":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-10":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-11":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-12":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-13":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-14":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-15":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-16":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-17":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-18":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "26-19":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-1":
			this.Order ("7-20", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-2":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-3":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-4":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-5":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-6":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-7":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-8":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-9":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-10":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-11":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-12":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-13":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-14":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-15":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-16":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-17":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-18":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "27-19":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-1":
			this.Order ("7-1", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-2":
			this.Order ("7-2", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-3":
			this.Order ("7-3", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-4":
			this.Order ("7-4", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-5":
			this.Order ("7-5", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-6":
			this.Order ("7-6", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-7":
			this.Order ("7-7", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-8":
			this.Order ("7-8", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-9":
			this.Order ("7-9", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-10":
			this.Order ("7-10", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-11":
			this.Order ("7-11", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-12":
			this.Order ("7-12", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-13":
			this.Order ("7-13", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-14":
			this.Order ("7-14", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-15":
			this.Order ("7-15", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-16":
			this.Order ("7-16", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-17":
			this.Order ("7-17", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-18":
			this.Order ("7-18", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "28-19":
			this.Order ("7-19", () => {
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			});
			break;
			
		case "29-1":
		case "29-2":
		case "29-3":
		case "29-4":
		case "29-5":
			this.topRail.ChangeHitPicture(1);
			this.mediumRail.ChangeHitPicture(1);
			this.belowRail.ChangeHitPicture(1);
			break;
			
		case "30-1":
		case "30-2":
		case "30-3":
		case "30-4":
		case "30-5":
			this.topRail.ChangeHitPicture(2);
			this.mediumRail.ChangeHitPicture(2);
			this.belowRail.ChangeHitPicture(2);
			break;
			
		case "31-1":
		case "31-2":
		case "31-3":
		case "31-4":
		case "31-5":
			this.topRail.ChangeHitPicture(3);
			this.mediumRail.ChangeHitPicture(3);
			this.belowRail.ChangeHitPicture(3);
			break;
			
		case "32-1":
		case "32-2":
		case "32-3":
		case "32-4":
		case "32-5":
			this.topRail.ChangeHitPicture(4);
			this.mediumRail.ChangeHitPicture(4);
			this.belowRail.ChangeHitPicture(4);
			break;
			
		case "33-1":
		case "33-2":
		case "33-3":
		case "33-4":
		case "33-5":
			this.topRail.ChangeHitPicture(5);
			this.mediumRail.ChangeHitPicture(5);
			this.belowRail.ChangeHitPicture(5);
			break;
			
		case "34-1":
		case "34-2":
		case "34-3":
		case "34-4":
		case "34-5":
			this.topRail.ChangeHitPicture(6);
			this.mediumRail.ChangeHitPicture(6);
			this.belowRail.ChangeHitPicture(6);
			break;
			
		case "35-1":
		case "35-2":
		case "35-3":
		case "35-4":
		case "35-5":
			this.topRail.ChangeHitPicture(7);
			this.mediumRail.ChangeHitPicture(7);
			this.belowRail.ChangeHitPicture(7);
			break;
			
		case "36-1":
		case "36-2":
		case "36-3":
		case "36-4":
		case "36-5":
			this.topRail.ChangeHitPicture(8);
			this.mediumRail.ChangeHitPicture(8);
			this.belowRail.ChangeHitPicture(8);
			break;
			
		case "37-1":
		case "37-2":
		case "37-3":
		case "37-4":
		case "37-5":
			this.topRail.ChangeHitPicture(9);
			this.mediumRail.ChangeHitPicture(9);
			this.belowRail.ChangeHitPicture(9);
			break;
			
		case "38-1":
		case "38-2":
		case "38-3":
		case "38-4":
		case "38-5":
			this.topRail.ChangeHitPicture(10);
			this.mediumRail.ChangeHitPicture(10);
			this.belowRail.ChangeHitPicture(10);
			break;

        case "39-0":
			this.topRail.StartAnime (0);
			this.mediumRail.StartAnime (0);
			this.belowRail.StartAnime (0);
			break;

		case "39-1":
			this.topRail.StartAnime (1);
			this.mediumRail.StartAnime (1);
			this.belowRail.StartAnime (1);
			break;
			
		case "40-1":
			this.topRail.StartAnime (2);
			this.mediumRail.StartAnime (2);
			this.belowRail.StartAnime (2);
			break;
			
		case "41-1":
			this.topRail.StartAnime (3);
			this.mediumRail.StartAnime (3);
			this.belowRail.StartAnime (3);
			break;
			
		case "42-1":
			this.topRail.StartAnime (4);
			this.mediumRail.StartAnime (4);
			this.belowRail.StartAnime (4);
			break;
			
		case "43-1":
			this.topRail.StartAnime (5);
			this.mediumRail.StartAnime (5);
			this.belowRail.StartAnime (5);
			break;
			
		case "44-1":
			this.topRail.StartAnime (6);
			this.mediumRail.StartAnime (6);
			this.belowRail.StartAnime (6);
			break;
			
		case "45-1":
			this.topRail.StartAnime (7);
			this.mediumRail.StartAnime (7);
			this.belowRail.StartAnime (7);
			break;
			
		case "46-1":
			this.topRail.StartAnime (8);
			this.mediumRail.StartAnime (8);
			this.belowRail.StartAnime (8);
			break;
			
		case "47-1":
			this.topRail.StartAnime (9);
			this.mediumRail.StartAnime (9);
			this.belowRail.StartAnime (9);
			break;
			
		case "48-1":
			this.topRail.StartAnime (10);
			this.mediumRail.StartAnime (10);
			this.belowRail.StartAnime (10);
			break;
			
		case "101":
            Background.Instance.ChangeTexture(this.backgroundTexture[0]);
			if(callback != null) callback();
			break;
			
		case "102":
            Background.Instance.ChangeTexture(this.backgroundTexture[1]);
			if(callback != null) callback();
			break;
			
		case "103":
            Background.Instance.ChangeTexture(this.backgroundTexture[2]);
			if(callback != null) callback();
			break;
			
		case "104":
            Bubble.Instance.Rise();
			//this.bubbleNoticeAnchor.transform.gameObject.SetActive (true);
			StartCoroutine (this.BubbleNotice (callback));
			break;
			
		case "105":
            Gyogun.Instance.Flow();
			//this.shoalNoticeAnchor.transform.gameObject.SetActive (true);
			StartCoroutine (this.GyogunInDisplay (callback));
			break;
			
        // さんご礁左IN
		case "106-1":
			this.coralReefNoticeAnchor.transform.gameObject.SetActive (true);
            StartCoroutine(this.CoralReefNoticeIN(CORAL_POSITION.LEFT, callback));
			break;

        // さんご礁左OUT
		case "106-2":
			this.coralReefNoticeAnchor.transform.gameObject.SetActive (true);
            StartCoroutine(this.CoralReefNoticeOUT(CORAL_POSITION.LEFT, callback));
			break;

        // さんご礁中央IN
        case "106-3":
            this.coralReefNoticeAnchor.transform.gameObject.SetActive(true);
            StartCoroutine(this.CoralReefNoticeIN(CORAL_POSITION.CENTER, callback));
            break;

        // さんご礁中央OUT
        case "106-4":
            this.coralReefNoticeAnchor.transform.gameObject.SetActive(true);
            StartCoroutine(this.CoralReefNoticeOUT(CORAL_POSITION.CENTER, callback));
            break;

        // さんご礁右IN
        case "106-5":
            this.coralReefNoticeAnchor.transform.gameObject.SetActive(true);
            StartCoroutine(this.CoralReefNoticeIN(CORAL_POSITION.RIGHT, callback));
            break;

        // さんご礁右OUT
        case "106-6":
            this.coralReefNoticeAnchor.transform.gameObject.SetActive(true);
            StartCoroutine(this.CoralReefNoticeOUT(CORAL_POSITION.RIGHT, callback));
            break;

        // マリン降臨
		case "107-1":
			StartCoroutine (this.MarinNoticeIN(callback));
			break;
			
		case "107-2":
			break;
			
		case "107-3":
			break;
		
	    // マリン上昇
		case "107-4":
			StartCoroutine (this.MarinNoticeUpOUT(callback));
			break;
			
		case "108-1":
			break;
			
		case "108-2":
			break;
			
		case "201":
            Background.Instance.up();
			StartCoroutine (this.DisplayUpper (callback));
			break;

        // リールが下がった状態から元に戻す
        case "201-2":
            Background.Instance.down();
			StartCoroutine (this.DisplayDowner (callback));
			break;

		case "202":
			StartCoroutine (this.MarinShakeHand (callback));
			break;
			
		case "203":
            MarinLose.Instance.Display();
			this.loseBubbleAnchor.transform.gameObject.SetActive (true);
			StartCoroutine(this.MarinBrown(callback));
			break;
		
        case "203-2":
            MarinLose.Instance.Hide();
			this.loseBubbleAnchor.transform.gameObject.SetActive (false);
			if(callback!=null){callback();};
			break;

		case "204":
			//this.lostStringAnchor.transform.gameObject.SetActive (true);
            LostSprite.Instance.Show();
			//StartCoroutine(this.LostString(callback));
			break;

        case "204-2":
            LostSprite.Instance.Hide();
			//this.lostStringAnchor.transform.gameObject.SetActive (false);
			//if(callback!=null){callback();};
			break;

		// マリンピース開始
		case "301":
			this.rollBubble.transform.gameObject.SetActive (true);
            BataashiMarin.Instance.Display();
			StartCoroutine(this.MarinPeaceStart(callback));
			StartCoroutine(this.RollBubbleStart(callback));
			break;
		
        // マリンピース終了
        // だったが、ラウンド中もマリン表示するので、
        // マリンは消さずに泡だけ表示する
        case "301-2":
			this.rollBubble.transform.gameObject.SetActive (false);
            Lucky.Instance.Hide();
            //BataashiMarin.Instance.Hide();
			this.MarinPeaceStop(callback);
			this.RollBubbleStop(callback);
            break;

        // バタ足マリンを消す
        case "301-3":
            BataashiMarin.Instance.Hide();
            break;

        // ラッキー
		case "302":
            Lucky.Instance.Show();
			break;

        // 図柄表示消す
        case "401-0":
            AtariZugara.Instance.Hide();
			if(callback != null) callback();
            break;

	    // 図柄１
		case "401-1":
            AtariZugara.Instance.Display(AtariZugara.Kind.z1);
			if(callback != null) callback();
			break;
			
		case "401-2":
            AtariZugara.Instance.Display(AtariZugara.Kind.z2);
			if(callback != null) callback();
			break;
			
		case "401-3":
            AtariZugara.Instance.Display(AtariZugara.Kind.z3);
			if(callback != null) callback();
			break;
			
		case "401-4":
            AtariZugara.Instance.Display(AtariZugara.Kind.z4);
			if(callback != null) callback();
			break;
			
		case "401-5":
            AtariZugara.Instance.Display(AtariZugara.Kind.z5);
			if(callback != null) callback();
			break;
			
		case "401-6":
            AtariZugara.Instance.Display(AtariZugara.Kind.z6);
			if(callback != null) callback();
			break;
			
		case "401-7":
            AtariZugara.Instance.Display(AtariZugara.Kind.z7);
			if(callback != null) callback();
			break;
			
		case "401-8":
            AtariZugara.Instance.Display(AtariZugara.Kind.z8);
			if(callback != null) callback();
			break;
			
		case "401-9":
            AtariZugara.Instance.Display(AtariZugara.Kind.z9);
			if(callback != null) callback();
			break;

        // 当たり図柄１０表示
		case "401-10":
            AtariZugara.Instance.Display(AtariZugara.Kind.z10);
			if(callback != null) callback();
			break;

        case "402-0":
            RoundDisplay.Instance.hide();
			if(callback != null) callback();
			break;

		case "402-1":
            RoundDisplay.Instance.display(1);
			if(callback != null) callback();
			break;
			
		case "402-2":
            RoundDisplay.Instance.display(2);
			if(callback != null) callback();
			break;
			
		case "402-3":
            RoundDisplay.Instance.display(3);
			if(callback != null) callback();
			break;
			
		case "402-4":
            RoundDisplay.Instance.display(4);
			if(callback != null) callback();
			break;
			
		case "402-5":
            RoundDisplay.Instance.display(5);
			if(callback != null) callback();
			break;
			
		case "402-6":
            RoundDisplay.Instance.display(6);
			if(callback != null) callback();
			break;
			
		case "402-7":
            RoundDisplay.Instance.display(7);
			if(callback != null) callback();
			break;
			
		case "402-8":
            RoundDisplay.Instance.display(8);
			if(callback != null) callback();
			break;
			
		case "402-9":
            RoundDisplay.Instance.display(9);
			if(callback != null) callback();
			break;
			
		case "402-10":
            RoundDisplay.Instance.display(10);
			if(callback != null) callback();
			break;
			
		case "402-11":
            RoundDisplay.Instance.display(11);
			if(callback != null) callback();
			break;
			
		case "402-12":
            RoundDisplay.Instance.display(12);
			if(callback != null) callback();
			break;
			
		case "402-13":
            RoundDisplay.Instance.display(13);
			if(callback != null) callback();
			break;
			
		case "402-14":
            RoundDisplay.Instance.display(14);
			if(callback != null) callback();
			break;
			
		case "402-15":
            RoundDisplay.Instance.display(15);
			if(callback != null) callback();
			break;
			
		case "402-16":
            RoundDisplay.Instance.display(16);
			if(callback != null) callback();
			break;
			
		case "403":
			//this.bonusPicture.transform.gameObject.SetActive (false);
			//this.bonusPictureNum.transform.gameObject.SetActive(false);
			//this.bonusPictureBase.transform.gameObject.SetActive (false);
			//this.bonusRound.transform.gameObject.SetActive(false);
			//this.bonusRoundBase.transform.gameObject.SetActive(false);
			
			//this.bonusFinishBackground.transform.gameObject.SetActive (true);
			//this.bonusFinishLabel.transform.gameObject.SetActive (true);
			//this.marinFinishAnime.transform.gameObject.SetActive (true);
			StartCoroutine (this.BonusFinish(callback));
			break;
			
		case "501":
			if(this.back.transform.gameObject.activeSelf){
				this.back.StopAnim ();
				this.back.textureNum = 0;
			}else{
				this.lamp1.StopAnim ();
				this.lamp1.textureNum = 0;
				this.lamp6.StopAnim ();
				this.lamp6.textureNum = 0;
				this.lamp7.StopAnim ();
				this.lamp7.textureNum = 0;
				this.lamp8.StopAnim ();
				this.lamp8.textureNum = 0;
			}
			this.pull11.StopAnim ();
			this.pull11.textureNum = 0;
			this.lampCircle2.StopAnim ();
			this.lampCircle2.textureNum = 0;
			this.lampCircle3.StopAnim ();
			this.lampCircle3.textureNum = 0;

			if(callback != null) callback();
			break;
			
		case "502":
			if(this.back.transform.gameObject.activeSelf){
				this.back.StopAnim ();
				this.back.textureNum = 1;
			}else{
				this.lamp1.StopAnim ();
				this.lamp1.textureNum = 1;
				this.lamp6.StopAnim ();
				this.lamp6.textureNum = 1;
				this.lamp7.StopAnim ();
				this.lamp7.textureNum = 1;
				this.lamp8.StopAnim ();
				this.lamp8.textureNum = 1;
			}
			this.pull11.StopAnim ();
			this.pull11.textureNum = 1;
			this.lampCircle2.StopAnim ();
			this.lampCircle2.textureNum = 1;
			this.lampCircle3.StopAnim ();
			this.lampCircle3.textureNum = 1;
			
			if(callback != null) callback();
			break;
			
		case "503":
			if(this.back.transform.gameObject.activeSelf){
				this.back.PlayAnim (0);
			}else{
				this.lamp1.PlayAnim (0);
				this.lamp6.PlayAnim (0);
				this.lamp7.PlayAnim (0);
				this.lamp8.PlayAnim (0);
			}
			this.pull11.PlayAnim (0);
			this.lampCircle2.PlayAnim (0);
			this.lampCircle3.PlayAnim (0);
			
			if(callback != null) callback();
			break;
			
		case "504":
			if(this.back.transform.gameObject.activeSelf){
				this.back.PlayAnim (1);
			}else{
				this.lamp1.PlayAnim (1);
				this.lamp6.PlayAnim (1);
				this.lamp7.PlayAnim (1);
				this.lamp8.PlayAnim (1);
			}
			this.pull11.PlayAnim (1);
			this.lampCircle2.PlayAnim (1);
			this.lampCircle3.PlayAnim (1);
			
			if(callback != null) callback();
			break;
			
		case "505":
			if(this.back.transform.gameObject.activeSelf){
				this.back.PlayAnim (2);
			}else{
				this.lamp1.PlayAnim (2);
				this.lamp6.PlayAnim (2);
				this.lamp7.PlayAnim (2);
				this.lamp8.PlayAnim (2);
			}
			this.pull11.PlayAnim (2);
			this.lampCircle2.PlayAnim (2);
			this.lampCircle3.PlayAnim (2);
			
			if(callback != null) callback();
			break;

        case "901":
            // ホワイトアウト
            WhiteScreen.GetComponent<PlayMakerFSM>().SendEvent("ホワイトアウト");
            if (callback != null) callback();
            break;

		default:
			errorCode = "指定コードが間違えています";
            Debug.LogWarning("指定コードが間違えています　要求されたコード:" + patternNo);
			break;
		}

		return errorCode;
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator BubbleNotice(System.Action callback){
		float totalTime = 0;
		while(totalTime < 1f){
			float time = Time.deltaTime;
			totalTime += time;
			float xValue = 0;
			if(totalTime < 0.3f)
				xValue = -0.03f;
			else if(totalTime < 0.7f)
				xValue = -0.14f;
			else
				xValue = -0.03f;
				
			this.bubbleNoticeAnchor.relativeOffset += new Vector2(time * xValue, time * 2f);
			yield return null;
		}
		this.bubbleNoticeAnchor.relativeOffset = new Vector2(0, -1f);
		this.bubbleNoticeAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}

	/// <summary>
	/// 魚群
	/// </summary>
	/// <param name="callback"></param>
	/// <returns></returns>
	private IEnumerator GyogunInDisplay(System.Action callback){
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.shoalNoticeAnchor.relativeOffset -= new Vector2(time * 1.5f, 0);
			yield return null;
		}
		this.shoalNoticeAnchor.relativeOffset = new Vector2(1.5f, 0);
		this.shoalNoticeAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}

	/// <summary>
	/// さんご礁イン
	/// </summary>
	/// <param name="position"></param>
	/// <param name="callback"></param>
	/// <returns></returns>
    private IEnumerator CoralReefNoticeIN(CORAL_POSITION position, System.Action callback)
    {
		this.coralReefNoticeAnchor.relativeOffset = new Vector2(0, -1.7f);
		var anchorX = 0f;

        switch (position)
        {
            case CORAL_POSITION.LEFT:
                anchorX = -0.333f;
                break;
            case CORAL_POSITION.CENTER:
                anchorX = 0f;
                break;
            case CORAL_POSITION.RIGHT:
                anchorX = 0.333f;
                break;
        }
		this.coralReefNoticeAnchor.relativeOffset = new Vector2(anchorX, this.coralReefNoticeAnchor.relativeOffset.y);

		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.coralReefNoticeAnchor.relativeOffset += new Vector2(0, time * 0.5f);
			yield return null;
		}
		if(callback != null) callback();
	}
	
    /// <summary>
    /// さんご礁アウト
    /// </summary>
    /// <param name="position"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    private IEnumerator CoralReefNoticeOUT(CORAL_POSITION position, System.Action callback)
    {
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.coralReefNoticeAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			yield return null;
		}
		
		this.coralReefNoticeAnchor.relativeOffset = new Vector2(0, -1.2f);
		this.coralReefNoticeAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}

	/// <summary>
	/// マリン降臨
	/// </summary>
	/// <param name="callback"></param>
	/// <returns></returns>
	private IEnumerator MarinNoticeIN(System.Action callback){

        //this.marinNoticeCallAnime.Play(null);
        Marin.Instance.display();
		if(callback != null) callback();

        yield return null;
	}

	/// <summary>
	/// マリン上昇
	/// </summary>
	/// <param name="callback"></param>
	/// <returns></returns>
	private IEnumerator MarinNoticeUpOUT(System.Action callback){

        //this.marinNoticeCallAnime.Stop(null);
        Marin.Instance.hide();
		if(callback != null) callback();

        yield return null;

    }

	//----------------------------------------------------------------------------------------------------
	private IEnumerator DisplayUpper(System.Action callback){
		float totalTime = 0;
		while(totalTime < 6f){
			float time = Time.deltaTime;
			totalTime += time;
			float value = this.railAreaAnchor.relativeOffset.y - (this.deltaTime / 5f);
			this.railAreaAnchor.relativeOffset = new Vector2(this.railAreaAnchor.relativeOffset.x ,value);
			yield return null;
		}

		if(callback != null) callback();
	}

    //----------------------------------------------------------------------------------------------------
    // 液晶を大当たりから通常に戻す
    private IEnumerator DisplayDowner(System.Action callback)
    {
        float totalTime = 0;
        while (totalTime < 6f)
        {
            float time = Time.deltaTime;
            totalTime += time;
            float value = this.railAreaAnchor.relativeOffset.y + (this.deltaTime / 5f);
            this.railAreaAnchor.relativeOffset = new Vector2(this.railAreaAnchor.relativeOffset.x, value);
            yield return null;
        }

        if (callback != null) callback();
    }
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator MarinShakeHand(System.Action callback){
        /*
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.marinShakeHandAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			yield return null;
		}
		
		this.marinShakeHandAnime.Play (null);
		
		while(this.marinShakeHandAnime.IsAnimating)
			yield return null;
		
		this.marinShakeHandAnchor.relativeOffset = new Vector2(0, 0);
		this.marinShakeHandAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
         */

        yield return null;
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator MarinBrown(System.Action callback){
        /*
		this.marinSBrownAnime.Play (null);
		this.loseBubbleAnime.Play (null);
		
		while(this.marinSBrownAnime.IsAnimating  ||  this.loseBubbleAnime.IsAnimating)
			yield return null;
		
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.loseBubbleAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			this.marinBrownAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			yield return null;
		}
		
		this.marinBrownAnchor.relativeOffset = new Vector2(0, 0);
		this.loseBubbleAnchor.relativeOffset = new Vector2(0, 0);
		this.loseBubbleAnchor.transform.gameObject.SetActive (false);
		this.marinBrownAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
         */

        yield return null;
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator LostString(System.Action callback){
		this.lostStringAnime.Play (null);
		
		while(this.lostStringAnime.IsAnimating  ||  this.loseBubbleAnime.IsAnimating)
			yield return null;
		
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.lostStringAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			yield return null;
		}
		
		this.lostStringAnchor.relativeOffset = new Vector2(0, 0);
		this.lostStringAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}

	/// <summary>
	/// マリンピース開始
	/// </summary>
	/// <param name="callback"></param>
	/// <returns></returns>
	private IEnumerator MarinPeaceStart(Action callback){
        /*
        this.marinPeaceAnime.TotalTime = -1f;
        this.marinPeaceAnime.IsLoop = true;
		this.marinPeaceAnime.Play (null);
		
		while(this.marinPeaceAnime.IsAnimating  ||  this.loseBubbleAnime.IsAnimating)
			yield return null;
		
		//this.marinPeaceAnchor.relativeOffset = new Vector2(0, 0);
		this.marinPeaceAnchor.transform.gameObject.SetActive (false);
         */
		if(callback != null) callback();
        yield return null;
	}

    /// <summary>
    /// マリンピース停止
    /// </summary>
    /// <param name="callback"></param>
    private void MarinPeaceStop(Action callback)
    {
        this.marinPeaceAnime.Stop(null);
    }

    /// <summary>
    /// 泡回転開始
    /// </summary>
    /// <param name="callback"></param>
    /// <returns></returns>
	private IEnumerator RollBubbleStart(Action callback){
        this.rollBubble.TotalTime = -1f;
        this.rollBubble.IsLoop = true;
        this.rollBubble.Play(null);
		
		while(this.rollBubble.IsAnimating  ||  this.loseBubbleAnime.IsAnimating){
			this.rollBubble.transform.Rotate (0, 0, -90f * this.deltaTime);
			yield return null;
		}
		
		this.rollBubble.transform.localRotation = new Quaternion();
		this.rollBubble.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}

    /// <summary>
    /// 泡回転終了
    /// </summary>
    /// <param name="callback"></param>
    private void RollBubbleStop(Action callback)
    {
        this.rollBubble.Stop(null);
    }

	private IEnumerator BonusFinish(System.Action callback)
    {
        /*
		this.marinFinishAnime.Play( ()=> {
			this.marinFinishAnchor.relativeOffset = new Vector2(-0.35f, 0);
			this.marinFinishAnime.transform.gameObject.SetActive (false);
			this.bonusFinishBackground.transform.gameObject.SetActive (false);
			this.bonusFinishLabel.transform.gameObject.SetActive (false);
			if(callback != null) callback();
		});
		
		while(this.marinFinishAnime.IsAnimating){
			this.marinFinishAnchor.relativeOffset += new Vector2(this.deltaTime * 0.35f / 3f, 0);
			yield return null;
		}
        */
        yield return null;
	}

    /// <summary>
    /// 魚が喜ぶ演出
    /// </summary>
    /// <param name="Tokuzu">特図（１～１０）</param>
    /// <param name="callback">演出完了コールバック</param>
    /// <returns></returns>
    private IEnumerator HappyFish( int Tokuzu, System.Action callback )
    {
        // 演出No29→１図柄 No38→10図柄
        var EnsyutuMainNo = (Tokuzu + 28).ToString();
        foreach (var count in Enumerable.Range(0, 3))
        {
            foreach (var subNo in Enumerable.Range(1, 5))
            {
                var EnsyutuNo = EnsyutuMainNo + "-" + subNo.ToString();
                this.Order(EnsyutuNo);
                yield return new WaitForSeconds(0.25f);
            }
        }
        if (callback != null) callback();
        yield return null;
    }

    Queue<Action> gensokuQueue = new Queue<Action>();

    public void RegistGensokuAction(Action action)
    {
        gensokuQueue.Enqueue(action);
    }

    public Action DequeueGensokuAction()
    {
        if (gensokuQueue.Count == 0)
        {
            return null;
        }

        Action action;
        while ((action = gensokuQueue.Dequeue()) != null)
        {
            return action;
        }
        return null;
    }

	//----------------------------------------------------------------------------------------------------
	#if UNITY_EDITOR
	void OnGUI(){
		GUILayout.Label ("パターンNoを入力（Enterで実行） : " + this.orderCode, GUILayout.Height (Screen.height / 5));
	}
	#endif
}
