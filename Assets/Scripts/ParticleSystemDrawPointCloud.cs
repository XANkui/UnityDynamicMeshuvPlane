using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使用粒子系统进行点云点集绘制
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemDrawPointCloud : MonoBehaviour
{
    public Material mat;        // 材质，（可优化地方：最好是代码 new ，尽量不要手动拖拽）

    List<Vector3> list;         // 测试的点集合列表
    ParticleSystem.Particle[] allParticles; // 所有粒子的集合 

    // Start is called before the first frame update
    void Start()
    {
        // 初始化点集合列表，并添加几个点作为测试 mesh 的点绘制
        list = new List<Vector3>();

        list.Add(new Vector3(1, 1, 1));
        list.Add(new Vector3(2, 3, 1));
        list.Add(new Vector3(4, 3, 3));
        list.Add(new Vector3(2, 1, 3));
        list.Add(new Vector3(4, 2, 3));

        // 把点集合传入，绘制点集
        DrawPointCloud(list);
    }

    /// <summary>
    /// 使用粒子系统，进行点集点云绘制
    /// </summary>
    /// <param name="drawList">点的集合列表</param>
    void DrawPointCloud(List<Vector3> drawList) {
        var main = GetComponent<ParticleSystem>().main;
        main.startSpeed = 0.0f;             // 设置粒子的初始速度为0 
        main.startLifetime = 1000.0f;       // 设置粒子的存活时间
        int pointCount = drawList.Count;    
        allParticles = new ParticleSystem.Particle[pointCount];
        main.maxParticles = pointCount;
        GetComponent<ParticleSystem>().Emit(pointCount);
        GetComponent<ParticleSystem>().GetParticles(allParticles);


        for (int i = 0; i < pointCount; i++) {
            allParticles[i].position = (Vector3)drawList[i]; // 设置每个点的位置 
            allParticles[i].startColor = Color.yellow; // 设置每个点的rgb 
            allParticles[i].startSize = 0.02f;
        }

        GetComponent<ParticleSystem>().SetParticles(allParticles, pointCount); // 将点云载入粒子系统 

    }

}
