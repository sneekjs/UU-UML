using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Collection
{
    private int limit;

    public List<Card> GetHand()
    {
        return cards;
    }

    public int GetLimit()
    {
        return limit;
    }

    public int SetLimit(int newLimit)
    {
        limit = newLimit;
        return newLimit;
    }

    private void Start()
    {
        Debug.Log("Create starting hand");
        SetLimit(7);
        List<Card> startingHand = new List<Card>();

        for (int i = 0; i < 5; i++)
        {
            Card startingCard = new Card();
            int cardIndex = Random.Range(0, 999);
            startingCard.name = "Starting card " + cardIndex.ToString();
            startingCard.description = "This is starting card no. " + cardIndex.ToString();

            startingHand.Add(startingCard);
        }
        cards.AddRange(startingHand);
    }

    public void EmptyToLimit()
    {
        if (cards.Count > GetLimit())
        {
            Debug.Log("Discard a card because hand is too full");
            MoveCardTo(cards[Random.Range(0, cards.Count)], GameManager.Instance.discardPile);
        }
        if (cards.Count > GetLimit())
        {
            EmptyToLimit();
        }
    }
}
