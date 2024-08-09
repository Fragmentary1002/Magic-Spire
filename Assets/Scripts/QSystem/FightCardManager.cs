using Config.Card;
using QFramework;
using QModel;
using QUtility;
using System.Collections.Generic;
using Config;
using UnityEngine.Events;

namespace QSystem
{
    public class FightCardManager:AbstractSystem
    {
        private CardPileData _cardPileData;
        private FighterData _fighterData;
        
        
        protected override void OnInit()
        {
            _cardPileData = this.GetModel<CardPileData>();
            _fighterData = this.GetModel<FighterData>();
        }

        public void PlayCard(BaseCard card,UnityAction callBack)
        {

            if (card == null)
            {
                LogTool.Log("找不到Card数据");
                return ;
            }


            if (_fighterData.GetPlayer().curEnergy < card.CardCost)
            {
                LogTool.Log("你的能量不够");
                return ;
            }

            // if (cardUI.card.cardType != CardTj.CardType.Attack && enemies[0].GetComponent<Fighter>().enrage.buffValue > 0)
            //   enemies[0].GetComponent<Fighter>().AddBuff(Buff.Type.strength, enemies[0].GetComponent<Fighter>().enrage.buffValue);

            try
            {   
                // 执行卡片的动作。  
                PerformPlayerAction(card);
                callBack?.Invoke();
                _fighterData.GetPlayer().curEnergy -= card.CardCost;
                StringEventSystem.Global.Send(EventID.EnergyUpdate);
                // 从手牌列表中移除该卡片。
                _cardPileData.RemoveCurCardForCardsInHand(card);
                _cardPileData.AddDiscardPile(card);
                StringEventSystem.Global.Send(EventID.CardsUpdate);
                
            }
            catch
            {
                return ;
            }

   
            return ;

        }



        private void PerformPlayerAction(BaseCard card)
        {
            if(card==null) return;
            LogTool.Log("执行卡片的动作");

            Fighter player = _fighterData.GetPlayer();
            Fighter enemy = _fighterData.GetEnemy(1);
            
            switch (card.Type)
            {
                case CardType.Attack:
                    //攻击牌敌人收到伤害
                    enemy.DoTakeDamageAndIsEndFight(card.CardEffect);
                    break;
                case CardType.Skill:
                    //防御牌玩家增加防御
                    player.DoAddBlock(card.CardEffect);
                    break;
                case CardType.Power:
                    //能力牌玩家加buff
                   
                    break;
            }
        }
        
        
        /// <summary>
        /// 抽牌操作 默认为抽5张
        /// </summary>
        public void DrawCards(int amountToDraw)
        {

            // 当需要抽取的卡片数量还未满足，并且手牌数量不超过10张时继续循环

            for (int i = 1; i <= amountToDraw; i++)
            {

                if (_cardPileData.IsFullDrawPile())
                {
                    LogTool.Log("手牌已经满了");
                    return;
                }
                if (_cardPileData.IsEmptyDrawPile()) // 如果抽牌堆中没有卡片可供抽取  
                {
                    _cardPileData.ShuffleCards(); // 则执行洗牌操作，重新填充抽牌堆
                }
                
                //Debug.Log($"抽牌操作  第{i}张 抽到了 id={ drawPile[0].cardId}的卡 ");

                _cardPileData.DrawCard();
            }
            //单抽触发抽卡事件
            if (amountToDraw == 1)
            {
                EnumEventSystem.Global.Send(CallBackPointEventID.DrawCard);
            }
        }

        
      
       

    }
}