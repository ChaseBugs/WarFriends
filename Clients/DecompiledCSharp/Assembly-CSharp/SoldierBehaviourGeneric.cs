using UnityEngine;

[RequireComponent(typeof(EnemyBasicInventory))]
[ExecuteInEditMode]
public class SoldierBehaviourGeneric<T> : SoldierBehaviour where T : SoldierBehaviourDefinititon
{
	public T baseDefinition;

	public override SoldierBehaviourDefinititon soldierBaseDefinition
	{
		get
		{
			return baseDefinition;
		}
		set
		{
		}
	}

	protected T mBehaviourDef => (T)base.behaviourDefinition;

	public override BehaviourDefinititon baseBehaviourDefinititon => soldierBaseDefinition;

	public override void Copy(AIObject to)
	{
		base.Copy(to);
		EnemyBasicInventory component = GetComponent<EnemyBasicInventory>();
		to.gameObject.CopyComponent(component);
	}
}
