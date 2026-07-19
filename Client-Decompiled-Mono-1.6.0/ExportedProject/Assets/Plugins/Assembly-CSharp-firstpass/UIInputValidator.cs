using System;
using UnityEngine;

[RequireComponent(typeof(UIInput))]
[AddComponentMenu("NGUI/Interaction/Input Validator")]
public class UIInputValidator : MonoBehaviour
{
	public enum Validation
	{
		None = 0,
		Integer = 1,
		Float = 2,
		Alphanumeric = 3,
		Username = 4,
		Name = 5,
		NoWhiteSpaces = 6
	}

	public Validation logic;

	private static char[] mWhiteSpaces = new char[6] { ' ', '\n', '\t', '\r', '\b', '\u00a0' };

	private void Start()
	{
		GetComponent<UIInput>().validator = Validate;
	}

	private char Validate(string text, char ch)
	{
		if (logic == Validation.None || !base.enabled)
		{
			return ch;
		}
		if (logic == Validation.Integer)
		{
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
			if (ch == '-' && text.Length == 0)
			{
				return ch;
			}
		}
		else if (logic == Validation.Float)
		{
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
			if (ch == '-' && text.Length == 0)
			{
				return ch;
			}
			if (ch == '.' && !text.Contains("."))
			{
				return ch;
			}
		}
		else if (logic == Validation.Alphanumeric)
		{
			if (ch >= 'A' && ch <= 'Z')
			{
				return ch;
			}
			if (ch >= 'a' && ch <= 'z')
			{
				return ch;
			}
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
		}
		else if (logic == Validation.Username)
		{
			if (ch >= 'A' && ch <= 'Z')
			{
				return ch;
			}
			if (ch >= 'a' && ch <= 'z')
			{
				return ch;
			}
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
		}
		else if (logic == Validation.Name)
		{
			char c = ((text.Length <= 0) ? ' ' : text[text.Length - 1]);
			if (ch >= 'a' && ch <= 'z')
			{
				if (c == ' ')
				{
					return (char)(ch - 97 + 65);
				}
				return ch;
			}
			if (ch >= 'A' && ch <= 'Z')
			{
				if (c != ' ' && c != '\'')
				{
					return (char)(ch - 65 + 97);
				}
				return ch;
			}
			switch (ch)
			{
			case '\'':
				if (c != ' ' && c != '\'' && !text.Contains("'"))
				{
					return ch;
				}
				break;
			case ' ':
				if (c != ' ' && c != '\'')
				{
					return ch;
				}
				break;
			}
		}
		else if (logic == Validation.NoWhiteSpaces)
		{
			return (Array.IndexOf(mWhiteSpaces, ch) <= -1) ? ch : '\0';
		}
		return '\0';
	}
}
