using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class Card: ScriptableObject, ITreasure
{
    [SerializeField] private int cardId;
    [SerializeField] private string cardName;
    [SerializeField] private string description;
    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private Sprite sprite;

    public string CardName { get => cardName; }
    public string Description { get => description; }
    public Sprite Sprite { get => sprite; }
    public int CardId { get => cardId; }
    public GameObject CardPrefab { get => cardPrefab; }

    public string GetDescription()
    {
        return description;
    }

    public string GetName()
    {
        return "Card: " + cardName;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }
}