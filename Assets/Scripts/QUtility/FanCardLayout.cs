using System.Collections.Generic;
using QFramework;
using Unity.VisualScripting;
using UnityEngine;

public class FanCardLayout : IUtility
{
    public float angle = 15f;         // 每个卡牌的旋转角度范围
    public float radius = 2000f;      // 扇形半径
    public float startAngleDeg = 105f; // 扇形的起始角度（以度为单位）
    public float endAngleDeg = 75f;    // 扇形的结束角度（以度为单位）

    public List<T> SetLayout<T>(List<T> arr) where T : Component
    {
        int len = arr.Count;
        if (len < 0) return arr;
        if (len <= 3)
        {
            SetLineLayOut(arr, len);
        }
        else if (len <= 10)
        {
            SetCircleLayout(arr, len);
        }
        else
        {
            Debug.Log("ERROR len>10");
        }

        return arr;
    }

    public List<T> SetLineLayOut<T>(List<T> arr, int len) where T : Component
    {
        for (int i = 0; i < len; i++)
        {
            // 计算卡牌位置，假设为水平排列
            Vector3 cardPosition = new Vector3(
                (i - (len - 1) / 2f) * 400f, // 根据卡牌数量动态计算 X 轴位置，假设 400f 是卡牌的宽度
                0f,
                1f
            );

            // 设置卡牌位置
            arr[i].transform.localPosition = cardPosition;
            arr[i].transform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        return arr;
    }

    public List<T> SetCircleLayout<T>(List<T> arr, int len) where T : Component
    {
        float startAngle = Mathf.PI * startAngleDeg / 180f;  // 将起始角度转换为弧度
        float endAngle = Mathf.PI * endAngleDeg / 180f;      // 将结束角度转换为弧度

        for (int i = 0; i < len; i++)
        {
            float curAngle = Mathf.Lerp(startAngle, endAngle, i / (len - 1f));
            // 计算卡牌位置，Y 轴根据角度位置抬升，形成弧形
            Vector3 cardPosition = new Vector3(
                Mathf.Cos(curAngle) * radius,
                Mathf.Sin(curAngle) * radius - radius - 0.3f,
                1f
            );

            // 设置卡牌位置
            arr[i].transform.localPosition = cardPosition;
            arr[i].transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(angle, -angle, i / (len - 1f)));
        }

        return arr;
    }
}
