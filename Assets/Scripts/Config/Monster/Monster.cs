using UnityEngine;

namespace Config.Monster {

    [CreateAssetMenu(fileName = "Monster", menuName = "ScriptableObject/Monster")]
    public class Monster : ScriptableObject
    {
        public string monsterId;

        public MonsterType monsterType;   
        
        public Sprite MonsterIcon;      // 角色预制体对象
        
        public int startHealth;                 //初始最大生命值
    }
}
