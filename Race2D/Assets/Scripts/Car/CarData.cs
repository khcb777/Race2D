using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "CreateCarData")]
public class CarData : ScriptableObject
{
    public Car _carPref;

    [SerializeField] private string _carName;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _goldCost;
    


    [Header("Speed:")]
    [SerializeField] private int _speed;
    [SerializeField] private int _maxSpeed;
     [Header("Dumping ratio:")]
    [SerializeField] private int _dumpingRatio;
    [SerializeField] private int _maxDumpingRatio;
     [Header("Fuel:")]
    [SerializeField] private int _fuel;
    [SerializeField] private int _maxFuel;

    [Header("Wheel:")]
    [SerializeField] private float _wheel;
    [SerializeField] private float _maxWheel;

    [Header("Drive type:")] 
    [SerializeField] private CarDriveType _driveType;

    public int Fuel => _fuel;
    public int Speed => _speed;
    public float DumpingRatio => _dumpingRatio;
    public float Wheel => _wheel;

    public int DriveType => (int)_driveType;



    private bool isOpen;

    private void OnValidate()
    {
        Validate(ref _speed,ref _maxSpeed);
        Validate(ref _dumpingRatio,ref _maxDumpingRatio);
        Validate(ref _fuel, ref _maxFuel);
        Validate(ref _wheel, ref _maxWheel);
    }

    private void Validate( ref int cur, ref int max)
    {
        if(max < 0) max = 0;
        if(cur > max) cur = max;
        else if(cur < 0) cur = 0;
    }
    private void Validate( ref float cur, ref float max)
    {
        if(max < 0) max = 0;
        if(cur > max) cur = max;
        else if(cur < 0) cur = 0;
    }

}

