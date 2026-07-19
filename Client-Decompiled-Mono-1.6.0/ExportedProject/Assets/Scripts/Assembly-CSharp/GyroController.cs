using UnityEngine;

public class GyroController : MonoBehaviour
{
	private bool OKLAKKMAJGG = true;

	private Quaternion OBAGIAGFJLB = Quaternion.identity;

	private Quaternion BKMMECPFBLC = Quaternion.identity;

	private Quaternion CACEMKJJKFJ = Quaternion.Euler(90f, 0f, 0f);

	private Quaternion DEPFGEAJHGP = Quaternion.identity;

	public Quaternion KGPGAPNAIBM;

	public void HGAFMOJIIGA()
	{
		OKLAKKMAJGG = false;
		LEIOILJPDCJ(true);
		GGCPJPOPPEJ();
	}

	public void IEHMHDIMNEN()
	{
		OKLAKKMAJGG = true;
		ILPHEAINMAL(true);
		HAEFJOIINJB();
	}

	private void AMINGNAJJMI()
	{
	}

	private void EKCLGJIFBBJ(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 813f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	public void GEJPNDKKDKN()
	{
		OKLAKKMAJGG = false;
		BPMCOOHCJFN(true);
		IGDIOMPOEDG();
	}

	private void PEOOFFLNFHN()
	{
		OKLAKKMAJGG = true;
	}

	private void HBMJHIFMBEF()
	{
	}

	private void IILEINHKPJC(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 1699f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	private void BPMCOOHCJFN(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 146f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	private void HPGGOLILJHJ(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 518f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	private static Quaternion MACMJFKAMDH(Quaternion DAFGEIDJBGM)
	{
		return new Quaternion(DAFGEIDJBGM.x, DAFGEIDJBGM.y, 0f - DAFGEIDJBGM.z, 0f - DAFGEIDJBGM.w);
	}

	private static Quaternion BOGAIPENEOB(Quaternion DAFGEIDJBGM)
	{
		return new Quaternion(DAFGEIDJBGM.x, DAFGEIDJBGM.y, 0f - DAFGEIDJBGM.z, 0f - DAFGEIDJBGM.w);
	}

	private void GFLHCEAGOPJ()
	{
	}

	private void AEEICLHHGHA()
	{
	}

	private void KFCKGEDDLHP(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 835f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	private void HAEFJOIINJB()
	{
		DEPFGEAJHGP = Quaternion.Inverse(CACEMKJJKFJ) * Quaternion.Inverse(BKMMECPFBLC);
	}

	private void FDDLPIGFLAH()
	{
	}

	private void PBIOAIFPLMC()
	{
	}

	private void NJPMDNPCLJI(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 159f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	private void PAKPJHJBPCC()
	{
		OKLAKKMAJGG = false;
	}

	protected void PIMNKPOIFOM()
	{
		Singleton<GameController>.instance.GameStarted += IJCMBBEAOKG;
	}

	public void AttachGyro()
	{
		OKLAKKMAJGG = true;
		IMABEKHLGKB(true);
		HAEFJOIINJB();
	}

	private void IMABEKHLGKB(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 0f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	private void ILPHEAINMAL(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 1336f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	public void FNPADFGFIHC()
	{
		OKLAKKMAJGG = true;
		ILPHEAINMAL(true);
		FGHPGCKJFGK();
	}

	protected void GMLBBGGLAHG()
	{
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	private void BOAJMKAIHHA()
	{
	}

	private void JMABACBLDLE()
	{
	}

	public void ENGFPFBFGNL()
	{
		OKLAKKMAJGG = true;
		LJDEFNCGALL(false);
		HAEFJOIINJB();
	}

	private void IEFABJFCCJJ()
	{
		OKLAKKMAJGG = false;
	}

	private void CPIBEPFKGKC()
	{
		OKLAKKMAJGG = false;
	}

	private void LEIOILJPDCJ(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 1056f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	protected void NHAEGCBBJNP()
	{
		Singleton<GameController>.instance.GameStarted += JMABACBLDLE;
	}

	public void HHLKFONIGKF()
	{
		OKLAKKMAJGG = false;
		LJDEFNCGALL(true);
		HAEFJOIINJB();
	}

	private void LCNMCKCCMDH()
	{
	}

	private void ACLCPJHKHLL()
	{
	}

	private void KFPMNKPEHOG()
	{
		OKLAKKMAJGG = false;
	}

	private void ECGHIJLMKDI()
	{
		OKLAKKMAJGG = true;
	}

	protected void Start()
	{
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	protected void FCNDEINOOCM()
	{
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	private void HCNNNCOEJCP()
	{
		DEPFGEAJHGP = Quaternion.Inverse(CACEMKJJKFJ) * Quaternion.Inverse(BKMMECPFBLC);
	}

	private void FGHPGCKJFGK()
	{
		DEPFGEAJHGP = Quaternion.Inverse(CACEMKJJKFJ) * Quaternion.Inverse(BKMMECPFBLC);
	}

	private void AECEAJAKJOH()
	{
	}

	private static Quaternion CHDCKMBGAJG(Quaternion DAFGEIDJBGM)
	{
		return new Quaternion(DAFGEIDJBGM.x, DAFGEIDJBGM.y, 0f - DAFGEIDJBGM.z, 0f - DAFGEIDJBGM.w);
	}

	private void HFCLCAHMAGN()
	{
	}

	private void GGCPJPOPPEJ()
	{
		DEPFGEAJHGP = Quaternion.Inverse(CACEMKJJKFJ) * Quaternion.Inverse(BKMMECPFBLC);
	}

	private void IHJBABHLAEE()
	{
		DEPFGEAJHGP = Quaternion.Inverse(CACEMKJJKFJ) * Quaternion.Inverse(BKMMECPFBLC);
	}

	protected void CMDMNDCMBJO()
	{
		Singleton<GameController>.instance.GameStarted += JMABACBLDLE;
	}

	private void MFMJGPIBNCL()
	{
	}

	protected void KCCGPMHIHNG()
	{
		Singleton<GameController>.instance.GameStarted += BOAJMKAIHHA;
	}

	private void OJDJLDDCNPM()
	{
	}

	private void PDAIKBCLJNE()
	{
		OKLAKKMAJGG = true;
	}

	private void IGDIOMPOEDG()
	{
		DEPFGEAJHGP = Quaternion.Inverse(CACEMKJJKFJ) * Quaternion.Inverse(BKMMECPFBLC);
	}

	private void LJDEFNCGALL(bool HLJINDGKCGB)
	{
		if (HLJINDGKCGB)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 1952f;
			if (vector == Vector3.zero)
			{
				BKMMECPFBLC = Quaternion.identity;
			}
			else
			{
				BKMMECPFBLC = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			BKMMECPFBLC = Input.gyro.attitude;
		}
	}

	private void IJCMBBEAOKG()
	{
	}
}
