using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stable : Collection
{
    private void Start()
    {
        Unicorn starter = new Unicorn();
        starter.name = "Baby starter";
        starter.description = "A useless little unicorn to get you started";
        starter.thisRace = Unicorn.Race.Baby;
        cards.Add(starter);
    }

    public List<Card> GetStable()
    {
        return cards;
    }

    public void TriggerStartupEffect()
    {
        Debug.Log("Start-up effect trigger");
        foreach (Card unicorn in cards)
        {
            if (unicorn is Magical magicalUnicorn)
            {
                if (magicalUnicorn.hasStartOfTurnEffect)
                {
                    magicalUnicorn.TriggerEffect();
                }
            }
        }
    }
}
