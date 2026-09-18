using System;
using System.Collections;
using BestHTTP;
using UnityEngine;

public class IntroductionDealsSpecialOffer : IntroductionDealsItem
{
	[Header("Special Offer")]
	public UILabel topName;

	public Collider buttonCollider;

	public UITexture smallTexture;

	public GameObject salePart;

	public UILabel saleLabel;

	public UILabel timer;

	private bool mIsAvailable;

	private bool mIsRunning;

	private RadicalRoutine mTimeWorker;

	private OneOffer[] mOffers;

	private int mIndex;

	public override bool hasMoreLooks
	{
		get
		{
			CheckOffers();
			if (mOffers == null)
			{
				return false;
			}
			int num = 0;
			for (int i = 0; i < mOffers.Length; i++)
			{
				if (mOffers[i].isApplicable)
				{
					num++;
				}
			}
			return num > 1;
		}
	}

	public override bool isLastLook
	{
		get
		{
			if (mOffers == null)
			{
				return false;
			}
			for (int i = mIndex + 1; i < mOffers.Length; i++)
			{
				if (mOffers[i].isApplicable)
				{
					return false;
				}
			}
			return true;
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		buttonCollider.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(buttonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnButtonClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += DataLoaded;
		Singleton<OfferManager>.instance.SalesChanged += DownloadOffers;
	}

	private void OnButtonClick(GameObject go)
	{
		GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(mOffers, mIndex);
		Singleton<EventTrackingManager>.instance.SpecialOffer("Banner_Clicked");
		SetShowTimeEnd(0.5f);
		buttonCollider.enabled = false;
	}

	private void DataLoaded(DatabaseAction action)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && action == DatabaseAction.BuyPack)
		{
			UpdateAvailable();
		}
	}

	private void DownloadOffers()
	{
		mOffers = Singleton<OfferManager>.instance.currentOffers;
		mIndex = 0;
	}

	public override void InitGuiValues()
	{
		base.InitGuiValues();
		UpdateAvailable();
	}

	public override bool IsAvailable()
	{
		CheckOffers();
		if (mOffers == null || mOffers.Length == 0)
		{
			return false;
		}
		bool flag = false;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		for (int i = 0; i < mOffers.Length; i++)
		{
			bool flag2 = mOffers[i].deadline > currentTimestamp;
			bool isApplicable = mOffers[i].isApplicable;
			flag = flag || (flag2 && isApplicable);
		}
		return flag;
	}

	public override IEnumerator Show(float time)
	{
		mIndex = 0;
		ShowOffer();
		return base.Show(time);
	}

	public override IEnumerator Hide(float time)
	{
		HideOffer(time);
		return base.Hide(time);
	}

	private IEnumerator TimerWorker()
	{
		while (true)
		{
			int currentDeadline = mOffers[mIndex].deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			timer.text = string.Format("{0} {1}{2}", Localization.Localize("ID_OFFERACTIVE"), Colours.stringBlue, MiscTools.PrintableTime(currentDeadline, "-", string.Empty));
			yield return new WaitForRealSeconds(0.333f);
		}
	}

	private void UpdateAvailable()
	{
		mIsAvailable = IsAvailable();
		if (!mIsAvailable)
		{
			SetShowTimeEnd(0.5f);
			buttonCollider.enabled = false;
		}
	}

	private void CheckOffers()
	{
		if (mOffers == null)
		{
			return;
		}
		int num = 0;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		for (int i = 0; i < mOffers.Length; i++)
		{
			if (mOffers[i].deadline < currentTimestamp)
			{
				continue;
			}
			if (mOffers[i].type == OffersDestination.BuyInApp)
			{
				if (!PlayerAnalytics.instance.IsPackBought(mOffers[i].additionalInfo))
				{
					num++;
				}
			}
			else
			{
				num++;
			}
		}
		if (num == 0)
		{
			mOffers = new OneOffer[0];
			return;
		}
		if (num < mOffers.Length)
		{
			OneOffer[] array = new OneOffer[num];
			int num2 = 0;
			for (int j = 0; j < mOffers.Length; j++)
			{
				if (mOffers[j].deadline >= currentTimestamp)
				{
					if (mOffers[j].type == OffersDestination.BuyInApp && !PlayerAnalytics.instance.IsPackBought(mOffers[j].additionalInfo))
					{
						array[num2++] = mOffers[j];
					}
					else
					{
						array[num2++] = mOffers[j];
					}
				}
			}
			mOffers = array;
		}
		mIndex = Mathf.Clamp(mIndex, 0, mOffers.Length);
	}

