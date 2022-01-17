using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInstantiate : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private PanelGameinfo _panelGameInfo;
    [SerializeField] private PanelGameOver _panelGameOver;

    private Car _car;

    private void Start()
    {
        _car = Instantiate(_gameData.CarCurrent,transform.position,Quaternion.identity);
        _panelGameInfo.SetCar(_car);
        _panelGameOver.SetCar(_car);
    }


}
