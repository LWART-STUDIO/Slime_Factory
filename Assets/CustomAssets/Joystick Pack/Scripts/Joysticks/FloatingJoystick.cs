using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
   
    protected override void Start()
    {
        base.Start();
       // background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        _canvasGroup.alpha = 1f;
       // background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.anchoredPosition = new Vector2(0, 200f);
        _canvasGroup.alpha = 0.3f;
        base.OnPointerUp(eventData);
    }
}