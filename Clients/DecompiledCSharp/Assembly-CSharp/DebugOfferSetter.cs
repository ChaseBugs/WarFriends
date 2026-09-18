using UnityEngine;

public class DebugOfferSetter : MonoBehaviour
{
	public GameObject hide;

	public UIInput offerName;

	public UIInput hours;

	public UIInput minutes;

	public UIInput discount;

	public GameObject setButton;

	public GameObject replaceButton;

	public GameObject replaceChecker;

	private void setOffer(GameObject go)
	{
		string text = offerName.text;
		if (text.Length < 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERTOOSHORTNAME"), 0f);
			return;
		}
		int num = StringParser.ParseInt(hours.text);
		int num2 = StringParser.ParseInt(minutes.text);
		int num3 = num * 3600 + num2 * 60;
		if (num3 < 60)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERTOOSHORTDURATION"), 0f);
			return;
		}
		int num4 = StringParser.ParseInt(discount.text);
		if (num4 < 1 || num4 > 99)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERWRONGDISCOUNT"), 0f);
			return;
		}
		string saleName = Random.Range(1, 100).ToString("'fakeOffername'0");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.currentTimestamp + num3, num4, text, saleName, replaceChecker.activeSelf);
	}

	private void Awake()
	{
		UIEventListener.Get(hide).onClick = delegate
		{
			base.gameObject.SetActive(value: false);
		};
		offerName.text = "VIP-SALE-ALL;WEAPON-EXPLOSIVE-SALE";
		hours.text = "0";
		minutes.text = "6";
		discount.text = "50";
		UIEventListener.Get(setButton).onClick = setOffer;
		UIEventListener.Get(replaceButton).onClick = delegate
		{
			replaceChecker.SetActive(!replaceChecker.activeSelf);
		};
	}
}
