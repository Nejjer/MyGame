using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] float _damage = 0.2f;
    [SerializeField] float _deathTime = 1.5f;
    private void Start()
    {
        //Смещаем центр масс
        gameObject.GetComponent<Rigidbody2D>().centerOfMass = new Vector2(0.1f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth _player))
        {
            _player.Damage(_damage);
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
