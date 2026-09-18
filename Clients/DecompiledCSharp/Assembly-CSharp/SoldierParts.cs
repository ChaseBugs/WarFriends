using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierParts : Core_BaseScript
{
	public AimTarget aimTarget;

	public GameObject head;

	public GameObject body;

	public Transform coltSnap;

	public FakeRigidBodySwapper helmett;

	private List<FakeRigidBodySwapper> mWeaponRigidBodySwappers = new List<FakeRigidBodySwapper>();

	public Transform gunSnapPointNotScaled;

	public Transform gunSnapPointNotScaledLeft;

	public Transform shieldSnapPointNotScaled;

	public GameObject shadow;

	private Rigidbody[] mRigidbodies;

	public AimTarget headAimTarget;

	public FakeRigidBodySwapper mWeaponRigidBodySwapper;

	private FakeRigidBodySwapper mShield;

	public ParticleSystem scifiFlamePrefab;

	public List<Transform> paticlesParents;

	private List<ParticleSystem> mScifiParticles;

	public void DisableJetPackParticles()
	{
		if (mScifiParticles == null)
		{
			return;
		}
		foreach (ParticleSystem mScifiParticle in mScifiParticles)
		{
			mScifiParticle.gameObject.SetActive(value: false);
		}
	}

	public void EnableJetPack(Fractions fraction)
	{
		if (mScifiParticles == null)
		{
			mScifiParticles = new List<ParticleSystem>();
			foreach (Transform paticlesParent in paticlesParents)
			{
				ParticleSystem particleSystem = UnityEngine.Object.Instantiate(scifiFlamePrefab);
				particleSystem.transform.parent = paticlesParent;
				particleSystem.transform.localPosition = default(Vector3);
				particleSystem.transform.localScale = Vector3.one;
				particleSystem.transform.localRotation = Quaternion.identity;
				mScifiParticles.Add(particleSystem);
			}
		}
		foreach (ParticleSystem mScifiParticle in mScifiParticles)
		{
			mScifiParticle.gameObject.SetActive(value: true);
			mScifiParticle.Play();
			mScifiParticle.emissionRate = 8f;
			mScifiParticle.startLifetime = 0.65f;
			mScifiParticle.startSpeed = 0.3f;
			bool flag = PlayerController.currentPlayer.fraction == fraction;
			mScifiParticle.startColor = ((!flag) ? new Color32(byte.MaxValue, 71, 71, byte.MaxValue) : new Color32(109, 168, byte.MaxValue, byte.MaxValue));
		}
	}

	public void LessJetPackParticles()
	{
		if (mScifiParticles == null)
		{
			return;
		}
		foreach (ParticleSystem mScifiParticle in mScifiParticles)
		{
			if (mScifiParticle.gameObject.activeSelf)
			{
				mScifiParticle.emissionRate = 5f;
				mScifiParticle.startLifetime = 0.6f;
				mScifiParticle.startSpeed = 0.06f;
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mRigidbodies = GetComponentsInChildren<Rigidbody>();
	}

	public void SoldierDeath()
	{
		if (aimTarget != null)
		{
			aimTarget.gameObject.layer = TagsAndLayers.bulletsIgnoreLayer;
		}
		head.gameObject.layer = TagsAndLayers.bulletsIgnoreLayer;
		body.gameObject.layer = TagsAndLayers.bulletsIgnoreLayer;
		shadow.gameObject.SetActive(value: false);
		foreach (FakeRigidBodySwapper mWeaponRigidBodySwapper in mWeaponRigidBodySwappers)
		{
			mWeaponRigidBodySwapper.Swap(toRigidBody: true);
		}
	}

	public void MakeCollidersBulletVisible()
	{
		if (aimTarget != null)
		{
			aimTarget.gameObject.layer = TagsAndLayers.aimingHelpLayerNumber;
		}
		shadow.gameObject.SetActive(value: true);
		foreach (FakeRigidBodySwapper mWeaponRigidBodySwapper in mWeaponRigidBodySwappers)
		{
			mWeaponRigidBodySwapper.Swap(toRigidBody: false);
			mWeaponRigidBodySwapper.Reset();
		}
		helmett.Swap(toRigidBody: false);
		helmett.Reset();
	}

	protected void Update()
	{
		if (DebugSettings.debugShooting)
		{
			if (headAimTarget != null)
			{
				CameraLineRenderer.DrawSphere(headAimTarget.transform.TransformPoint(((SphereCollider)headAimTarget.GetComponent<Collider>()).center), ((SphereCollider)headAimTarget.GetComponent<Collider>()).radius, Colours.greenHalfAlpha);
			}
			if (aimTarget != null)
			{
				CameraLineRenderer.DrawSphere(aimTarget.transform.TransformPoint(((SphereCollider)aimTarget.GetComponent<Collider>()).center), ((SphereCollider)aimTarget.GetComponent<Collider>()).radius, Colours.greenHalfAlpha);
			}
		}
	}

	public void SetAllRigidBodiesToKinematic(bool value)
	{
		Rigidbody[] array = mRigidbodies;
		foreach (Rigidbody rigidbody in array)
		{
			if ((!(aimTarget != null) || !(rigidbody.gameObject == aimTarget.gameObject)) && (!(headAimTarget != null) || !(rigidbody.gameObject == headAimTarget.gameObject)))
			{
				rigidbody.isKinematic = value;
			}
		}
	}

	public void MakeTrigger(bool value)
	{
		body.GetComponent<SphereCollider>().isTrigger = value;
		body.GetComponent<BoxCollider>().isTrigger = value;
		head.GetComponent<Collider>().isTrigger = value;
	}

	public void EnableRagdol(bool wasHeadshot)
	{
		if (wasHeadshot && helmett != null)
		{
			helmett.Swap(toRigidBody: true);
		}
		if (mShield != null)
		{
			mShield.Swap(toRigidBody: true);
		}
		Rigidbody[] array = mRigidbodies;
		foreach (Rigidbody rigidbody in array)
		{
			if ((!(aimTarget != null) || !(rigidbody.gameObject == aimTarget.gameObject)) && (!(headAimTarget != null) || !(rigidbody.gameObject == headAimTarget.gameObject)))
			{
				if (wasHeadshot)
				{
					rigidbody.isKinematic = false;
				}
				else if (helmett == null || rigidbody.gameObject != helmett.RigidBodyObject)
				{
					rigidbody.isKinematic = false;
				}
			}
		}
	}

	public List<Weapon> AttachWeapons(List<EnemyBasicInventory.InventoryWeapon> weaponPrefabs)
	{
		List<Weapon> list = new List<Weapon>();
		mWeaponRigidBodySwappers = new List<FakeRigidBodySwapper>();
		foreach (EnemyBasicInventory.InventoryWeapon weaponPrefab in weaponPrefabs)
		{
			Quaternion localRotation = weaponPrefab.weapon.transform.localRotation;
			Weapon weapon = (Weapon)ObjectPoolDatabase.networkPool.Instantiate(weaponPrefab.weapon);
			weapon.transform.parent = ((!weaponPrefab.leftHand) ? gunSnapPointNotScaled.transform : gunSnapPointNotScaledLeft.transform);
			weapon.transform.localRotation = localRotation;
			weapon.transform.localPosition = Vector3.zero;
			weapon.transform.localScale = Vector3.one;
			weapon.weaponType = weaponPrefab.type;
			list.Add(weapon);
			mWeaponRigidBodySwappers.Add(weapon.GetComponentsInChildren<FakeRigidBodySwapper>(includeInactive: true)[0]);
		}
		foreach (FakeRigidBodySwapper mWeaponRigidBodySwapper in mWeaponRigidBodySwappers)
		{
			mWeaponRigidBodySwapper.Swap(toRigidBody: false);
			mWeaponRigidBodySwapper.Reset();
		}
		return list;
	}

	public List<Weapon> AttachWeapons(List<EnemyBasicInventory.InventoryWeapon> weaponPrefabs, byte[] indices)
	{
		List<Weapon> list = new List<Weapon>();
		mWeaponRigidBodySwappers = new List<FakeRigidBodySwapper>();
		for (int i = 0; i < weaponPrefabs.Count; i++)
		{
			EnemyBasicInventory.InventoryWeapon inventoryWeapon = weaponPrefabs[i];
			Quaternion localRotation = inventoryWeapon.weapon.transform.localRotation;
			Weapon weapon = (Weapon)ObjectPoolDatabase.networkPool.ReInstantiate(inventoryWeapon.weapon, indices[i]);
			weapon.transform.parent = ((!inventoryWeapon.leftHand) ? gunSnapPointNotScaled.transform : gunSnapPointNotScaledLeft.transform);
			weapon.transform.localRotation = localRotation;
			weapon.transform.localPosition = Vector3.zero;
			weapon.weaponType = inventoryWeapon.type;
			list.Add(weapon);
			mWeaponRigidBodySwappers.Add(weapon.GetComponentsInChildren<FakeRigidBodySwapper>(includeInactive: true)[0]);
		}
		foreach (FakeRigidBodySwapper mWeaponRigidBodySwapper in mWeaponRigidBodySwappers)
		{
			mWeaponRigidBodySwapper.Swap(toRigidBody: false);
			mWeaponRigidBodySwapper.Reset();
		}
		return list;
	}

	public void ChangeShieldMat(Material material)
	{
		if ((bool)mShield)
		{
			MeshRenderer component = mShield.RigidBodyObject.GetComponent<MeshRenderer>();
			if ((bool)component)
			{
				component.sharedMaterial = material;
			}
			MeshRenderer component2 = mShield.NoRigidBodyObject.GetComponent<MeshRenderer>();
			if ((bool)component2)
			{
				component2.sharedMaterial = material;
			}
		}
	}

	public void AttachShield(GameObject shieldPrefab)
	{
		if (mShield == null || !mShield.name.StartsWith(shieldPrefab.name))
		{
			if (mShield != null)
			{
				UnityEngine.Object.Destroy(mShield.gameObject);
			}
			mShield = UnityEngine.Object.Instantiate(shieldPrefab).GetComponent<FakeRigidBodySwapper>();
			mShield.transform.parent = shieldSnapPointNotScaled.transform;
			mShield.transform.localRotation = Quaternion.identity;
			mShield.transform.localPosition = Vector3.zero;
			mShield.Swap(toRigidBody: false);
		}
		else
		{
			mShield.Swap(toRigidBody: false);
			mShield.Reset();
		}
	}

	public void SetWeapon(Weapon weapon)
	{
		FakeRigidBodySwapper[] componentsInChildren = weapon.GetComponentsInChildren<FakeRigidBodySwapper>(includeInactive: true);
		if (componentsInChildren.Length > 0)
		{
			mWeaponRigidBodySwapper = componentsInChildren[0];
			return;
		}
		throw new NullReferenceException();
	}

	public void RepositionHelmetAttachments()
	{
		helmett.Reposition();
	}

	public void SnapColt(bool toCover)
	{
		foreach (FakeRigidBodySwapper mWeaponRigidBodySwapper in mWeaponRigidBodySwappers)
		{
			if (toCover)
			{
				mWeaponRigidBodySwapper.SnapTo(coltSnap);
			}
			else
			{
				mWeaponRigidBodySwapper.Swap(toRigidBody: false);
			}
		}
	}

	public void SnapWeaponToWorld()
	{
		foreach (FakeRigidBodySwapper mWeaponRigidBodySwapper in mWeaponRigidBodySwappers)
		{
			mWeaponRigidBodySwapper.SetParent(Singleton<MainSceneRoot>.instance.transform);
		}
	}

	public void SnapToHand()
	{
		foreach (FakeRigidBodySwapper mWeaponRigidBodySwapper in mWeaponRigidBodySwappers)
		{
			mWeaponRigidBodySwapper.Swap(toRigidBody: false);
		}
	}

	public void ShadowSetActive(bool active)
	{
		shadow.gameObject.SetActive(active);
	}
}
