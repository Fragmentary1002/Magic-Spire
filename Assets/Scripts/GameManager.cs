using System;
using FightFSM;
using UnityEditor;
using UnityEngine;
using QFramework;
using System.Collections.Generic;
using System.Collections;
using Config.Card;
using QModel;
using Config.Character;
using Config.Monster;

public class GameManager : MonoSingleton<GameManager>, IController
{
    private CardPileData cardPileData;
    private FighterData fighterData;
    public Character startCharacter;
    public List<Monster> monsters;
    /// <summary>
    /// 页面的名字
    /// </summary>
    public string PanelName;

    /// <summary>
    /// 层级名字
    /// </summary>
    public UILevel Level;

    private void Awake()
    {
        ResKit.Init();
        UIKit.Root.SetResolution(1920, 1080, 0);

        cardPileData = this.GetModel<CardPileData>();
        cardPileData.OnInitDeck(startCharacter.startingDeck);

        fighterData = this.GetModel<FighterData>();
        List<Fighter> fighters = new List<Fighter>();
        for (int i = 0; i < monsters.Count; i++)
        {
            fighters.Add(new Fighter(monsters[i]));
        }
        fighterData.InitFighterData(new Fighter(startCharacter), fighters);

    }

    private IEnumerator Start()
    {
        yield return ResKit.InitAsync();

        yield return new WaitForSeconds(0.2f);


        UIKit.OpenPanel(PanelName, Level);

    }
    // 指定架构
    public IArchitecture GetArchitecture()
    {
        return CounterApp.Interface;
    }
}
