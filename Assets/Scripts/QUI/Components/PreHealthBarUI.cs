/****************************************************************************
 * 2024.7 linhao
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QModel;

namespace QUI
{
	public partial class PreHealthBarUI : UIComponent
	{
		private void Awake()
		{
		}
		
		protected override void OnBeforeDestroy()
		{
		}

		public void RefreshBar(Fighter fighter)
		{
			txtHealth.text = $"{fighter.curHp}/{fighter.maxHp}";
			sliderHealth.maxValue = fighter.maxHp;
			sliderHealth.value = fighter.curHp;
			if (fighter.currentBlock > 0)
			{
				imgBlockIcon.enabled = true;
				txtBlock.text = fighter.currentBlock.ToString();
			}
			else
			{
				imgBlockIcon.enabled = false;
				txtBlock.enabled = false;
			}
		}
	}
}