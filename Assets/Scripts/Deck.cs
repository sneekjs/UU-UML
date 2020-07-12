using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : Collection
{
    public List<Card> Shuffle()
    {
        Debug.Log("The deck is shuffled");
        List<Card> newDeck = cards;
        newDeck = newDeck.OrderBy(x => Random.value).ToList();
        return newDeck;
    }

    public List<Card> LookForType(Card cardType)
    {
        Debug.Log("Looking through the deck for a " + cardType + " card");
        List<Card> allOfType = new List<Card>();
        foreach (Card card in cards)
        {
            if (card.GetType() == cardType.GetType())
            {
                allOfType.Add(card);
            }
        }
        return allOfType;
    }
}
