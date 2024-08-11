using NoSLoofah.BuffSystem;
using UnityEngine;
using System;
using QUtility;


namespace Config.Card
{

    [CreateAssetMenu(fileName = "Card", menuName = "ScriptableObject/Card")]
    public class BaseCard : ScriptableObject, ICard
    {
        public virtual void Apply(GameObject target, GameObject caster)
        {
            LogTool.Log($"Apply Card Type : {GetType()}");
        }



        #region �1�7�1�7�1�7�1�7

        [Header("�1�7�1�7�1�7�1�7")]
        //�1�7�1�7�1�7�1�7id
        public int cardId;

        // �1�7�0�9�1�7�1�7�1�7�1�7�1�7�1�7�1�7
        public bool isUpgraded;

        #endregion



        #region �1�7�1�7�1�7�1�7���1�7�1�7�1�7�5�5�1�7�1�7
        // �1�7�1�7�1�7�0�3�1�7�1�7���1�7���1�7�1�7�1�7�0�5�5�5�1�7�1�7
        [System.Serializable]
        public struct ScardAmount
        {
            public int baseAmount; // �1�7�1�7�1�7�1�7�0�5
            public int upgradedAmount; // �1�7�1�7�1�7�1�7�1�7�1�7�1�7�0�5
        }

        // �1�7�1�7�1�7�1�7�1�7�1�7�1�7�1�7�1�7�0�5�5�5�1�7�1�7
        [System.Serializable]
        public struct ScardDescription
        {
            public string baseAmount; // �1�7�1�7�1�7�1�7�0�5
            public string upgradedAmount; // �1�7�1�7�1�7�1�7�1�7�1�7�1�7�0�5
        }
        #endregion



        #region �1�7�1�7�1�7�1�7UI
        [Header("�1�7�1�7�1�7�1�7UI")]


        // �1�7�1�7�1�7�0�7�1�7�1�7�1�7
        [SerializeField]
        private string cardTitle;
        public string CardTitle
        {
            get { return cardTitle; }
        }




        // �1�7�1�7�1�7�1�7�1�7�1�7�1�7�1�7
        [SerializeField]
        private ScardDescription cardDescription;

        public string CardDescription
        {
            get
            {
                if (!isUpgraded)
                    return cardDescription.baseAmount;
                else
                    return cardDescription.upgradedAmount;
            }
        }


        // �1�7�1�7�1�7�1�7�1�7�1�7�1�7
        [SerializeField]
        private CardColor cardColor;
        public CardColor CardColor
        {
            get { return cardColor; }
        }



        [SerializeField]
        // �1�7�1�7�1�7�1�7�0�0�1�7�1�7
        private Sprite cardIcon;
        public Sprite CardIcon
        {
            get { return cardIcon; }
        }
        #endregion



        #region �1�7�1�7�1�7�1�7�1�7�1�7�1�7�1�7�1�7�0�5

        [Header("�1�7�1�7�1�7�1�7�1�7�1�7�1�7�1�7�1�7�0�5")]

        // �1�7�1�7�1�7�0�3�1�7�1�7�1�7
        [SerializeField]
        private ScardAmount cardCost;
        public int CardCost
        {
            get
            {
                if (!isUpgraded)
                    return cardCost.baseAmount;
                else
                    return cardCost.upgradedAmount;
            }
        }
        // �1�7�1�7�1�7�1�7�1�7�1�7�0�5
        [SerializeField]
        private ScardAmount cardEffect;
        public int CardEffect
        {
            get
            {
                if (!isUpgraded)
                    return cardEffect.baseAmount;
                else
                    return cardEffect.upgradedAmount;
            }
        }





        // �1�7�1�7�1�7�1�7�1�7�1�7�1�7�1�7
        [SerializeField]
        private CardType type;
        public CardType Type
        {
            get { return type; }
        }



        // �1�7�1�7�1�7�1�7�0�7�1�7�1�7�1�7�1�7�1�7�1�7
        [SerializeField]
        private CardTargetType target;
        public CardTargetType Target
        {
            get { return target; }
        }

        #endregion



        #region �1�7�1�7�1�7�1�7Buff
        [Header("�1�7�1�7�1�7�1�7Buff")]
        //�1�7�0�9�1�7�0�4�1�7�1�7buff


        [SerializeField]
        private bool isBuffs;
        public bool IsBuffs
        {
            get { return isBuffs; }
        }

        //�0�4�1�7�0�3�1�7buff
        [SerializeField]
        private int cardBuffId;
        public int CardBuffId
        {
            get { return cardBuffId; }
        }

        // �1�7�1�7�1�7�1�7buff�1�7�1�7�1�7�1�7�1�7�1�7�0�5
        [SerializeField]
        private ScardAmount buffAmount;
        public int BuffAmount
        {
            get
            {
                if (!isUpgraded)
                    return buffAmount.baseAmount;
                else
                    return buffAmount.upgradedAmount;
            }
        }


        // �1�7�1�7�1�7�1�7buff�0�7�1�7�1�7�1�7�1�7�1�7�1�7
        [SerializeField]
        private CardTargetType targetBuff;
        public CardTargetType TargetBuff
        {
            get { return targetBuff; }
        }
    }
    #endregion
}


