using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
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
        One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
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
