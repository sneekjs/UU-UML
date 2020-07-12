using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand hand;
    public Stable stable;
    
    public Stable GetStable()
    {
        return stable;
    }
}
