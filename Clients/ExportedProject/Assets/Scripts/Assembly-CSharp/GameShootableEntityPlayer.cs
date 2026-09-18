using System.Collections.Generic;
using UnityEngine;

public class GameShootableEntityPlayer : GameShootableEntity
{
	private PlayerController mPlayer;

	public Transform shotOut;

	private Vector3 mShotOutPos;

	protected override void Awake()
	{
		base.Awake();
		mPlayer = GetComponent<PlayerController>();
		mShotOutPos = shotOut.transform.localPosition;
	}

	protected override void Update()
	{
		base.Update();
	}

	public override List<ShotTarget> GetShotTargets(ShotTargetType type)
	{
		if ((type & ShotTargetType.Shield) == ShotTargetType.Shield)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (mPlayer.currentPlayerPoint != null && mPlayer.currentPlayerPoint.point != null && mPlayer.currentPlayerPoint.point.shield != null)
			{
				list.Add(new ShotTarget
				{
					transform = mPlayer.currentPlayerPoint.point.shield.shotPosition,
					type = ShotTargetType.Shield,
					mShootableEntity = this
				});
			}
			type &= ~ShotTargetType.Shield;
			list.AddRange(base.GetShotTargets(type));
			return list;
		}
		return base.GetShotTargets(type);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		for (int i = 0; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.DrawGizmoCross(shotTarget.transform.position, 0.23f, Color.red);
		}
	}
}
