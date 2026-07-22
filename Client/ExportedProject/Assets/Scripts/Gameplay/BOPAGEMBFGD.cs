using System;

public abstract class BOPAGEMBFGD
{
	protected bool CABPOBJLLFD;

	public virtual void BFENONOEFBF()
	{
		CABPOBJLLFD = true;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.HDAIFEPKOBH = (Action)Delegate.Remove(instance.HDAIFEPKOBH, new Action(NFNGHLBEOJO));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.HDAIFEPKOBH = (Action)Delegate.Combine(instance2.HDAIFEPKOBH, new Action(NFNGHLBEOJO));
		CounterManager instance3 = Singleton<CounterManager>.instance;
		instance3.MPCAACLAGOA = (Action)Delegate.Remove(instance3.MPCAACLAGOA, new Action(LHMJNPCNNCO));
		CounterManager instance4 = Singleton<CounterManager>.instance;
		instance4.MPCAACLAGOA = (Action)Delegate.Combine(instance4.MPCAACLAGOA, new Action(LHMJNPCNNCO));
	}

	public virtual void FMFJKGGPDPI()
	{
		CABPOBJLLFD = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.HDAIFEPKOBH = (Action)Delegate.Remove(instance.HDAIFEPKOBH, new Action(NFNGHLBEOJO));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Remove(instance2.MPCAACLAGOA, new Action(LHMJNPCNNCO));
	}

	protected abstract void NFNGHLBEOJO();

	protected abstract void LHMJNPCNNCO();
}
