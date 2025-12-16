using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public virtual void OnDrop(PointerEventData eventData)
    {
        var item = DragDrop.DragItem;
        var child = transform.GetComponentInChildren<DragDrop>();
        if (item is not null && !child)
        {
            if (IsConditionsCompleted()) { 

                item.UseCardOnSlot(transform);
            }
        }
        else if (item is not null && child)
        {
            var slot = item.CurrentSlot;
            child.SetItemToSlot(slot);
            item.SetItemToSlot(transform);
        }
    }

    private bool IsConditionsCompleted() {

        var slot = GetComponent<HeroSlot>();
        var slotRole = slot.Role;

        var item = DragDrop.DragItem.GetComponent<CardDisplay>();
        var cardRole = item.Role;

        if (TurnManager.GetInstance.State == TurnManager.States.PlayersTurn &&
            (slotRole == cardRole || cardRole == Player.Roles.Any) &&
            Player.GetInstance.GetActonNumberByRole(slotRole) > 0) { 
            return true;
        }
        return false;
    }
}
