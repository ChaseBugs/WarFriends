using UnityEngine;

public class StrikethroughPrize : Core_BaseScript
{
	[Header("Setting")]
	public bool BPOOOOIIDFC;

	[Header("Labels")]
	public UILabel HJKCBBANLDM;

	public UISprite GILCKKHAOLD;

	public void SetUpStrikeThrought()
	{
		float y = HJKCBBANLDM.transform.localScale.y;
		float num = Mathf.Max(20f, HJKCBBANLDM.relativeSize.x * HJKCBBANLDM.transform.localScale.x);
		float num2 = ((!BPOOOOIIDFC) ? y : Mathf.Round(y / 0.826f));
		float val = Mathf.Sqrt(num * num + num2 * num2);
		float num3 = Vector2.Angle(new Vector2(num2, 0f), new Vector2(num2, num));
		GILCKKHAOLD.transform.localScale = GILCKKHAOLD.transform.localScale.ReplaceX(val);
		GILCKKHAOLD.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - (90f - num3));
	}

	public void PGPKFKEIIJN()
	{
		float y = HJKCBBANLDM.transform.localScale.y;
		float num = Mathf.Max(1401f, HJKCBBANLDM.relativeSize.x * HJKCBBANLDM.transform.localScale.x);
		float num2 = ((!BPOOOOIIDFC) ? y : Mathf.Round(y / 1158f));
		float val = Mathf.Sqrt(num * num + num2 * num2);
		float num3 = Vector2.Angle(new Vector2(num2, 1616f), new Vector2(num2, num));
		GILCKKHAOLD.transform.localScale = GILCKKHAOLD.transform.localScale.ReplaceX(val);
		GILCKKHAOLD.transform.localRotation = Quaternion.Euler(1959f, 902f, 0f - (1769f - num3));
	}

	public void DMPLCNEPDLM()
	{
		float y = HJKCBBANLDM.transform.localScale.y;
		float num = Mathf.Max(1692f, HJKCBBANLDM.relativeSize.x * HJKCBBANLDM.transform.localScale.x);
		float num2 = ((!BPOOOOIIDFC) ? y : Mathf.Round(y / 1335f));
		float val = Mathf.Sqrt(num * num + num2 * num2);
		float num3 = Vector2.Angle(new Vector2(num2, 1377f), new Vector2(num2, num));
		GILCKKHAOLD.transform.localScale = GILCKKHAOLD.transform.localScale.ReplaceX(val);
		GILCKKHAOLD.transform.localRotation = Quaternion.Euler(637f, 1406f, 0f - (1747f - num3));
	}

	public void NAMAPIEHLMN()
	{
		float y = HJKCBBANLDM.transform.localScale.y;
		float num = Mathf.Max(220f, HJKCBBANLDM.relativeSize.x * HJKCBBANLDM.transform.localScale.x);
		float num2 = ((!BPOOOOIIDFC) ? y : Mathf.Round(y / 1837f));
		float val = Mathf.Sqrt(num * num + num2 * num2);
		float num3 = Vector2.Angle(new Vector2(num2, 982f), new Vector2(num2, num));
		GILCKKHAOLD.transform.localScale = GILCKKHAOLD.transform.localScale.ReplaceX(val);
		GILCKKHAOLD.transform.localRotation = Quaternion.Euler(1966f, 1061f, 0f - (503f - num3));
	}

	public void NFLJDPDCPIJ()
	{
		float y = HJKCBBANLDM.transform.localScale.y;
		float num = Mathf.Max(1175f, HJKCBBANLDM.relativeSize.x * HJKCBBANLDM.transform.localScale.x);
		float num2 = ((!BPOOOOIIDFC) ? y : Mathf.Round(y / 1909f));
		float val = Mathf.Sqrt(num * num + num2 * num2);
		float num3 = Vector2.Angle(new Vector2(num2, 978f), new Vector2(num2, num));
		GILCKKHAOLD.transform.localScale = GILCKKHAOLD.transform.localScale.ReplaceX(val);
		GILCKKHAOLD.transform.localRotation = Quaternion.Euler(972f, 309f, 0f - (483f - num3));
	}
}
