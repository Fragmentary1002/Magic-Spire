using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	// Generate Id:5d85c783-95b7-48b8-b76a-93e07f3965ea
	public partial class PreHealthBarUI
	{
		public const string Name = "PreHealthBarUI";
		
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
		
		private PreHealthBarUIData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			sliderHealth = null;
			txtHealth = null;
			tranBuffsParent = null;
			imgBlockIcon = null;
			txtBlock = null;
			
			mData = null;
		}
		
		public PreHealthBarUIData Data
		{
			get
			{
				return mData;
			}
		}
		
		PreHealthBarUIData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new PreHealthBarUIData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
