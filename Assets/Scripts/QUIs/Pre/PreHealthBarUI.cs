using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	public class PreHealthBarUIData : UIPanelData
	{
	}
	public partial class PreHealthBarUI : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as PreHealthBarUIData ?? new PreHealthBarUIData();
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
