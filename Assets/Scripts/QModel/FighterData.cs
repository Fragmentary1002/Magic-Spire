using System.Collections.Generic;
using NUnit.Framework;
using QFramework;

namespace QModel
{
    public class FighterData:AbstractModel
    {
        private Fighter player = new Fighter();
        private List<Fighter> enemies=new List<Fighter>();
        
        protected override void OnInit(){}

        /// <summary>
        /// 传入至少俩个参数，限制生成怪物为3
        /// </summary>
        /// <param name="fighters"></param>
        public void InitFighterData(Fighter player,List<Fighter> enemies)
        {
            this.player = player;
            this.enemies = enemies;
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
    }
}