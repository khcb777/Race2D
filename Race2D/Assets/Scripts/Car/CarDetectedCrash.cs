using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetectedCrash : MonoBehaviour
{
    [SerializeField] private Car _car;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ground")
        {
            _car.OnCarCrash();
        }
    }
}
