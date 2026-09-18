using UnityEngine;

public class BeanstalkUrlCreator
{
	public bool isLocalhost => false;

	private static string mServerVersion => "09_25_2015";

	private static string mPort
	{
		get
		{
			if (environment == DatabaseEnvironment.Staging)
			{
				return "http://";
			}
			if (environment == DatabaseEnvironment.Production)
			{
				return "https://";
			}
			if (environment == DatabaseEnvironment.QA)
			{
				return "http://";
			}
			return "http://";
		}
	}

	public static DatabaseEnvironment environment
	{
		get
		{
			DatabaseEnvironment databaseEnvironment = DatabaseEnvironment.DevelopmentSvk;
			return DatabaseEnvironment.Production;
		}
	}

	public string CreateUrl()
	{
		string result = string.Empty;
		string empty = string.Empty;
		switch (environment)
		{
		case DatabaseEnvironment.DevelopmentSvk:
			empty = ((!isLocalhost) ? (mPort + "warfriends-dev.eu-west-1.elasticbeanstalk.com/") : "http://localhost:8082/");
			result = empty + "index_" + mServerVersion + ".php";
			break;
		case DatabaseEnvironment.Staging:
			empty = ((!isLocalhost) ? (mPort + "warfriends-staging.eu-west-1.elasticbeanstalk.com/") : "http://localhost:8082/");
			result = empty + "index_" + mServerVersion + ".php";
			break;
		case DatabaseEnvironment.Production:
			empty = ((!isLocalhost) ? (mPort + "warfriends-prod.eu-west-1.elasticbeanstalk.com/") : "http://localhost:8082/");
			result = empty + "index_" + mServerVersion + ".php";
			break;
		case DatabaseEnvironment.QA:
			empty = ((!isLocalhost) ? (mPort + "warfriends-qa.eu-west-1.elasticbeanstalk.com/") : "http://localhost:8082/");
			result = empty + "index_" + mServerVersion + ".php";
			break;
		}
		return result;
	}

	public string CreateAppLink()
	{
		Debug.Log("FB hosted app link: https://fb.me/1157647734253183");
		return "https://fb.me/1157647734253183";
	}
}
