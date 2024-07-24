using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	// Generate Id:3009c3e7-b4e8-44f6-b9fa-1a49d75440f5
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
