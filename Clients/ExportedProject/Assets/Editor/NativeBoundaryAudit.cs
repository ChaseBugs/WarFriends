using UnityEngine;

public static class NativeBoundaryAudit
{
    public static void Run()
    {
        Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "Audit", "Unused");
        Terms.initialiseTermsSession(false, false, Terms.ComplianceLevel.FULLY_COMPLIANT_ADULT_CONTENT);
        Terms.showTermsUI();
        Terms.closeTermsSession();
        Offers.closeOffersSession();
        foreach (string name in new[] { "Terms", "Offers" })
        {
            System.Type type = typeof(Terms).Assembly.GetType(name);
            foreach (var method in type.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic))
                if ((method.Attributes & System.Reflection.MethodAttributes.PinvokeImpl) != 0)
                    throw new System.Exception("Native mobile import remained in Editor: " + method.Name);
        }
        Debug.Log("NATIVE_BOUNDARY_AUDIT_PASSED");
        foreach (string scene in new[] { "SplashScene", "MainScene" })
        {
            var opened = UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scenes/" + scene + ".unity");
            foreach (GameObject root in opened.GetRootGameObjects())
                foreach (Transform child in root.GetComponentsInChildren<Transform>(true))
                    foreach (Component component in child.GetComponents<Component>())
                        if (component == null)
                            throw new System.Exception("Missing script in " + scene + ": " + child.name);
            Debug.Log("SCENE_REFERENCE_AUDIT_PASSED " + scene);
        }
    }
}
