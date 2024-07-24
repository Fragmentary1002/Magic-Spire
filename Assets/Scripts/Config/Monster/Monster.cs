using UnityEngine;

namespace Config.Monster {

    [CreateAssetMenu(fileName = "Monster", menuName = "ScriptableObject/Monster")]
    public class Monster : ScriptableObject
    {
        public string monsterId;

        public MonsterType monsterType;   
        
        public GameObject MonsterClassPrefab;      // ��ɫԤ�������
        
        public int startHealth;                 //��ʼ�������ֵ
    }
}
