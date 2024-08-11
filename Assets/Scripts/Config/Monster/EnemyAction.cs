using NoSLoofah.BuffSystem;
using UnityEngine;
using QUtility;


namespace Config.Monster
{

    [CreateAssetMenu(fileName = "EnemyAction", menuName = "ScriptableObject/EnemyAction")]
    public class EnemyAction : ScriptableObject
    {

        public EnemyActionType type;  //��ͼ����

        public int amount;      //����������ֵ

        public bool isGetBuff;

        public int buffAmount;  //ʩ�ӻ������buff��ֵ

        public int BuffId;//ʩ�ӻ������buff����

        public int chance;  // ��ʾĳ����ͼ���������ļ��ʡ�  

        public Sprite icon;     // ��ʾ��EnemyAction��ͼ�ꡣ 

    }

}