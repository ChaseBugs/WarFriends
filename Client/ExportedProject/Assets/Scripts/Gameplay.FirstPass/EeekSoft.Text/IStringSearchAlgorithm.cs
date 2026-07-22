namespace EeekSoft.Text
{
	public interface IStringSearchAlgorithm
	{
		string[] Keywords { get; set; }

		StringSearchResult[] FindAll(string text);

		StringSearchResult FindFirst(string text);

		bool ContainsAny(string text);
	}
}
