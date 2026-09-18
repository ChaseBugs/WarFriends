using System;
using System.Reflection;
using UnityEngine;

public static class StartupReadinessAudit
{
    public static void Run()
    {
        NativeBoundaryAudit.Run();
        foreach (Type type in new[] { typeof(InputController), typeof(GameControllerWarArena),
            typeof(GameControllerCoop), typeof(GameControllerDeathMatch), typeof(SessionManager),
            typeof(VipManager), typeof(BeanstalkServerManager), typeof(WeaponPreviewCamera) })
        {
            UnityEngine.Object[] instances = UnityEngine.Object.FindObjectsOfType(type);
            if (instances.Length == 0) throw new Exception("Audit component missing: " + type.Name);
            string methodName = type == typeof(WeaponPreviewCamera) ? "LateUpdate" : "Update";
            MethodInfo method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (UnityEngine.Object instance in instances) method.Invoke(instance, null);
            Debug.Log("STARTUP_UPDATE_AUDIT_PASSED " + type.Name);
        }
        if (GuiElementSingle<ConfirmDialog>.instance == null)
            throw new Exception("Recovered ConfirmDialog is missing");
        Debug.Log("STARTUP_READINESS_AUDIT_PASSED");
    }
}
