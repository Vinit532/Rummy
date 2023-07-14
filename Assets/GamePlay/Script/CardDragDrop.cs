using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform cardRectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent;

    private void Awake()
    {
        cardRectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = cardRectTransform.anchoredPosition;
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        cardRectTransform.anchoredPosition += eventData.delta / GetCanvasScale();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (IsInDrawCardContainer(eventData.position))
        {
            Transform drawCardContainer = GameObject.FindGameObjectWithTag("DrawCardContainer").transform;
            cardRectTransform.SetParent(drawCardContainer);
            cardRectTransform.anchoredPosition = Vector2.zero;
            cardRectTransform.localPosition = new Vector3(0f, 0f, 0f);
        }
        else
        {
            cardRectTransform.SetParent(originalParent);
            cardRectTransform.anchoredPosition = originalPosition;
        }
    }


    private bool IsInDrawCardContainer(Vector2 screenPosition)
    {
        RectTransform drawCardContainerRectTransform = GameObject.FindGameObjectWithTag("DrawCardContainer").GetComponent<RectTransform>();
        if (drawCardContainerRectTransform != null)
        {
            Vector2 localPosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(drawCardContainerRectTransform, screenPosition, null, out localPosition))
            {
                Rect drawCardContainerRect = drawCardContainerRectTransform.rect;
                return drawCardContainerRect.Contains(localPosition);
            }
        }
        return false;
    }

    private float GetCanvasScale()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            return canvas.scaleFactor;
        }
        return 1f;
    }
}
