using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<bool> OnButtonDown;
    [SerializeField] Sprite buttonUp;
     [SerializeField] Sprite buttonDown;


    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonDown?.Invoke(true);
        ChangeSprite(buttonDown);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonDown?.Invoke(false);
        ChangeSprite(buttonUp);
    }

    private void ChangeSprite(Sprite currentsprite)
    {
        GetComponent<Image>().sprite = currentsprite;
    }
}
