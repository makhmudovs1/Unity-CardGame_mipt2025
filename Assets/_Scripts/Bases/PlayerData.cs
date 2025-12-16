using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [SerializeField] float healthPercent;

    [SerializeField] BaseHero[] heroesTemplate;
    [SerializeField] List<BaseHero> heroes;
        
    [SerializeField] Card[] cardsTemplate;
    [SerializeField] List<Card> cards;

    public float HealthPercent { get => healthPercent; set => healthPercent = value; }
    public Card[] Cards { get => cards.ToArray(); }
    public BaseHero[] Heroes { get => heroes.ToArray(); }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public bool RemoveCard(Card card)
    {
        return cards.Remove(card);
    }

    public void ReloadCardsFromTemplate() {
        cards.Clear();
        cards.AddRange(cardsTemplate);
    }

    public void ReloadHeroesFromTemplate()
    {
        heroes.Clear();
        heroes.AddRange(heroesTemplate);
    }

    public void AddHero(BaseHero hero)
    {
        heroes.Add(hero);
    }

    public bool RemoveHero(BaseHero hero)
    {
        return heroes.Remove(hero);
    }

    public void SetFullHealth() 
    {
        healthPercent = 1;
    }
}
