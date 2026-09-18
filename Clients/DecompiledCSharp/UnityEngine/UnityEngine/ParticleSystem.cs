using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>Script interface for particle systems (Shuriken).</para>
/// </summary>
public sealed class ParticleSystem : Component
{
	/// <summary>
	///   <para>Script interface for a Particle.</para>
	/// </summary>
	public struct Particle
	{
		private Vector3 m_Position;

		private Vector3 m_Velocity;

		private Vector3 m_AnimatedVelocity;

		private Vector3 m_AxisOfRotation;

		private float m_Rotation;

		private float m_AngularVelocity;

		private float m_Size;

		private Color32 m_Color;

		private uint m_RandomSeed;

		private float m_Lifetime;

		private float m_StartLifetime;

		private float m_EmitAccumulator0;

		private float m_EmitAccumulator1;

		/// <summary>
		///   <para>The position of the particle.</para>
		/// </summary>
		public Vector3 position
		{
			get
			{
				return m_Position;
			}
			set
			{
				m_Position = value;
			}
		}

		/// <summary>
		///   <para>The velocity of the particle.</para>
		/// </summary>
		public Vector3 velocity
		{
			get
			{
				return m_Velocity;
			}
			set
			{
				m_Velocity = value;
			}
		}

		/// <summary>
		///   <para>The lifetime of the particle.</para>
		/// </summary>
		public float lifetime
		{
			get
			{
				return m_Lifetime;
			}
			set
			{
				m_Lifetime = value;
			}
		}

		/// <summary>
		///   <para>The starting lifetime of the particle.</para>
		/// </summary>
		public float startLifetime
		{
			get
			{
				return m_StartLifetime;
			}
			set
			{
				m_StartLifetime = value;
			}
		}

		/// <summary>
		///   <para>The initial size of the particle. The current size of the particle is calculated procedurally based on this value and the active size modules.</para>
		/// </summary>
		public float size
		{
			get
			{
				return m_Size;
			}
			set
			{
				m_Size = value;
			}
		}

		public Vector3 axisOfRotation
		{
			get
			{
				return m_AxisOfRotation;
			}
			set
			{
				m_AxisOfRotation = value;
			}
		}

		/// <summary>
		///   <para>The rotation of the particle.</para>
		/// </summary>
		public float rotation
		{
			get
			{
				return m_Rotation * 57.29578f;
			}
			set
			{
				m_Rotation = value * ((float)Math.PI / 180f);
			}
		}

		/// <summary>
		///   <para>The angular velocity of the particle.</para>
		/// </summary>
		public float angularVelocity
		{
			get
			{
				return m_AngularVelocity * 57.29578f;
			}
			set
			{
				m_AngularVelocity = value * ((float)Math.PI / 180f);
			}
		}

