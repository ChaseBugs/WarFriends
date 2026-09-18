using UnityEngine;

internal class DailyRentalMessage : DatabaseMessage
{
	private string mRentalID;

	private int mRentalDiscount;

	private GameItem mRentalType;

	private bool mIsOnSale;

	public DailyRentalMessage(string rentalID, int rentalDiscount, GameItem rentalType, bool isOnSale, string nextRentalTimeString)
		: base($"DailyRentalMessage{rentalID}{isOnSale}{nextRentalTimeString}", Type.DailyRental)
	{
		mRentalID = rentalID;
		mRentalDiscount = rentalDiscount;
		mRentalType = rentalType;
		mIsOnSale = isOnSale;
		Debug.Log("ABOUT TO SHOW DAILY RENTAL");
	}

	public DailyRentalMessage(string rentalID, string rentalDiscount, GameItem rentalType, bool isOnSale, string nextRentalTimeString)
		: base($"DailyRentalMessage{rentalID}{isOnSale}{nextRentalTimeString}", Type.DailyRental)
	{
		mRentalID = rentalID;
		if (!int.TryParse(rentalDiscount, out mRentalDiscount))
		{
			mRentalDiscount = 0;
			Debug.LogError("Rental Dialog, rental discount is not integer: " + rentalDiscount);
		}
		mRentalType = rentalType;
		mIsOnSale = isOnSale;
		Debug.Log("ABOUT TO SHOW DAILY RENTAL");
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<RentalDialog>.instance.ShowRentalDialog(mRentalID, mRentalDiscount, mRentalType, mIsOnSale);
	}
}
