using Google2u;

public class StarterAssignmentCraftCard : StarterAssignment
{
	protected override int numberId
	{
		get
		{
			return 8;
		}
	}

	private bool mSucces
	{
		get
		{
			return SavingLastSelected.instance.data.goldCardCrafted;
		}
		set
		{
			if (mSucces != value)
			{
				SavingLastSelected.instance.data.goldCardCrafted = value;
				SavingLastSelected.instance.Save();
			}
		}
	}

	public override string text
	{
		get
		{
			return Localization.Localize("ID_STARTERASSIGNMENT" + numberId);
		}
	}

	public override string textProgress
	{
		get
		{
			return string.Format("({0}\u00a0/\u00a0{1})", mSucces ? 1 : 0, 1);
		}
	}

	public override void Init(StarterAssignmentsRow starterAssignmentsRow)
	{
		base.Init(starterAssignmentsRow);
		if (!base.completed)
		{
			CardCraftingManager.instance.CardWasCrafted += OnCardWasCrafted;
		}
	}

	private void OnCardWasCrafted(Card card)
	{
		if (!base.completed && card.rarity == CardManager.CardType.Gold)
		{
			mSucces = true;
			CardCraftingManager.instance.CardWasCrafted -= OnCardWasCrafted;
			StarterAssignmentsManager.instance.Evaluate();
		}
	}

	public override bool Evaluate()
	{
		if (!base.completed && mSucces)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
