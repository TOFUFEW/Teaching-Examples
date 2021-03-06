﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum Suit
    {
        Spade,
        Heart,
        Diamond,
        Club
    };

    public enum Value
    {
        Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack = 10, Queen = 10, King = 10
    };

    private Value value;
    private Suit suit;

    public Card(Suit suit, Value value)
    {
        this.suit = suit;
        this.value = value;

    }

    public Value getValue()
    {
        return value;
    }

    public Suit getSuit()
    {
        return suit;
    }
}
