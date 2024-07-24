using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	// Generate Id:b3d9033f-1e67-48af-869b-4a06aac595e0
	public partial class FightMainWnd
	{
		public const string Name = "FightMainWnd";
		
		/// <summary>
		/// 结束回合动画
		/// </summary>
		[SerializeField]
		public UnityEngine.Animator animBanner;
		/// <summary>
		/// 玩家结点
		/// </summary>
		[SerializeField]
		public RectTransform tranPlayerParent;
		/// <summary>
		/// 敌人结点
		/// </summary>
		[SerializeField]
		public RectTransform tranEnemyParent;
		/// <summary>
		/// 卡牌节点
		/// </summary>
		[SerializeField]
		public RectTransform Cards;
		/// <summary>
		/// 弃牌堆按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button btnDiscardPile;
		/// <summary>
		/// 弃牌堆数字
		/// </summary>
		[SerializeField]
		public TMPro.TextMeshProUGUI txtDiscardPileCnt;
		/// <summary>
		/// 抽牌堆按钮
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Button btnDrawPile;
		/// <summary>
		/// 抽牌堆数字
		/// </summary>
		[SerializeField]
		public TMPro.TextMeshProUGUI txtDrawPileCnt;
		/// <summary>
		/// 能量数字
		/// </summary>
		[SerializeField]
		public TMPro.TextMeshProUGUI txtEnergyCnt;
		[SerializeField]
		public UnityEngine.UI.Button btnEndTurn;
		
		private FightMainWndData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			animBanner = null;
			tranPlayerParent = null;
			tranEnemyParent = null;
			Cards = null;
			btnDiscardPile = null;
			txtDiscardPileCnt = null;
			btnDrawPile = null;
			txtDrawPileCnt = null;
			txtEnergyCnt = null;
			btnEndTurn = null;
			
			mData = null;
		}
		
		public FightMainWndData Data
		{
			get
			{
				return mData;
			}
		}
		
		FightMainWndData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new FightMainWndData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
