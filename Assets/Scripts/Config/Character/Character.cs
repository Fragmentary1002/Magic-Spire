using System.Collections.Generic;
using Config.Card;
using UnityEngine;

namespace Config.Character
{

    /// <summary>
    /// ��ɫ�࣬�̳���ScriptableObject�����ڴ�����ɫ��Դ
    /// </summary>
    /// 
    [CreateAssetMenu(fileName = "Character", menuName = "ScriptableObject/Character")]
    public class Character : ScriptableObject,ICharacter
    {
        public string characterId;
        public CharacterClass characterClass;   // ��ɫְҵ
        public Sprite characterIcon;      // ��ɫԤ�������
        public Sprite splashArt;                // ��ɫͷ��
        public List<BaseCard> startingDeck;         // ��ɫ��ʼ����
        public int startHealth;                 //��ʼ�������ֵ
    }
}