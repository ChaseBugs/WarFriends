using System.Collections.Generic;

public class SpawnHelper
{
	public Dictionary<Fractions, int> generatedCount = new Dictionary<Fractions, int>();

	public Dictionary<Fractions, int> killedCount = new Dictionary<Fractions, int>();

	public int this[Fractions index] => generatedCount[index] - killedCount[index];

	public void Reset()
	{
		generatedCount[Fractions.Allies] = 0;
		generatedCount[Fractions.Enemies] = 0;
		killedCount[Fractions.Allies] = 0;
		killedCount[Fractions.Enemies] = 0;
	}

	public void Kill(Fractions fraction)
	{
		Dictionary<Fractions, int> dictionary2;
		Dictionary<Fractions, int> dictionary = (dictionary2 = killedCount);
		Fractions key2;
		Fractions key = (key2 = fraction);
		int num = dictionary2[key2];
		dictionary[key] = num + 1;
	}

	public void Spawn(Fractions fraction, int numberOfEnemies)
	{
		Dictionary<Fractions, int> dictionary2;
		Dictionary<Fractions, int> dictionary = (dictionary2 = generatedCount);
		Fractions key2;
		Fractions key = (key2 = fraction);
		int num = dictionary2[key2];
		dictionary[key] = num + numberOfEnemies;
	}

	public override string ToString()
	{
		string text = string.Empty;
		foreach (KeyValuePair<Fractions, int> item in generatedCount)
		{
			string text2 = text;
			text = string.Concat(text2, item.Key, ": G:", generatedCount[item.Key], " K:", killedCount[item.Key], " S:", this[item.Key], "\n");
		}
		return text;
	}
}
