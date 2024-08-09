using UnityEngine;

namespace Config.Monster {

    [CreateAssetMenu(fileName = "Monster", menuName = "ScriptableObject/Monster")]
    public class Monster : ScriptableObject
    {
        public string monsterId;

        public MonsterType monsterType;   
        
        public Sprite MonsterIcon;      // ��ɫԤ�������
        
        public int startHealth;                 //��ʼ�������ֵ
    }
}
