using System;

public interface NKMKCCDCHCL : KMHCMCBGFFC
{
	int power { get; set; }

	bool isAlive { get; set; }

	event Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> Killed;
}
