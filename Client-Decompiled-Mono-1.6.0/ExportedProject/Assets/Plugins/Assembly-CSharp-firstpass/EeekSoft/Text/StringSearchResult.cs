namespace EeekSoft.Text
{
	public struct StringSearchResult
	{
		private int _index;

		private string _keyword;

		public int Index
		{
			get
			{
				return _index;
			}
		}

		public string Keyword
		{
			get
			{
				return _keyword;
			}
		}

		public static StringSearchResult Empty
		{
			get
			{
				return new StringSearchResult(-1, string.Empty);
			}
		}

		public StringSearchResult(int index, string keyword)
		{
			_index = index;
			_keyword = keyword;
		}
	}
}
