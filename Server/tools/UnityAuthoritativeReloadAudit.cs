using System;
using System.Linq;
using System.Reflection;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// Checks the recovered weapon component's host reload projection and legacy release boundary.
/// </summary>
public static class UnityAuthoritativeReloadAudit
{
    private const ulong StartTick = 100;
    private const ulong ReloadEndTick = 130;
    private const int InitialClipAmmo = 1;
    private const int InitialReserveAmmo = 10;
    private static int _checks;

    /// <summary>Runs only in a disposable project without writing any scene or prefab.</summary>
    public static void Run()
    {
        try
        {
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
            {
                throw new InvalidOperationException("Use a disposable validation project.");
            }
            EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Weapon weapon = Resources.FindObjectsOfTypeAll<Weapon>()
                .First(candidate => candidate.GetType() == typeof(AutomaticRifle) && candidate.reloadableWeapon &&
                    (int)candidate.clipSize > InitialClipAmmo &&
                    (float)candidate.reloadTime > 1f);
            VerifyHostProjection(weapon);
            Debug.Log("PASS: " + _checks + " actual weapon reload authority checks.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifyHostProjection(Weapon weapon)
    {
        weapon.ammoLeftInClip = InitialClipAmmo;
        weapon.ammoLeft = InitialReserveAmmo;
        weapon.ApplySelfHostedReload(StartTick, ReloadEndTick);
        Require(weapon.isReloading, "A pending host reload must be displayed.");
        Require(weapon.reloadingTimeLeft == 1f, "The countdown must use the host tick difference.");
        float progress = weapon.reloadProgress;
        Require(progress >= 0f && progress <= 1f, "The host reload progress must be bounded.");
        InvokeLocalCompletion(weapon);
        RequireUnchangedAmmunition(weapon);
        Require(weapon.isReloading, "Local completion must not clear a pending host reload.");
        VerifyInvalidDuration(weapon, progress);
        weapon.ApplySelfHostedReload(ReloadEndTick, 0);
        Require(!weapon.isReloading && weapon.reloadingTimeLeft == 0f,
            "A completed host snapshot must clear the reload display.");
        InvokeLocalCompletion(weapon);
        RequireUnchangedAmmunition(weapon);
        weapon.ClearSelfHostedReload();
        InvokeLocalCompletion(weapon);
        int transferred = Math.Min((int)weapon.clipSize - InitialClipAmmo, InitialReserveAmmo);
        Require(weapon.ammoLeftInClip == InitialClipAmmo + transferred &&
            weapon.ammoLeft == InitialReserveAmmo - transferred,
            "Releasing the projection must preserve ordinary local reload arithmetic.");
    }

    private static void VerifyInvalidDuration(Weapon weapon, float expectedProgress)
    {
        float originalDuration = weapon.reloadTime;
        bool rejected = false;
        try
        {
            weapon.reloadTime = 0f;
            weapon.ApplySelfHostedReload(StartTick, ReloadEndTick);
        }
        catch (InvalidOperationException)
        {
            rejected = true;
        }
        finally
        {
            weapon.reloadTime = originalDuration;
        }
        Require(rejected, "An invalid reload duration must fail before projection publication.");
        Require(weapon.isReloading && weapon.reloadProgress == expectedProgress && weapon.reloadingTimeLeft == 1f,
            "Rejected projection must retain the previous complete display state.");
    }

    private static void RequireUnchangedAmmunition(Weapon weapon)
    {
        Require(weapon.ammoLeftInClip == InitialClipAmmo && weapon.ammoLeft == InitialReserveAmmo,
            "Only a host snapshot may replenish ammunition while the projection is owned.");
    }

    private static void InvokeLocalCompletion(Weapon weapon)
    {
        typeof(Weapon).GetMethod("FinishReload", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(weapon, null);
    }

    private static void Require(bool condition, string message)
    {
        _checks++;
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
