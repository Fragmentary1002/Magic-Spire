using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	// Generate Id:404df0fd-763f-4f64-9884-b8adf1447867
	public partial class PreBaseEnemyUI
	{
		public const string Name = "PreBaseEnemyUI";
		
		[SerializeField]
		public Animator Intent;
		/// <summary>
		/// 意图图标

		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Image IntentIcon;
		/// <summary>
		/// 意图数值
		/// </summary>
		[SerializeField]
		public TMPro.TextMeshProUGUI IntentAmountText;
		/// <summary>
		/// 敌人图标
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Image EnemyIcon;
		[SerializeField]
		public PreHealthBarUI PreHealthBarUI;
		
		private PreBaseEnemyUIData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Intent = null;
			IntentIcon = null;
			IntentAmountText = null;
			EnemyIcon = null;
			PreHealthBarUI = null;
			
			mData = null;
		}
		
		public PreBaseEnemyUIData Data
		{
			get
			{
				return mData;
			}
		}
		
		PreBaseEnemyUIData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new PreBaseEnemyUIData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
