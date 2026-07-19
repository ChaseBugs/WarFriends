using System.Collections;

namespace EeekSoft.Text
{
	public class StringSearch : IStringSearchAlgorithm
	{
		private class TreeNode
		{
			private char _char;

			private TreeNode _parent;

			private ArrayList _results;

			private string[] _resultsAr;

			private Hashtable _transHash;

			private TreeNode[] _transitionsAr;

			public char Char
			{
				get
				{
					return _char;
				}
			}

			public TreeNode Parent
			{
				get
				{
					return _parent;
				}
			}

			public TreeNode Failure { get; set; }

			public TreeNode[] Transitions
			{
				get
				{
					return _transitionsAr;
				}
			}

			public string[] Results
			{
				get
				{
					return _resultsAr;
				}
			}

			public TreeNode(TreeNode parent, char c)
			{
				_char = c;
				_parent = parent;
				_results = new ArrayList();
				_resultsAr = new string[0];
				_transitionsAr = new TreeNode[0];
				_transHash = new Hashtable();
			}

			public void AddResult(string result)
			{
				if (!_results.Contains(result))
				{
					_results.Add(result);
					_resultsAr = (string[])_results.ToArray(typeof(string));
				}
			}

			public void AddTransition(TreeNode node)
			{
				_transHash.Add(node.Char, node);
				TreeNode[] array = new TreeNode[_transHash.Values.Count];
				_transHash.Values.CopyTo(array, 0);
				_transitionsAr = array;
			}

			public TreeNode GetTransition(char c)
			{
				return (TreeNode)_transHash[c];
			}

			public bool ContainsTransition(char c)
			{
				return GetTransition(c) != null;
			}
		}

		private string[] _keywords;

		private TreeNode _root;

		public string[] Keywords
		{
			get
			{
				return _keywords;
			}
			set
			{
				_keywords = value;
				BuildTree();
			}
		}

		public StringSearch(string[] keywords)
		{
			Keywords = keywords;
		}

		public StringSearch()
		{
		}

		private void BuildTree()
		{
			_root = new TreeNode(null, ' ');
			string[] keywords = _keywords;
			foreach (string text in keywords)
			{
				TreeNode treeNode = _root;
				string text2 = text;
				foreach (char c in text2)
				{
					TreeNode treeNode2 = null;
					TreeNode[] transitions = treeNode.Transitions;
					foreach (TreeNode treeNode3 in transitions)
					{
						if (treeNode3.Char == c)
						{
							treeNode2 = treeNode3;
							break;
						}
					}
					if (treeNode2 == null)
					{
						treeNode2 = new TreeNode(treeNode, c);
						treeNode.AddTransition(treeNode2);
					}
					treeNode = treeNode2;
				}
				treeNode.AddResult(text);
			}
			ArrayList arrayList = new ArrayList();
			TreeNode[] transitions2 = _root.Transitions;
			foreach (TreeNode treeNode4 in transitions2)
			{
				treeNode4.Failure = _root;
				TreeNode[] transitions3 = treeNode4.Transitions;
				foreach (TreeNode value in transitions3)
				{
					arrayList.Add(value);
				}
			}
			while (arrayList.Count != 0)
			{
				ArrayList arrayList2 = new ArrayList();
				foreach (TreeNode item in arrayList)
				{
					TreeNode failure = item.Parent.Failure;
					char c2 = item.Char;
					while (failure != null && !failure.ContainsTransition(c2))
					{
						failure = failure.Failure;
					}
					if (failure == null)
					{
						item.Failure = _root;
					}
					else
					{
						item.Failure = failure.GetTransition(c2);
						string[] results = item.Failure.Results;
						foreach (string result in results)
						{
							item.AddResult(result);
						}
					}
					TreeNode[] transitions4 = item.Transitions;
					foreach (TreeNode value2 in transitions4)
					{
						arrayList2.Add(value2);
					}
				}
				arrayList = arrayList2;
			}
			_root.Failure = _root;
		}

		public StringSearchResult[] FindAll(string text)
		{
			ArrayList arrayList = new ArrayList();
			TreeNode treeNode = _root;
			for (int i = 0; i < text.Length; i++)
			{
				TreeNode treeNode2 = null;
				while (treeNode2 == null)
				{
					treeNode2 = treeNode.GetTransition(text[i]);
					if (treeNode == _root)
					{
						break;
					}
					if (treeNode2 == null)
					{
						treeNode = treeNode.Failure;
					}
				}
				if (treeNode2 != null)
				{
					treeNode = treeNode2;
				}
				string[] results = treeNode.Results;
				foreach (string text2 in results)
				{
					arrayList.Add(new StringSearchResult(i - text2.Length + 1, text2));
				}
			}
			return (StringSearchResult[])arrayList.ToArray(typeof(StringSearchResult));
		}

		public StringSearchResult FindFirst(string text)
		{
			TreeNode treeNode = _root;
			for (int i = 0; i < text.Length; i++)
			{
				TreeNode treeNode2 = null;
				while (treeNode2 == null)
				{
					treeNode2 = treeNode.GetTransition(text[i]);
					if (treeNode == _root)
					{
						break;
					}
					if (treeNode2 == null)
					{
						treeNode = treeNode.Failure;
					}
				}
				if (treeNode2 != null)
				{
					treeNode = treeNode2;
				}
				string[] results = treeNode.Results;
				int num = 0;
				if (num < results.Length)
				{
					string text2 = results[num];
					return new StringSearchResult(i - text2.Length + 1, text2);
				}
			}
			return StringSearchResult.Empty;
		}

		public bool ContainsAny(string text)
		{
			TreeNode treeNode = _root;
			for (int i = 0; i < text.Length; i++)
			{
				TreeNode treeNode2 = null;
				while (treeNode2 == null)
				{
					treeNode2 = treeNode.GetTransition(text[i]);
					if (treeNode == _root)
					{
						break;
					}
					if (treeNode2 == null)
					{
						treeNode = treeNode.Failure;
					}
				}
				if (treeNode2 != null)
				{
					treeNode = treeNode2;
				}
				if (treeNode.Results.Length > 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
