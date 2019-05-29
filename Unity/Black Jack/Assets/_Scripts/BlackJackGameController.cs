using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackGameController : MonoBehaviour
{
    public GameObject player;
    public GameObject dealer;

    private Dealer dealerScript;
    private Player playerScript;
    private Transform playerHandLocation;
    private Transform dealerHandLocation;

    private Turn turn;

    private Deck deck;

    public enum Turn
    {
        Start,
        Player,
        Dealer,
        Wait
    }

    void Start()
    {
        CreateDeck(false);

        dealerScript = dealer.GetComponent<Dealer>();
        playerScript = player.GetComponent<Player>();

        dealerHandLocation = dealer.GetComponent<Transform>();
        playerHandLocation = player.GetComponent<Transform>();
        turn = Turn.Start;
    }

    private void CreateDeck(bool jokers)
    {
        deck = new Deck(jokers);
        deck.Shuffle();
    }

    public Card Deal()
    {
        return deck.DrawCard();
    }


    private void Update()
    {
        if (turn == Turn.Start)
        {
            dealerScript.ReceiveCard(Deal());
            playerScript.ReceiveCard(Deal());
            dealerScript.ReceiveCard(Deal());
            playerScript.ReceiveCard(Deal());

            turn = Turn.Player;
        }
        else if (turn == Turn.Player)
        {
            playerScript.TakeTurn();
        }
        else if (turn == Turn.Dealer)
        {
            dealerScript.TakeTurn();
            Debug.Log(dealerScript.GetScore());
            Debug.Break();
        }
        else
        {
            GameOver();
        }
        
    }

    public void NextTurn(string turn)
    {
        this.turn = (Turn)System.Enum.Parse(typeof(Turn), turn);
    }

    public void PlayerBust()
    {

    }

    public void GameOver()
    {
    }
}
