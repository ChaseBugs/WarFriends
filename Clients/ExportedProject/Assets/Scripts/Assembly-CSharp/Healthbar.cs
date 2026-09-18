using System.Collections.Generic;
using UnityEngine;

public class Healthbar : GeneratedGameObject
{
	public enum HealthBarStyle
	{
		Classic,
		Small,
		Border
	}

	private const float BUFF_DEBUFF_DISTANCE = 3.25f;

	public bool vertical;

	[Header("Healh Bar")]
	public GameObject bg;

	public myFilledSprite hb;

	public tk2dBaseSprite border;

	[Header("Label")]
	public TextMeshWithStroke levelLabel;

	[Header("Buffs / Debuffs")]
	public tk2dBaseSprite buffs;

	public tk2dBaseSprite debuffs;

	private DestroyableObject mDestroyableObject;

	private Color mColor;

	private bool mIsShowed;

	private bool mEnabled = true;

	private bool mShowBuffs;

	private TweenAnimator mTweenAnimator;

	private Renderer mBuffsRenderer;

	private Renderer mDebuffsRenderer;

	private Vector3 defaultScale = new Vector3(16.3f, 2.286557f, 0.5f);

	private Vector3 enemiesScale = new Vector3(9.78f, 1.7149177f, 0.5f);

	public DestroyableObject destroyableObject
	{
		get
		{
			return mDestroyableObject;
		}
		set
		{
			mDestroyableObject = value;
			Enable();
			Show(show: true);
		}
	}

	public Color color
	{
		set
		{
			hb.color = value;
			mColor = value;
			if ((bool)border)
			{
				border.color = value;
			}
		}
	}

