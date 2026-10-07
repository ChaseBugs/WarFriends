using System;
using UnityEngine;
using War.Protocol;

// Explicit presentation binding for a server-owned player rig. The caller must
// own animation updates; this does not activate or replace normal controllers.
public sealed class SelfHostedRiflePoseRenderer
{
    private static readonly string[] Clips = { "idle", "player_look_left3", "player_fire_left3",
        "player_left_coverBack3", "player_look_right3", "player_fire_right3", "player_right_coverBack3",
        "player_look_left_qbz", "player_fire_left_qbz", "player_left_coverBack_qbz",
        "player_look_right_qbz", "player_fire_right_qbz", "player_right_coverBack_qbz",
        "player_look_left_qbz2", "player_fire_left_qbz2", "player_left_coverBack_qbz2",
        "player_look_right_qbz2", "player_fire_right_qbz2", "player_right_coverBack_qbz2",
        "player_look_left_shotgun", "player_fire_left_shotgun", "player_left_coverBack_shotgun",
        "player_look_right_shotgun", "player_fire_right_shotgun", "player_right_coverBack_shotgun",
        "run", "qbz_run", "qbz2_run", "shotgunner_run", "shootAdditive",
        "player_look_left_pistol", "player_fire_left_pistol", "player_left_coverBack_pistol",
        "player_look_right_pistol", "player_fire_right_pistol", "player_right_coverBack_pistol", "pistol_run",
        "player_look_left_minigun", "player_fire_left_minigun", "player_left_coverBack_minigun",
        "player_look_right_minigun", "player_fire_right_minigun", "player_right_coverBack_minigun",
        "minigun_run", "minigun_idle",
        "player_look_left_sniper", "player_fire_left_sniper", "player_left_coverBack_sniper",
        "player_look_right_sniper", "player_fire_right_sniper", "player_right_coverBack_sniper",
        "sniper_run", "sniper_idle",
        "bazooka_uncover_left", "bazooka_shoot_left", "bazooka_uncover_right", "bazooka_shoot_right",
        "bazooka_run", "bazooka_idle",
        "throw_grenade_left", "throw_grenade_right", "grenade_run", "grenade_idle",
        "player_look_left_grenadelauncher", "player_fire_left_grenadelauncher", "player_left_coverBack_grenadelauncher",
        "player_look_right_grenadelauncher", "player_fire_right_grenadelauncher", "player_right_coverBack_grenadelauncher",
        "run_grenadelauncher", "grenadelauncher_idle" };
    private readonly Transform root;
    private readonly SoldierAnimationController controller;
    private readonly Animation animation;
    private readonly Transform[] nodes;
    private readonly Local[] baseline;
    private readonly Local[][] samples;
    private readonly Local[] upperSample;
    private readonly SelfHostedRemoteTransformBuffer remoteTransform;
    private struct Local { public Vector3 Position, Scale; public Quaternion Rotation; }

    public SelfHostedRiflePoseRenderer(Transform playerRoot, SoldierAnimationController animator,
        bool remotePlayer = false)
    {
        if (playerRoot == null || animator == null || !animator.transform.IsChildOf(playerRoot) || animator.upperBody == null)
            throw new ArgumentException("A complete player animation rig is required.");
        root = playerRoot; controller = animator; animation = animator.GetComponent<Animation>();
        if (animation == null) throw new ArgumentException("Missing legacy Animation.");
        SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
        if (animation["T_pose"] == null) throw new ArgumentException("Missing reset pose.");
        foreach (string name in Clips) if (animation[name] == null || animation[name].length <= 0)
            throw new ArgumentException("Missing rifle clip: " + name);
        nodes = root.GetComponentsInChildren<Transform>(true);
        baseline = new Local[nodes.Length]; samples = new Local[4][]; upperSample = new Local[nodes.Length];
        Capture(baseline);
        for (int i = 0; i < samples.Length; i++) samples[i] = new Local[nodes.Length];
        if (remotePlayer) remoteTransform = new SelfHostedRemoteTransformBuffer();
    }

