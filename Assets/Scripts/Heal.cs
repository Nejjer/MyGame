using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    //Костыль, чтобы OnTrigger не обрабатывал 2 раза, потому что на игроке два колладйдера
    private bool _firstEnter = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //проверяем игрок ли зашел в тригер
        if (collision.TryGetComponent(out PlayerHealth player) && _firstEnter)
        {
            Debug.Log("Try heal player");
            //лечим игрока
            player.Heal(0.5f);
            //уничтожаем хилл
            Destroy(gameObject);
            //чтобы второй коллайдер не обработался
            _firstEnter = false;
        }
    }

    


    
}
