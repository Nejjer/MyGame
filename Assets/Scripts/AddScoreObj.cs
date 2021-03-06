using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreObj : MonoBehaviour
{
    //Player has 2 collider, so we checked a first occurrence
    private bool _firstAdded = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerScore>(out PlayerScore _player) && _firstAdded)
        {
            _player.AddScore(1);

            Destroy(gameObject);
            _firstAdded = false;
        }
    }
}
