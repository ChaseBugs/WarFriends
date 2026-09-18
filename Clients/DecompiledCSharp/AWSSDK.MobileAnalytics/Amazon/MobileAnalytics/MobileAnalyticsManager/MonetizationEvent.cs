using System;
using System.Globalization;
using Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;
using Amazon.MobileAnalytics.Model;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager;

public class MonetizationEvent : CustomEvent
{
	private const string PURCHASE_EVENT_NAME = "_monetization.purchase";

	private const string PURCHASE_EVENT_QUANTITY_METRIC = "_quantity";

	private const string PURCHASE_EVENT_ITEM_PRICE_METRIC = "_item_price";

	private const string PURCHASE_EVENT_PRODUCT_ID_ATTR = "_product_id";

	private const string PURCHASE_EVENT_ITEM_PRICE_FORMATTED_ATTR = "_item_price_formatted";

	private const string PURCHASE_EVENT_STORE_ATTR = "_store";

	private const string PURCHASE_EVENT_TRANSACTION_ID_ATTR = "_transaction_id";

	private const string PURCHASE_EVENT_CURRENCY_ATTR = "_currency";

	public double? Quantity { get; set; }

	public double? ItemPrice { get; set; }

	public string ProductId { get; set; }

	public string ItemPriceFormatted { get; set; }

	public string Store { get; set; }

	public string TransactionId { get; set; }

	public string Currency { get; set; }

	public MonetizationEvent()
		: base("_monetization.purchase")
	{
	}

	internal override Event ConvertToMobileAnalyticsModelEvent(Amazon.MobileAnalytics.MobileAnalyticsManager.Internal.Session session)
	{
		if (Quantity.HasValue)
		{
			AddMetric("_quantity", Convert.ToDouble(Quantity, CultureInfo.InvariantCulture));
		}
		if (ItemPrice.HasValue)
		{
			AddMetric("_item_price", Convert.ToDouble(ItemPrice, CultureInfo.InvariantCulture));
		}
		if (!string.IsNullOrEmpty(ProductId))
		{
			AddAttribute("_product_id", ProductId);
		}
		if (!string.IsNullOrEmpty(ItemPriceFormatted))
		{
			AddAttribute("_item_price_formatted", ItemPriceFormatted);
		}
		if (!string.IsNullOrEmpty(Store))
		{
			AddAttribute("_store", Store);
		}
		if (!string.IsNullOrEmpty(TransactionId))
		{
			AddAttribute("_transaction_id", TransactionId);
		}
		if (!string.IsNullOrEmpty(Currency))
		{
			AddAttribute("_currency", Currency);
		}
		return base.ConvertToMobileAnalyticsModelEvent(session);
	}
}
