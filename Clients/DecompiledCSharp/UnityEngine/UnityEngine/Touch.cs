namespace UnityEngine;

/// <summary>
///   <para>Structure describing the status of a finger touching the screen.</para>
/// </summary>
public struct Touch
{
	private int m_FingerId;

	private Vector2 m_Position;

	private Vector2 m_RawPosition;

	private Vector2 m_PositionDelta;

	private float m_TimeDelta;

	private int m_TapCount;

	private TouchPhase m_Phase;

	private TouchType m_Type;

	private float m_Pressure;

	private float m_maximumPossiblePressure;

	private float m_Radius;

	private float m_RadiusVariance;

	private float m_AltitudeAngle;

	private float m_AzimuthAngle;

	/// <summary>
	///   <para>The unique index for the touch.</para>
	/// </summary>
	public int fingerId => m_FingerId;

	/// <summary>
	///   <para>The position of the touch in pixel coordinates.</para>
	/// </summary>
	public Vector2 position => m_Position;

	public Vector2 rawPosition => m_RawPosition;

	/// <summary>
	///   <para>The position delta since last change.</para>
	/// </summary>
	public Vector2 deltaPosition => m_PositionDelta;

	/// <summary>
	///   <para>Amount of time that has passed since the last recorded change in Touch values.</para>
	/// </summary>
	public float deltaTime => m_TimeDelta;

	/// <summary>
	///   <para>Number of taps.</para>
	/// </summary>
	public int tapCount => m_TapCount;

	/// <summary>
	///   <para>Describes the phase of the touch.</para>
	/// </summary>
	public TouchPhase phase => m_Phase;

	/// <summary>
	///   <para>The current amount of pressure being applied to a touch.  1.0f is considered to be the pressure of an average touch.  If Input.touchPressureSupported returns false, the value of this property will always be 1.0f.</para>
	/// </summary>
	public float pressure => m_Pressure;

	/// <summary>
	///   <para>The maximum possible pressure value for a platform.  If Input.touchPressureSupported returns false, the value of this property will always be 1.0f.</para>
	/// </summary>
	public float maximumPossiblePressure => m_maximumPossiblePressure;

	/// <summary>
	///   <para>A value that indicates whether a touch was of Direct, Indirect (or remote), or Stylus type.</para>
	/// </summary>
	public TouchType type => m_Type;

	/// <summary>
	///   <para>Value of 0 radians indicates that the stylus is parallel to the surface, pi/2 indicates that it is perpendicular.</para>
	/// </summary>
	public float altitudeAngle => m_AltitudeAngle;

	/// <summary>
	///   <para>Value of 0 radians indicates that the stylus is pointed along the x-axis of the device.</para>
	/// </summary>
	public float azimuthAngle => m_AzimuthAngle;

	/// <summary>
	///   <para>An estimated value of the radius of a touch.  Add radiusVariance to get the maximum touch size, subtract it to get the minimum touch size.</para>
	/// </summary>
	public float radius => m_Radius;

	/// <summary>
	///   <para>The amount that the radius varies by for a touch.</para>
	/// </summary>
	public float radiusVariance => m_RadiusVariance;
}
