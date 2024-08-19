/****************************************************************************
 * 2024.8 linhao
 ****************************************************************************/

using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QModel;

namespace QUI
{
	public partial class PreBasePlayerUI : UIComponent
	{
		private void Awake()
		{
			Register();
		}

		protected override void OnBeforeDestroy()
		{
		}
		private void Register()
		{
			
		}

		public void OnHurt(Fighter f)
		{
			PreHealthBarUI.RefreshBar(f);
		}
	}
}