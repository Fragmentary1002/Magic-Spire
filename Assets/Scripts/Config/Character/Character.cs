using System.Collections.Generic;
using Config.Card;
using UnityEngine;

namespace Config.Character
{
    // 角色职业枚举
    public enum CharacterClass
    {
        ironChad,
        silent
    }   

    /// <summary>
    /// 角色类，继承自ScriptableObject，用于创建角色资源
    /// </summary>
    /// 
    [CreateAssetMenu(fileName = "Character", menuName = "ScriptableObject/Character")]
    public class Character : ScriptableObject
    {
        public string characterId;
        public CharacterClass characterClass;   // 角色职业
        public GameObject characterPrefab;      // 角色预制体对象
        public Sprite splashArt;                // 角色头像
        public List<BaseCard> startingDeck;         // 角色初始卡组
        public int startHealth;                 //初始最大生命值
    }
}