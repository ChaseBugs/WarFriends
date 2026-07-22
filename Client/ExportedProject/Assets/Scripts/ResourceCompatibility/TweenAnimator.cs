using System;
using System.Collections.Generic;
using UnityEngine;

public class TweenAnimator : Core_BaseScript
{
	public enum FOBNKLOLDGI
	{
		Position,
		Rotation,
		AlphaTk2d,
		Color,
		Scale,
		Alpha,
		TextCounter,
		SufixTextCounter,
		TextCounterSpecial,
		TimeCounter,
		ProgressBar,
		AlphaHider,
		Sound,
		TextCounterLong
	}

	[Serializable]
	public class TweenRecord
	{
		[SerializeField]
		public int id;

		[SerializeField]
		public FOBNKLOLDGI type;

		[SerializeField]
		public float time;

		[SerializeField]
		public float delay;

		[SerializeField]
		public object to;

		[SerializeField]
		public object from;

		[SerializeField]
		public UITweener.Method method;

		[SerializeField]
		public UITweener.Style style;

		[SerializeField]
		public int playAfterId;

		[SerializeField]
		public GameObject tweenTarget;

		[SerializeField]
		public int numOfRepetitions;

		[SerializeField]
		public SoundsManager.SoundsEnum soundEnum;
	}

	private sealed class PIFFHGDEDGP
	{
		public TweenRecord PKNHPGLIEAE;

		internal void JGFLJEFBGHO()
		{
		}
	}

	public List<TweenRecord> EKAMONHBBAB;

	public Action<int> BACCNIFOBEH;

	private bool KMECKHKOAIC;

	public bool IFJGEMJNGIJ;

	private static Dictionary<FOBNKLOLDGI, Type> ABHDLINJNKK;

	public TweenRecord AddTween(int AOCDKEILCLP, FOBNKLOLDGI LCOCOANKCNG, GameObject BMBJCHCEEHI, float GAMFJEOGHJD, object FFJGKOLGFLL, float PCCJGICLAEL = 0f, int HNMDJBJLHPJ = -1, object EMMCJEEABGA = null, UITweener.Method HDMPBACOMBH = UITweener.Method.EaseInOut, UITweener.Style MNMBOLOJOOH = UITweener.Style.Once, int OHOLJJCCGGA = 1)
	{
		return null;
	}

	public TweenRecord AddSoundTween(int AOCDKEILCLP, SoundsManager.SoundsEnum FGPAHMHGPEP, float PCCJGICLAEL = 0f, int HNMDJBJLHPJ = -1)
	{
		return null;
	}

	public void PlayTweens()
	{
	}

	public TweenRecord GetTween(int AKBOMMEMLHM)
	{
		return null;
	}

	private void IINMMIEFJKM(TweenRecord PKNHPGLIEAE, bool KGELLCMPKOA = true)
	{
	}

	public void Stop()
	{
	}

	private void NDJAHDHKCMG(UITweener GDPAJADKOPD)
	{
	}

	protected void Update()
	{
	}

	public void GenerateTweens()
	{
	}

	public void ResetTweens()
	{
	}

	public void FinishTweens()
	{
	}
}
