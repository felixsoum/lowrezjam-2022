using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<bool> OnButtonDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonDown?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonDown?.Invoke(false);
    }
}
