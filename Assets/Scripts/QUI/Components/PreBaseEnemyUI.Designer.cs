/****************************************************************************
 * 2024.8 linhao
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QUI
{
	public partial class PreBaseEnemyUI
	{
		[SerializeField] public RectTransform BuffParent;
		[SerializeField] public Animator Intent;
		[SerializeField] public UnityEngine.UI.Image IntentIcon;
		[SerializeField] public TMPro.TextMeshProUGUI IntentAmountText;
		[SerializeField] public UnityEngine.UI.Image EnemyIcon;
		[SerializeField] public Outline OutLine;
		[SerializeField] public PreHealthBarUI PreHealthBarUI;
		
		public void Clear()
		{
			BuffParent = null;
			Intent = null;
			IntentIcon = null;
			IntentAmountText = null;
			EnemyIcon = null;
			OutLine = null;
			PreHealthBarUI = null;
		}

		public override string ComponentName
		{
			get { return "PreBaseEnemyUI";}
		}
	}
}
