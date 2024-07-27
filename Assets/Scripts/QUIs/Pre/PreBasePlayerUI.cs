using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Config;

namespace QUI
{
	public class PreBasePlayerUIData : UIPanelData
	{
	}
	public partial class PreBasePlayerUI : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as PreBasePlayerUIData ?? new PreBasePlayerUIData();
			// please add init code here
			
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
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
	}
}
