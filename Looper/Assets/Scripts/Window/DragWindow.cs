using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class DragWindow : MonoBehaviour
{
    public Canvas canvas;
    public Vector2 offset;
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = transform.parent.GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }


    public void beginDrag(BaseEventData baseData)
    { 
    PointerEventData data = (PointerEventData) baseData;
    
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform) canvas.transform,
            data.position,
            data.pressEventCamera,
            out offset);

        offset =  (Vector2) rectTransform.anchoredPosition - offset;
    }

    public void DragHandler(BaseEventData baseData)
    {
        PointerEventData data = (PointerEventData)baseData;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)  canvas.transform,
            data.position,
            data.pressEventCamera,
            out Vector2 pos);

        rectTransform.anchoredPosition = pos + offset;
    }
}
