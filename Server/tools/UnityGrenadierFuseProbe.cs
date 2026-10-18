using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>Executes recovered contact and countdown methods, stopping before Photon explosion dispatch.</summary>
public sealed class UnityGrenadierFuseProbe : GrenadeAmmoBase
{
    private const int CaptureRate = 30;
    private const int RecontactLiftTick = 10;
    private const float RecontactLiftHeight = 0.1f;
    private static readonly BindingFlags PrivateFields = BindingFlags.Instance | BindingFlags.NonPublic;
    [SerializeField] private float _fuseSeconds;
    [SerializeField] private bool _hasRecontact;
    [SerializeField] private Vector3 _initialVelocity;
    [SerializeField] private Vector3 _contactAcceleration;
    private readonly List<object> _contacts = new List<object>();
    private readonly List<object> _exits = new List<object>();
    private readonly HashSet<string> _activeSources = new HashSet<string>();
    private int _startFrame;
    private int _tick;
    private int _lastContactTick;
    private bool _lifted;
    private string _contactSourceName;
    private Rigidbody _body;

    /// <summary>Configures the source interval before entering Play Mode.</summary>
    public float FuseSeconds
    {
        get
        {
            return _fuseSeconds;
        }
        set
        {
            _fuseSeconds = value;
        }
    }

    /// <summary>Enables one controlled separation and second real floor contact.</summary>
    public bool HasRecontact
    {
        get
        {
            return _hasRecontact;
        }
        set
        {
            _hasRecontact = value;
        }
    }

    /// <summary>Supplies a controlled initial velocity for the isolated corner-contact observation.</summary>
    public Vector3 InitialVelocity
    {
        get
        {
            return _initialVelocity;
        }
        set
        {
            _initialVelocity = value;
        }
    }

    /// <summary>Maintains a controlled wall contact in the corner experiment; normal floor probes use zero.</summary>
    public Vector3 ContactAcceleration
    {
        get
        {
            return _contactAcceleration;
        }
        set
        {
            _contactAcceleration = value;
        }
    }

    public bool IsComplete { get; private set; }

    public string Failure { get; private set; }

    public int ExpiryTick { get; private set; }

    protected override void Awake()
    {
        // Bypass unrelated pool/render initialization; the original countdown fields and methods remain unchanged.
        _body = GetComponent<Rigidbody>();
        Field("mRigidBody").SetValue(this, _body);
        Field("mCollider").SetValue(this, GetComponent<Collider>());
    }

    protected override void Start()
    {
        Time.captureFramerate = CaptureRate;
        Time.fixedDeltaTime = 1f / CaptureRate;
        _startFrame = Time.frameCount;
        mExplodeAfter = FuseSeconds;
        _body.velocity = _initialVelocity;
    }

    private void FixedUpdate()
    {
        // Collider is already enabled. Only the controlled corner experiment presses against its wall.
        if (_contactAcceleration != Vector3.zero)
        {
            _body.AddForce(_contactAcceleration, ForceMode.Acceleration);
        }
    }

    private new void Update()
    {
        if (IsComplete || Failure != null)
        {
            return;
        }

        _tick = Time.frameCount - _startFrame;
        if (HasRecontact && !_lifted && _contacts.Count > 0 && _tick >= RecontactLiftTick)
        {
            _body.position += Vector3.up * RecontactLiftHeight;
            _body.velocity = Vector3.zero;
            _lifted = true;
        }

        try
        {
            base.Update();
        }
        catch (NullReferenceException)
        {
            // Source clears its countdown flag before reading photonView.isMine. No Photon component is installed.
            if ((bool)Field("mShouldExplode").GetValue(this) ||
                (float)Field("mExplodeTime").GetValue(this) != 0f || photonView != null)
            {
                Failure = "Unexpected source exception before the explosion dispatch boundary.";
                return;
            }

            ExpiryTick = _tick;
            IsComplete = true;
        }

        if (_tick > 220 && !IsComplete)
        {
            Failure = "The recovered contact/countdown did not expire inside its bounded fixture.";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsComplete || Failure != null)
        {
            return;
        }

        _contactSourceName = collision.gameObject.name;
        try
        {
            typeof(GrenadeAmmoBase).GetMethod("OnCollisionEnter", PrivateFields)
                .Invoke(this, new object[] { collision });
        }
        catch (Exception exception)
        {
            Failure = exception.ToString();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsComplete || Failure != null)
        {
            return;
        }

        if (_activeSources.Remove(collision.gameObject.name))
        {
            _exits.Add(new { tick = Time.frameCount - _startFrame, source = collision.gameObject.name });
        }
    }

    protected override void GroundHitted()
    {
        // The original OnCollisionEnter calls this hook after resetting its countdown.
        _lastContactTick = Time.frameCount - _startFrame;
        _activeSources.Add(_contactSourceName);
        _contacts.Add(new { tick = _lastContactTick, source = _contactSourceName,
            remaining = (float)Field("mExplodeTime").GetValue(this) });
    }

    /// <summary>Returns observed source contact and expiry frames without claiming explosion dispatch.</summary>
    public object ExportObservation()
    {
        return new { fuseSeconds = FuseSeconds, recontact = HasRecontact,
            contacts = _contacts.ToArray(), exits = _exits.ToArray(),
            activeSources = _activeSources.OrderBy(source => source).ToArray(),
            lastContactTick = _lastContactTick, expiryTick = ExpiryTick };
    }

    private static FieldInfo Field(string name)
    {
        return typeof(GrenadeAmmoBase).GetField(name, PrivateFields);
    }
}
