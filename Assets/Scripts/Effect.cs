using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : Card
{
    private MagicalEffect magicalEffect;
    private enum EffectType { instant, turnbased, reaction};
    private EffectType triggerTime;

    public void Trigger()
    {
        magicalEffect.TriggerEffect();
    }
}
