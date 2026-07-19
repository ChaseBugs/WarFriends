using System;
using UnityEngine;

public class RopeTubeRenderer
{
	public bool calculateTangents;

	private GameObject _gameObject;

	private Transform _transform;

	private int targetVertexCount;

	private Vector3[] points = new Vector3[0];

	private float radius = 0.5f;

	private float[] radiuses;

	private int edgeCount = 12;

	private Color[] pointColors;

	private Rect capUVRect = new Rect(0f, 0f, 1f, 1f);

	private Rect bodyUVRect = new Rect(0f, 0f, 1f, 1f);

	private Vector3[] vertices = new Vector3[0];

	private Vector3[] normals = new Vector3[0];

	private int[] triangles;

	private Vector2[] uvs;

	private Vector4[] tangents = new Vector4[0];

	private Color[] colors;

	private Vector3[] circleLookup;

	private Quaternion[] rotations = new Quaternion[0];

	private MeshFilter filter;

	private bool updateCircleLookupFlag;

	private bool updateUVsFlag;

	private bool updateTrianglesFlag;

	private bool updateTangentsFlag;

	private bool updateColorsFlag;

	private bool redrawFlag;

	private bool pointCountChanged;

	private const float TWO_PI = (float)Math.PI * 2f;

	private Vector3 pastUp;

	private Mesh _mesh;

	public GameObject gameObject
	{
		get
		{
			return _gameObject;
		}
	}

	public Transform transform
	{
		get
		{
			return _transform;
		}
	}

	public Vector3 up
	{
		get
		{
			return (!(pastUp != Vector3.zero)) ? Vector3.up : pastUp;
		}
		set
		{
			pastUp = value;
		}
	}

	public Mesh mesh
	{
		get
		{
			return _mesh;
		}
	}

