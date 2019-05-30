using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardController : MonoBehaviour
{
    private Card card;
    private GameObject suit;
    private GameObject value;
    private string imgPath;

    public void SetCard(Card card)
    {
        imgPath = "Images/";
        suit = transform.GetChild(0).gameObject;
        value = transform.GetChild(1).gameObject;
        
        this.card = card;

        Sprite suitSprite = Resources.Load<Sprite>(imgPath + card.getSuit().ToString());
        Sprite valueSprite = Resources.Load<Sprite>(imgPath + card.getValue().ToString());
    
        suit.GetComponent<SpriteRenderer>().sprite = suitSprite;
        value.GetComponent<SpriteRenderer>().sprite = valueSprite;
    }

}
