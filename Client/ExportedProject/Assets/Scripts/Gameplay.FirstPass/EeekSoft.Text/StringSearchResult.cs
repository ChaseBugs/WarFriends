namespace EeekSoft.Text
{
	public struct StringSearchResult
	{
		private int _index;

		private string _keyword;

		public int Index => _index;

		public string Keyword => _keyword;

		public static StringSearchResult Empty => new StringSearchResult(-1, string.Empty);

		public StringSearchResult(int index, string keyword)
		{
			_index = index;
			_keyword = keyword;
		}
	}
}
