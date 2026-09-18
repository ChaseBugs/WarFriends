using System;

namespace Prime31;

public class FacebookAuthHelper
{
	public Action afterAuthAction;

	public bool requiresPublishPermissions;

	private static FacebookAuthHelper _instance;

	public FacebookAuthHelper(bool requiresPublishPermissions, Action afterAuthAction)
	{
		_instance = this;
		this.requiresPublishPermissions = requiresPublishPermissions;
		this.afterAuthAction = afterAuthAction;
		FacebookManager.sessionOpenedEvent += sessionOpenedEvent;
		FacebookManager.loginFailedEvent += loginFailedEvent;
	}

	~FacebookAuthHelper()
	{
		cleanup();
	}

	public void cleanup()
	{
		if (afterAuthAction != null)
		{
			FacebookManager.sessionOpenedEvent -= sessionOpenedEvent;
			FacebookManager.loginFailedEvent -= loginFailedEvent;
		}
		_instance = null;
	}

	public void start()
	{
		FacebookAndroid.login();
	}

	private void sessionOpenedEvent()
	{
		if (requiresPublishPermissions && !FacebookAndroid.getSessionPermissions().Contains("publish_actions"))
		{
			FacebookAndroid.loginWithPublishPermissions(new string[1] { "publish_actions" });
		}
		else
		{
			afterAuthAction();
			cleanup();
		}
	}

	private void loginFailedEvent(P31Error error)
	{
		cleanup();
	}
}
