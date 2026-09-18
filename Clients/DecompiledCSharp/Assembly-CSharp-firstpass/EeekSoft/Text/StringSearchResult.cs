namespace EeekSoft.Text;

public struct StringSearchResult(int index, string keyword)
{
	private int _index = index;

	private string _keyword = keyword;

	public int Index => _index;

	public string Keyword => _keyword;

	public static StringSearchResult Empty => new StringSearchResult(-1, string.Empty);
}
