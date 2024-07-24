using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	// Generate Id:1217da0a-79a5-4ff1-9de0-a5253c9c1758
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
		/// <summary>
		/// 生命条
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Slider sliderHealth;
		/// <summary>
		/// 生命数字
		/// </summary>
		[SerializeField]
		public TMPro.TextMeshProUGUI txtHealth;
		/// <summary>
		/// buff结点
		/// </summary>
		[SerializeField]
		public RectTransform tranBuffsParent;
		/// <summary>
		/// 防御图标
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Image imgBlockIcon;
		/// <summary>
		/// 防御数字
		/// </summary>
		[SerializeField]
		public TMPro.TextMeshProUGUI txtBlock;
		
		private PreBaseEnemyUIData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Intent = null;
			IntentIcon = null;
			IntentAmountText = null;
			EnemyIcon = null;
			sliderHealth = null;
			txtHealth = null;
			tranBuffsParent = null;
			imgBlockIcon = null;
			txtBlock = null;
			
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
