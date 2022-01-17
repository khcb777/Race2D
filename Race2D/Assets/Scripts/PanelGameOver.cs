using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameOver : MonoBehaviour
{
    [SerializeField] private Text _textDie;

    private Animator _anim;

    private void Start()
    {
        gameObject.SetActive(false);
        _anim = GetComponent<Animator>();
    }

    public void SetCar(Car car)
    {
        car.CarCrash += ShowForCrash;
        car.CarEmptyFuel += ShowForEmptyFuel;
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
        _anim.SetBool("isShow",true);
        _textDie.text = message;
    }
    
}
