using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private int _count;

    public int Count
    {
        get
        {
            return _count;
        }
        set
        {
            if(value >= 0)
            {
                _count = value;
            }
        }
    }
}
