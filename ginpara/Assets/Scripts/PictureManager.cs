using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PictureManager : MonoBehaviour {

    [SerializeField]
    private bool isTop = false;

    public int PictureNum { get { return this.pictureNum; } }
    public int[] RecodePanelNum { get { return new int[3] { this.recodePanel[1].pictureNum, this.recodePanel[2].pictureNum, this.recodePanel[3].pictureNum }; } }

	private bool[] isAnimationNow = new bool[11];
	private float[] animeTimeElapsed = new float[11];
	private int[] currentNum = new int[11];

    private List<List<string>> spriteNameListList = new List<List<string>>();
    private List<string> hitSpriteNameList = new List<string>();

	private int pictureNum = 1;
	private List<RecodePanel> recodePanel = new List<RecodePanel>();

    private float[] animeIntervalTimes = new float[] {
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
        0.06f,
    };

	void Awake(){
        this.spriteNameListList = new List<List<string>>(){
            new List<string>(){ "b_a","b_a","b_a","b_a","b_a","b_a","b_b","b_b","b_b","b_b","b_b","b_b", },
            new List<string>(){ "1_a","1_b","1_c","1_d","1_e","1_f","1_g","1_f","1_e","1_d","1_c","1_b", },
            new List<string>(){ "2_a","2_b","2_c","2_d","2_e","2_f","2_g","2_f","2_e","2_d","2_c","2_b", },
            new List<string>(){ "3_a","3_b","3_c","3_d","3_e","3_f","3_g","3_f","3_e","3_d","3_c","3_b", },
            new List<string>(){ "4_a","4_b","4_c","4_d","4_e","4_f","4_g","4_f","4_e","4_d","4_c","4_b", },
            new List<string>(){ "5_a","5_b","5_c","5_d","5_e","5_f","5_g","5_f","5_e","5_d","5_c","5_b", },
            new List<string>(){ "6_a","6_b","6_c","6_d","6_e","6_f","6_g","6_f","6_e","6_d","6_c","6_b", },
            new List<string>(){ "7_a","7_b","7_c","7_d","7_e","7_f","7_g","7_f","7_e","7_d","7_c","7_b", },
            new List<string>(){ "8_a","8_b","8_c","8_d","8_e","8_f","8_g","8_f","8_e","8_d","8_c","8_b", },
            new List<string>(){ "9_a","9_b","9_c","9_d","9_e","9_f","9_g","9_f","9_e","9_d","9_c","9_b", },
            new List<string>(){ "10_a","10_b","10_c","10_d","10_e","10_f","10_g","10_f","10_e","10_d","10_c","10_b", },
        };

        this.hitSpriteNameList = new List<string>(){
            "1_wow",
            "2_wow",
            "3_wow",
            "4_wow",
            "5_wow",
            "6_wow",
            "7_wow",
            "8_wow",
            "9_wow",
            "10_wow",
        };
	}
	
	//----------------------------------------------------------------------------------------------------
	void Update(){
		for(int i = 0; i < this.isAnimationNow.Length; ++i){

            if (!this.isAnimationNow[i])
            {
                continue;
            }

			this.animeTimeElapsed[i] += Time.deltaTime;

			if(this.animeTimeElapsed[i] > this.animeIntervalTimes[this.currentNum[i]]){
				this.animeTimeElapsed[i] = 0;

                if (this.currentNum[i] == this.spriteNameListList[i].Count - 1)
                {
                    this.currentNum[i] = 0;
                }
                else
                {
                    this.currentNum[i] ++;
                }

				foreach(RecodePanel recode in this.recodePanel){
                    if (recode.pictureNum == i)
                    {
                        if (this.spriteNameListList[i][this.currentNum[i]] != null)
                        {
                            recode.railPanel.spriteName = this.spriteNameListList[i][this.currentNum[i]];
                        }
                        //recode.railPanel.MainTexture = this.pictures[1][this.currentNum[1]];
                    }
				}
			}
		}
	}
	
	public string GetSpriteName(RailPanel railPanel){
		int index = 0;
		if(!this.isTop){
			if(this.pictureNum == -10)
				this.pictureNum = 1;
			else
				this.pictureNum = (this.pictureNum > 0) ? -this.pictureNum : -this.pictureNum + 1;

			index = (this.pictureNum > 0) ? this.pictureNum + 2 : this.pictureNum - 2;
			if(index > 10) index = index - 10;
			if(index < -10) index = index + 10;
		} else {
			if(this.pictureNum == -1)
				this.pictureNum = 10;
			else
				this.pictureNum = (this.pictureNum > 0) ? -this.pictureNum : -this.pictureNum - 1;

			if(this.pictureNum == 2)
				index = 10;
			else if(this.pictureNum == -2)
				index = -10;
			else if(this.pictureNum == 1)
				index = 9;
			else if(this.pictureNum == -1)
				index = -9;
			else{
				index = (this.pictureNum > 0) ? this.pictureNum - 2 : this.pictureNum + 2;
			}
		}

		if(index > 0){
			this.recodePanel.Add(new RecodePanel(index, railPanel));
			if(this.recodePanel.Count > 6) this.recodePanel.RemoveAt(0);
            return this.spriteNameListList[index][this.spriteNameListList[index].Count - 1];
		} else {
			this.recodePanel.Add(new RecodePanel(0, railPanel));
			if(this.recodePanel.Count > 6) this.recodePanel.RemoveAt(0);
            return this.spriteNameListList[0][this.spriteNameListList[0].Count - 1];
		}
	}
	
    /// <summary>
    /// initializeでDictionaryを返却すべきではない。
    /// initializeは初期化をすべき。カテゴリーエラー。
    /// </summary>
    /// <param name="pictureNum"></param>
    /// <param name="panelList"></param>
    /// <returns></returns>
	public Dictionary<int, string> Initialize(int pictureNum, RailPanel[] panelList)
    {
		if(pictureNum > this.spriteNameListList.Count){
			Debug.LogError("指定範囲がオーバー！【指定値："+pictureNum+"】");
			return null;
		}

        var dic = new Dictionary<int, string>();

		this.pictureNum = pictureNum;
		int index = this.pictureNum;

		this.recodePanel.Clear ();

		if(!this.isTop){
			if(index == 1)
				index = -10;
			else
				index = (index > 0) ? -(index - 1) : -index;
		}else {
			if(index == 10)
				index = -1;
			else
				index = (index > 0) ? -(index + 1) : -index;
		}
		if(index > 0){
			this.recodePanel.Add(new RecodePanel(index, panelList[0]));
			//dic.Add (0, this.pictures[index][this.pictures[index].Count - 1]);
            dic.Add(0, this.spriteNameListList[index][this.spriteNameListList[index].Count - 1]);
		} else {
			this.recodePanel.Add(new RecodePanel(0, panelList[0]));
            //dic.Add(0, this.pictures[0][this.pictures[0].Count - 1]);
            dic.Add(0, this.spriteNameListList[0][this.spriteNameListList[0].Count - 1]);
        }

		if(this.pictureNum > 0){
			this.recodePanel.Add(new RecodePanel(pictureNum, panelList[1]));
            //dic.Add(1, this.pictures[this.pictureNum][this.pictures[this.pictureNum].Count - 1]);
            dic.Add(1, this.spriteNameListList[this.pictureNum][this.spriteNameListList[this.pictureNum].Count - 1]);
        }
        else
        {
			this.recodePanel.Add(new RecodePanel(0, panelList[1]));
            //dic.Add(1, this.pictures[0][this.pictures[0].Count - 1]);
            dic.Add(1, this.spriteNameListList[0][this.spriteNameListList[0].Count - 1]);
        }
		
		index = this.pictureNum;

		for(int i = 2; i < 6; ++i){
			if(!this.isTop){
				if(index == -10)
					index = 1;
				else
					index = (index > 0) ? -index : -index + 1;
			}else {
				if(index == -1)
					index = 10;
				else
					index = (index > 0) ? -index : -index - 1;
			}
			
			if(index > 0){
				this.recodePanel.Add(new RecodePanel(index, panelList[i]));
                //dic.Add(i, this.pictures[index][this.pictures[index].Count - 1]);
                dic.Add(i, this.spriteNameListList[index][this.spriteNameListList[index].Count - 1]);
            }
            else
            {
				this.recodePanel.Add(new RecodePanel(0, panelList[i]));
                //dic.Add(i, this.pictures[0][this.pictures[0].Count - 1]);
                dic.Add(i, this.spriteNameListList[0][this.spriteNameListList[0].Count - 1]);
            }
		}

		return dic;
	}
	
	public int StopStartNum(int targetNum){
		if(!this.isTop){
			if(targetNum == 1)
				return -9;
			else if(targetNum == - 1)
				return 10;
			else if(targetNum == 2)
				return -10;
			else
				return (targetNum > 0) ? -(targetNum - 2) : (-targetNum) - 1;
		} else {
			if(targetNum == 10)
				return -2;
			else if(targetNum == -10)
				return 1;
			else if(targetNum == 9)
				return -1;
			else
				return (targetNum > 0) ? -(targetNum + 2) : (-targetNum) + 1;
		}
	}
	
	public void StartAnime(int pictureNum){
		this.isAnimationNow[pictureNum] = true;
		this.currentNum[pictureNum] = 0;
		this.animeTimeElapsed[pictureNum] = 0;
	}
	
	public void StopAnime(int pictureNum){
		this.isAnimationNow[pictureNum] = false;
	}
	
	public void ChangeHitPicture(int pictureNum)
    {
		this.StopAnime(pictureNum);
		foreach(RecodePanel recode in this.recodePanel)
        {
            if (recode.pictureNum == pictureNum)
            {
                recode.railPanel.spriteName = this.hitSpriteNameList[pictureNum - 1];
            }
		}
	}
	
	//====================================================================================================
	// InnerClass
	//====================================================================================================
	private class RecodePanel{
		public int pictureNum = 0;
		public RailPanel railPanel = null;
		public RecodePanel(int num, RailPanel panel){
			this.pictureNum = num;
			this.railPanel = panel;
		}
	}
}
