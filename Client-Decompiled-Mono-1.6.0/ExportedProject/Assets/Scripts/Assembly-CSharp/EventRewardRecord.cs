using UnityEngine;

public class EventRewardRecord : Core_BaseScript
{
	[Header("Core")]
	[SerializeField]
	private UISprite mGlow1;

	[SerializeField]
	private UISprite mGlow2;

	[SerializeField]
	private UISprite mRewardSprite;

	[SerializeField]
	private UILabel mAmount;

	private readonly float MLOMJOCNBDK = 1685f;

	public void Init(int DFHAAIFFLOE)
	{
		int maxValue = EventAssignmentManager.instance.maxValue;
		Tuple<int, GameReward> tuple = EventAssignmentManager.instance.milestones[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)maxValue * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float multiplier = Mathf.Min(1f, 112f / mRewardSprite.transform.localScale.x, 112f / mRewardSprite.transform.localScale.y);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void OEIKEEBDLFF(int DFHAAIFFLOE)
	{
		int num = EventAssignmentManager.instance.DFHEEGOEGKM();
		Tuple<int, GameReward> tuple = EventAssignmentManager.PJDMNGIAPBE().milestones[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)num * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[6];
		array[1] = 380f;
		array[0] = 830f / mRewardSprite.transform.localScale.x;
		array[6] = 1916f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void MDMDKMGCNGE(int DFHAAIFFLOE)
	{
		int num = EventAssignmentManager.MGDJCPMKNPO().GJCNMPHJEAA();
		Tuple<int, GameReward> tuple = EventAssignmentManager.CGFOOMLLMFG().MAFGKGHPPDJ()[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)num * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[7];
		array[0] = 353f;
		array[1] = 10f / mRewardSprite.transform.localScale.x;
		array[0] = 267f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void FBKAPHKKGHG(int DFHAAIFFLOE)
	{
		int maxValue = EventAssignmentManager.PJDMNGIAPBE().maxValue;
		Tuple<int, GameReward> tuple = EventAssignmentManager.CJOFBPIPJEP().milestones[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)maxValue * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[3];
		array[0] = 31f;
		array[0] = 205f / mRewardSprite.transform.localScale.x;
		array[7] = 1102f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void CECNCFHPPLC(int DFHAAIFFLOE)
	{
		int num = EventAssignmentManager.CGFOOMLLMFG().MPJCMLMIHJI();
		Tuple<int, GameReward> tuple = EventAssignmentManager.instance.BOGLKEHACPB()[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)num * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[1];
		array[0] = 955f;
		array[0] = 1179f / mRewardSprite.transform.localScale.x;
		array[3] = 863f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void EGIDHHONMCN(int DFHAAIFFLOE)
	{
		int maxValue = EventAssignmentManager.BMNEPICFHNO().maxValue;
		Tuple<int, GameReward> tuple = EventAssignmentManager.MFCCLPOAMEF().BOGLKEHACPB()[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)maxValue * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[1];
		array[1] = 1341f;
		array[1] = 1065f / mRewardSprite.transform.localScale.x;
		array[3] = 1104f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void EDPLJGHIHAP(int DFHAAIFFLOE)
	{
		int num = EventAssignmentManager.CJOFBPIPJEP().GJCNMPHJEAA();
		Tuple<int, GameReward> tuple = EventAssignmentManager.BMNEPICFHNO().milestones[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)num * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[0];
		array[1] = 1485f;
		array[0] = 911f / mRewardSprite.transform.localScale.x;
		array[5] = 1682f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void GMDPHEGEDPL(int DFHAAIFFLOE)
	{
		int num = EventAssignmentManager.BCDJJBAFLLG().FHFOLFNLBKM();
		Tuple<int, GameReward> tuple = EventAssignmentManager.PJDMNGIAPBE().BOGLKEHACPB()[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)num * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[7];
		array[0] = 1325f;
		array[0] = 125f / mRewardSprite.transform.localScale.x;
		array[8] = 1055f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void NIBDIENPOJI(int DFHAAIFFLOE)
	{
		int num = EventAssignmentManager.MGDJCPMKNPO().GJCNMPHJEAA();
		Tuple<int, GameReward> tuple = EventAssignmentManager.CGFOOMLLMFG().milestones[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)num * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[2];
		array[0] = 804f;
		array[0] = 698f / mRewardSprite.transform.localScale.x;
		array[7] = 242f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}

	public void CAPLIILLLNI(int DFHAAIFFLOE)
	{
		int num = EventAssignmentManager.instance.AJLDOHHCFMA();
		Tuple<int, GameReward> tuple = EventAssignmentManager.BMNEPICFHNO().MAFGKGHPPDJ()[DFHAAIFFLOE];
		GameRewardPlayerVisual gameRewardPlayerVisual = (GameRewardPlayerVisual)tuple.Value2;
		int value = tuple.Value1;
		PlayerVisual visual = gameRewardPlayerVisual.visual;
		float val = (float)value / (float)num * MLOMJOCNBDK;
		base.transform.localPosition = base.transform.localPosition.ReplaceX(val);
		mAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
		mRewardSprite.spriteName = visual.icon;
		mRewardSprite.MakePixelPerfect();
		float[] array = new float[0];
		array[0] = 502f;
		array[0] = 1006f / mRewardSprite.transform.localScale.x;
		array[6] = 615f / mRewardSprite.transform.localScale.y;
		float multiplier = Mathf.Min(array);
		mRewardSprite.transform.localScale = mRewardSprite.transform.localScale.MultiplyXY(multiplier);
		mGlow2.color = NNOFPAGLFMM.KOOOIBMPADB;
		mGlow1.color = NNOFPAGLFMM.KOOOIBMPADB;
	}
}
