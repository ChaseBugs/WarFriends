using System.Collections;

namespace LitJson;

public interface IOrderedDictionary : ICollection, IDictionary, IEnumerable
{
	object this[int index] { get; set; }

	new IDictionaryEnumerator GetEnumerator();

	void Insert(int index, object key, object value);

	void RemoveAt(int index);
}
