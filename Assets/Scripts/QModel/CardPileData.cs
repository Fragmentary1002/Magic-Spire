using QFramework;
using Config.Card;
using System.Collections.Generic;
using Config;
using QUtility;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace QModel
{
    public class CardPileData:AbstractModel
    {
        
        //model
        private List<BaseCard> deck = new List<BaseCard>();                         //卡组 

        private List<BaseCard> drawPile = new List<BaseCard>();                     // 抽卡堆  


        private List<BaseCard> cardsInHand = new List<BaseCard>();                  // 手牌  


        private List<BaseCard> discardPile = new List<BaseCard>();                  // 弃牌堆  

        private List<BaseCard> cemeteryPile = new List<BaseCard>();                 //墓地堆
        
        protected override void OnInit(){}

        #region 手牌
        public void RemoveCurCardForCardsInHand(BaseCard card)
        {
            this.cardsInHand.Remove(card);
        }

        #endregion
        
        #region 抽牌堆
        public void AddDrawPile(BaseCard card)
        { 
            if(card==null) return;
            this.drawPile.Add(card);
        }

        public bool IsEmptyDrawPile()
        {
            return drawPile.Count <= 0;
        }
        public bool IsFullDrawPile()
        {
            return drawPile.Count >= GameSetting.FullCardCnt;
        }
        public void ClearDrawPile()
        {
            this.drawPile.Clear();
        }

        public int LengthOfDrawPile()
        {
            return drawPile.Count;
        }
        #endregion

        #region 弃牌堆
        
        /// <summary>
        /// 丢弃所有手牌
        /// </summary>
        public void DisCardHandAll()
        {
             LogTool.Log("遍历手中的每一张卡牌，并将其置入弃牌堆  ");
             // 遍历手中的每一张卡牌，并将其置入弃牌堆  
             foreach (BaseCard card in this.cardsInHand)
             {
                 AddDiscardPile(card);
             }
            
             this.ClearDrawPile();

           // PushPoolAll();
        }
        
        /// <summary>
        /// 用于将一张卡片放入弃牌堆 
        /// </summary>
        public void AddDiscardPile(BaseCard card)
        { 
            if(card==null) return;
            this.discardPile.Add(card);
        }
        public int GetDrawPileCnt()
        {
            return discardPile.Count;
        }

        public void ClearDiscardPile()
        {
            this.discardPile.Clear();
        }
        

        #endregion

        #region 洗牌

        /// <summary>
        /// 洗牌操作
        /// </summary>
        public void ShuffleCards()
        {

            this.discardPile.Shuffle(); // 洗牌操作，将弃牌堆中的卡片随机排序  

            this.drawPile = this.discardPile; // 将洗好的弃牌堆赋值给抽牌堆，准备下一次抽牌  

            this.ClearDiscardPile();  // 重置弃牌堆，为下一次洗牌做准备

            LogTool.Log("洗牌");

        }

        public int LengthOfDiscardPile()
        {
            return discardPile.Count;
        }
        #endregion

        #region 抽牌

        public void DrawCard()
        {
            this.cardsInHand.Add(this.discardPile[0]);
            // LoadPool(battleInfo.drawPile[0]);
            this.drawPile.Remove(this.discardPile[0]);
        }

        #endregion
    }
}