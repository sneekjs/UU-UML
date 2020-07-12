using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public void MoveCardTo(Card movedCard, Collection targetLocation)
    {
        Debug.Log("Moved the card " + movedCard.name + " from " + name + " to " + targetLocation.name);
        cards.Remove(movedCard);
        targetLocation.cards.Add(movedCard);
    }

    public void MoveCardsTo(List<Card> movedCards, Collection targetLocation)
    {
        Debug.Log("Moved multiple cards from " + name + " to " + targetLocation.name);
        foreach (Card card in movedCards)
        {
            cards.Remove(card);
        }
        targetLocation.cards.AddRange(movedCards);
    }
}
