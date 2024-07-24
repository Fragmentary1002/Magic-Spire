using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	public class PreBaseEnemyUIData : UIPanelData
	{
	}
	public partial class PreBaseEnemyUI : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as PreBaseEnemyUIData ?? new PreBaseEnemyUIData();
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
