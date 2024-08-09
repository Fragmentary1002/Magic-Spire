using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QModel;
using QUtility;
using Config;
using Config.Card;

namespace QUI
{
	public class FightMainWndData : UIPanelData,IController 
	{
		public CardPileData cardPileData;
		public FighterData fighterData;
		public PlayerData playerData;
		public FanCardLayout fanCardLayout;
		public ResLoader mResLoader;
		public List<PreCardIcon> PreCardIcons;
		public List<PreBaseEnemyUI> PreBaseEnemiesUI;
		
		public FightMainWndData()
		{
			cardPileData = this.GetModel<CardPileData>();
			fighterData = this.GetModel<FighterData>();
			playerData = this.GetModel<PlayerData>();
			fanCardLayout = this.GetUtility<FanCardLayout>();
			mResLoader = ResLoader.Allocate();
		}
		
		// 指定架构
		public IArchitecture GetArchitecture()
		{
			return CounterApp.Interface;
		}
	}
	
	
	public partial class FightMainWnd : UIPanel
	{
				
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as FightMainWndData ?? new FightMainWndData();
			
			ButtonInit();
			Register();
			InitMData();
			UpdateCardLayout();
		}

		private void ButtonInit()
		{
			// please add init code here
			btnDrawPile.onClick.AddListener(() =>
			{
				LogTool.Log("onClick btnDrawPile ");
			});
			
			btnDiscardPile.onClick.AddListener(() =>
			{
				LogTool.Log("onClick btnDiscardPile ");
			});
			
			btnEndTurn.onClick.AddListener((() =>
			{
				LogTool.Log("onClick btnEndTurn ");
			}));

		}

		private void Register()
		{
			StringEventSystem.Global.Register(EventID.EnergyUpdate,()=>UpdateEnergy());;
			StringEventSystem.Global.Register(EventID.CardsUpdate, () => UpdateCardLayout());
		}

		private void InitMData()
		{
			this.mData.PreCardIcons=new List<PreCardIcon>(this.Cards.GetComponentsInChildren<PreCardIcon>());
			this.mData.PreBaseEnemiesUI =
				new List<PreBaseEnemyUI>(this.tranEnemyParent.GetComponentsInChildren<PreBaseEnemyUI>());
			for(int i=0;i<this.mData.PreCardIcons.Count;i++)
			{	
				if (i < this.mData.cardPileData.deck.Count)
				{
					this.mData.PreCardIcons[i].RefreshCard(this.mData.cardPileData.deck[i]);
				}
				else
				{
					this.mData.PreCardIcons[i].RefreshCard(null);
				}
			}
		}
		
		private void UpdateEnergy()
		{
			this.txtEnergyCnt.text = this.mData.fighterData.GetPlayer().curEnergy.ToString();
		}

		private void UpdateCardLayout()
		{
			this.mData.fanCardLayout.SetLayout<PreCardIcon>(this.mData.PreCardIcons);
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			LoadData();
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
			
		}


		private void LoadData()
		{
			
			txtDrawPileCnt.text = this.mData.cardPileData.LengthOfDrawPile().ToString();
			txtDiscardPileCnt.text = this.mData.cardPileData.LengthOfDiscardPile().ToString();
			txtEnergyCnt.text = this.mData.fighterData.GetPlayer().curEnergy.ToString();
			
			this.PreBasePlayerUI.gameObject.GetComponent<Image>().sprite = this.mData.fighterData.GetPlayer().icon;
			// PlayerParent
			// EnemyParent	
			// Cards

		}

		
	}
}
