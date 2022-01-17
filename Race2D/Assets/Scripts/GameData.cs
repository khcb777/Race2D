using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private CarData[] _carsData;
    [SerializeField] private CarData _carCurrent;

    public Car CarCurrent
    {
        get => _carCurrent._carPref;
    }
}

