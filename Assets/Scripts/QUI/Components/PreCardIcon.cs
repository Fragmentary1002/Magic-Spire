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
	public partial class PreCardIcon : UIComponent, IController, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
	{
		public FightCardManager fightCardManager;

		private UIPoolManager uiPoolManager;
		public BaseCard curCard;
		private CanvasGroup canvasGroup;
		private int index;
		private void Awake()
		{
			fightCardManager = this.GetSystem<FightCardManager>();
			canvasGroup = GetComponent<CanvasGroup>();
			uiPoolManager = this.GetSystem<UIPoolManager>();
		}
		protected override void OnBeforeDestroy()
		{
		}
		private void OnDisable()
		{
			uiPoolManager.PushObj(this);
		}
		public void RefreshCard(BaseCard card)
		{
			if (card == null)
			{
				this.curCard = null;
				this.gameObject.SetActive(false);

				return;
			}

			this.curCard = card;
			this.CardDescription.text = this.curCard.CardDescription;
			// this.Background.sprite
			this.CardNameText.text = this.curCard.CardTitle;
			this.CardCost.text = this.curCard.CardCost.ToString();
			this.Icon.sprite = this.curCard.CardIcon;
		}

		#region �¼��ӿ�ʵ��

		public void OnPointerClick(PointerEventData eventData)
		{
			if (this.curCard == null) return;
			// ��֪ս�������������ÿ����ѱ�ѡ��
			//battleSceneManager.selectedCard = this;
			//Debug.Log("ѡ��ÿ��Ƶķ���");
			transform.DOScale(1.5f, 0.5f);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{

			if (this.curCard == null) return;
			transform.DOScale(1.5f, 0.25f);
			index = transform.GetSiblingIndex();
			transform.SetAsLastSibling();

			// transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor",Color.yellow);
			// transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth",10);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (this.curCard == null) return;
			transform.DOScale(1.0f, 0.25f);
			transform.SetSiblingIndex(index);

			// transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor", Color.black);
			// transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth", 1);

		}
		Vector2 initPos;//��ק��ʼʱ��¼���Ƶ�λ��
						//��ʼ��ק
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			initPos = transform.GetComponent<RectTransform>().anchoredPosition;
			//canvasGroup.alpha = 0.5f;//��ק�ù����н���͸����
			canvasGroup.blocksRaycasts = false;

		}

		public void OnDrag(PointerEventData eventData)
		{
			transform.position = Input.mousePosition;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			//canvasGroup.alpha = 1f;
			canvasGroup.blocksRaycasts = true;//���Լ�����ק
			transform.GetComponent<RectTransform>().anchoredPosition = initPos;
			transform.SetSiblingIndex(index);
			// Debug.Log("����������ק����ʱ�����ķ��� ��ߵ���FightCardManager");
			this.fightCardManager.PlayCard(this.curCard, () =>
			{
				this.gameObject.SetActive(false);
			});
		}


		#endregion
		// ָ���ܹ�
		public IArchitecture GetArchitecture()
		{
			return CounterApp.Interface;
		}
	}
}