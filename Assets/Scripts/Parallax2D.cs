using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Weiva Parallax
/// 2D 视差效果
/// 本组件背景视差效果是根据背景对象的世界坐标z值来计算。默认参数中的背景数组第一个元素为最远平面，
/// 既与摄像机同步的平面，该对象之间的背景根据z值进行视差计算。也可以单独设置参数 synZ 强制设置最
/// 远平面。大于最远平面的 z 值将会反超摄像机移动。
/// weivain@qq.com
/// www.weiva.com
/// </summary>
public class Parallax2D : MonoBehaviour
{

    [Header("背景图片对象，Element 0 为与摄像机同步的背景层")]
    public Transform[] backgrounds;

    // 主摄像机
    private Transform cam;
    // 上一帧摄像机的位置
    private Vector3 previousCamPos;
    // 摄像机同步背景层的 z 值
    [Header("摄像机同步背景层Z值，若0为背景层0")]
    public float synZ = 0f;
    [Header("偏移x系数")]
    public float parallaxScaleX = 1f;
    [Header("偏移y系数")]
    public float parallaxScaleY = 1f;


    // 初始化
    void Start()
    {
        cam = Camera.main.transform;
        // 上一帧摄像机的位置
        previousCamPos = cam.position;
        if (synZ == 0 && null != backgrounds[0])
        {
            synZ = backgrounds[0].position.z;
        }
        if (synZ == 0)
        {
            synZ = 100f;
        }

    }

    // 每一帧执行
    void Update()
    {
        // 获得摄像机和上一帧的偏移值
        float parallax = previousCamPos.x - cam.position.x;

        //摄像机偏移矢量
        Vector3 camMove = cam.position - previousCamPos;
        camMove.x *= parallaxScaleX;
        camMove.y *= parallaxScaleY;

        //同步背景
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (null == backgrounds[i]) continue;

            Vector3 targetToMove = backgrounds[i].position + camMove * (backgrounds[i].position.z / synZ);
            backgrounds[i].position = targetToMove;

        }

        // 更新上一帧摄像机的位置
        previousCamPos = cam.position;
    }
}