    public void Apply(BattlePlayerState player)
    {
        if (player == null || player.RiflePose == null) throw new ArgumentException("Missing rifle pose.");
        var pose = player.RiflePose;
        if (pose.Layers.Count < 1 || pose.Layers.Count > 4 || !Finite(player.PositionX) || !Finite(player.PositionY) || !Finite(player.PositionZ))
            throw new ArgumentException("Invalid rifle pose.");
        Vector3 visualPosition = root.position;
        Quaternion visualRotation = root.rotation;
        Quaternion rotation = Rotation(pose.RootRotation), body = Rotation(pose.BodyLocalRotation);
        Quaternion? upper = pose.UpperLocalRotation == null ? (Quaternion?)null : Rotation(pose.UpperLocalRotation);
        float total = 0;
        foreach (var layer in pose.Layers)
        {
            if ((int)layer.Clip < 1 || (int)layer.Clip > Clips.Length || double.IsNaN(layer.Seconds) || double.IsInfinity(layer.Seconds) ||
                layer.Seconds < 0 || layer.Seconds > 86400 || !Finite(layer.Weight) || layer.Weight < 0 || layer.Weight > 1)
                throw new ArgumentException("Invalid rifle layer.");
            total += layer.Weight;
        }
        if (Math.Abs(total - 1) > .00001f) throw new ArgumentException("Unnormalized rifle layers.");
        var overlay = pose.UpperBodyLayer;
        if (overlay != null && (!Finite(overlay.Seconds) || overlay.Seconds < 0 || overlay.Seconds > 86400 ||
            !Finite(overlay.Weight) || overlay.Weight < 0 || overlay.Weight > 1))
            throw new ArgumentException("Invalid upper-body rifle layer.");
        animation.Stop();
        for (int i = 0; i < pose.Layers.Count; i++)
        {
            Restore(baseline);
            Sample("T_pose", animation["T_pose"].length);
            var layer = pose.Layers[i]; var state = animation[Clips[(int)layer.Clip - 1]];
            double seconds = layer.Loop ? layer.Seconds % state.length : layer.Seconds;
            float held = seconds >= state.length ? state.length : (float)Math.Floor(seconds * 30) / 30f;
            Sample(state.name, held);
            Capture(samples[i]);
        }
        if (overlay != null)
        {
            Restore(baseline);
            Sample("T_pose", animation["T_pose"].length);
            var shot = animation["shootAdditive"];
            float held = overlay.Seconds >= shot.length ? shot.length : (float)Math.Floor(overlay.Seconds * 30) / 30f;
            Sample("shootAdditive", held);
            Capture(upperSample);
        }
        // Blend local transforms, including repeated instances of one clip at
        // different times. Legacy AnimationState cannot represent those directly.
        for (int n = 1; n < nodes.Length; n++)
        {
            Vector3 position = Vector3.zero, scale = Vector3.zero;
            Quaternion sum = new Quaternion(0, 0, 0, 0), hemisphere = Quaternion.identity;
            bool first = true;
            for (int i = 0; i < pose.Layers.Count; i++)
            {
                float weight = pose.Layers[i].Weight; if (weight == 0) continue;
                var local = samples[i][n];
                if (first) { hemisphere = local.Rotation; first = false; }
                position += local.Position * weight; scale += local.Scale * weight;
                float signed = Quaternion.Dot(hemisphere, local.Rotation) < 0 ? -weight : weight;
                sum.x += local.Rotation.x * signed; sum.y += local.Rotation.y * signed;
                sum.z += local.Rotation.z * signed; sum.w += local.Rotation.w * signed;
            }
            nodes[n].localPosition = position; nodes[n].localScale = scale; nodes[n].localRotation = sum.normalized;
        }
        if (overlay != null && overlay.Weight > 0)
            for (int n = 1; n < nodes.Length; n++)
                if (nodes[n] == controller.upperBody || nodes[n].IsChildOf(controller.upperBody))
                {
                    nodes[n].localPosition = Vector3.Lerp(nodes[n].localPosition, upperSample[n].Position, overlay.Weight);
                    nodes[n].localScale = Vector3.Lerp(nodes[n].localScale, upperSample[n].Scale, overlay.Weight);
                    nodes[n].localRotation = Quaternion.Lerp(nodes[n].localRotation, upperSample[n].Rotation, overlay.Weight).normalized;
                }
        var hostPosition = new Vector3(player.PositionX, player.PositionY, player.PositionZ);
        if (remoteTransform == null)
        {
            root.position = hostPosition;
            root.rotation = rotation;
        }
        else
        {
            // Recovered PlayerController updates PhotonTransform only for the
            // remote player. Keep the host pose as the animation authority and
            // buffer only its visual root transform.
            remoteTransform.Add(pose.SampledTick, hostPosition, rotation, Time.realtimeSinceStartup);
            if (remoteTransform.Count == 1)
            {
                root.position = hostPosition;
                root.rotation = rotation;
            }
            else
            {
                // Sampling the recovered Animation temporarily restores the
                // prefab's root transform. Keep the interpolated visual pose
                // until the next per-frame remote render.
                root.position = visualPosition;
                root.rotation = visualRotation;
            }
        }
        controller.transform.localRotation = body;
        if (upper.HasValue) controller.upperBody.localRotation = upper.Value;
    }
    public void RenderRemote(float now, float frameSeconds)
    {
        if (remoteTransform != null)
            remoteTransform.Render(root, now, frameSeconds);
    }
    public void ResetRemote()
    {
        if (remoteTransform != null) remoteTransform.Clear();
    }
    private void Sample(string name, float seconds)
    {
        foreach (AnimationState state in animation) state.enabled = false;
        var selected = animation[name]; selected.enabled = true; selected.weight = 1; selected.time = seconds;
        animation.Sample(); selected.enabled = false;
    }
    private void Capture(Local[] into)
    {
        for (int i = 0; i < nodes.Length; i++) into[i] = new Local { Position = nodes[i].localPosition, Rotation = nodes[i].localRotation, Scale = nodes[i].localScale };
    }
    private void Restore(Local[] from)
    {
        for (int i = 0; i < nodes.Length; i++) { nodes[i].localPosition = from[i].Position; nodes[i].localRotation = from[i].Rotation; nodes[i].localScale = from[i].Scale; }
    }
    private static bool Finite(float value) { return !float.IsNaN(value) && !float.IsInfinity(value); }
    private static Quaternion Rotation(PoseRotation q)
    {
        if (q == null || !Finite(q.X) || !Finite(q.Y) || !Finite(q.Z) || !Finite(q.W) || Math.Abs(q.X*q.X+q.Y*q.Y+q.Z*q.Z+q.W*q.W-1) > .0001f)
            throw new ArgumentException("Invalid pose rotation.");
        return new Quaternion(q.X,q.Y,q.Z,q.W);
    }
}

