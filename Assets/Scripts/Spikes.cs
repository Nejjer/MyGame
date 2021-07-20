using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private bool _firstAdded = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth _player) && _firstAdded)
        {
            //Kill player
            _player.Damage(1.5f);
            _firstAdded = false;
        }
        
    }
    
}
