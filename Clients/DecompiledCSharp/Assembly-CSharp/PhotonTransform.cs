using UnityEngine;

public class PhotonTransform
{
	internal struct State
	{
		internal Vector3 pos;

		internal Quaternion rot;

		internal double timestamp;

		public void Reset()
		{
			pos = Vector3.one * 100000f;
			timestamp = 0.0;
		}
	}

	private double mInterpolationBackTime = 0.18;

	private readonly State[] m_BufferedState = new State[10];

	private int m_TimestampCount;

	public void Update(Transform transform)
	{
		double time = PhotonNetwork.time;
		double num = time - mInterpolationBackTime;
		if (m_BufferedState[0].timestamp > num)
		{
			for (int i = 0; i < m_TimestampCount; i++)
			{
				if (m_BufferedState[i].timestamp <= num || i == m_TimestampCount - 1)
				{
					State state = m_BufferedState[Mathf.Max(i - 1, 0)];
					State state2 = m_BufferedState[i];
					double num2 = state.timestamp - state2.timestamp;
					float t = 0f;
					if (num2 > 0.0001)
					{
						t = (float)((num - state2.timestamp) / num2);
					}
					transform.localPosition = Vector3.Lerp(state2.pos, state.pos, t);
					transform.localRotation = Quaternion.Slerp(state2.rot, state.rot, t);
					break;
				}
			}
			return;
		}
		double num3 = num - m_BufferedState[0].timestamp;
		if (m_BufferedState.Length > 1 && m_TimestampCount > 1)
		{
			if (num3 < 0.20000000298023224)
			{
				float num4 = Mathf.Clamp((float)(m_BufferedState[0].timestamp - m_BufferedState[1].timestamp), 0.08f, float.MaxValue);
				transform.localPosition = m_BufferedState[0].pos + (m_BufferedState[0].pos - m_BufferedState[1].pos) / num4 * (float)num3;
			}
			else if (num3 < 1.0)
			{
				transform.localPosition = Vector3.Lerp(transform.localPosition, m_BufferedState[0].pos, Time.deltaTime * 2f);
			}
			else
			{
				transform.localPosition = m_BufferedState[0].pos;
			}
			transform.localRotation = m_BufferedState[0].rot;
		}
	}

	public void OnPhotonSerializeView(Transform transform, PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			Quaternion localRotation = transform.localRotation;
			stream.SendNext(transform.localPosition);
			stream.SendNext(transform.localRotation);
			return;
		}
		Vector3 zero = Vector3.zero;
		Quaternion identity = Quaternion.identity;
		zero = (Vector3)stream.ReceiveNext();
		identity = (Quaternion)stream.ReceiveNext();
		for (int num = m_BufferedState.Length - 1; num >= 1; num--)
		{
			ref State reference = ref m_BufferedState[num];
			reference = m_BufferedState[num - 1];
		}
		if (info.photonView.ownerId != 0 || !Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			AddNewState(info.timestamp, zero, identity);
		}
	}

	public void AddNewState(double time, Vector3 pos, Quaternion rot)
	{
		State state = default(State);
		state.timestamp = time;
		state.pos = pos;
		state.rot = rot;
		m_BufferedState[0] = state;
		m_TimestampCount = Mathf.Min(m_TimestampCount + 1, m_BufferedState.Length);
		for (int i = 0; i < m_TimestampCount - 1; i++)
		{
		}
	}

	public void Reset()
	{
		for (int i = 0; i < m_BufferedState.Length; i++)
		{
			m_BufferedState[i].Reset();
		}
		m_TimestampCount = 0;
	}
}
