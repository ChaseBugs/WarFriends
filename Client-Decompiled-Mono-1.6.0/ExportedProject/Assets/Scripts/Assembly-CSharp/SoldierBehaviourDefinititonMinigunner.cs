using System;

[Serializable]
public class SoldierBehaviourDefinititonMinigunner : SoldierBehaviourDefinititon
{
	public float shieldRechargeRate;

	public override void ILGFLFJIIKD()
	{
		FPKDOOLFAMM();
		shieldRechargeRate = 1047f;
	}

	public override void CDLJAKLCDMG()
	{
		CEFGHPBGDHJ();
		shieldRechargeRate = 1142f;
	}

	public override void IIEBAPPGDPH()
	{
		FPKDOOLFAMM();
		shieldRechargeRate = 769f;
	}

	public override void KFLADKOLPCM()
	{
		base.KFLADKOLPCM();
		shieldRechargeRate = 0f;
	}

	public virtual void FEDBFPFLPFK()
	{
		DIFCLHEPNHH();
		shieldRechargeRate = 555f;
	}
}
