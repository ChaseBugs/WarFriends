using System;
using System.Linq;
using System.Reflection;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace WarFriends.Validation
{
    /// <summary>Exercises exact scene-subscription ownership and explicit service teardown.</summary>
    public static class UnityFuseLifecycleAudit
    {
        private const BindingFlags Fields = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        private static int _checks;

        public static void Run()
        {
            try
            {
                if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
                {
                    throw new InvalidOperationException("Use a disposable validation project.");
                }
                EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
                var service = new FuseboxxService();
                try
                {
                    VerifyBindings(service);
                }
                finally
                {
                    service.Dispose();
                }
                Require(typeof(FuseboxxService).GetMethod("Finalize",
                    BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic) == null,
                    "The service must not access Unity from a GC finalizer.");
                Debug.Log("PASS: " + _checks + " Fuse scene-subscription lifecycle checks.");
                EditorApplication.Exit(0);
            }
            catch (Exception failure)
            {
                Debug.LogException(failure);
                EditorApplication.Exit(1);
            }
        }

        private static void VerifyBindings(FuseboxxService service)
        {
            BeanstalkServerManager server = Singleton<BeanstalkServerManager>.instance;
            GameController game = Singleton<GameController>.instance;
            IDisposable previous = service.BindSceneEvents();
            RequireSubscriptions(service, server, game, 1);
            IDisposable current = service.BindSceneEvents();
            RequireSubscriptions(service, server, game, 1);
            previous.Dispose();
            RequireSubscriptions(service, server, game, 1);
            current.Dispose();
            current.Dispose();
            RequireSubscriptions(service, server, game, 0);
            IDisposable last = service.BindSceneEvents();
            bool wasQuitting = Singleton.applicationIsQuitting;
            try
            {
                Singleton.applicationIsQuitting = true;
                service.Dispose();
                service.Dispose();
                last.Dispose();
                RequireSubscriptions(service, server, game, 0);
            }
            finally
            {
                Singleton.applicationIsQuitting = wasQuitting;
            }
            try
            {
                service.BindSceneEvents();
                throw new InvalidOperationException("A disposed service rebound scene events.");
            }
            catch (ObjectDisposedException)
            {
                _checks++;
            }
        }

        private static void RequireSubscriptions(FuseboxxService service,
            BeanstalkServerManager server, GameController game, int expected)
        {
            Require(Count(server, "AfterPlayerDataLoaded", service) == expected,
                "Player-data completion must have one current owner.");
            Require(Count(server, "DataLoaded", service) == expected,
                "Configuration updates must have one current owner.");
            Require(Count(game, "GameEnded", service) == expected,
                "Battle completion must have one current owner.");
        }

        private static int Count(object publisher, string name, FuseboxxService service)
        {
            var subscribers = (Delegate)publisher.GetType().GetField(name, Fields).GetValue(publisher);
            return subscribers == null ? 0 : subscribers.GetInvocationList().Count(item => item.Target == service);
        }

        private static void Require(bool condition, string message)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }
            _checks++;
        }
    }
}
