using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private Card card;

    private int cardId;
    [SerializeField] private Image image;

    [SerializeField] private Text cardName;
    [SerializeField] private Text description;

    public Card Card
    {
        get => card;
        set
        {
            card = value;
            SetData();
        }
    }

    public int CardId { get => cardId; }
    public Player.Roles Role { 
        get 
        {
            Debug.Log(cardId.ToString().Trim()[0]);
            if (cardId.ToString().Trim()[0] == '2') return Player.Roles.Support;
            else if (cardId.ToString().Trim()[0] == '3') return Player.Roles.Range;
            else if (cardId.ToString().Trim()[0] == '4') return Player.Roles.Melee;
            else return Player.Roles.Any;
        } 
    }

    private void Awake()
    {
        SetData();
    }

    private void SetData()
    {
        if (!card) return;
        image.sprite = card.Sprite;
        cardName.text = card.CardName;
        description.text = card.Description;
        cardId = card.CardId;
    }
}
