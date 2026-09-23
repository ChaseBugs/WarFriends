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
    private struct Local { public Vector3 Position, Scale; public Quaternion Rotation; }

    public SelfHostedRiflePoseRenderer(Transform playerRoot, SoldierAnimationController animator)
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
    }

    public void Apply(BattlePlayerState player)
    {
        if (player == null || player.RiflePose == null) throw new ArgumentException("Missing rifle pose.");
        var pose = player.RiflePose;
        if (pose.Layers.Count < 1 || pose.Layers.Count > 4 || !Finite(player.PositionX) || !Finite(player.PositionY) || !Finite(player.PositionZ))
            throw new ArgumentException("Invalid rifle pose.");
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
        root.position = new Vector3(player.PositionX, player.PositionY, player.PositionZ); root.rotation = rotation;
        controller.transform.localRotation = body;
        if (upper.HasValue) controller.upperBody.localRotation = upper.Value;
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
