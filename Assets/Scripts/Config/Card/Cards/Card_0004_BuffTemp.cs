using NoSLoofah.BuffSystem;
using UnityEngine;
using System;
using QUtility;
using NoSLoofah.BuffSystem.Manager;


namespace Config.Card.Cards
{
    public class Card_0004_BuffTemp : BaseCard
    {

        private IBuff buff;
        private BuffHandler buffHandler;
        public override void Apply(GameObject target, GameObject caster)
        {
            base.Apply(target, caster);
            buff = BuffManager.GetInstance().GetBuff(this.CardBuffId);
            buffHandler = target.GetComponent<BuffHandler>();
            buff.Initialize(buffHandler, caster);
            buffHandler.AddBuff(this.CardBuffId, caster);
        }
    }
}