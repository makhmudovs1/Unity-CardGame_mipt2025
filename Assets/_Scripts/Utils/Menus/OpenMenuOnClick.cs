using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenMenuOnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject menu;

    public void OnPointerClick(PointerEventData eventData)
    {
        menu.SetActive(true);
        HeroSelectorManager.Sender = gameObject;
    }
}
