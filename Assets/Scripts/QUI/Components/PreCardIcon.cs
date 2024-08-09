/****************************************************************************
 * 2024.8 linhao
 ****************************************************************************/

using System;
using System.Collections.Generic;
using Config.Card;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QSystem;
using UnityEngine.EventSystems;

namespace QUI
{
	public partial class PreCardIcon : UIComponent,IController,IPoolable,IPoolType, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler,IBeginDragHandler
	{
		public FightCardManager fightCardManager;
		public BaseCard curCard;
		private CanvasGroup canvasGroup;
		private int index;
		private void Awake()
		{
			fightCardManager = this.GetSystem<FightCardManager>();
			canvasGroup = GetComponent<CanvasGroup>();
		}
		protected override void OnBeforeDestroy()
		{
		}

		public void RefreshCard(BaseCard card)
		{
			if (card == null)
			{
				this.gameObject.SetActive(false);
				
				return;
			}
			
			this.curCard=card;
			this.CardDescription.text = this.curCard.CardDescription;
			// this.Background.sprite
			this.CardNameText.text = this.curCard.CardTitle;
			this.CardCost.text = this.curCard.CardCost.ToString();
			this.Icon.sprite = this.curCard.CardIcon;
		}
		
		#region 事件接口实现

		public void OnPointerClick(PointerEventData eventData)
		{
			if(this.curCard==null) return;
			// 告知战斗场景管理器该卡牌已被选择
			//battleSceneManager.selectedCard = this;
			//Debug.Log("选择该卡牌的方法");
			transform.DOScale(1.5f, 0.5f);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			
			if(this.curCard==null) return;
			transform.DOScale(1.5f, 0.25f);
			index = transform.GetSiblingIndex();
			transform.SetAsLastSibling();
 
			// transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor",Color.yellow);
			// transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth",10);
		}

		public void OnPointerExit(PointerEventData eventData)
		{	
			if(this.curCard==null) return;
			transform.DOScale(1.0f, 0.25f);
			transform.SetSiblingIndex(index);
 
			// transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor", Color.black);
			// transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth", 1);

		}
		Vector2 initPos;//拖拽开始时记录卡牌的位置
		//开始拖拽
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			initPos = transform.GetComponent<RectTransform>().anchoredPosition; 
			//canvasGroup.alpha = 0.5f;//拖拽得过程中降低透明度
			canvasGroup.blocksRaycasts = false;

		}
		
		public void OnDrag(PointerEventData eventData)
		{
			transform.position = Input.mousePosition;
		}
		
		public void OnEndDrag(PointerEventData eventData)
		{
			//canvasGroup.alpha = 1f;
			canvasGroup.blocksRaycasts = true;//可以继续拖拽
			transform.GetComponent<RectTransform>().anchoredPosition = initPos;
			transform.SetSiblingIndex(index);
			// Debug.Log("当鼠标结束拖拽卡牌时触发的方法 这边调到FightCardManager");
			this.fightCardManager.PlayCard(this.curCard, () =>
			{
				this.gameObject.SetActive(false);
			});
		}
		
		
		#endregion
		// 指定架构
		public IArchitecture GetArchitecture()
		{
			return CounterApp.Interface;
		}
	}
}