﻿using QFramework;
using System.Collections;
using System.Collections.Generic;
using Config.Character;
using Config.Monster;
using NoSLoofah.BuffSystem;
using UnityEngine;

using QUtility;

namespace QModel
{
    
    // 战斗者类
    public class Fighter
    {
        // 0是玩家
        public int fighterId;
        
        public int curHp;
        public int maxHp;
        public Sprite icon;
        public int curEnergy;
        public int maxEnergy;
        // 当前阻挡值，默认为0
        [Range(0, 999)]
        public int currentBlock = 0;

        public Fighter()
        {
            
        }
        public Fighter(Character character)
        {
            fighterId = 0;
            curHp = maxHp = character.startHealth;
            curEnergy = maxEnergy = 3;
            icon = character.characterIcon;

        }

        public Fighter(Monster monster)
        {
            fighterId = 1;
            curHp = maxHp = monster.startHealth;
            icon = monster.MonsterIcon;
        }
     
        
        #region 改数据
        public void ResetCurrentBlock()
        {

            this.currentBlock = 0;
        }

        /// <summary>
        /// /受到伤害的方法 ,返回是否死亡
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool DoTakeDamageAndIsEndFight(int amount)
        {
            if (this.currentBlock > 0)
            {
                if (this.currentBlock >= amount)
                {
                    // 全部阻挡
                    this.currentBlock -= amount;
                    amount = 0;
                }
                else
                {
                    // 无法全部阻挡
                    amount -= this.currentBlock;
                    this.currentBlock = 0;
                }
            }

            // 打印造成的伤害值
            LogTool.Log("$\"造成 {amount} 点伤害\"");


            // 实例化伤害指示器，并在一段时间后销毁


            // 减少当前生命值，并更新生命值UI
            this.curHp = amount;

            if (this.curHp < 0) { return false; }

            return true;
        }

        /// <summary>
        /// 增加阻挡值的方法
        /// </summary>
        /// <param name="amount"></param>
        public void DoAddBlock(int amount)
        {
        
            this.currentBlock += amount;
            LogTool.Log($"增加 {amount} 防御");
        }
      
        #endregion 
    }
    
}
