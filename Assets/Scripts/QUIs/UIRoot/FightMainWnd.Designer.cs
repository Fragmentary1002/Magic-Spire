using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	// Generate Id:6e3d188f-f39c-45bc-95b4-a3d371f647c1
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
		[SerializeField]
		public PreBasePlayerUI PreBasePlayerUI;
		/// <summary>
		/// 敌人结点
		/// </summary>
		[SerializeField]
		public RectTransform tranEnemyParent;
		[SerializeField]
		public PreBaseEnemyUI PreBaseEnemyUI;
		[SerializeField]
		public PreBaseEnemyUI PreBaseEnemyUI1;
		[SerializeField]
		public PreBaseEnemyUI PreBaseEnemyUI2;
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
			PreBasePlayerUI = null;
			tranEnemyParent = null;
			PreBaseEnemyUI = null;
			PreBaseEnemyUI1 = null;
			PreBaseEnemyUI2 = null;
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
