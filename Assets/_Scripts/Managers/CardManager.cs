using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class CardManager : MonoBehaviour
{
    [SerializeField] private int cardsInHand;
    private Card[] cardDeck;

    private static CardManager instance;
    public static CardManager GetInstance { get => instance; }
    [SerializeField] private Transform holder;


    [SerializeField] private List<Card> cardsInGame;

    private void Awake()
    {
        instance = this;

        cardDeck = Player.GetInstance.Cards;
        cardsInGame = new List<Card>();
        
        ResetCards();  
    }     

    void ResetCards() {
        cardsInGame.Clear();
        cardsInGame.AddRange(cardDeck);
    }

    public void FillHand() {
        if (cardsInGame.Count <= cardsInHand) { ResetCards(); }

        for (int i = holder.childCount; i < cardsInHand; i++) {
            var card = SetUpCardObject();
            card.transform.SetParent(holder);
            card.transform.localScale = new Vector3(1, 1, 1);
            card.transform.localPosition = new Vector3(card.transform.localPosition.x, card.transform.localPosition.y, holder.position.z);
        }
    }

    GameObject SetUpCardObject()
    {
        int index = UnityEngine.Random.Range(0, cardsInGame.Count);

        GameObject card = Instantiate(cardsInGame[index].CardPrefab);
        card.GetComponent<CardDisplay>().Card = cardsInGame[index];
        cardsInGame.RemoveAt(index);

        return card;
    }
}
