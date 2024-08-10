using QFramework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Config;
using QUI;
using Config.Card;

namespace QSystem
{
    public class UIPoolManager : AbstractSystem
    {
        private FanCardLayout fanCardLayout;
        private SimpleObjectPool<PreCardIcon> cardIconPool;
        private List<PreCardIcon> activeCardIcons = new List<PreCardIcon>();

        public ResLoader mResLoader;


        protected override void OnInit()
        {
            fanCardLayout = this.GetUtility<FanCardLayout>();
            mResLoader = ResLoader.Allocate();


            InitializeCardPool();
            Register();

        }

        private void Register()
        {
            StringEventSystem.Global.Register(EventID.CardsUpdate, () => UpdateCardLayout());
        }

        private void InitializeCardPool()
        {
            // 初始化卡牌图标对象池
            cardIconPool = new SimpleObjectPool<PreCardIcon>(() =>
            {
                // 创建一个新的卡牌图标对象

                GameObject preCardIconPrefab = mResLoader.LoadSync<GameObject>(ABPath.PreCardIcon);

                GameObject gameObj = GameObject.Instantiate(preCardIconPrefab);

                PreCardIcon preCardIcon = gameObj.GetComponent<PreCardIcon>();

                return preCardIcon;

            }, (preCardIcon) =>
            {
                // 重置卡牌图标对象
                preCardIcon.RefreshCard(null);
                preCardIcon.gameObject.SetActive(false);
            }, 10); // 初始池大小

        }

        public void GetObj(BaseCard card, Transform go)
        {
            Debug.Log(card);
            var preCardIcon = cardIconPool.Allocate();
            activeCardIcons.Add(preCardIcon);
            preCardIcon.RefreshCard(card);
            preCardIcon.gameObject.transform.SetParent(go);
        }
        public void PushObj(PreCardIcon preCardIcon)
        {
            cardIconPool.Recycle(preCardIcon);
            activeCardIcons.Remove(preCardIcon);
        }
        public void RefreshCardList(List<BaseCard> deck)
        {
            // 清除现有的活动卡牌图标
            foreach (var cardIcon in activeCardIcons)
            {
                cardIconPool.Recycle(cardIcon);
            }
            activeCardIcons.Clear();

            // 根据deck创建/更新卡牌图标
            for (int i = 0; i < deck.Count; i++)
            {
                var cardIcon = cardIconPool.Allocate();
                cardIcon.RefreshCard(deck[i]);
                cardIcon.gameObject.SetActive(true);
                activeCardIcons.Add(cardIcon);
            }

            UpdateCardLayout();
        }

        public void UpdateCardLayout()
        {
            // 使用FanCardLayout来设置卡牌图标的布局
            fanCardLayout.SetLayout(activeCardIcons);
        }
    }
}
