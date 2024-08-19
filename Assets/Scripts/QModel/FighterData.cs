using System.Collections.Generic;
using Config;
using NUnit.Framework;
using QFramework;
using UnityEngine;

namespace QModel
{
    public class FighterData:AbstractModel
    {
        private Fighter player = new Fighter();
        private List<Fighter> enemies=new List<Fighter>();
        private GameObject playerObj;
        private GameObject enemyObj;

        protected override void OnInit()
        {
            StringEventSystem.Global.Register<GameObject>(EventID.SetCurEnemy, (go) =>
            {
                if (enemyObj == go)
                {
                    enemyObj = null;
                    Debug.Log("SetCurEnemy null");
                    return; 
                }
                enemyObj = go;
                Debug.Log("SetCurEnemy go");
            });
        }

        /// <summary>
        /// 传入至少俩个参数，限制生成怪物为3
        /// </summary>
        /// <param name="fighters"></param>
        public void InitFighterData(Fighter player,List<Fighter> enemies)
        {
            this.player = player;
            this.player.fighterId = 0;
            this.enemies = enemies;
            for (int i = 0; i < enemies.Count; i++)
            {
                this.enemies[i].fighterId=i+1;
            }
        }
        
        public Fighter GetPlayer()
        {
            return player;
        }
        
        public List<Fighter> GetEnemies()
        {
            return enemies;
        }

        public Fighter GetEnemy(int idx)
        {
            return idx < enemies.Count ? enemies[idx] : null;
        }

        public GameObject PlayerObj
        {
            get;
            set;
        }

        public GameObject EnemyObj
        {
            get;
            set;
        }
        // public void PushEnemiesObj(GameObject obj)
        // {
        //     enemiesObj.Add(obj);
        // }
        //
        // public GameObject GetIndexForEnemiesObj(int idx)
        // {
        //     return idx < enemiesObj.Count ? enemiesObj[idx] : null;
        // }
        // public void ClearEnemiesObj()
        // {
        //     enemiesObj.Clear();
        // }
        
        
    }
}