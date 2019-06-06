using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    public GameObject board;
    public GameObject card;
    public Text scoreText;
    
    private static float xStartPosition = -1;
    private static float yPosition = (float)2.65;

    private BlackJackGameController gameController;
    private List<Card> hand;
    private List<GameObject> cards;
    public int score;

    private void Awake()
    {
        hand = new List<Card>();
        cards = new List<GameObject>();

        gameController = board.GetComponent<BlackJackGameController>();
    }

    public void ReceiveCard(Card card)
    {
        hand.Add(card);
        UpdateCards();
    }

    public void TakeTurn()
    {
        while (GetScore() < 17)
        {
            hand.Add(gameController.Deal());
            UpdateCards();
        }
        GameOver();
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

    private void UpdateCards()
    {
        for (int i = cards.Count; i < hand.Count; i++)
        {
            cards.Add(Instantiate(card, new Vector3(xStartPosition + i, yPosition, 0), Quaternion.identity));
            cards[i].GetComponent<CardController>().SetCard(hand[i]);
        }
    }

    public void GameOver()
    {
        UpdateCards();
        UpdateScore();
        gameController.GameOver();
    }

    private void UpdateScore()
    {
        score = 0;
        foreach (Card card in hand)
        {
            score += (int)card.getValue();
        }
        scoreText.text = "Points: " + score;
        if (score > 21)
        {
            gameController.PlayerBust();
        }
    }

}
