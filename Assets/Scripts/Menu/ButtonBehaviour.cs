using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image img;
    RectTransform rectButton;

    private void Start()
    {
        rectButton = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectButton.localScale = Vector3.one * 1.2f;
        img.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectButton.localScale = Vector3.one * 1f;
        img.color = Color.white;
    }
}
