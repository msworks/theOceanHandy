using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RailPanel : MonoBehaviour
{
    [SerializeField]
    private UIAnchor anchorPanel = null;

	[SerializeField]
    private UITexture texturePanel = null;

    [SerializeField]
    private UISprite spritePanel = null;

	[SerializeField]
    private PictureManager pictureManager = null;

    private float preAnchorValue = 0;

    public UIAnchor Anchor
    {
        get
        {
            return this.anchorPanel;
        }
    }

    /// <summary>
    /// 謎の上の流儀に倣ってみる
    /// </summary>
    public string spriteName
    {
        set
        {
            this.spritePanel.spriteName = value;
        }
    }

	void Start()
    {
		this.preAnchorValue = this.anchorPanel.relativeOffset.x;
	}

	void Update()
    {
		float anchorValue = this.anchorPanel.relativeOffset.x;
		if(anchorValue > this.preAnchorValue)
        {
            //this.MainTexture = this.pictureManager.GetTexture(this);
            this.spriteName = this.pictureManager.GetSpriteName(this);
        }

		this.preAnchorValue = anchorValue;
	}
	
	public void Reset()
    {
		this.preAnchorValue = this.anchorPanel.relativeOffset.x;
	}
}
