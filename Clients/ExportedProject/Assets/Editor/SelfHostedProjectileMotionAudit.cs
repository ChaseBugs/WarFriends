using System;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedProjectileMotionAudit
{
    public static void Run()
    {
        var owner = new GameObject("ProjectileMotionAudit");
        try
        {
            var presenter = owner.AddComponent<SelfHostedProjectilePresenter>();
            var snapshot = new MatchSnapshot();
            var projectile = new BattleProjectileState
            {
                ProjectileId = 77,
                Kind = "grenade",
                X = 1f, Y = 2f, Z = 3f,
                VelocityX = 10f
            };
            snapshot.Projectiles.Add(projectile);
            presenter.Apply(snapshot);
            var visual = GameObject.Find("SelfHostedProjectile_77");
            Require(visual != null && visual.transform.position == new Vector3(1f, 2f, 3f),
                "first host pose");

            presenter.RenderAt(Time.realtimeSinceStartup + .05f);
            Require(Mathf.Abs(visual.transform.position.x - 1.5f) < .06f,
                "velocity advances the visual between snapshots: x="+visual.transform.position.x);
            presenter.RenderAt(Time.realtimeSinceStartup + 1f);
            Require(Mathf.Abs(visual.transform.position.x - 2f) < .01f,
                "visual prediction stops after one poll interval");

            projectile.X = 2f;
            presenter.Apply(snapshot);
            Require(Mathf.Abs(visual.transform.position.x - 2f) < .01f,
                "new host pose corrects the visual");
            presenter.RenderAt(Time.realtimeSinceStartup + .05f);
            Require(Mathf.Abs(visual.transform.position.x - 2.5f) < .06f,
                "new host velocity starts a fresh bounded segment");

            bool rejected = false;
            projectile.VelocityX = float.NaN;
            try { presenter.Apply(snapshot); }
            catch (InvalidOperationException) { rejected = true; }
            Require(rejected && Mathf.Abs(visual.transform.position.x - 2.5f) < .06f,
                "malformed host velocity cannot change the visual");
            snapshot.Projectiles.Clear();
            presenter.Apply(snapshot);
            Require(GameObject.Find("SelfHostedProjectile_77") == null,
                "complete host snapshot removes absent projectile");

            Debug.Log("UNITY_PROJECTILE_MOTION_PASSED boundedStep=True correction=True removal=True");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogError(exception);
            EditorApplication.Exit(1);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException("Projectile motion audit: " + message);
    }
}
