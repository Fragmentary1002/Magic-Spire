/****************************************************************************
 * 2024.8 linhao
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	public partial class PreCardIcon
	{
		[SerializeField] public UnityEngine.UI.Image Image;
		[SerializeField] public TMPro.TextMeshProUGUI CardDescription;
		[SerializeField] public UnityEngine.UI.Image Background;
		[SerializeField] public UnityEngine.UI.Image Icon;
		[SerializeField] public TMPro.TextMeshProUGUI CardNameText;
		[SerializeField] public TMPro.TextMeshProUGUI CardCost;

		public void Clear()
		{
			Image = null;
			CardDescription = null;
			Background = null;
			Icon = null;
			CardNameText = null;
			CardCost = null;
		}

		public override string ComponentName
		{
			get { return "PreCardIcon";}
		}
	}
}
