using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
	[Serializable]
	public struct ObscuredFloat : IEquatable<ObscuredFloat>, IFormattable
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct FloatIntBytesUnion
		{
			[FieldOffset(0)]
			public float f;

			[FieldOffset(0)]
			public int i;

			[FieldOffset(0)]
			public byte b1;

			[FieldOffset(1)]
			public byte b2;

			[FieldOffset(2)]
			public byte b3;

			[FieldOffset(3)]
			public byte b4;
		}

		private static int cryptoKey;

		[SerializeField]
		private int currentCryptoKey;

		[SerializeField]
		private byte[] hiddenValue;

		[SerializeField]
		private float fakeValue;

		[SerializeField]
		private bool inited;

		private ObscuredFloat(byte[] value)
		{
			currentCryptoKey = 0;
			hiddenValue = null;
			fakeValue = 0f;
			inited = false;
		}

		public static void SetNewCryptoKey(int newKey)
		{
		}

		public static int Encrypt(float value)
		{
			return 0;
		}

		public static int Encrypt(float value, int key)
		{
			return 0;
		}

		private static byte[] InternalEncrypt(float value)
		{
			return null;
		}

		private static byte[] InternalEncrypt(float value, int key)
		{
			return null;
		}

		public static float Decrypt(int value)
		{
			return 0f;
		}

		public static float Decrypt(int value, int key)
		{
			return 0f;
		}

		public void ApplyNewCryptoKey()
		{
		}

		public void RandomizeCryptoKey()
		{
		}

		public int GetEncrypted()
		{
			return 0;
		}

		public void SetEncrypted(int encrypted)
		{
		}

		private float InternalDecrypt()
		{
			return 0f;
		}

		public static implicit operator ObscuredFloat(float value)
		{
			return default(ObscuredFloat);
		}

		public static implicit operator float(ObscuredFloat value)
		{
			return 0f;
		}

		public static ObscuredFloat operator ++(ObscuredFloat input)
		{
			return default(ObscuredFloat);
		}

		public static ObscuredFloat operator --(ObscuredFloat input)
		{
			return default(ObscuredFloat);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(ObscuredFloat obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(string format)
		{
			return null;
		}

		public string ToString(IFormatProvider provider)
		{
			return null;
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return null;
		}
	}
}
