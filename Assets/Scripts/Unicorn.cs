using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Unicorn : Card
{
    public enum Race { Default, Basic, Baby, Panda, Lama};
    public Race thisRace;
}
