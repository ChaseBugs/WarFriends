using UnityEngine;
using Vectrosity;

public class PlaceMineAbility : Core_BaseScript
{
	public Material lineMaterial;

	public Transform playerTransform;

	private float rot;

	private VectorLine line;

	public float scale = 1f;

	private RadiusWeaponSetup mRadiusWeaponSetup;

	public Weapon weapon;

	private bool mIsPlacing;

	private bool mIsPlaced;

	public bool IsPlacing
	{
		get
		{
			return mIsPlacing;
		}
		set
		{
			mIsPlacing = value;
		}
	}

	protected override void Start()
	{
		base.Start();
		Vector3[] linePoints = new Vector3[51];
		line = new VectorLine("Line", linePoints, lineMaterial, 5f, LineType.Continuous);
		line.MakeCircle(Vector3.zero, Vector3.up, 1f, 50);
		line.SetTextureScale(10f);
		mRadiusWeaponSetup = weapon.ammoSetup as RadiusWeaponSetup;
		weapon.owner = PlayerController.currentPlayer;
		Object.DontDestroyOnLoad(line.vectorObject);
	}

	public void PlaceMine()
	{
		IsPlacing = true;
		line.vectorObject.SetActive(value: true);
		PlayerController.currentPlayer.updateWeapons = false;
		mIsPlaced = false;
	}

	public void Disable()
	{
		IsPlacing = false;
		line.vectorObject.SetActive(value: false);
		PlayerController.currentPlayer.updateWeapons = true;
		mIsPlaced = false;
	}

	public void UpdateMine()
	{
		if (IsPlacing)
		{
			playerTransform.position = (weapon.owner as Component).transform.position;
			playerTransform.rotation = Quaternion.AngleAxis(rot, Vector3.up);
			if (mRadiusWeaponSetup != null)
			{
				float radius = mRadiusWeaponSetup.radius;
				playerTransform.localScale = new Vector3(radius, radius, radius);
			}
			rot += Time.deltaTime * 5f;
			line.SetTextureScale(playerTransform, scale);
			line.Draw3D(playerTransform);
			if (Input.GetMouseButtonDown(0) && !PlayerController.currentPlayer.clicked)
			{
				Vector3 to = Singleton<AimingHelper>.instance.Aim(weapon);
				if ((bool)weapon.Fire(to))
				{
					line.vectorObject.SetActive(value: false);
					IsPlacing = false;
					mIsPlaced = true;
				}
			}
		}
		if (Input.GetMouseButtonUp(0) && mIsPlaced && !IsPlacing)
		{
			PlayerController.currentPlayer.updateWeapons = true;
			mIsPlaced = false;
		}
	}
}
