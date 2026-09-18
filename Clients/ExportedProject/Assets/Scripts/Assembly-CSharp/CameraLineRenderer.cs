using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraLineRenderer : MonoBehaviour
{
	private struct Line
	{
		public Vector3 StartPosition;

		public Vector3 EndPosition;

		public Color Color;
	}

	private const int circleParts = 16;

	public Material lineMaterial;

	private List<Line> _lines = new List<Line>();

	private static CameraLineRenderer _instance;

	private Dictionary<string, List<Line>> StaticLines = new Dictionary<string, List<Line>>();

	public static CameraLineRenderer Instance
	{
		get
		{
			_instance = _instance ?? (UnityEngine.Object.FindObjectOfType(typeof(CameraLineRenderer)) as CameraLineRenderer);
			return _instance;
		}
	}

	private static void CreateLineMaterial()
	{
		if (!Instance.lineMaterial)
		{
			Instance.lineMaterial = new Material(Shader.Find("Lines/Colored Blended"));
			Instance.lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			Instance.lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	private void Awake()
	{
		_instance = this;
		lineMaterial = new Material(Shader.Find("Lines/Colored Blended"));
		lineMaterial.hideFlags = HideFlags.HideAndDontSave;
		lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
	}

	private void OnPostRender()
	{
		CreateLineMaterial();
		lineMaterial.SetPass(0);
		DrawLines(_lines);
		foreach (KeyValuePair<string, List<Line>> staticLine in StaticLines)
		{
			DrawLines(staticLine.Value);
		}
		_lines = new List<Line>();
	}

	private static void DrawLines(List<Line> lines)
	{
		if (!DebugSettings.drawCameraLines)
		{
			return;
		}
		GL.Begin(1);
		foreach (Line line in lines)
		{
			GL.Color(line.Color);
			GL.Vertex3(line.StartPosition.x, line.StartPosition.y, line.StartPosition.z);
			GL.Vertex3(line.EndPosition.x, line.EndPosition.y, line.EndPosition.z);
		}
		GL.End();
	}

	public void DrawL(Vector3 start, Vector3 end, Color color)
	{
		if (DebugSettings.drawCameraLines)
		{
			_lines.Add(new Line
			{
				StartPosition = start,
				EndPosition = end,
				Color = color
			});
		}
	}

	public static void DrawLine(Vector3 start, Vector3 end, Color color)
	{
		Instance.DrawL(start, end, color);
	}

	public void ClearStaticLine(string lineName)
	{
		if (StaticLines.TryGetValue(lineName, out var value))
		{
			value = new List<Line>();
			StaticLines[lineName] = new List<Line>();
		}
	}

	public void DrawStaticL(string lineName, Vector3 start, Vector3 end, Color color)
	{
		Instance.DrawL(start, end, color);
		if (!StaticLines.TryGetValue(lineName, out var value))
		{
			value = new List<Line>();
			StaticLines[lineName] = new List<Line>();
		}
		value.Add(new Line
		{
			StartPosition = start,
			EndPosition = end,
			Color = color
		});
	}

	public static void DrawStaticLine(string lineName, Vector3 start, Vector3 end, Color color)
	{
		Instance.DrawStaticL(lineName, start, end, color);
	}

	public static void DrawCross(Vector3 pos, float size, Color c)
	{
		DrawLine(pos - 0.5f * size * Vector3.left, pos - 0.5f * size * Vector3.right, c);
		DrawLine(pos - 0.5f * size * Vector3.up, pos - 0.5f * size * Vector3.down, c);
		DrawLine(pos - 0.5f * size * Vector3.forward, pos - 0.5f * size * Vector3.back, c);
	}

	public static void DrawGizmoCross(Vector3 pos, float size, Color c)
	{
		Gizmos.DrawLine(pos - 0.5f * size * Vector3.left, pos - 0.5f * size * Vector3.right);
		Gizmos.DrawLine(pos - 0.5f * size * Vector3.up, pos - 0.5f * size * Vector3.down);
		Gizmos.DrawLine(pos - 0.5f * size * Vector3.forward, pos - 0.5f * size * Vector3.back);
	}

	public static void DrawSphere(Vector3 pos, float size, Color c)
	{
		DrawCircle(pos, size, c, Quaternion.Euler(0f, 0f, 0f));
		DrawCircle(pos, size, c, Quaternion.Euler(0f, 30f, 0f));
		DrawCircle(pos, size, c, Quaternion.Euler(0f, 60f, 0f));
		DrawCircle(pos, size, c, Quaternion.Euler(0f, 90f, 0f));
	}

	public static void DrawCircle(Vector3 pos, float size, Color c, Quaternion q)
	{
		for (int i = 1; i <= 16; i++)
		{
			float f = (float)(22 * (i - 1)) * ((float)Math.PI / 180f);
			float num = Mathf.Cos(f);
			float num2 = 0f - Mathf.Sin(f);
			Vector3 vector = q * new Vector3(num * size, num2 * size, 0f);
			f = (float)(22 * i) * ((float)Math.PI / 180f);
			num = Mathf.Cos(f);
			num2 = 0f - Mathf.Sin(f);
			Vector3 vector2 = q * new Vector3(num * size, num2 * size, 0f);
			DrawLine(vector + pos, vector2 + pos, c);
		}
	}
}
