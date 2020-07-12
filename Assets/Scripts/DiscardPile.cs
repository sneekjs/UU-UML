using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : Collection
{
    public List<Card> GetDiscardPile()
    {
        return cards;
    }

    public void ClearPile()
    {
        Debug.Log("The discard pile was cleared");
        cards.Clear();
    }
}
