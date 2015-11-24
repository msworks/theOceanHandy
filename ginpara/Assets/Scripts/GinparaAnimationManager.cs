using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
GinparaAnimationManager.cs
created by k-sasaki

盤面アニメーション管理用クラス
シングルトン
演出NOを渡すことで対応するアニメーションを起動します
渡された演出ナンバーをキューに格納し順に起動します 

****使い方****
AnimationListに対象のゲームオブジェクトをインスペクターからセットしてください
AnimationNameListに再生したいクリップのファイルをセットしてください（AnimationListに紐づいたelementNO）

SendMessengerにはSendMesseageでメソッドをよびたいときに書いてください.再生時に処理されます
AnimationStopClipListにクリップをセットするとストップ命令時に再生されます

演出の再生 runAnimation(int index)
演出の停止 stopAniamtion(int index)
*************
*/

public class GinparaAnimationManager : MonoBehaviour {
	[SerializeField] List<GameObject> m_AnimationObjectList = new List<GameObject>();
	[SerializeField] List<AnimationClip> m_AnimationClipList = new List<AnimationClip>();
	[SerializeField] List<AnimationClip> m_AnimationStopClipList = new List<AnimationClip>();
	[SerializeField] List<string> m_SendMessengerList = new List<string>();
	Dictionary<int , WrapMode> m_DefaultWrapModeDict = new Dictionary<int , WrapMode>();


	static GinparaAnimationManager _Instance;
	private Queue m_ActionQue = new Queue();
	void Awake(){
		_Instance = this;
	}

	static public GinparaAnimationManager getInstance(){
		return _Instance;
	}

	// Use this for initialization
	void Start () {
		//ループモードの初期設定を保存
		for(int i = 0; i < m_AnimationClipList.Count ; i++){
			if(m_AnimationObjectList[i]){
				m_DefaultWrapModeDict.Add(i,m_AnimationClipList[i].wrapMode); 
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//キューを消化 
		while(m_ActionQue.Count > 0){
			Dictionary<string , int> eventDict = (Dictionary<string , int>)m_ActionQue.Dequeue ();
			bool isPlay = ( eventDict["isPlay"] != 0 )? true : false;
			run ((int)eventDict["index"] , isPlay);
		}
	}

	//アニメーションの起動 
	public void runAnimation(int index ){
		Dictionary<string , int> eventDict = new Dictionary<string , int>();
		eventDict.Add ("index" , index);//演出noを格納 
		eventDict.Add ("isPlay" , 1);//再生の有無を格納 

		m_ActionQue.Enqueue(eventDict);//キューに格納 
	}

	//アニメーションの停止 
	public void stopAnimation(int index ){
		Dictionary<string , int> eventDict = new Dictionary<string , int>();
		eventDict.Add ("index" , index);//演出noを格納 
		eventDict.Add ("isPlay" , 0);//再生の有無を格納 

		m_ActionQue.Enqueue(eventDict);//キューに格納 
	}

	//演出noごとの動作指定 
	void run(int index , bool isPlay){
		if (!m_AnimationObjectList [index]) {
			Debug.LogWarning ("演出NO:" + index + " はオブジェクトがありません");
			return;
		}
		Animation animation = m_AnimationObjectList[index].GetComponent<Animation>();
		if (!animation) {
			Debug.LogWarning ("演出NO:" + index + " はありません");
			return;
		}

		if (isPlay) {
			if(m_SendMessengerList.Count >= index && m_SendMessengerList[index].Length > 0){
				//SendMessengerListに値があれば対象オブジェクトに送信
				m_AnimationObjectList[index].SendMessage(m_SendMessengerList[index]);
			}
			if(m_DefaultWrapModeDict.ContainsKey(index)){
				animation.wrapMode = m_DefaultWrapModeDict[index];
			}else{
				Debug.LogWarning ("デフォルトループモード:" + index + " はありません");
				return;
			}
			animation.clip = m_AnimationClipList[index];
			animation.Play();
			Debug.Log ("演出NO:"+index+ "の" + m_AnimationClipList[index].name + " を　再生");
		} else {
			animation.wrapMode = WrapMode.Once;

			if(m_SendMessengerList.Count >= index && m_AnimationStopClipList[index]){
				//ストップ用のアニメーションがあったら再生
				animation.clip = m_AnimationStopClipList[index];
				animation.Play();
				Debug.Log ("演出NO:"+index+" を　停止(アニメーション)");
				return;
			}

			Debug.Log ("演出NO:"+index+" を　停止");
			return;
		}
	}

	//テスト用gui 
	int testIndex = 1;
	void OnGUI()
	{
		if ( GUI.Button(new Rect(40, 0, 30, 20), "←" ) )
		{
			testIndex--;
		}
		if ( GUI.Button(new Rect(0, 0, 40, 20), "←←" ) )
		{
			testIndex-=10;
		}

		if ( GUI.Button(new Rect(110, 0, 30, 20), "→" ) )
		{
			testIndex++;
		}
		if ( GUI.Button(new Rect(140, 0, 40, 20), "→→" ) )
		{
			testIndex+=10;
		}

		if ( GUI.Button(new Rect(0, 21, 50, 20), "再生" ) )
		{
			runAnimation(testIndex);
		}
		if ( GUI.Button(new Rect(50, 21, 50, 20), "停止" ) )
		{
			stopAnimation(testIndex);
		}

		if ( GUI.Button(new Rect(100, 21, 50, 20), "全再生" ) )
		{
			for(int i = 0 ; i < m_AnimationObjectList.Count ; i++){
				runAnimation(i);
			}
		}

		if ( GUI.Button(new Rect(150, 21, 50, 20), "全停止" ) )
		{
			for(int i = 0 ; i < m_AnimationObjectList.Count ; i++){
				stopAnimation(i);
			}
		}

		if (testIndex < 0)testIndex = 0;

		GUI.Label (new Rect(76, 0, 60, 20) , ("No:"+testIndex));
	}

}





