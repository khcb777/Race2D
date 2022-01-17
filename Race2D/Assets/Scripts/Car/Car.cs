using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CarMovement))]
public class Car : MonoBehaviour
{
    [SerializeField] private CarData _carData;

    private int _fuelCurrent;

    public event UnityAction CarCrash;
    public event UnityAction CarEmptyFuel;
    public event UnityAction AddCoin;

    
    public int Fuel 
    { 
        get => _fuelCurrent; 
        set
        {
            if(value >= 0 && value <= _carData.Fuel)
            {
                _fuelCurrent = value;
            }
            else if(value >= _carData.Fuel) _fuelCurrent = _carData.Fuel;
            else
            {
                _fuelCurrent = 0;
                OnCarEmptyFuel();
            }
        }
    }
    public int Speed 
    { 
        get => _carData.Speed; 
    }
    public float Wheel
    {
        get => _carData.Wheel;
    }
    public float Dumping
    {
        get => _carData.DumpingRatio;
    }
    public int DriveType
    {
        get => _carData.DriveType;
    }
    public bool IsCrash { get => isCrash; set => isCrash = value; }

    private bool isCrash;

    private void Start()
    {
        IsCrash = false;
        Fuel = _carData.Fuel;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent(out Coin coin))
        {
            OnCoinAdd();
            Destroy(coin.gameObject);
        }
    }
    
    public void OnCoinAdd()
    {
        AddCoin?.Invoke();
    }

    public void OnCarCrash()
    {
        CarCrash?.Invoke();
        IsCrash = true;
    }

    public void OnCarEmptyFuel()
    {
        CarEmptyFuel?.Invoke();
    }
}
