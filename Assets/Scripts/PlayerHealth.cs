using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject _healthBar;
    private float _health = 1f;
    private bool _alive;
    private Animator _animator;

    private void Start()
    {
        _alive = true;
        _animator = GetComponent<Animator>();
    }



    public void Damage(float dm)
    {
        if (dm > 0)
            _health -= dm;
        else
            Debug.Log("Error damage(PlayerHealth)");
    }

    public void Heal(float heal)
    {
        if (heal > 0)
            _health += heal;
        else
            Debug.Log("Error heal (PlayerHealth)");
    }

    public float GetHealth()
    {
        return _health;
    }

    public bool GetAlive()
    {
        return _alive;
    }





    void Update()
    {

        //Смерть игрока
        if (_health <= 0)
        {
            _alive = false;
            _animator.SetBool("hit", true);
        }
        else
            _alive = true;
        _healthBar.GetComponent<Image>().fillAmount = _health;

        //Чтобы здоровье не превышало единицу
        if (_health > 1)
        {
            _health = 1f;
        }
    }


    
}
    