	public RopeTubeRenderer(GameObject _gameObject, bool useMeshOnly)
	{
		if (!useMeshOnly)
		{
			this._gameObject = _gameObject;
			_transform = _gameObject.transform;
			MeshFilter meshFilter = _gameObject.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = _gameObject.AddComponent<MeshFilter>();
			}
			MeshRenderer meshRenderer = _gameObject.GetComponent<MeshRenderer>();
			if (meshRenderer == null)
			{
				meshRenderer = _gameObject.AddComponent<MeshRenderer>();
			}
			_mesh = new Mesh();
			_mesh.name = "RopeTube_" + _gameObject.GetInstanceID();
			meshFilter.mesh = _mesh;
			if (meshRenderer.sharedMaterial == null)
			{
				meshRenderer.sharedMaterial = (Material)Resources.Load("Materials/Rope", typeof(Material));
			}
		}
		else
		{
			this._gameObject = _gameObject;
			_transform = _gameObject.transform;
			_mesh = new Mesh();
			_mesh.name = "RopeTube_" + _gameObject.GetInstanceID();
		}
	}

	public void Update()
	{
		if (points.Length != 0)
		{
			if (updateCircleLookupFlag)
			{
				UpdateCircleLookup();
			}
			if (updateUVsFlag)
			{
				UpdateUVs();
			}
			if (updateTangentsFlag && calculateTangents)
			{
				UpdateTangents();
			}
			if (updateTrianglesFlag)
			{
				UpdateTriangles();
			}
			if (redrawFlag)
			{
				ReDraw();
			}
			if (updateColorsFlag)
			{
				UpdateColors();
			}
			updateCircleLookupFlag = false;
			updateTangentsFlag = false;
			updateTrianglesFlag = false;
			updateUVsFlag = false;
			redrawFlag = false;
			updateColorsFlag = false;
		}
	}

	private void ReDraw()
	{
		if (vertices.Length != targetVertexCount)
		{
			_mesh.triangles = new int[0];
			vertices = new Vector3[targetVertexCount];
		}
		if (normals.Length != targetVertexCount)
		{
			normals = new Vector3[targetVertexCount];
		}
		int num = 1 + edgeCount + 1;
		Vector3 vector = new Vector3(10000f, 10000f, 10000f);
		Vector3 vector2 = new Vector3(-10000f, -10000f, -10000f);
		for (int i = 0; i < points.Length; i++)
		{
			if (radiuses != null)
			{
				if (points[i].x - radiuses[i] < vector.x)
				{
					vector.x = points[i].x - radiuses[i];
				}
				if (points[i].y - radiuses[i] < vector.y)
				{
					vector.y = points[i].y - radiuses[i];
				}
				if (points[i].z - radiuses[i] < vector.z)
				{
					vector.z = points[i].z - radiuses[i];
				}
				if (points[i].x + radiuses[i] > vector2.x)
				{
					vector2.x = points[i].x + radiuses[i];
				}
				if (points[i].y + radiuses[i] > vector2.y)
				{
					vector2.y = points[i].y + radiuses[i];
				}
				if (points[i].z + radiuses[i] > vector2.z)
				{
					vector2.z = points[i].z + radiuses[i];
				}
				for (int j = 0; j < edgeCount + 1; j++)
				{
					vertices[num] = _transform.InverseTransformPoint(points[i] + rotations[i] * circleLookup[j] * radiuses[i]);
					normals[num] = _transform.InverseTransformDirection(rotations[i] * circleLookup[j]);
					num++;
				}
			}
			else
			{
				if (points[i].x - radius < vector.x)
				{
					vector.x = points[i].x - radius;
				}
				if (points[i].y - radius < vector.y)
				{
					vector.y = points[i].y - radius;
				}
				if (points[i].z - radius < vector.z)
				{
					vector.z = points[i].z - radius;
				}
				if (points[i].x + radius > vector2.x)
				{
					vector2.x = points[i].x + radius;
				}
				if (points[i].y + radius > vector2.y)
				{
					vector2.y = points[i].y + radius;
				}
				if (points[i].z + radius > vector2.z)
				{
					vector2.z = points[i].z + radius;
				}
				for (int k = 0; k < edgeCount + 1; k++)
				{
					vertices[num] = _transform.InverseTransformPoint(points[i] + rotations[i] * circleLookup[k] * radius);
					normals[num] = _transform.InverseTransformDirection(rotations[i] * circleLookup[k]);
					num++;
				}
			}
		}
		vertices[0] = _transform.InverseTransformPoint(points[0]);
		vertices[vertices.Length - 1] = _transform.InverseTransformPoint(points[points.Length - 1]);
		normals[0] = _transform.InverseTransformDirection(rotations[0] * Vector3.forward);
		normals[targetVertexCount - 1] = _transform.InverseTransformDirection(rotations[0] * -Vector3.forward);
		num = 1;
		for (int l = 0; l < edgeCount + 1; l++)
		{
			vertices[num] = vertices[num + edgeCount + 1];
			normals[num] = normals[0];
			num++;
		}
		num = vertices.Length - edgeCount - 2;
		for (int m = 0; m < edgeCount + 1; m++)
		{
			vertices[num] = vertices[num - edgeCount - 1];
			normals[num] = normals[targetVertexCount - 1];
			num++;
		}
		_mesh.vertices = vertices;
		if (updateUVsFlag)
		{
			_mesh.uv = uvs;
		}
		if (updateTrianglesFlag)
		{
			_mesh.triangles = triangles;
		}
		_mesh.normals = normals;
		if (calculateTangents)
		{
			_mesh.tangents = tangents;
		}
		_mesh.RecalculateBounds();
	}

	private void UpdateCircleLookup()
	{
		circleLookup = new Vector3[edgeCount + 1];
		float num = 1f / (float)edgeCount;
		for (int i = 0; i < circleLookup.Length; i++)
		{
			float f = (float)i * num * ((float)Math.PI * 2f);
			circleLookup[i] = new Vector3(0f, Mathf.Cos(f), Mathf.Sin(f));
		}
	}

	private void UpdateUVs()
	{
		uvs = new Vector2[targetVertexCount];
		float num = 1f / ((float)points.Length - 1f);
		float num2 = 1f / (float)edgeCount;
		int num3 = 0;
		uvs[num3++] = new Vector2(capUVRect.width * 0.5f + capUVRect.x, capUVRect.height * 0.5f + capUVRect.y);
		for (int i = 0; i < edgeCount + 1; i++)
		{
			float f = (float)i * num2 * ((float)Math.PI * 2f) + (float)Math.PI / 2f;
			uvs[num3++] = new Vector2(uvs[0].x + Mathf.Cos(f) * 0.5f * capUVRect.width, uvs[0].y + Mathf.Sin(f) * 0.5f * capUVRect.height);
		}
		for (int j = 0; j < points.Length; j++)
		{
			float num4 = (float)j * num;
			for (int k = 0; k < edgeCount + 1; k++)
			{
				float num5 = (float)k * num2;
				uvs[num3++] = new Vector2(bodyUVRect.x + num4 * bodyUVRect.width, bodyUVRect.y + num5 * bodyUVRect.height);
			}
		}
		for (int l = 0; l < edgeCount + 1; l++)
		{
			uvs[num3++] = uvs[l + 1];
		}
		uvs[num3++] = uvs[0];
	}

	private void UpdateTangents()
	{
		tangents = new Vector4[targetVertexCount];
		int num = 0;
		Vector3 vector = _transform.InverseTransformDirection(rotations[0] * Vector3.right);
		for (int i = 0; i < edgeCount + 2; i++)
		{
			tangents[num++] = new Vector4(vector.x, vector.y, vector.z, 1f);
		}
		for (int j = 0; j < rotations.Length; j++)
		{
			vector = _transform.InverseTransformDirection(rotations[j] * Vector3.forward);
			if (calculateTangents)
			{
				for (int k = 0; k < edgeCount + 1; k++)
				{
					tangents[num++] = new Vector4(vector.x, vector.y, vector.z, 1f);
				}
			}
		}
		vector = _transform.InverseTransformDirection(rotations[rotations.Length - 1] * Vector3.left);
		for (int l = 0; l < edgeCount + 2; l++)
		{
			tangents[num++] = new Vector4(vector.x, vector.y, vector.z, 1f);
		}
	}

	private void UpdateTriangles()
	{
		int num = (points.Length - 1) * edgeCount * 2;
		int num2 = 2 * edgeCount;
		triangles = new int[(num + num2) * 3];
		int num3 = 1;
		int num4 = 0;
		for (int i = 0; i < edgeCount; i++)
		{
			triangles[num4++] = num3 + 1;
			triangles[num4++] = num3;
			triangles[num4++] = 0;
			num3++;
		}
		num3++;
		int[] array = new int[6]
		{
			0,
			1,
			edgeCount + 2,
			0,
			edgeCount + 2,
			edgeCount + 1
		};
		for (int j = 0; j < points.Length - 1; j++)
		{
			for (int k = 0; k < edgeCount; k++)
			{
				for (int l = 0; l < array.Length; l++)
				{
					triangles[num4++] = num3 + array[l];
				}
				num3++;
			}
			num3++;
		}
		num3++;
		num3 += edgeCount;
		for (int m = 0; m < edgeCount; m++)
		{
			triangles[num4++] = num3;
			triangles[num4++] = num3 + 1;
			triangles[num4++] = targetVertexCount - 1;
			num3++;
		}
	}

	private void UpdateColors()
	{
		if (pointColors == null)
		{
			return;
		}
		colors = new Color[targetVertexCount];
		int num = 0;
		colors[num++] = pointColors[0];
		for (int i = 0; i < edgeCount + 1; i++)
		{
			colors[num++] = pointColors[0];
		}
		for (int j = 0; j < points.Length; j++)
		{
			for (int k = 0; k < edgeCount + 1; k++)
			{
				colors[num++] = pointColors[j];
			}
		}
		for (int l = 0; l < edgeCount + 1; l++)
		{
			colors[num++] = pointColors[pointColors.Length - 1];
		}
		colors[num++] = pointColors[pointColors.Length - 1];
		mesh.colors = colors;
	}

	public void SetPointCount(int pointCount)
	{
		if (pointCount < 2)
		{
			Debug.LogWarning("TubeRenderer must have at two three points.");
			return;
		}
		updateTrianglesFlag = true;
		updateUVsFlag = true;
		updateColorsFlag = true;
		updateTangentsFlag = true;
		if (circleLookup == null)
		{
			updateCircleLookupFlag = true;
		}
		redrawFlag = true;
		targetVertexCount = pointCount * (edgeCount + 1);
		points = new Vector3[pointCount];
	}

	public void SetPointsAndRotations(Vector3[] points, Quaternion[] rotations)
	{
		if (points.Length < 2)
		{
			Debug.LogWarning("RopeTubeRenderer must have at two three points.");
			return;
		}
		if (points.Length != rotations.Length)
		{
			Debug.LogWarning("point array must match length of rotation array.");
			return;
		}
		int num = ((this.points != null) ? this.points.Length : 0);
		if (points.Length != num)
		{
			updateTrianglesFlag = true;
			updateUVsFlag = true;
			updateColorsFlag = true;
		}
		updateTangentsFlag = true;
		if (circleLookup == null)
		{
			updateCircleLookupFlag = true;
		}
		redrawFlag = true;
		if (radiuses != null && points.Length != radiuses.Length)
		{
			radiuses = null;
		}
		targetVertexCount = (points.Length + 2) * (edgeCount + 1) + 2;
		this.points = points;
		this.rotations = rotations;
	}

	public void SetEdgeCount(int edgeCount)
	{
		if (edgeCount < 3)
		{
			edgeCount = 3;
		}
		this.edgeCount = edgeCount;
		updateTrianglesFlag = true;
		updateUVsFlag = true;
		updateCircleLookupFlag = true;
		updateColorsFlag = true;
		redrawFlag = true;
		targetVertexCount = (points.Length + 2) * (edgeCount + 1) + 2;
	}

	public void SetRadius(float radius)
	{
		this.radius = radius;
		redrawFlag = true;
	}

	public void SetRadiuses(float[] radiuses)
	{
		if (radiuses == null)
		{
			this.radiuses = null;
			return;
		}
		if (radiuses.Length != points.Length)
		{
			Debug.Log("TubeRenderer only receives as many radius values as it has points. Use SetPoints() or SetPointCount() before using SetRadiuses()");
			return;
		}
		this.radiuses = radiuses;
		redrawFlag = true;
	}

	public void SetColors(Color[] colors)
	{
		if (colors.Length != points.Length)
		{
			Debug.Log("TubeRenderer only receives as many color values as it has points. Use SetPoints() or SetPointCount() before using SetColors()");
			return;
		}
		pointColors = colors;
		updateColorsFlag = true;
	}

	public void SetBodyUVRect(Rect uvRect)
	{
		bodyUVRect = uvRect;
		updateUVsFlag = true;
	}

	public void SetCapsUVRect(Rect uvRect)
	{
		capUVRect = uvRect;
		updateUVsFlag = true;
	}

	public Vector3[] Points()
	{
		Vector3[] array = new Vector3[points.Length];
		points.CopyTo(array, 0);
		return array;
	}

	public float[] Radiuses()
	{
		float[] array = new float[radiuses.Length];
		radiuses.CopyTo(array, 0);
		return array;
	}

	public int EdgeCount()
	{
		return edgeCount;
	}
}
