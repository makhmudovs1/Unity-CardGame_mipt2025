using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private static DragDrop dragItem;
    [SerializeField] private Transform currentSlot;
    private Vector3 startPosition;
    private Transform startParent;
    private CanvasGroup canvasGroup;
    private RectTransform dragLayer;
    private Transform slot;

    [SerializeField] DragDrop dragItemDebug;

    [SerializeField] DropSlot dropSlot;

    public static DragDrop DragItem { get => dragItem;}
    public Transform CurrentSlot { get => currentSlot; }
    public CanvasGroup CanvasGroup { get => canvasGroup; set => canvasGroup = value; }

    private void Start()
    {
        canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        dragLayer = GameObject.FindGameObjectWithTag("DragLayer").GetComponent<RectTransform>();
        currentSlot = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        slot = null;
        dragItem = this;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(dragLayer);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        Debug.Log(GetComponent<CardDisplay>().Role);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragItem = null;

        canvasGroup.blocksRaycasts = true;
        if (slot == null)
        {
            transform.SetParent(startParent);
            transform.position = startPosition;
        }
        slot = null;
    }

    public void SetItemToSlot(Transform slot)
    {
        this.slot = slot;
        transform.SetParent(slot);
        currentSlot = slot;
        transform.localPosition = Vector3.zero;
    }

    public void UseCardOnSlot(Transform slot) {
        int cardId = GetComponent<CardDisplay>().CardId;
        slot.GetComponent<HeroSlot>().HeroController.UseCard(cardId);
        SetItemToSlot(slot);
        StartCoroutine(DeleteAfterSeconds(1));
    }

    IEnumerator DeleteAfterSeconds(int time)
    {
        var obj = gameObject;
        enabled = false;
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }
}
