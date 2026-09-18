using System;
using System.Collections;
using UnityEngine;

public class ArmyPreviewCamera : Singleton<ArmyPreviewCamera>
{
	public Camera playerTextureCamera;

	public PlayerController playerForRendering;

	public Vector3 playerForRenderingPosition;

	public Vector3 playerForRenderingScale;

	public Vector3 playerForRenderingPositionCards;

	public Vector3 playerForRenderingScaleCards;

	public Vector3 playerForRenderingPositionSmall;

	public Vector3 playerForRenderingScaleSmall;

	public GameObject lights;

	public GameObject background;

	public RenderTexture player1Texture;

	public RenderTexture player2Texture;

	public RenderTexture player3Texture;

	public RenderTexture playerTexture;

	public Transform armyUnitParent;

	public float rotationSpeed = -17f;

	public Transform target;

	public float distance = 5f;

	public float xSpeed = 120f;

	public float ySpeed = 120f;

	public float yMinLimit = -20f;

	public float yMaxLimit = 80f;

	public float interiaTtime = 2f;

	public float damping = 5f;

	public static bool rotationEnabled = true;

	private float x;

	private float y;

	private AIObject mInstance;

	private Transform mParent;

	private bool mISrendering;

	private bool mIsHit;

	private float xDiff;

	private float yDiff;

	private bool mUnderInertia = true;

	private Camera mCamera;

	private bool mIsLoadingPreview;

	public bool isLoadingPreview => mIsLoadingPreview;

	public event Action<bool> OnRotate;

