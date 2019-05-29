using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public GameObject board;

    private BlackJackGameController gameController; 

    List<Card> hand;

    private void Awake()
    {
        hand = new List<Card>();
        gameController = board.GetComponent<BlackJackGameController>();
    }

    public void ReceiveCard(Card card)
    {
        hand.Add(card);
    }

    public void TakeTurn()
    {
        while (GetScore() < 17)
        {
            hand.Add(gameController.Deal());
        }

    }
    
    public int GetScore()
    {
        int score = 0;
        foreach (Card card in hand)
        {
            score += (int)card.getValue();
        }
        return score;
    }

}
