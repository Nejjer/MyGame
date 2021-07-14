using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] float _sizeBoost = 1f;
    [SerializeField] float _timeBoost = 5f;
    [SerializeField] float _deathTime = 1.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player_move _player))
        {
            _player.BoostSpeed(_sizeBoost, _timeBoost);
            Destroy(gameObject);
        }
        //Если столкнулся с землей/платформой
        else if(collision.gameObject.layer == 6)
        {
            StartCoroutine("Death");
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }


    
}
