using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject board;
    public Button hitButton;
    public Button stayButton;

    private BlackJackGameController gameController;
    private BlackJackGameController.Turn turn;
    private int result;

    List<Card> hand;

    private void Awake()
    {
        result = 0;
        hand = new List<Card>();
        gameController = board.GetComponent<BlackJackGameController>();
        turn = BlackJackGameController.Turn.Wait;
    }

    public void ReceiveCard(Card card)
    {
        hand.Add(card);
    }

    public void TakeTurn()
    {
        result = 0;
        if (turn != BlackJackGameController.Turn.Player)
        {
            ShowScore();
            turn = BlackJackGameController.Turn.Player;
            hitButton.enabled = true;
            stayButton.enabled = true;
        }
    }

    public void Hit() 
    {
        hand.Add(gameController.Deal());

        ShowScore();
    }

    public void Stay()
    {
        turn = BlackJackGameController.Turn.Wait;
        hitButton.enabled = false;
        stayButton.enabled = false;
        gameController.NextTurn("Dealer");
        ShowScore();
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


    private void Update()
    {
        
    }
}
