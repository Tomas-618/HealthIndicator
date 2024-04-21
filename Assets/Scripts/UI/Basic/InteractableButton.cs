using System;
using UnityEngine.EventSystems;

public class InteractableButton : Interactable
{
    public event Action OnClick;

    public override void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
        base.OnPointerClick(eventData);
    }
}
