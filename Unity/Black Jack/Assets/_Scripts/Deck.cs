using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    List<Card> cards;
    List<Card> usedCards;

    public Deck(bool jokers)
    {
        cards = new List<Card>();
        usedCards = new List<Card>();

        foreach (string suit in System.Enum.GetNames(typeof(Card.Suit)))
        {
            foreach (string value in System.Enum.GetNames(typeof(Card.Value)))
            {
                cards.Add(new Card((Card.Suit)System.Enum.Parse(typeof(Card.Suit), suit), (Card.Value)System.Enum.Parse(typeof(Card.Value), value)));
            }
        }

    }

    public int GetNumberOfCardsRemaining()
    {
        return cards.Count;
    }

    public void Shuffle()
    {
        int count = cards.Count;
        for (int i = 0; i < count - 1; i++)
        {
            var r = Random.Range(i, count);
            var temp = cards[i];
            cards[i] = cards[r];
            cards[r] = temp;
        }
    }

    public Card DrawCard()
    {
        int num = Random.Range(0, cards.Count);
        Card card = cards[num];
        cards.RemoveAt(num);
        cards.RemoveRange(num, 1);

        usedCards.Add(card);

        return card;
    }
    
}
