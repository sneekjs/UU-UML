using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magical : Unicorn
{
    public bool hasStartOfTurnEffect;
    private MagicalEffect magicalEffect;

    public void TriggerEffect()
    {
        Debug.Log("Magical effect was triggered");
        magicalEffect.TriggerEffect();
    }
}
