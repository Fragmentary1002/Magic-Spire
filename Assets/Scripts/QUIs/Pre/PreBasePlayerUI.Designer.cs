using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	// Generate Id:6b6b29a9-fe80-469d-b6d9-7b097368a4f3
	public partial class PreBasePlayerUI
	{
		public const string Name = "PreBasePlayerUI";
		
		/// <summary>
		/// 玩家图标
		/// </summary>
		[SerializeField]
		public UnityEngine.UI.Image imgPlayerIcon;
		[SerializeField]
		public PreHealthBarUI PreHealthBarUI;
		
		private PreBasePlayerUIData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			imgPlayerIcon = null;
			PreHealthBarUI = null;
			
			mData = null;
		}
		
		public PreBasePlayerUIData Data
		{
			get
			{
				return mData;
			}
		}
		
		PreBasePlayerUIData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new PreBasePlayerUIData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
