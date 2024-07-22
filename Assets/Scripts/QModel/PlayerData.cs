using System.Collections.Generic;
using Config.Card;
using Config.Gem;
using Config.Wand;
using QFramework;

namespace QModel
{
    // 需要存储的数据
    public class PlayerData: AbstractModel
    {
        private string playerName;           // 玩家名称

        private int maxHp;

        private int curHp;

        private int maxEnegry;

        private int gold;                    // 金币数量

        private int curFloor;            // 当前所在楼层
        
        private List<BaseCard> cards = new List<BaseCard>();         // 玩家持有的卡牌列表
        
        private List<BaseWand> wands = new List<BaseWand>();

        private List<BaseGem> gems = new List<BaseGem>();

        //public Character character;
        
        protected override void OnInit(){}
        
        /// <summary>
        /// 添加卡牌
        /// </summary>
        /// <param name="newCard">新的卡牌</param>
        /// <param name="amount">卡牌数量默认为1</param>
        public void AddCards(BaseCard newCard, int amount = 1)
        {
            if (newCard == null)
            {
                return;
            }

            for (int i = 0; i < amount; i++)
            {
                this.cards.Add(newCard);
            }

        }

        public void UpdateFloor()
        {
            this.curFloor++;

            return;
        }


    }
    
}