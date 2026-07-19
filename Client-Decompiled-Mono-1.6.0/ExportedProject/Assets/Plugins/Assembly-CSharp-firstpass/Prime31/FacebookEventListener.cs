using System.Collections.Generic;
using UnityEngine;

namespace Prime31
{
	public class FacebookEventListener : MonoBehaviour
	{
		private void OnEnable()
		{
			FacebookManager.sessionOpenedEvent += sessionOpenedEvent;
			FacebookManager.loginFailedEvent += loginFailedEvent;
			FacebookManager.graphRequestCompletedEvent += graphRequestCompletedEvent;
			FacebookManager.graphRequestFailedEvent += facebookCustomRequestFailed;
			FacebookManager.facebookComposerCompletedEvent += facebookComposerCompletedEvent;
			FacebookManager.shareDialogFailedEvent += shareDialogFailedEvent;
			FacebookManager.shareDialogSucceededEvent += shareDialogSucceededEvent;
			FacebookManager.gameDialogFailedEvent += gameDialogFailedEvent;
			FacebookManager.gameDialogSucceededEvent += gameDialogSucceededEvent;
		}

		private void OnDisable()
		{
			FacebookManager.sessionOpenedEvent -= sessionOpenedEvent;
			FacebookManager.loginFailedEvent -= loginFailedEvent;
			FacebookManager.graphRequestCompletedEvent -= graphRequestCompletedEvent;
			FacebookManager.graphRequestFailedEvent -= facebookCustomRequestFailed;
			FacebookManager.facebookComposerCompletedEvent -= facebookComposerCompletedEvent;
			FacebookManager.shareDialogFailedEvent -= shareDialogFailedEvent;
			FacebookManager.shareDialogSucceededEvent -= shareDialogSucceededEvent;
			FacebookManager.gameDialogFailedEvent -= gameDialogFailedEvent;
			FacebookManager.gameDialogSucceededEvent -= gameDialogSucceededEvent;
		}

		private void sessionOpenedEvent()
		{
			Debug.Log("Successfully logged in to Facebook");
		}

		private void loginFailedEvent(P31Error error)
		{
			Debug.Log("Facebook login failed: " + error);
		}

		private void facebokDialogCompleted()
		{
			Debug.Log("facebokDialogCompleted");
		}

		private void graphRequestCompletedEvent(object obj)
		{
			Debug.Log("graphRequestCompletedEvent");
			Utils.logObject(obj);
		}

		private void facebookCustomRequestFailed(P31Error error)
		{
			Debug.Log("facebookCustomRequestFailed failed: " + error);
		}

		private void facebookComposerCompletedEvent(bool didSucceed)
		{
			Debug.Log("facebookComposerCompletedEvent did succeed: " + didSucceed);
		}

		private void shareDialogFailedEvent(P31Error error)
		{
			Debug.Log("shareDialogFailedEvent: " + error);
		}

		private void shareDialogSucceededEvent(string postId)
		{
			Debug.Log("shareDialogSucceededEvent: " + postId);
		}

		private void gameDialogFailedEvent(P31Error error)
		{
			Debug.Log("gameDialogFailedEvent: " + error);
		}

		private void gameDialogSucceededEvent(Dictionary<string, object> dict)
		{
			Debug.Log("gameDialogSucceededEvent");
			Utils.logObject(dict);
		}
	}
}
