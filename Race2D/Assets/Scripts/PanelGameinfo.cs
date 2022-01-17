using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameinfo : MonoBehaviour
{
    [SerializeField] private Text _coinsCountText;
    [SerializeField] private Coins _coins;

    public void SetCar(Car car)
    {
        car.AddCoin += UpdateInfo;
    }

    private void UpdateInfo()
    {
        _coins.Count ++;
        _coinsCountText.text = $"Coins: {_coins.Count}";
    }

    
}
