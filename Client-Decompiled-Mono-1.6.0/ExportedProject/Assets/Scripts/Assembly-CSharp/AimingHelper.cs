using UnityEngine;

public class AimingHelper : Singleton<AimingHelper>
{
	public AimTarget JGDJDMFBLIK()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 875f, 1 << (TagsAndLayers.PLPNKLDHELM & 0x6A));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public AimTarget KJKCJCHBDHA()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 230f, 1 << (TagsAndLayers.PLPNKLDHELM & 0x1D));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 CFLEMLNCJHK(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 OJKJFJOBLJG(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.HEANFGONCBJ().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1273f, (int)Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (1 << (TagsAndLayers.PLPNKLDHELM & 0x10)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1420f;
				if (component != null)
				{
					return KEMKJNHCEIM(KHKAAGCIJPO, point, component.velocity, 370f);
				}
				Debug.LogError("VipReward2");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return BBAAMJMGEJB(KHKAAGCIJPO, component2.KGFGMKFMJFM(), component2.velocity, 1355f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 114f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(1568f);
	}

	public Vector3 EGBOMBHDFDN(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.HIFFNOAFCOC().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1388f, (int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & -11)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 582f;
				if (component != null)
				{
					return CBAPBGAHPAC(KHKAAGCIJPO, point, component.velocity, 237f);
				}
				Debug.LogError("ChillingoSdkManager");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return ILFJCEAPCFF(KHKAAGCIJPO, component2.targetPosition, component2.ADNKJFBOENP(), 268f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1344f, Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(417f);
	}

	public Vector3 OAOOGPJEDBL(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public AimTarget GNMGAGKMJGP()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 460f, 0 << (TagsAndLayers.PLPNKLDHELM & 0x24));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public AimTarget IOOFFDNINML()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 937f, 0 << (TagsAndLayers.PLPNKLDHELM & -105));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 NCGDJBJAHKK(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.LBBFBJMLEJB().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 461f, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & -122)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 681f;
				if (component != null)
				{
					return HHJLJCLJNED(KHKAAGCIJPO, point, component.velocity, 1339f);
				}
				Debug.LogError("ID_BATTLECANCELED");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return HEPNNOHFFGH(KHKAAGCIJPO, component2.KGFGMKFMJFM(), component2.velocity, 661f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1977f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(323f);
	}

	public Vector3 KAEMPBHPOLJ(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 HEPNNOHFFGH(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public AimTarget FENIDHHCHDA()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 404f, 0 << (TagsAndLayers.PLPNKLDHELM & 0x2A));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 PNBAFAAGNMC(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 NDABLFANEEG(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1664f, (int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (1 << (TagsAndLayers.PLPNKLDHELM & 0x1D)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1119f;
				if (component != null)
				{
					return IPADKBMDBLE(KHKAAGCIJPO, point, component.velocity, 908f);
				}
				Debug.LogError("Game shoootable entitiy without owner");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return CBAPBGAHPAC(KHKAAGCIJPO, component2.KGFGMKFMJFM(), component2.velocity, 1985f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1319f, Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(1377f);
	}

	public Vector3 BJKKKKJEAON(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.JLJAJAMJJJM().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 347f, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & 0x55)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1471f;
				if (component != null)
				{
					return PHHCNIABKLA(KHKAAGCIJPO, point, component.velocity, 916f);
				}
				Debug.LogError("create new account and add FB");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return PredictPosition(KHKAAGCIJPO, component2.targetPosition, component2.velocity, 530f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 513f, Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(141f);
	}

	public Vector3 CINBKABMMMH(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 FGFDJJHPCHG(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 GMEGNIBBCCP(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.JLJAJAMJJJM().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 768f, (int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (1 << (TagsAndLayers.PLPNKLDHELM & 1)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1191f;
				if (component != null)
				{
					return ABKLEHLLDBN(KHKAAGCIJPO, point, component.velocity, 747f);
				}
				Debug.LogError("ID_ABILITY");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return EGLIJJGEINK(KHKAAGCIJPO, component2.NLKMPOCDOCD(), component2.ADNKJFBOENP(), 702f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 530f, Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(257f);
	}

	public Vector3 PHHCNIABKLA(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 FHIELLINPIH(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public AimTarget CKDMHONHLJC()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 292f, 0 << (TagsAndLayers.PLPNKLDHELM & -14));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public AimTarget NNFMBLMFNEH()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1850f, 1 << (TagsAndLayers.PLPNKLDHELM & -53));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 PBCOBBGJNPD(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 142f, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & -69)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 588f;
				if (component != null)
				{
					return FHIELLINPIH(KHKAAGCIJPO, point, component.velocity, 1042f);
				}
				Debug.LogError("ID_LESSTHANMINUTE");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return KAEMPBHPOLJ(KHKAAGCIJPO, component2.NLKMPOCDOCD(), component2.ADNKJFBOENP(), 1310f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1503f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(1292f);
	}

	public Vector3 ILFJCEAPCFF(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 KEMKJNHCEIM(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 ENKMEEDAALF(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public AimTarget AOGHAPMGKOG()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 34f, 0 << (TagsAndLayers.PLPNKLDHELM & -10));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 MEPOKAJNLKA(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.LBBFBJMLEJB().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 213f, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (1 << (TagsAndLayers.PLPNKLDHELM & 0x50)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 536f;
				if (component != null)
				{
					return BBAAMJMGEJB(KHKAAGCIJPO, point, component.velocity, 368f);
				}
				Debug.LogError("WarArenaRuleConcreteMap");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return KAEMPBHPOLJ(KHKAAGCIJPO, component2.targetPosition, component2.velocity, 973f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1168f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(889f);
	}

	public AimTarget CBPJBFMKFCE()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1549f, 0 << (TagsAndLayers.PLPNKLDHELM & -111));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 OIHCCIIKEHK(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 KBGHDKFGGHN(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.HIFFNOAFCOC().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 161f, (int)Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & 0x55)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 258f;
				if (component != null)
				{
					return IPADKBMDBLE(KHKAAGCIJPO, point, component.velocity, 96f);
				}
				Debug.LogError("DPS");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return GLHKCPOMKHE(KHKAAGCIJPO, component2.targetPosition, component2.velocity, 316f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1979f, Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(564f);
	}

	public AimTarget AimClickableColliders()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, 1 << TagsAndLayers.PLPNKLDHELM);
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public AimTarget CHMKGLEHMLF()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1444f, 0 << (TagsAndLayers.PLPNKLDHELM & -94));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 INLBJMAJKNJ(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.HIFFNOAFCOC().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1082f, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & -2)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 133f;
				if (component != null)
				{
					return KAEMPBHPOLJ(KHKAAGCIJPO, point, component.velocity, 12f);
				}
				Debug.LogError("friend name");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return EGLIJJGEINK(KHKAAGCIJPO, component2.NLKMPOCDOCD(), component2.velocity, 189f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1621f, Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(1143f);
	}

	public AimTarget KBMBCFNHPEH()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1936f, 0 << (TagsAndLayers.PLPNKLDHELM & -54));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public AimTarget FEDHBDJFPGM()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1193f, 0 << (TagsAndLayers.PLPNKLDHELM & -77));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 NPHBNNJCMGJ(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.HEANFGONCBJ().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 903f, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (1 << (TagsAndLayers.PLPNKLDHELM & 0x60)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1678f;
				if (component != null)
				{
					return KCDPGLNJDKI(KHKAAGCIJPO, point, component.velocity, 1394f);
				}
				Debug.LogError("right");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return HHJLJCLJNED(KHKAAGCIJPO, component2.NLKMPOCDOCD(), component2.velocity, 283f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1043f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(411f);
	}

	public Vector3 BBAAMJMGEJB(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 IPADKBMDBLE(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 CBAPBGAHPAC(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 JHBMEELACLE(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 BGJEKHOIJPF(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 EGIAKBDFDIJ(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public AimTarget LMBFOCMKCJB()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1180f, 0 << (TagsAndLayers.PLPNKLDHELM & 0xA));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 FIJGLECEEDH(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 KCDPGLNJDKI(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 GKOLANDFNBB(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.CAGAKKADGDG().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1336f, (int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & 0x55)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1826f;
				if (component != null)
				{
					return GLHKCPOMKHE(KHKAAGCIJPO, point, component.velocity, 712f);
				}
				Debug.LogError("RewardGold");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return OAOOGPJEDBL(KHKAAGCIJPO, component2.NLKMPOCDOCD(), component2.velocity, 1977f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 380f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(747f);
	}

	public Vector3 EGLIJJGEINK(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 ABKLEHLLDBN(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 OHDMDJLDNOK(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.LBBFBJMLEJB().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 484f, (int)Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & 0x1D)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1150f;
				if (component != null)
				{
					return PNBAFAAGNMC(KHKAAGCIJPO, point, component.velocity, 587f);
				}
				Debug.LogError(",");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return OIHCCIIKEHK(KHKAAGCIJPO, component2.NLKMPOCDOCD(), component2.ADNKJFBOENP(), 809f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1455f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(829f);
	}

	public AimTarget DGBNJIHFPID()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 322f, 1 << (TagsAndLayers.PLPNKLDHELM & -18));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 KFOKKHBKDMI(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.LBBFBJMLEJB().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1176f, (int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & -127)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 85f;
				if (component != null)
				{
					return EGLIJJGEINK(KHKAAGCIJPO, point, component.velocity, 1521f);
				}
				Debug.LogError("Facebook");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return BGJEKHOIJPF(KHKAAGCIJPO, component2.KGFGMKFMJFM(), component2.DJALAFHCBLF(), 1852f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 682f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(1003f);
	}

	public Vector3 BNGJMLKGEFP(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.HIFFNOAFCOC().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1811f, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & -79)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1331f;
				if (component != null)
				{
					return BGJEKHOIJPF(KHKAAGCIJPO, point, component.velocity, 1776f);
				}
				Debug.LogError("ID_NOTIFICATION_WEAPONUPGRADEDELIVERED");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return FHIELLINPIH(KHKAAGCIJPO, component2.targetPosition, component2.DJALAFHCBLF(), 1657f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 254f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(1175f);
	}

	public Vector3 GLHKCPOMKHE(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public Vector3 DEMHOCOMAGM(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.HIFFNOAFCOC().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1137f, (int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (1 << (TagsAndLayers.PLPNKLDHELM & 0xD)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 23f;
				if (component != null)
				{
					return JHBMEELACLE(KHKAAGCIJPO, point, component.velocity, 133f);
				}
				Debug.LogError("()I");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return PNBAFAAGNMC(KHKAAGCIJPO, component2.targetPosition, component2.ADNKJFBOENP(), 333f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1702f, Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(1005f);
	}

	public Vector3 PredictPosition(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public AimTarget OGPBDKKDKIP()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1639f, 0 << (TagsAndLayers.PLPNKLDHELM & 9));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public AimTarget NEFMLKDDAOB()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 366f, 0 << (TagsAndLayers.PLPNKLDHELM & 4));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 NBIFJONHHGF(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1508f, (int)Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & -66)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1475f;
				if (component != null)
				{
					return FGFDJJHPCHG(KHKAAGCIJPO, point, component.velocity, 265f);
				}
				Debug.LogError("OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return KEMKJNHCEIM(KHKAAGCIJPO, component2.KGFGMKFMJFM(), component2.DJALAFHCBLF(), 1210f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1024f, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(1603f);
	}

	public AimTarget FCEEOHKMBIN()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1528f, 1 << (TagsAndLayers.PLPNKLDHELM & -84));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 NEEAFOMPJLH(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1404f, (int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (1 << (TagsAndLayers.PLPNKLDHELM & 0x3E)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 547f;
				if (component != null)
				{
					return ENKMEEDAALF(KHKAAGCIJPO, point, component.velocity, 1214f);
				}
				Debug.LogError("Assigment");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return KAEMPBHPOLJ(KHKAAGCIJPO, component2.KGFGMKFMJFM(), component2.velocity, 1073f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 1105f, Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(356f);
	}

	public AimTarget IPEGJFFIIJE()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1054f, 1 << (TagsAndLayers.PLPNKLDHELM & 0x22));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 Aim(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (1 << TagsAndLayers.PLPNKLDHELM));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 0.1f;
				if (component != null)
				{
					return PredictPosition(KHKAAGCIJPO, point, component.velocity);
				}
				Debug.LogError("Some object has soldier layer, but not DestroyableObject");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return PredictPosition(KHKAAGCIJPO, component2.targetPosition, component2.velocity);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, Singleton<TagsAndLayers>.instance.GetBulletMask(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(100f);
	}

	public AimTarget BENKIPNAFKE()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 225f, 0 << (TagsAndLayers.PLPNKLDHELM & 0x5E));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 PCDBBLFKFCJ(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}

	public AimTarget MHNCHHNNILD()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1282f, 0 << (TagsAndLayers.PLPNKLDHELM & 0x71));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public AimTarget OPMLEKMNJLK()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, 1473f, 0 << (TagsAndLayers.PLPNKLDHELM & 0x53));
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.LDAIHPHDLDA && component.BDKNNNCHILL)
			{
				if (component.POJELIKFDPO)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL > aimTarget.GBAABHGGFOL || aimTarget.POJELIKFDPO)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.GBAABHGGFOL == aimTarget.GBAABHGGFOL && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.POJELIKFDPO)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 KDJDDOJCBJA(Weapon KHKAAGCIJPO)
	{
		Ray ray = Singleton<GameCamera>.instance.JLJAJAMJJJM().ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (KHKAAGCIJPO.PKBALLDJEOL)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, 1225f, (int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM) | (0 << (TagsAndLayers.PLPNKLDHELM & 0x5B)));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.PLPNKLDHELM)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 1965f;
				if (component != null)
				{
					return PHHCNIABKLA(KHKAAGCIJPO, point, component.velocity, 618f);
				}
				Debug.LogError("ZoneHasIAPOffer");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.OMHOPBAAOAH != null)
				{
					return FIJGLECEEDH(KHKAAGCIJPO, component2.NLKMPOCDOCD(), component2.ADNKJFBOENP(), 809f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, 699f, Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(KHKAAGCIJPO.fraction, KHKAAGCIJPO.BLOHNLJOPIM)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(741f);
	}

	public Vector3 HHJLJCLJNED(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI, float FOIJCMBLMBD = 0f)
	{
		float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) + FOIJCMBLMBD;
		return MPHCNMDIPAI + num * Time.timeScale * MHLDJIABNFI;
	}
}