	private void ShowPictureForOffer()
	{
		Texture2D texture2D = OfferManager.LoadImage(small: true, mOffers[mIndex].id, Localization.instance.currentLanguage);
		if (texture2D != null)
		{
			smallTexture.gameObject.SetActive(value: true);
			TweenAlpha component = smallTexture.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			smallTexture.alpha = 1f;
			smallTexture.mainTexture = texture2D;
		}
		else
		{
			smallTexture.gameObject.SetActive(value: false);
			string urlSmall = mOffers[mIndex].urlSmall;
			HTTPRequest hTTPRequest = new HTTPRequest(new Uri(urlSmall), OnPictureDownload);
			hTTPRequest.Send();
		}
	}

	private void HidePicture()
	{
		smallTexture.gameObject.SetActive(value: false);
		UnityEngine.Object.Destroy(smallTexture.mainTexture);
	}

	private void OnPictureDownload(HTTPRequest request, HTTPResponse response)
	{
		if (!mIsRunning)
		{
			return;
		}
		if (response == null)
		{
			Debug.LogErrorFormat("Picture download error: {0}", request.Exception);
			return;
		}
		for (int i = 0; i < mOffers.Length; i++)
		{
			if (request.CurrentUri.AbsoluteUri == mOffers[i].urlSmall)
			{
				OfferManager.SaveImage(small: true, mOffers[i].id, Localization.instance.currentLanguage, response.DataAsTexture2D);
				break;
			}
		}
		if (!(request.CurrentUri.AbsoluteUri != mOffers[mIndex].urlSmall))
		{
			smallTexture.gameObject.SetActive(value: true);
			TweenAlpha component = smallTexture.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			smallTexture.alpha = 1f;
			smallTexture.mainTexture = response.DataAsTexture2D;
		}
	}

	public override IEnumerator Change(float time)
	{
		mShowTimeEnd = TimeManager.realTimeWithoutPauses + time + time + showTime;
		HideOffer(time);
		foreach (WidgetAlpha widget in widgets)
		{
			TweenAlpha.Begin(widget.element, time, 0f);
		}
		yield return new WaitForSeconds(time);
		mIndex++;
		while (mIndex < mOffers.Length && !mOffers[mIndex].isApplicable)
		{
			mIndex++;
		}
		ShowOffer();
		foreach (WidgetAlpha widget2 in widgets)
		{
			TweenAlpha.Begin(widget2.element, time, widget2.alpha);
		}
		yield return new WaitForSeconds(time);
		mShowTimeEnd = TimeManager.realTimeWithoutPauses + showTime;
	}

	private void ShowOffer()
	{
		buttonCollider.enabled = true;
		if (!mIsRunning)
		{
			mIsRunning = true;
			mTimeWorker = RadicalRoutine.Create(TimerWorker());
			StartCoroutine(RadicalRoutine.Run(mTimeWorker.enumerator));
		}
		ShowPictureForOffer();
		topName.text = mOffers[mIndex].title;
		int discount = mOffers[mIndex].discount;
		saleLabel.text = Localization.LocalizeFormat("ID_SALEPERCENT", discount);
		salePart.SetActive(discount > 0);
	}

	private void HideOffer(float time)
	{
		buttonCollider.enabled = false;
		if (mIsRunning)
		{
			mIsRunning = false;
			mTimeWorker.Cancel();
		}
		TweenAlpha.Begin(smallTexture.gameObject, time, 0f).onFinished = delegate
		{
			HidePicture();
		};
	}
}
