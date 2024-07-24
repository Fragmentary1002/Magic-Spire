using System.Collections.Generic;
using QFramework;

namespace QModel
{
    public class FighterData:AbstractModel
    {
        private Fighter player = new Fighter();
        private List<Fighter> enemies=new List<Fighter>();
        
        protected override void OnInit(){}

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