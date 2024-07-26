/****************************************************************************
 * 2024.7 linhao
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	public partial class PreHealthBarUI
	{
		[SerializeField] public UnityEngine.UI.Slider sliderHealth;
		[SerializeField] public TMPro.TextMeshProUGUI txtHealth;
		[SerializeField] public RectTransform tranBuffsParent;
		[SerializeField] public UnityEngine.UI.Image imgBlockIcon;
		[SerializeField] public TMPro.TextMeshProUGUI txtBlock;

		public void Clear()
		{
			sliderHealth = null;
			txtHealth = null;
			tranBuffsParent = null;
			imgBlockIcon = null;
			txtBlock = null;
		}

		public override string ComponentName
		{
			get { return "PreHealthBarUI";}
		}
	}
}