	public float healthRatio
	{
		set
		{
			if ((value < 1f && value > 0f) || (destroyableObject.forceHealthBar && value > 0f))
			{
				Show(show: true);
			}
			else
			{
				Show(show: false);
			}
			if (value <= 0f)
			{
				Show(show: false);
			}
			if (mShowBuffs)
			{
				if (buffs != null)
				{
					buffs.gameObject.SetActive(value > 0f);
				}
				if (debuffs != null)
				{
					debuffs.gameObject.SetActive(value > 0f);
				}
			}
			if (mIsShowed)
			{
				hb.fillFract = Mathf.Clamp(value, 0.05f, 1f);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mTweenAnimator = GetComponent<TweenAnimator>();
		mTweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		mTweenAnimator.GenerateTweens();
		if (buffs != null)
		{
			mBuffsRenderer = buffs.GetComponent<Renderer>();
		}
		if (debuffs != null)
		{
			mDebuffsRenderer = debuffs.GetComponent<Renderer>();
		}
	}

	public void SetText(string text)
	{
		if ((bool)levelLabel)
		{
			levelLabel.text = text;
		}
	}

	private void OnEnable()
	{
		mEnabled = true;
	}

	private void OnDisable()
	{
		if (levelLabel != null)
		{
			levelLabel.text = string.Empty;
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		if (buffs != null)
		{
			buffs.gameObject.SetActive(value: false);
		}
		if (debuffs != null)
		{
			debuffs.gameObject.SetActive(value: false);
		}
	}

	public void InitHealthbar(DestroyableObject destroyableObject, Color color)
	{
		this.destroyableObject = destroyableObject;
		this.color = color;
		if (destroyableObject.healthBarStyle == HealthBarStyle.Border)
		{
			if ((bool)border)
			{
				border.gameObject.SetActive(value: true);
			}
			bg.transform.localScale = bg.transform.localScale.ReplaceXY(defaultScale.x, defaultScale.y);
			hb.transform.localScale = hb.transform.localScale.ReplaceXY(defaultScale.y, defaultScale.x);
			if ((bool)levelLabel)
			{
				levelLabel.transform.localPosition = levelLabel.transform.localPosition.ReplaceX(-7.6f);
			}
		}
		else if (destroyableObject.healthBarStyle == HealthBarStyle.Small)
		{
			if ((bool)border)
			{
				border.gameObject.SetActive(value: false);
			}
			bg.transform.localScale = bg.transform.localScale.ReplaceXY(enemiesScale.x, enemiesScale.y);
			hb.transform.localScale = hb.transform.localScale.ReplaceXY(enemiesScale.y, enemiesScale.x);
			if ((bool)levelLabel)
			{
				levelLabel.transform.localPosition = levelLabel.transform.localPosition.ReplaceX(-5.86f);
			}
		}
		else
		{
			if ((bool)border)
			{
				border.gameObject.SetActive(value: false);
			}
			bg.transform.localScale = bg.transform.localScale.ReplaceXY(defaultScale.x, defaultScale.y);
			hb.transform.localScale = hb.transform.localScale.ReplaceXY(defaultScale.y, defaultScale.x);
			if ((bool)levelLabel)
			{
				levelLabel.transform.localPosition = levelLabel.transform.localPosition.ReplaceX(-7.6f);
			}
		}
		RepositionBuffs(center: false);
		mShowBuffs = false;
		if (buffs != null)
		{
			buffs.gameObject.SetActive(value: false);
		}
		if (debuffs != null)
		{
			debuffs.gameObject.SetActive(value: false);
		}
		AIObject aIObject = mDestroyableObject.owner as AIObject;
		if (aIObject != null && aIObject.destroyableObj != null && aIObject.destroyableObj.healthbar == this)
		{
			SetBuffs(aIObject.perk);
		}
	}

	private void Show(bool show)
	{
		RepositionBuffs(!mEnabled || !show);
		if (mEnabled && mIsShowed != show)
		{
			hb.GetComponentInChildren<MeshRenderer>().enabled = show;
			bg.GetComponent<MeshRenderer>().enabled = show;
			if ((bool)border)
			{
				border.GetComponent<MeshRenderer>().enabled = show;
			}
			mIsShowed = show;
			if (mIsShowed)
			{
				FadeIn(0f);
			}
			else
			{
				FadeOut(0f);
			}
		}
	}

	public void SetBuffs(Perk perk)
	{
		if (!(buffs == null) && !(debuffs == null))
		{
			int buffCount = perk.GetBuffCount(PerkType.Buff);
			int buffCount2 = perk.GetBuffCount(PerkType.Debuff);
			bool flag = buffCount > 0;
			bool flag2 = buffCount2 > 0;
			string[] array = new string[4] { "game-elite-buff", "game-elite-buff1", "game-elite-buff2", "game-elite-buff3" };
			string[] array2 = new string[4] { "game-elite-debuff", "game-elite-debuff1", "game-elite-debuff2", "game-elite-debuff3" };
			mBuffsRenderer.enabled = flag;
			if (mBuffsRenderer.enabled)
			{
				buffs.SetSprite(array[buffCount - 1]);
			}
			mDebuffsRenderer.enabled = flag2;
			if (mDebuffsRenderer.enabled)
			{
				debuffs.SetSprite(array2[buffCount2 - 1]);
			}
			buffs.transform.localPosition = buffs.transform.localPosition.ReplaceX((buffCount2 != 0 && buffCount != 0) ? (debuffs.transform.localPosition.x + 3.25f) : debuffs.transform.localPosition.x);
			mShowBuffs = mBuffsRenderer.enabled || mDebuffsRenderer.enabled;
			buffs.gameObject.SetActive(value: true);
			debuffs.gameObject.SetActive(value: true);
		}
	}

	public void Enable()
	{
		mEnabled = true;
	}

	public void Disable()
	{
		mIsShowed = false;
		hb.GetComponentInChildren<MeshRenderer>().enabled = mIsShowed;
		bg.GetComponent<MeshRenderer>().enabled = mIsShowed;
		if ((bool)border)
		{
			border.GetComponent<MeshRenderer>().enabled = mIsShowed;
		}
		if ((bool)levelLabel)
		{
			levelLabel.text = string.Empty;
		}
		FadeOut(0f);
		mEnabled = false;
		RepositionBuffs(center: true);
	}

	public void FadeIn(float time = 1f)
	{
		if (mEnabled)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(hb.gameObject, time, 1f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)border)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(border.gameObject, time, 1f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)levelLabel)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(levelLabel.gameObject, time, 1f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(bg, time, 0.25f);
		}
	}

	public void FadeOut(float time = 0.5f)
	{
		if (mEnabled)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(hb.gameObject, time, 0f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)border)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(border.gameObject, time, 0f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)levelLabel)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(levelLabel.gameObject, time, 0f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(bg, time, 0f);
		}
	}

	public void BlinkToWhite()
	{
		if (hb.color == mColor)
		{
			TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(hb.gameObject, 0.5f, mColor, Color.white);
			tweenColorTk2d.style = UITweener.Style.PingPong;
			tweenColorTk2d.NumOfRepetitions = 2;
			if ((bool)border)
			{
				TweenColorTk2d tweenColorTk2d2 = TweenColorTk2d.Begin(border.gameObject, 0.5f, mColor, Color.white);
				tweenColorTk2d2.NumOfRepetitions = 2;
			}
		}
	}

	private float GetBuffPosition(HealthBarStyle style)
	{
		if (style == HealthBarStyle.Small)
		{
			return 6.5f;
		}
		return 10f;
	}

	private void RepositionBuffs(bool center)
	{
		if (!(buffs == null) && !(debuffs == null))
		{
			if (center && debuffs.transform.localPosition.x == buffs.transform.localPosition.x)
			{
				buffs.transform.localPosition = buffs.transform.localPosition.ReplaceX(0f);
				debuffs.transform.localPosition = debuffs.transform.localPosition.ReplaceX(0f);
				return;
			}
			float num = ((!center) ? GetBuffPosition(destroyableObject.healthBarStyle) : (-1.625f));
			float num2 = ((debuffs.transform.localPosition.x != buffs.transform.localPosition.x) ? 3.25f : 0f);
			buffs.transform.localPosition = buffs.transform.localPosition.ReplaceX(num + num2);
			debuffs.transform.localPosition = debuffs.transform.localPosition.ReplaceX(num);
		}
	}
}
