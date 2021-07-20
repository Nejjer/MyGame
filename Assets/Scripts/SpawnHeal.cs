using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeal : MonoBehaviour
{
    [SerializeField] GameObject _healObject;
    [SerializeField] float _timeBetweenSpawn;
    // A crutch to spawn only one object
    private bool _firstObj = true;

    void Update()
    {
        // Checks for the existence of an object
        if (transform.childCount == 0 && _firstObj)
        {
            StartCoroutine("Spawn");
            //false, so that the object does not spawn anymore
            _firstObj = false;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_timeBetweenSpawn);
        //создаем HEAL на месте пустышки и сразу делаем пустышку родителем
        // create a HEAL in place of the EmptyObj and immediately make the EmptyObj parent
        Instantiate(_healObject, transform.position, Quaternion.identity, transform);
        //true, so that the object can spawn again
        _firstObj = true;
    }
}
