using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    // A crutch so that OnTrigger does not process 2 times, because the player has two colliders
    private bool _firstEnter = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent(out PlayerHealth player) && _firstEnter)
        {
            Debug.Log("Try heal player");
            //heal player
            player.Heal(0.5f);
            //destroy obj
            Destroy(gameObject);
            // so that the second collider is not processed
            _firstEnter = false;
        }
    }

    


    
}
