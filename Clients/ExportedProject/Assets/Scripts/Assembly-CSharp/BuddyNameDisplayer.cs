using UnityEngine;

[ExecuteInEditMode]
public class BuddyNameDisplayer : PoolableObject
{
	public Transform snapTransform;

	[SerializeField]
	private TextMesh[] stroke;

	public float strokeSize;

	public TextMesh text;

	private AIObject mOwner;

	private bool mIsHiding;

	public void Init(string playerName, AIObject owner, Transform snapTransform, bool isMine)
	{
		text.text = playerName;
		text.color = ((!isMine) ? Colours.redEnemy : Colours.pink);
		this.snapTransform = snapTransform;
		mOwner = owner;
		GenerateOutline();
		mIsHiding = false;
	}

	protected void Update()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(snapTransform.position);
			point = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!mOwner.isAlive && !mIsHiding)
			{
				mIsHiding = true;
			}
			if (mIsHiding)
			{
				Hiding();
			}
		}
		else
		{
			GenerateOutline();
		}
	}

	private void Hiding()
	{
		Color color = text.color;
		color.a -= Time.deltaTime;
		text.color = color;
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 0f)
		{
			DestroyPooled();
		}
	}

	private void GenerateOutline()
	{
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 2 != 0) ? 1f : (-1f));
			float num2 = ((i % 2 != 0) ? 1f : (-1f));
			num *= strokeSize;
			num2 *= strokeSize;
			textMesh.color = Color.black;
			textMesh.text = text.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 0.01f);
		}
	}
}
