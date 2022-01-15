using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame : MonoBehaviour
{
    [SerializeField] private Text _textDie;
    [SerializeField] private CarMovement _carMovement;
    [SerializeField] private float _pauseForShow;

    private void Start()
    {
        _carMovement.CrashAction += ShowForCrash;
        _carMovement.FuelEmptyAction += ShowForEmptyFuel;
        gameObject.SetActive(false);
    }



    private void ShowForCrash()
    {
        Show("Вы разбились!");
    }

    private void ShowForEmptyFuel()
    {
        Show("У выс закончилось торливо");
    }

    private void Show(string message)
    {
        gameObject.SetActive(true);
        _textDie.text = message;
    }
    
}
