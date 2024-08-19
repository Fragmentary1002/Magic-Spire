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
using UnityEngine.EventSystems;

namespace QUI
{
	public partial class PreBaseEnemyUI : UIComponent,IPointerEnterHandler, IPointerExitHandler
	{
		private FighterData fighterData;
		private void Awake()
		{
			Register();
			OutLine.enabled = false;
		}

		protected override void OnBeforeDestroy()
		{
		}
		private void Register()
		{
		}

		public Fighter OnHurt(Fighter f)
		{
			PreHealthBarUI.RefreshBar(f);
			return f;
		}
		
		public void OnPointerEnter(PointerEventData eventData)
		{
			OutLine.enabled = true;
			StringEventSystem.Global.Send(EventID.SetCurEnemy,this.gameObject);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			OutLine.enabled = false;
			StringEventSystem.Global.Send(EventID.SetCurEnemy,this.gameObject);
		}
	}
}