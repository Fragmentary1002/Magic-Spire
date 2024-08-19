using System.Collections.Generic;
using QFramework;
using QUtility;
using Unity.VisualScripting;
using UnityEngine;

public class FanCardLayout : IUtility
{
    public float angle = 15f;         // 每个卡牌的旋转角度范围
    public float startAngleDeg = 105f; // 扇形的起始角度（以度为单位）
    public float endAngleDeg = 75f;    // 扇形的结束角度（以度为单位）


    // 用于动态计算半径的比例因子 (基准半径和最大卡牌数)
    private const float baseRadius = 2000f;  // 基准半径，对应10张卡牌
    private const int maxCardCount = 10;     // 最大卡牌数，用于基准半径

    public List<T> SetLayout<T>(List<T> arr) where T : Component
    {
        int len = arr.Count;
        if (len < 0) return arr;
        if (len <= 3)
        {
            SetLineLayOut(arr, len, CalculateRadius(len));
        }
        else if (len <= 10)
        {
            SetCircleLayout(arr, len, CalculateRadius(len));
        }
        else
        {
            Debug.Log("ERROR len>10");
        }

        return arr;
    }


    private float CalculateRadius(int len)
    {
        var t = baseRadius * len / maxCardCount;
        //LogTool.Log(t.ToString());

        // 动态)调整半径长度
        return baseRadius * len / maxCardCount;
    }


    public List<T> SetLineLayOut<T>(List<T> arr, int len, float radius) where T : Component
    {
        for (int i = 0; i < len; i++)
        {
            // 计算卡牌位置，假设为水平排列
            Vector3 cardPosition = new Vector3(
                (i - (len - 1) / 3f) * (radius / len), // 根据卡牌数量动态计算 X 轴位置，使用半径和卡牌数量
                0f,
                1f
            );

            // 设置卡牌位置
            arr[i].transform.localPosition = cardPosition;
            arr[i].transform.localRotation = Quaternion.Euler(Vector3.zero);
            arr[i].gameObject.transform.localScale = Vector3.one;
        }

        return arr;
    }


    public List<T> SetCircleLayout<T>(List<T> arr, int len, float radius) where T : Component
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
            arr[i].gameObject.transform.localScale = Vector3.one;

        }

        return arr;
    }
}
