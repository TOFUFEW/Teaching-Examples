using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject board;
    public Button hitButton;
    public Button stayButton;
    public GameObject card;
    public Text scoreText;

    private BlackJackGameController gameController;
    private BlackJackGameController.Turn turn;
    public int score;

    private static float yPosition = (float)-2.65;
    private static float xStartPosition = -1;

    List<Card> hand;
    List<GameObject> cards;

    private void Awake()
    {
        score = 0;
        hand = new List<Card>();
        cards = new List<GameObject>();

        gameController = board.GetComponent<BlackJackGameController>();
        turn = BlackJackGameController.Turn.Wait;
    }

    public void ReceiveCard(Card card)
    {
        hand.Add(card);
        UpdateCards();
        UpdateScore();
    }

    public void TakeTurn()
    {
        if (turn != BlackJackGameController.Turn.Player)
        {
            turn = BlackJackGameController.Turn.Player;
            hitButton.enabled = true;
            stayButton.enabled = true;
        }
    }

    public void Hit()
    {
        hand.Add(gameController.Deal());

        UpdateCards();
        UpdateScore();
    }

    public void Stay()
    {
        turn = BlackJackGameController.Turn.Wait;
        hitButton.enabled = false;
        stayButton.enabled = false;
        gameController.NextTurn("Dealer");
    }

    private void UpdateScore()
    {
        score = 0;
        bool hasAce = false;
        foreach (Card card in hand)
        {
            if (card.getValue() == Card.Value.Ace)
            {
                hasAce = true;
                if (score + 11 < 21)
                {
                    score += 11;
                } else
                {
                    score += (int)card.getValue();
                }
            }
            else
            {
                score += (int)card.getValue();
            }
        }
        scoreText.text = "Points: " + score;
        if (score > 21)
        {
            gameController.PlayerBust();
        }
    }

    public void ShowScore()
    {
        int score = 0;
        Debug.Log("Current Cards:");
        foreach (Card card in hand)
        {
            Debug.Log(card.getValue().ToString() + " of " + card.getSuit().ToString());
            score += (int)card.getValue();
        }
        Debug.Log("Score: " + score);
    }

    private void UpdateCards()
    {
        for (int i = cards.Count; i < hand.Count; i++)
        {
            cards.Add(Instantiate(card, new Vector3(xStartPosition + i, yPosition, 0), Quaternion.identity));
            cards[i].GetComponent<CardController>().SetCard(hand[i]);
        }
    }
}
