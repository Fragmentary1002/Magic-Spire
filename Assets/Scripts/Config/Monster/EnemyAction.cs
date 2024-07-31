using NoSLoofah.BuffSystem;
using UnityEngine;

namespace Config.Monster
{
    
    [CreateAssetMenu(fileName = "EnemyAction", menuName = "ScriptableObject/EnemyAction")]
    public class EnemyAction : ScriptableObject
    {

        public EnemyActionType type;  //��ͼ����

        public int amount;      //����������ֵ

        public bool isGetBuff;

        public int buffAmount;  //ʩ�ӻ������buff��ֵ

        public Buff Buff;//ʩ�ӻ������buff����

        public int chance;  // ��ʾĳ����ͼ���������ļ��ʡ�  

        public Sprite icon;     // ��ʾ��EnemyAction��ͼ�ꡣ 


        /// <summary>
        /// ������ ���˺�����
        /// </summary>
        //public void Damage()
        //{
        //    if (type == EnemyActionType.Attack)
        //    {
        //        // ����ֵ���ӵ��˵���������Ч��  
        //        amount += amount;
        //        if (true)
        //        {
        //            // ������������Ч�����򹥻�ֵ����50%  
        //            if (true)
        //            {
        //                amount = (int)(amount * 1.5f);
        //            }
        //        }
        //    }
        //}
    }

}