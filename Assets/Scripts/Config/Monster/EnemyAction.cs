using NoSLoofah.BuffSystem;
using UnityEngine;

namespace Config.Monster
{

    [CreateAssetMenu(fileName = "EnemyAction", menuName = "ScriptableObject/EnemyAction")]
    public class EnemyAction : ScriptableObject
    {

        public EnemyActionType type;  //意图类型

        public int amount;      //攻击防御数值

        public bool isGetBuff;

        public int buffAmount;  //施加或给自身buff数值

        public int BuffId;//施加或给自身buff类型

        public int chance;  // 表示某个意图或动作触发的几率。  

        public Sprite icon;     // 显示该EnemyAction的图标。 

    }

}