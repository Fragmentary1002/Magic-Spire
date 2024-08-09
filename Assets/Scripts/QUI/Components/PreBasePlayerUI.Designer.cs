/****************************************************************************
 * 2024.8 linhao
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	public partial class PreBasePlayerUI
	{
		[SerializeField] public UnityEngine.UI.Image imgPlayerIcon;
		[SerializeField] public PreHealthBarUI PreHealthBarUI;
		[SerializeField] public RectTransform BuffParent;

		public void Clear()
		{
			imgPlayerIcon = null;
			PreHealthBarUI = null;
			BuffParent = null;
		}

		public override string ComponentName
		{
			get { return "PreBasePlayerUI";}
		}
	}
}
