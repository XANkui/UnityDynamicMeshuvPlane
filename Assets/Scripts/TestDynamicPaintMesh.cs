using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDynamicPaintMesh : MonoBehaviour
{
    // Mesh 预制体，最好添加材质，因为简单的画 Mesh 做了 uv 处理
    public GameObject meshPaintPrefab;

    private GameObject meshPaint;
    private List<Vector3> points;       // 准备传给Mesh绘制的点集

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3>();

        points.Add(new Vector3(-2,0,0));
        points.Add(new Vector3(0,0,3));
        points.Add(new Vector3(2,0,0));
        points.Add(new Vector3(0,0,-2));

        // 生成实体，并添加 MeshPaint脚本
        meshPaint = GameObject.Instantiate(meshPaintPrefab);
        meshPaint.AddComponent<MeshPaint>().MeshDrawQuad(points);
    }

    // Update is called once per frame
    void Update()
    {
        // 动态更新点集
        if (Input.GetKeyDown(KeyCode.Space))
        {
            points.Clear();
            points.Add(new Vector3(-3, 0, 0));
            
            points.Add(new Vector3(0, 0, 4));
            points.Add(new Vector3(3, 0, 4));
            points.Add(new Vector3(3, 0, 0));
            points.Add(new Vector3(0, 0, -3));

            // 可以最好添加一个判断，判断是否有 MeshPaint
            meshPaint.GetComponent<MeshPaint>().MeshDrawQuad(points);
        }
    }
}
