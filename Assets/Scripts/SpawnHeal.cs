using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeal : MonoBehaviour
{
    [SerializeField] GameObject _healObject;
    [SerializeField] float _timeBetweenSpawn;
    //Костыль, чтобы спавнилсчя только один объект
    private bool _firstObj = true;

    // Update is called once per frame
    void Update()
    {
        //Проверяет наличие созданного оьбъекта
        if (transform.childCount == 0 && _firstObj)
        {
            StartCoroutine("Spawn");
            //false, чтобы объект больше не спавнился
            _firstObj = false;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_timeBetweenSpawn);
        //создаем HEAL на месте пустышки и сразу делаем пустышку родителем
        Instantiate(_healObject, transform.position, Quaternion.identity, transform);
        //true, чтобы объект мог спавниться внось
        _firstObj = true;
    }
}
