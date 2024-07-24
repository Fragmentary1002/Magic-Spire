using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QModel;
using QUtility;

namespace QUI
{
	public class FightMainWndData : UIPanelData,ICanGetModel
	{
		public CardPileData cardPileData;
		public FighterData fighterData;
		public PlayerData playerData;

		public FightMainWndData()
		{
			cardPileData = this.GetModel<CardPileData>();
			fighterData = this.GetModel<FighterData>();
			playerData = this.GetModel<PlayerData>();
		}
		
		// Ö¸¶¨¼Ü¹¹
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
		
		protected override void OnOpen(IUIData uiData = null)
		{
			LoadData(mData);
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


		private void LoadData(FightMainWndData data)
		{
			
			txtDrawPileCnt.text = data.cardPileData.LengthOfDrawPile().ToString();
			txtDiscardPileCnt.text = data.cardPileData.LengthOfDiscardPile().ToString();
			txtEnergyCnt.text = data.fighterData.GetPlayer().curEnergy.ToString();
			
			// PlayerParent
			// EnemyParent	
			// Cards
		}
	}
}
