using UnityEngine;

[RequireComponent(typeof(UITexture))]
public class PlayerIcon : Core_BaseScript
{
	private UITexture mTexture;

	public UILabel nameLabel;

	private Texture mAvatar;

	private UITexture Texture
	{
		get
		{
			if (mTexture == null)
			{
				mTexture = GetComponent<UITexture>();
			}
			return mTexture;
		}
		set
		{
			mTexture = value;
		}
	}

	public Texture avatar
	{
		set
		{
			mAvatar = value;
			if (value != null)
			{
				ChangeIcon();
			}
		}
	}

	public Color color
	{
		set
		{
			Texture.color = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Texture = GetComponent<UITexture>();
	}

	private void OnEnable()
	{
		FacebookService.FacebookFriendUpdated += OnFacebookFriendUpdated;
	}

	protected override void Start()
	{
		base.Start();
		ChangeIcon();
	}

	private void OnFacebookFriendUpdated(FacebookService.Friend facebookFriend)
	{
	}

	private void ChangeIcon()
	{
		if (mAvatar != null)
		{
			Texture.mainTexture = mAvatar;
		}
		else
		{
			Texture.mainTexture = null;
		}
	}

	private void OnDisable()
	{
		FacebookService.FacebookFriendUpdated -= OnFacebookFriendUpdated;
	}

	public void Reset()
	{
		Texture.mainTexture = null;
		if (nameLabel != null)
		{
			nameLabel.text = string.Empty;
		}
	}

	public void UpdateIcon()
	{
		ChangeIcon();
	}

	public void SetName(string name)
	{
		nameLabel.text = name;
	}
}
