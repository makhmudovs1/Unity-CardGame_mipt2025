using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RewardPopUp : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;

    [SerializeField] Text entityName;
    [SerializeField] Text description;


    public void SetData(string name, string description, Sprite sprite) 
    {
        image.sprite = sprite;
        entityName.text = name;
        this.description.text = description;
    }

    void ClosePopUp()
    {
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClosePopUp();
    }
}
