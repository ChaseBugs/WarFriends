using System;
using ExitGames.Client.Photon;

public class PhotonPlayer : IComparable<PhotonPlayer>, IComparable<int>, IEquatable<PhotonPlayer>, IEquatable<int>
{
	private int actorID;

	private string nameField;

	public readonly bool IsLocal;

	public object TagObject;

	public int ID => 0;

	public string NickName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string UserId { get; internal set; }

	public bool IsMasterClient => false;

	public bool IsInactive { get; set; }

	public Hashtable CustomProperties { get; internal set; }

	public Hashtable AllProperties => null;

	[Obsolete]
	public string name
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Obsolete]
	public string userId
	{
		get
		{
			return null;
		}
		internal set
		{
		}
	}

	[Obsolete]
	public bool isLocal => false;

	[Obsolete]
	public bool isMasterClient => false;

	[Obsolete]
	public bool isInactive
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete]
	public Hashtable customProperties
	{
		get
		{
			return null;
		}
		internal set
		{
		}
	}

	[Obsolete]
	public Hashtable allProperties => null;

	public PhotonPlayer(bool isLocal, int actorID, string name)
	{
	}

	protected internal PhotonPlayer(bool isLocal, int actorID, Hashtable properties)
	{
	}

	public override bool Equals(object p)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	internal void InternalChangeLocalID(int newID)
	{
	}

	internal void InternalCacheProperties(Hashtable properties)
	{
	}

	public void SetCustomProperties(Hashtable propertiesToSet, Hashtable expectedValues = null, bool webForward = false)
	{
	}

	public static PhotonPlayer Find(int ID)
	{
		return null;
	}

	public PhotonPlayer Get(int id)
	{
		return null;
	}

	public PhotonPlayer GetNext()
	{
		return null;
	}

	public PhotonPlayer GetNextFor(PhotonPlayer currentPlayer)
	{
		return null;
	}

	public PhotonPlayer GetNextFor(int currentPlayerId)
	{
		return null;
	}

	public int CompareTo(PhotonPlayer other)
	{
		return 0;
	}

	public int CompareTo(int other)
	{
		return 0;
	}

	public bool Equals(PhotonPlayer other)
	{
		return false;
	}

	public bool Equals(int other)
	{
		return false;
	}

	public override string ToString()
	{
		return null;
	}

	public string ToStringFull()
	{
		return null;
	}
}
