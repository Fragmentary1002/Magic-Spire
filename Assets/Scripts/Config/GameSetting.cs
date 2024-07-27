using UnityEngine;
using UnityEngine.UIElements;

namespace Config
{
    public static class GameSetting
    {
        public static int DrawCradCnt = 5;          //默认抽卡次数
        public static int FullCardCnt = 10;         //卡牌上限
        
        //ui生成位置
        public static Vector2 PlayerPos = new Vector2(-716, 0);
        public static Vector2 EnemyPos = new Vector2(569, 0);
        public static int EnemyUIPosOffset = 10;
    }
}