		/// <summary>
		///   <para>The initial color of the particle. The current color of the particle is calculated procedurally based on this value and the active color modules.</para>
		/// </summary>
		public Color32 color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
			}
		}

		/// <summary>
		///   <para>The random value of the particle.</para>
		/// </summary>
		[Obsolete("randomValue property is deprecated. Use randomSeed instead to control random behavior of particles.")]
		public float randomValue
		{
			get
			{
				return BitConverter.ToSingle(BitConverter.GetBytes(m_RandomSeed), 0);
			}
			set
			{
				m_RandomSeed = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
			}
		}

		/// <summary>
		///   <para>The random seed of the particle.</para>
		/// </summary>
		public uint randomSeed
		{
			get
			{
				return m_RandomSeed;
			}
			set
			{
				m_RandomSeed = value;
			}
		}
	}

	/// <summary>
	///   <para>Start delay in seconds.</para>
	/// </summary>
	public extern float startDelay
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Is the particle system playing right now ?</para>
	/// </summary>
	public extern bool isPlaying
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Is the particle system stopped right now ?</para>
	/// </summary>
	public extern bool isStopped
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Is the particle system paused right now ?</para>
	/// </summary>
	public extern bool isPaused
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Is the particle system looping?</para>
	/// </summary>
	public extern bool loop
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>If set to true, the particle system will automatically start playing on startup.</para>
	/// </summary>
	public extern bool playOnAwake
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Playback position in seconds.</para>
	/// </summary>
	public extern float time
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The duration of the particle system in seconds (Read Only).</para>
	/// </summary>
	public extern float duration
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The playback speed of the particle system. 1 is normal playback speed.</para>
	/// </summary>
	public extern float playbackSpeed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The current number of particles (Read Only).</para>
	/// </summary>
	public extern int particleCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>When set to false, the particle system will not emit particles.</para>
	/// </summary>
	public extern bool enableEmission
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The rate of emission.</para>
	/// </summary>
	public extern float emissionRate
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The initial speed of particles when emitted. When using curves, this values acts as a scale on the curve.</para>
	/// </summary>
	public extern float startSpeed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The initial size of particles when emitted. When using curves, this values acts as a scale on the curve.</para>
	/// </summary>
	public extern float startSize
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The initial color of particles when emitted.</para>
	/// </summary>
	public Color startColor
	{
		get
		{
			INTERNAL_get_startColor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_startColor(ref value);
		}
	}

	/// <summary>
	///   <para>The initial rotation of particles when emitted. When using curves, this values acts as a scale on the curve.</para>
	/// </summary>
	public extern float startRotation
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The total lifetime in seconds that particles will have when emitted. When using curves, this values acts as a scale on the curve. This value is set in the particle when it is create by the particle system.</para>
	/// </summary>
	public extern float startLifetime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Scale being applied to the gravity defined by Physics.gravity.</para>
	/// </summary>
	public extern float gravityModifier
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The maximum number of particles to emit.</para>
	/// </summary>
	public extern int maxParticles
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>This selects the space in which to simulate particles. It can be either world or local space.</para>
	/// </summary>
	public extern ParticleSystemSimulationSpace simulationSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Random seed used for the particle system emission. If set to 0, it will be assigned a random value on awake.</para>
	/// </summary>
	public extern uint randomSeed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_startColor(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_startColor(ref Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetParticles(Particle[] particles, int size);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern int GetParticles(Particle[] particles);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_Simulate(float t, bool restart);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_Play();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_Stop();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_Pause();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_Clear();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern bool Internal_IsAlive();

	/// <summary>
	///   <para>Fastforwards the particle system by simulating particles over given period of time, then pauses it.</para>
	/// </summary>
	/// <param name="t">Time to fastforward the particle system.</param>
	/// <param name="withChildren">Fastforward all child particle systems as well.</param>
	/// <param name="restart">Restart and start from the beginning.</param>
	[ExcludeFromDocs]
	public void Simulate(float t, bool withChildren)
	{
		bool restart = true;
		Simulate(t, withChildren, restart);
	}

	/// <summary>
	///   <para>Fastforwards the particle system by simulating particles over given period of time, then pauses it.</para>
	/// </summary>
	/// <param name="t">Time to fastforward the particle system.</param>
	/// <param name="withChildren">Fastforward all child particle systems as well.</param>
	/// <param name="restart">Restart and start from the beginning.</param>
	[ExcludeFromDocs]
	public void Simulate(float t)
	{
		bool restart = true;
		bool withChildren = true;
		Simulate(t, withChildren, restart);
	}

	/// <summary>
	///   <para>Fastforwards the particle system by simulating particles over given period of time, then pauses it.</para>
	/// </summary>
	/// <param name="t">Time to fastforward the particle system.</param>
	/// <param name="withChildren">Fastforward all child particle systems as well.</param>
	/// <param name="restart">Restart and start from the beginning.</param>
	public void Simulate(float t, [DefaultValue("true")] bool withChildren, [DefaultValue("true")] bool restart)
	{
		if (withChildren)
		{
			ParticleSystem[] particleSystems = GetParticleSystems(this);
			ParticleSystem[] array = particleSystems;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Internal_Simulate(t, restart);
			}
		}
		else
		{
			Internal_Simulate(t, restart);
		}
	}

	[ExcludeFromDocs]
	public void Play()
	{
		bool withChildren = true;
		Play(withChildren);
	}

	/// <summary>
	///   <para>Plays the particle system.</para>
	/// </summary>
	/// <param name="withChildren">Play all child particle systems as well.</param>
	public void Play([DefaultValue("true")] bool withChildren)
	{
		if (withChildren)
		{
			ParticleSystem[] particleSystems = GetParticleSystems(this);
			ParticleSystem[] array = particleSystems;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Internal_Play();
			}
		}
		else
		{
			Internal_Play();
		}
	}

	[ExcludeFromDocs]
	public void Stop()
	{
		bool withChildren = true;
		Stop(withChildren);
	}

	/// <summary>
	///   <para>Stops playing the particle system.</para>
	/// </summary>
	/// <param name="withChildren">Stop all child particle systems as well.</param>
	public void Stop([DefaultValue("true")] bool withChildren)
	{
		if (withChildren)
		{
			ParticleSystem[] particleSystems = GetParticleSystems(this);
			ParticleSystem[] array = particleSystems;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Internal_Stop();
			}
		}
		else
		{
			Internal_Stop();
		}
	}

	[ExcludeFromDocs]
	public void Pause()
	{
		bool withChildren = true;
		Pause(withChildren);
	}

	/// <summary>
	///   <para>Pauses playing the particle system.</para>
	/// </summary>
	/// <param name="withChildren">Pause all child particle systems as well.</param>
	public void Pause([DefaultValue("true")] bool withChildren)
	{
		if (withChildren)
		{
			ParticleSystem[] particleSystems = GetParticleSystems(this);
			ParticleSystem[] array = particleSystems;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Internal_Pause();
			}
		}
		else
		{
			Internal_Pause();
		}
	}

	[ExcludeFromDocs]
	public void Clear()
	{
		bool withChildren = true;
		Clear(withChildren);
	}

	/// <summary>
	///   <para>Remove all particles in the particle system.</para>
	/// </summary>
	/// <param name="withChildren">Clear all child particle systems as well.</param>
	public void Clear([DefaultValue("true")] bool withChildren)
	{
		if (withChildren)
		{
			ParticleSystem[] particleSystems = GetParticleSystems(this);
			ParticleSystem[] array = particleSystems;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Internal_Clear();
			}
		}
		else
		{
			Internal_Clear();
		}
	}

	[ExcludeFromDocs]
	public bool IsAlive()
	{
		bool withChildren = true;
		return IsAlive(withChildren);
	}

	/// <summary>
	///   <para>Does the system have any live particles (or will produce more)?</para>
	/// </summary>
	/// <param name="withChildren">Check all child particle systems as well.</param>
	/// <returns>
	///   <para>True if the particle system is still "alive", false if the particle system is done emitting particles and all particles are dead.</para>
	/// </returns>
	public bool IsAlive([DefaultValue("true")] bool withChildren)
	{
		if (withChildren)
		{
			ParticleSystem[] particleSystems = GetParticleSystems(this);
			ParticleSystem[] array = particleSystems;
			foreach (ParticleSystem particleSystem in array)
			{
				if (particleSystem.Internal_IsAlive())
				{
					return true;
				}
			}
			return false;
		}
		return Internal_IsAlive();
	}

	/// <summary>
	///   <para>Emit count particles immediately.</para>
	/// </summary>
	/// <param name="count"></param>
	public void Emit(int count)
	{
		INTERNAL_CALL_Emit(this, count);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Emit(ParticleSystem self, int count);

	/// <summary>
	///   <para>Emit a single particle with given parameters.</para>
	/// </summary>
	/// <param name="position">The position of the particle.</param>
	/// <param name="velocity">The velocity of the particle.</param>
	/// <param name="size">The size of the particle.</param>
	/// <param name="lifetime">The remaining lifetime of the particle.</param>
	/// <param name="color">The color of the particle.</param>
	public void Emit(Vector3 position, Vector3 velocity, float size, float lifetime, Color32 color)
	{
		Particle particle = new Particle
		{
			position = position,
			velocity = velocity,
			lifetime = lifetime,
			startLifetime = lifetime,
			size = size,
			rotation = 0f,
			angularVelocity = 0f,
			color = color,
			randomSeed = 5u
		};
		Internal_Emit(ref particle);
	}

	public void Emit(Particle particle)
	{
		Internal_Emit(ref particle);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_Emit(ref Particle particle);

	internal static ParticleSystem[] GetParticleSystems(ParticleSystem root)
	{
		if (!root)
		{
			return null;
		}
		List<ParticleSystem> list = new List<ParticleSystem>();
		list.Add(root);
		GetDirectParticleSystemChildrenRecursive(root.transform, list);
		return list.ToArray();
	}

	private static void GetDirectParticleSystemChildrenRecursive(Transform transform, List<ParticleSystem> particleSystems)
	{
		foreach (Transform item in transform)
		{
			ParticleSystem component = item.gameObject.GetComponent<ParticleSystem>();
			if (component != null)
			{
				particleSystems.Add(component);
				GetDirectParticleSystemChildrenRecursive(item, particleSystems);
			}
		}
	}
}