// Visual timing follows recovered PhotonTransform: ten samples, 0.18 seconds
// behind the newest host pose, with at most 0.2 seconds of extrapolation.
// No interpolated position is sent back as gameplay authority.
public sealed class SelfHostedRemoteTransformBuffer
{
    private struct Sample
    {
        public ulong Tick;
        public Vector3 Position;
        public Quaternion Rotation;
    }

    private const int Capacity = 10;
    // The self-hosted Worker advances exactly 30 simulation ticks per second.
    // Photon used timestamps in seconds; convert host ticks before applying
    // its recovered 0.18-second visual delay.
    private const double TickSeconds = 1.0 / 30.0;
    private readonly Sample[] samples = new Sample[Capacity]; // Newest first.
    private int count;
    private float receivedAt;

    public int Count { get { return count; } }

    public void Clear()
    {
        count = 0;
    }

    public void Add(ulong tick, Vector3 position, Quaternion rotation, float realtime)
    {
        if (tick > 10000000 || !Finite(position.x) || !Finite(position.y) || !Finite(position.z) ||
            !Finite(rotation.x) || !Finite(rotation.y) || !Finite(rotation.z) || !Finite(rotation.w) ||
            Mathf.Abs(Quaternion.Dot(rotation, rotation) - 1f) > .0001f ||
            !Finite(realtime) || realtime < 0)
            throw new ArgumentException("Invalid remote transform sample.");
        if (count > 0 && tick < samples[0].Tick)
            throw new InvalidOperationException("Remote transform sample moved backward in host time.");
        // Match admission can replace the recovered scene's placeholder rig
        // position with a distant server cover in the same match phase. That
        // is a spawn correction, not movement to interpolate across the map.
        if (count > 0 && Vector3.Distance(samples[0].Position, position) > 5f)
            Clear();
        if (count > 0 && tick == samples[0].Tick)
        {
            if (samples[0].Position == position && samples[0].Rotation == rotation)
                return; // Duplicate command responses do not restart visual time.
            samples[0] = new Sample { Tick = tick, Position = position, Rotation = rotation };
            receivedAt = realtime;
            return;
        }

        for (int i = Mathf.Min(count, Capacity - 1); i > 0; i--)
            samples[i] = samples[i - 1];
        samples[0] = new Sample { Tick = tick, Position = position, Rotation = rotation };
        count = Mathf.Min(count + 1, Capacity);
        receivedAt = realtime;
    }

    public void Render(Transform root, float realtime, float frameSeconds)
    {
        if (root == null || count == 0) return;
        if (!Finite(realtime) || !Finite(frameSeconds) || frameSeconds < 0)
            throw new ArgumentException("Invalid remote render time.");

        double elapsed = Math.Max(0, realtime - receivedAt);
        double renderTime = samples[0].Tick * TickSeconds + elapsed - .18;
        if (renderTime <= samples[count - 1].Tick * TickSeconds)
        {
            root.position = samples[count - 1].Position;
            root.rotation = samples[count - 1].Rotation;
            return;
        }

        for (int i = 1; i < count; i++)
        {
            double newerTime = samples[i - 1].Tick * TickSeconds;
            double olderTime = samples[i].Tick * TickSeconds;
            if (renderTime > newerTime || renderTime < olderTime) continue;
            float fraction = (float)((renderTime - olderTime) / (newerTime - olderTime));
            root.position = Vector3.Lerp(samples[i].Position, samples[i - 1].Position, fraction);
            root.rotation = Quaternion.Slerp(samples[i].Rotation, samples[i - 1].Rotation, fraction);
            return;
        }

        var latest = samples[0];
        double excess = renderTime - latest.Tick * TickSeconds;
        if (count > 1 && excess >= 0 && excess < .2)
        {
            double interval = Math.Max(.08, (latest.Tick - samples[1].Tick) * TickSeconds);
            root.position = latest.Position +
                (latest.Position - samples[1].Position) * (float)(excess / interval);
        }
        else if (count > 1 && excess >= .2 && excess < 1)
        {
            root.position = Vector3.Lerp(root.position, latest.Position, frameSeconds * 2f);
        }
        else
        {
            root.position = latest.Position;
        }
        root.rotation = latest.Rotation;
    }

    private static bool Finite(float value)
    {
        return !float.IsNaN(value) && !float.IsInfinity(value);
    }
}