	protected override void Start()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		distance = Vector3.Distance(base.transform.position, target.position);
	}

	protected override void Awake()
	{
		base.Awake();
		mCamera = GetComponent<Camera>();
		mCamera.enabled = false;
		mCamera.clearFlags = CameraClearFlags.Nothing;
	}

	public void PlayerDataLoaded()
	{
		playerForRendering.gameObject.SetActive(value: true);
		playerForRendering.playerProperties = PlayerProperties.CreateForLocalPlayer();
		PlayerController.currentPlayer.playerProperties = PlayerProperties.CreateForLocalPlayer();
		playerForRendering.InitPlayerForCamera();
		playerForRendering.gameObject.SetActive(value: false);
	}

	private IEnumerator DisplayPreview(LevelBehaviour behavior)
	{
		PlayerController.currentPlayer.fraction = Fractions.Allies;
		ArmyUnit3DModel s = null;
		mIsLoadingPreview = true;
		DestroyModel(unload: true);
		yield return StartCoroutine(behavior.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(behavior, 1f), bought: true, mine: true, unloadWeapon: true));
		mIsLoadingPreview = false;
		if (mCamera.enabled)
		{
			DestroyModel(unload: false);
			AIObject enemy = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(behavior);
			if (enemy != null && enemy.prefab != null)
			{
				enemy.isPrewiev = true;
				enemy.fraction = Fractions.Allies;
				mInstance = (AIObject)ObjectPoolDatabase.networkPool.ReInstantiate(enemy);
				mParent = mInstance.transform.parent;
				mInstance.transform.parent = armyUnitParent;
				mInstance.transform.localRotation = Quaternion.identity;
			}
			s = mInstance.GetComponent<ArmyUnit3DModel>();
			mInstance.transform.localPosition = -s.middle.localPosition;
			mInstance.transform.localScale = Vector3.one;
			armyUnitParent.localScale = s.scale * Vector3.one;
			mInstance.isPrewiev = true;
			mInstance.UpdatePreview(inGame: false);
			x = behavior.modelStartRotation.x;
			y = behavior.modelStartRotation.y;
			armyUnitParent.localPosition = behavior.modelPosition;
			LerpRotation();
		}
	}

	public void StartFastRotation()
	{
		rotationSpeed = -720f;
	}

	public void DefaultRotation()
	{
		rotationSpeed = -17f;
	}

	public void Display(LevelBehaviour b)
	{
		DefaultRotation();
		if (mInstance != null && mInstance.behaviour.GetType() == b.GetType())
		{
			HidePlayer(PlayerController.currentPlayer);
			mInstance.gameObject.SetActive(value: true);
			mCamera.enabled = true;
			lights.SetActive(value: true);
			Refresh();
		}
		else
		{
			Hide();
			HidePlayer(PlayerController.currentPlayer);
			mCamera.enabled = true;
			lights.SetActive(value: true);
			StartCoroutine(DisplayPreview(b));
		}
	}

	public void UpdateRotation(float endX, float endY, float time)
	{
		StartCoroutine(RadicalRoutine.Run(AnimateSoldier(endX, endY, time)));
	}

	private IEnumerator AnimateSoldier(float endX, float endY, float length)
	{
		float time = 0f;
		float startX = GetAngleInRightValues(x);
		float startY = y;
		endX = GetAngleInRightValues(endX);
		while (time < length)
		{
			x = Mathf.Lerp(startX, endX, time / length);
			y = Mathf.Lerp(startY, endY, time / length);
			time += Time.deltaTime;
			CreateRotation();
			yield return null;
		}
		x = endX;
		y = endY;
		CreateRotation();
	}

	private float GetAngleInRightValues(float angle)
	{
		return angle - Mathf.Floor(angle / 360f) * 360f;
	}

	public void DisplayPlayer(PlayerController b)
	{
		b.gameObject.SetActive(value: true);
		b.InitPlayerForCamera();
		b.SelectPrimary();
		b.Preview(idle: false);
		b.transform.parent = armyUnitParent;
		b.transform.localRotation = Quaternion.identity;
		b.transform.localPosition = -0.21f * Vector3.up;
		b.transform.localScale = Vector3.one;
		armyUnitParent.localScale = 1.2f * Vector3.one;
		armyUnitParent.localPosition = default(Vector3);
		x = 150f;
		y = 15f;
		CreateRotation();
		mCamera.enabled = true;
		lights.SetActive(value: true);
	}

	public void RenderToTexture(PlayerController player, bool useBackground, PlayerTexturePool.RenderType renderType = PlayerTexturePool.RenderType.Small)
	{
		base.gameObject.SetActive(value: true);
		StartCoroutine(RadicalRoutine.Run(CreatePlayerTexture(player, null, isPlayerTexture: true, useBackground, renderType)));
	}

	private void PositionPlayer(PlayerTexturePool.RenderType type)
	{
		switch (type)
		{
		case PlayerTexturePool.RenderType.Card:
			playerForRendering.transform.localPosition = playerForRenderingPositionCards;
			playerForRendering.transform.localScale = playerForRenderingScaleCards;
			break;
		case PlayerTexturePool.RenderType.Classic:
			playerForRendering.transform.localPosition = playerForRenderingPosition;
			playerForRendering.transform.localScale = playerForRenderingScale;
			break;
		default:
			playerForRendering.transform.localPosition = playerForRenderingPositionSmall;
			playerForRendering.transform.localScale = playerForRenderingScaleSmall;
			break;
		}
	}

	public IEnumerator CreatePlayerTexture(DatabasePlayer databasePlayer, Texture2D texture, bool useBackground = true, PlayerTexturePool.RenderType type = PlayerTexturePool.RenderType.Small)
	{
		while (mISrendering)
		{
			yield return null;
		}
		mISrendering = true;
		playerTextureCamera.enabled = true;
		playerForRendering.gameObject.SetActive(value: true);
		PositionPlayer(type);
		CamosManager.instance.ApplyVisuals(playerForRendering, databasePlayer.playerVisuals);
		playerForRendering.HideWeapon();
		playerForRendering.Preview(idle: true);
		playerTextureCamera.targetTexture = playerTexture;
		lights.SetActive(value: true);
		background.SetActive(useBackground);
		yield return new WaitForEndOfFrame();
		RenderTexture currentRT = RenderTexture.active;
		RenderTexture.active = playerTextureCamera.targetTexture;
		playerTextureCamera.Render();
		if (texture != null)
		{
			texture.ReadPixels(new Rect(0f, 0f, playerTextureCamera.targetTexture.width, playerTextureCamera.targetTexture.height), 0, 0);
			texture.Apply();
		}
		RenderTexture.active = currentRT;
		playerTextureCamera.targetTexture = null;
		playerForRendering.gameObject.SetActive(value: false);
		playerForRendering.isPreview = false;
		lights.SetActive(value: false);
		background.SetActive(value: false);
		mISrendering = false;
		playerTextureCamera.enabled = false;
	}

	public IEnumerator CreatePlayerTexture(string[] visualIndices, Texture2D texture, bool useBackground = true, PlayerTexturePool.RenderType type = PlayerTexturePool.RenderType.Small)
	{
		while (mISrendering)
		{
			yield return null;
		}
		mISrendering = true;
		playerTextureCamera.enabled = true;
		playerForRendering.gameObject.SetActive(value: true);
		PositionPlayer(type);
		CamosManager.instance.ApplyVisuals(playerForRendering, visualIndices);
		playerForRendering.HideWeapon();
		playerForRendering.Preview(idle: true);
		playerTextureCamera.targetTexture = playerTexture;
		lights.SetActive(value: true);
		background.SetActive(useBackground);
		yield return new WaitForEndOfFrame();
		RenderTexture currentRT = RenderTexture.active;
		RenderTexture.active = playerTextureCamera.targetTexture;
		playerTextureCamera.Render();
		if (texture != null)
		{
			texture.ReadPixels(new Rect(0f, 0f, playerTextureCamera.targetTexture.width, playerTextureCamera.targetTexture.height), 0, 0);
			texture.Apply();
		}
		RenderTexture.active = currentRT;
		playerTextureCamera.targetTexture = null;
		playerForRendering.gameObject.SetActive(value: false);
		playerForRendering.isPreview = false;
		lights.SetActive(value: false);
		background.SetActive(value: false);
		mISrendering = false;
		playerTextureCamera.enabled = false;
	}

	private IEnumerator CreatePlayerTexture(PlayerController player, Texture2D texture, bool isPlayerTexture = false, bool useBackground = true, PlayerTexturePool.RenderType type = PlayerTexturePool.RenderType.Small)
	{
		RenderTexture renderTexture = null;
		renderTexture = ((!isPlayerTexture) ? playerTexture : (player.isCurrentPlayer ? player1Texture : ((player.fraction == PlayerController.currentPlayer.fraction) ? player3Texture : player2Texture)));
		while (mISrendering)
		{
			yield return null;
		}
		mISrendering = true;
		playerForRendering.gameObject.SetActive(value: true);
		PositionPlayer(type);
		CamosManager.instance.ApplyVisuals(playerForRendering, player.playerProperties.playerVisuals, type == PlayerTexturePool.RenderType.Classic);
		playerForRendering.playerProperties.weapons = player.playerProperties.weapons;
		playerForRendering.weaponInventory.currentWeapon.gameObject.SetActive(value: true);
		playerForRendering.SelectPrimary();
		playerForRendering.Preview(idle: false);
		float maxWaitTime = TimeManager.realTimeWithoutPauses + 5f;
		while (!playerForRendering.weaponInventory.currentWeapon.IsLoaded())
		{
			if (TimeManager.realTimeWithoutPauses >= maxWaitTime)
			{
				Debug.LogError("Render player texture ERROR: Weapon load failed! (timeouted - 5 sec)");
				break;
			}
			yield return null;
		}
		playerTextureCamera.enabled = true;
		playerTextureCamera.targetTexture = renderTexture;
		lights.SetActive(value: true);
		background.SetActive(useBackground);
		yield return new WaitForEndOfFrame();
		RenderTexture currentRT = RenderTexture.active;
		RenderTexture.active = playerTextureCamera.targetTexture;
		playerTextureCamera.Render();
		if (texture != null)
		{
			texture.ReadPixels(new Rect(0f, 0f, playerTextureCamera.targetTexture.width, playerTextureCamera.targetTexture.height), 0, 0);
			texture.Apply();
		}
		RenderTexture.active = currentRT;
		playerTextureCamera.targetTexture = null;
		playerForRendering.gameObject.SetActive(value: false);
		playerForRendering.isPreview = false;
		lights.SetActive(value: false);
		background.SetActive(value: false);
		mISrendering = false;
		playerTextureCamera.enabled = false;
	}

	public IEnumerator CreateHiresPlayerTexture(DatabasePlayer databasePlayer, bool useBackground = true, PlayerTexturePool.RenderType type = PlayerTexturePool.RenderType.Small)
	{
		while (mISrendering)
		{
			yield return null;
		}
		mISrendering = true;
		playerForRendering.gameObject.SetActive(value: true);
		PositionPlayer(type);
		CamosManager.instance.ApplyVisuals(playerForRendering, databasePlayer.playerVisuals);
		playerForRendering.HideWeapon();
		playerForRendering.Preview(idle: true);
		playerTextureCamera.enabled = true;
		playerTextureCamera.targetTexture = player3Texture;
		lights.SetActive(value: true);
		background.SetActive(useBackground);
		yield return new WaitForEndOfFrame();
		RenderTexture currentRT = RenderTexture.active;
		RenderTexture.active = playerTextureCamera.targetTexture;
		playerTextureCamera.Render();
		RenderTexture.active = currentRT;
		playerTextureCamera.targetTexture = null;
		playerForRendering.gameObject.SetActive(value: false);
		playerForRendering.isPreview = false;
		lights.SetActive(value: false);
		background.SetActive(value: false);
		mISrendering = false;
		playerTextureCamera.enabled = false;
	}

	public void Hide()
	{
		mCamera.enabled = false;
		lights.SetActive(value: false);
		DestroyModel(unload: true);
	}

	private void DestroyModel(bool unload)
	{
		if (mInstance != null)
		{
			mInstance.transform.parent = mParent;
			mInstance.transform.localPosition = default(Vector3);
			mInstance.transform.localScale = Vector3.one;
			mInstance.DestroyPooled();
			if (unload)
			{
				mInstance.preparedBehaviour.Unload();
			}
			mInstance = null;
		}
	}

	public void HidePlayer(PlayerController b)
	{
		mCamera.enabled = false;
		lights.SetActive(value: false);
		b.gameObject.SetActive(value: false);
		b.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		b.transform.localScale = Vector3.one;
	}

	private void CreateRotation()
	{
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		Quaternion rotation = Quaternion.Euler(y, x, 0f);
		target.rotation = Quaternion.Inverse(rotation);
	}

	private void UpdateMouseRotation()
	{
		xDiff = Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
		yDiff = Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		x += xDiff;
		y -= yDiff;
		CreateRotation();
	}

	private void LerpRotation()
	{
		xDiff = Mathf.Lerp(xDiff, 0f, Time.deltaTime * damping);
		yDiff = Mathf.Lerp(yDiff, 0f, Time.deltaTime * damping);
		x += xDiff;
		y -= yDiff;
		CreateRotation();
	}

	private void LateUpdate()
	{
		if (!mCamera.enabled)
		{
			return;
		}
		if (mUnderInertia)
		{
			LerpRotation();
		}
		if ((bool)target && mIsHit)
		{
			UpdateMouseRotation();
		}
		if (Input.GetMouseButtonDown(0) && rotationEnabled)
		{
			mIsHit = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, cullingMask);
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				if (raycastHit.collider.name == "armyPreviewCollider")
				{
					mIsHit = true;
					mUnderInertia = false;
					if (this.OnRotate != null)
					{
						this.OnRotate(obj: true);
					}
				}
			}
		}
		if (rotationEnabled && mUnderInertia)
		{
			x += Time.deltaTime * rotationSpeed;
			CreateRotation();
		}
		if (Input.GetMouseButtonUp(0))
		{
			mIsHit = false;
			mUnderInertia = true;
			if (this.OnRotate != null)
			{
				this.OnRotate(obj: false);
			}
		}
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public void Refresh()
	{
		if (mCamera.enabled)
		{
			StartCoroutine(RefreshPreview());
		}
	}

	public Texture GetHiresPlayerTexture()
	{
		return player3Texture;
	}

	private IEnumerator RefreshPreview()
	{
		mIsLoadingPreview = true;
		yield return null;
		yield return null;
		if (!(mInstance != null))
		{
			yield break;
		}
		yield return StartCoroutine(mInstance.preparedBehaviour.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(mInstance.preparedBehaviour, 1f), bought: true, mine: true, unloadWeapon: true));
		mIsLoadingPreview = false;
		try
		{
			if (mInstance != null)
			{
				mInstance.PickUpgrades();
				mInstance.UpdatePreview(inGame: false);
			}
		}
		catch (Exception ex)
		{
			Exception e = ex;
			Crittercism.LogHandledException(e);
		}
	}

	public void Pause()
	{
		mCamera.enabled = false;
	}

	public void Resume()
	{
		mCamera.enabled = true;
	}
}
