using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoSLoofah.BuffSystem.Manager;
using NoSLoofah.BuffSystem;
using QModel;
public class Buff_0001_Strength : Buff
{
    [SerializeField] private int IncreaseAttackNum = 10;
    [SerializeField] private GameObject effect;
    private Fighter tarFighter;
    public override void OnBuffDestroy() { base.OnBuffDestroy(); }

    public override void OnBuffModifyLayer(int change) { }

    public override void OnBuffRemove() { }

    public override void OnBuffStart()
    {
        tarFighter = Target.GetComponent<Fighter>();

        tarFighter.BuffIncreaseAttack(IncreaseAttackNum);
        var g = Instantiate(effect);
        g.transform.position = Target.BuffParent.transform.position;

    }

    public override void Reset() { }

    protected override void OnBuffTickEffect()
    {
    }
}
