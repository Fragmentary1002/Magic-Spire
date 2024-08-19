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
using QSystem;

namespace QUI
{
	public class FightMainWndData : UIPanelData, IController
	{
		public CardPileData cardPileData;
		public FighterData fighterData;
		public PlayerData playerData;

		public ResLoader mResLoader;
		public List<PreCardIcon> PreCardIcons;
		public List<PreBaseEnemyUI> PreBaseEnemiesUI;

		public UIPoolManager uIPoolManager;
		public FightMainWndData()
		{
			cardPileData = this.GetModel<CardPileData>();
			fighterData = this.GetModel<FighterData>();
			playerData = this.GetModel<PlayerData>();
			uIPoolManager = this.GetSystem<UIPoolManager>();

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
			InitMData();
			Register();

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
			StringEventSystem.Global.Register(EventID.EnergyUpdate, () =>
			{
				EnergyUpdate();
			});
			StringEventSystem.Global.Register(EventID.PlayerHurt, () =>
			{
				PlayerHurt();

			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			
			StringEventSystem.Global.Register(EventID.EnemyHurt, () =>
			{
				EnemyHurt();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);;
		}

		private void InitMData()
		{

			this.mData.PreBaseEnemiesUI =
				new List<PreBaseEnemyUI>(this.tranEnemyParent.GetComponentsInChildren<PreBaseEnemyUI>());

		}

		private void EnergyUpdate()
		{
			this.txtEnergyCnt.text = this.mData.fighterData.GetPlayer().curEnergy.ToString();
		}

		private void PlayerHurt()
		{
			this.PreBasePlayerUI.OnHurt(this.mData.fighterData.GetPlayer());
		}

		private void EnemyHurt()
		{
			for (int i = 0; i < this.mData.PreBaseEnemiesUI.Count; i++)
			{
				this.mData.PreBaseEnemiesUI[i].OnHurt(this.mData.fighterData.GetEnemy(i));
			}
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
			
			// PlayerParent
			this.PreBasePlayerUI.gameObject.GetComponent<Image>().sprite = this.mData.fighterData.GetPlayer().icon;
			this.mData.fighterData.PlayerObj = this.PreBasePlayerUI.gameObject;
			// EnemyParent	
			
			// Cards

			for (int i = 0; i < this.mData.cardPileData.deck.Count; i++)
			{
				this.mData.uIPoolManager.GetObj(this.mData.cardPileData.deck[i], this.Cards.transform);

			}
			this.mData.uIPoolManager.UpdateCardLayout();

			// for (int i = 0; i < this.mData.cardPileData.GetCardsInHandLength(); i++)
			// {
			// 	print(i);
			// 	this.mData.uIPoolManager.GetObj(this.mData.cardPileData.CardsInHand[i], this.Cards.transform);
			// }

			PlayerHurt();
			EnemyHurt();

		}


	}
}
