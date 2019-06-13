using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使用 mesh 绘制点
/// 思路梳理：
/// 1、附材质是为了可以人为设置点颜色（没有材质，会是丢失材质状态，显示紫红色）
/// 2、绘制点函数要点 pointMesh.vertices = points;pointMesh.SetIndices(indecies, MeshTopology.Points, 0);
/// </summary>
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshPoint : MonoBehaviour
{
    public Material mat;        // 材质，（可优化地方：最好是代码 new ，尽量不要手动拖拽）

    List<Vector3> list;         // 测试的点集合列表

    // Start is called before the first frame update
    void Start()
    {
        // 初始化点集合列表，并添加几个点作为测试 mesh 的点绘制
        list = new List<Vector3>();

        list.Add(new Vector3(1,1,1));
        list.Add(new Vector3(2,3,1));
        list.Add(new Vector3(4,3,3));
        list.Add(new Vector3(2,1,3));
        list.Add(new Vector3(4,2,3));

        // 把点集合传入，绘制点集
        CreateMeshPoint(list);
    }


    /// <summary>
    /// Mesh 绘制点函数
    /// </summary>
    /// <param name="meshPoints">点的集合列表</param>
    void CreateMeshPoint(List<Vector3> meshPoints) {
        // 获取点的个数，并保存点数参数
        int pointCount = meshPoints.Count;

        // new 一个 GameObject，并添加 MeshRenderer、MeshFilter组件，作为点集绘制载体
        GameObject meshPointGo = new GameObject("MeshPointGO");
        meshPointGo.AddComponent<MeshRenderer>();
        meshPointGo.AddComponent<MeshFilter>();

        // new Mesh ，赋值给 MeshFilter 组件
        Mesh pointMesh = new Mesh();
        meshPointGo.GetComponent<MeshFilter>().mesh = pointMesh;

        //给 MeshRenderer 一个材质（物体没有材质会是紫红色状态，建议使用 new 材质，避免手动拖拽）
        //Material mat = new Material(Shader.Find("Custom/VertexColor"));
        meshPointGo.GetComponent<MeshRenderer>().material = mat;

        // 新建点集，颜色集，和 点排序集合，并通过传入的点赋值（是不是可以把传入的点直接赋值呢，而不是新建中介变量？）
        Vector3[] points = new Vector3[pointCount];
        Color[] colors = new Color[pointCount];
        int[] indecies = new int[pointCount];
        for (int i =0;i<pointCount;i++)
        {
            points[i] = meshPoints[i];
            indecies[i] = i;
            colors[i] = Color.white;
        }

        // 给 mesh 赋值顶点，设置颜色
        pointMesh.vertices = points;
        pointMesh.colors = colors;
        pointMesh.SetIndices(indecies, MeshTopology.Points, 0);
    }
      
}
