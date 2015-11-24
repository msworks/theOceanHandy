using UnityEngine;
using System.Collections;

public class UITextureManager : MonoBehaviour {
	[SerializeField] private UITexture uiTexture = null;
	[SerializeField] private Texture[] textures = null;
	public Animation textureAnimation = null;
	public AnimationClip[] anims = null;
	public float textureNum = 0;
	private int currentNum = 0;
	
	//====================================================================================================
	// Method
	//====================================================================================================
	void Update(){
		if (this.textureNum < 0)
			this.textureNum = 0;
		else if (this.textureNum > this.textures.Length - 1)
			this.textureNum = this.textures.Length - 1;

		if ((int)this.textureNum != this.currentNum) {
			this.currentNum = (int)this.textureNum;
			this.uiTexture.mainTexture = this.textures[this.currentNum];
		}
	}

    //----------------------------------------------------------------------------------------------------
	public void PlayAnim(int animNum){
		if (animNum > this.anims.Length - 1 || animNum < 0)
			return;

		this.StopAnim ();
		this.textureAnimation.clip = this.anims [animNum];
		this.textureAnimation.Play ();
	}
	
	//----------------------------------------------------------------------------------------------------
	public void StopAnim(){
		if (this.textureAnimation.isPlaying)
			this.textureAnimation.Stop ();
	}
}
