using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PolygonGenerator : MonoBehaviour
{
	public float polygonArea;

	public void GeneratePolygon(List<Tuple<Vector3, Vector2>> points)
	{
		Vector3[] array = new Vector3[points.Count];
		Vector2[] array2 = new Vector2[points.Count];
		for (int i = 0; i < points.Count; i++)
		{
			ref Vector3 reference = ref array[i];
			reference = points[i].Value1;
			ref Vector2 reference2 = ref array2[i];
			reference2 = points[i].Value2;
		}
		float area;
		int[] triangles = Triangulator.Triangulate(array, out area);
		polygonArea = area;
		Mesh mesh = new Mesh();
		mesh.vertices = array;
		mesh.triangles = triangles;
		mesh.RecalculateBounds();
		mesh.uv = array2;
		MeshFilter component = base.gameObject.GetComponent<MeshFilter>();
		component.mesh = mesh;
	}

	public void GeneratePolygon(List<List<Tuple<Vector3, Vector2>>> pointsIslands)
	{
		List<Vector3> list = new List<Vector3>();
		List<int> list2 = new List<int>();
		int num = 0;
		foreach (List<Tuple<Vector3, Vector2>> pointsIsland in pointsIslands)
		{
			num += pointsIsland.Count;
		}
		Vector2[] array = new Vector2[num];
		polygonArea = 0f;
		int num2 = 0;
		foreach (List<Tuple<Vector3, Vector2>> pointsIsland2 in pointsIslands)
		{
			Vector3[] array2 = new Vector3[pointsIsland2.Count];
			for (int i = 0; i < pointsIsland2.Count; i++)
			{
				ref Vector3 reference = ref array2[i];
				reference = pointsIsland2[i].Value1;
				ref Vector2 reference2 = ref array[i + num2];
				reference2 = pointsIsland2[i].Value2;
				list.Add(pointsIsland2[i].Value1);
			}
			float area;
			int[] array3 = Triangulator.Triangulate(array2, out area);
			polygonArea += area;
			int[] array4 = array3;
			foreach (int num3 in array4)
			{
				list2.Add(num3 + num2);
			}
			num2 += pointsIsland2.Count;
		}
		Mesh mesh = new Mesh();
		mesh.vertices = list.ToArray();
		mesh.triangles = list2.ToArray();
		mesh.RecalculateBounds();
		mesh.uv = array;
		MeshFilter component = base.gameObject.GetComponent<MeshFilter>();
		component.mesh = mesh;
	}
}
