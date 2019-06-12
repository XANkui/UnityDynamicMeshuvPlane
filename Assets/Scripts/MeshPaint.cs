using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动态Mesh绘制
/// 要求有 MeshFilter MeshRenderer
/// </summary>
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshPaint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 传点Mesh绘制面
    /// </summary>
    /// <param name="points">传入的点列表</param>
    /// 点的要求：
    /// 1、这些面的边界点，请顺时针添加进的列表点（由于单面显示，逆时针的话可能面朝下，从上可能会看不见）
    /// 2、这里的点要求是水平面上的点，因为目前这个函数主要用于水平面上（由于uv处理，目前只做了水平面上的）
    public void MeshDrawQuad(List<Vector3> points)
    {
        Debug.Log("MeshDrawQuad +++++++++++");

        Mesh quadMesh = new Mesh();
        quadMesh.vertices = points.ToArray();
        int coutArray = (points.Count - 2);
        int[] quadPoints = new int[coutArray * 3];

        // 以点队列的第 0 个点为定点，三点绘制一面，三点面的排序
        for (int i = 0; i < coutArray; i++)
        {

            quadPoints[i * 3] = 0;
            quadPoints[(i * 3) + 1] = i + 1;
            quadPoints[(i * 3) + 2] = i + 2;

        }

        quadMesh.triangles = quadPoints;

        // 水平面的，所以 uv 把 点的 x z 传递给 uv 处理
        Vector2[] uvs = new Vector2[points.Count];
        for (int i = 0; i < uvs.Length; i++) {
            uvs[i] = new Vector2(points[i].x, points[i].z);
        }

        quadMesh.uv = uvs;

        quadMesh.RecalculateBounds();
        quadMesh.RecalculateNormals();
        quadMesh.RecalculateTangents();

        GetComponent<MeshFilter>().mesh = quadMesh;
    }


}
