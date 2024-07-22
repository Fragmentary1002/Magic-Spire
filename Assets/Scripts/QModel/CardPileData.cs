using QFramework;
using Config.Card;
using System.Collections.Generic;

namespace QModel
{
    public class CardPileData:AbstractModel
    {
        
        //model
        public List<BaseCard> deck = new List<BaseCard>();                         //卡组 

        public List<BaseCard> drawPile = new List<BaseCard>();                     // 抽卡堆  


        public List<BaseCard> cardsInHand = new List<BaseCard>();                  // 手牌  


        public List<BaseCard> discardPile = new List<BaseCard>();                  // 弃牌堆  

        public List<BaseCard> cemeteryPile = new List<BaseCard>();                 //墓地堆
        
        protected override void OnInit(){}
    }
}