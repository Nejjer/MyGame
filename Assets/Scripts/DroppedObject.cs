using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObject : MonoBehaviour
{
    private float _timeSpawn;
    private GameObject _objSpawn;
    private Vector2 _spawnPos;

    //Метод устанавливающий необходимые для спавна параметры(позицию, объект, время)
    public void SpawnObject(GameObject _obj, float _timeBetweenSpawn)
    {
        //Устанавливаем время между спавном в сек
        _timeSpawn = _timeBetweenSpawn;
        //Устанавливаем объект спавна
        _objSpawn = _obj;
        //Устанавливаем случайные координаты спавна объекта
        float _posX = Random.Range(-9.5f, 9.5f);
        float _posY = 7f;
        _spawnPos = new Vector2(_posX, _posY);


        StartCoroutine("Spawn");

    }
    /*
    // перегрузка метода для получения координат спавна
    public void SpawnObject(GameObject _obj, float _timeBetweenSpawn, Vector2 _pos)
    {
        //Устанавливаем время между спавном в сек
        _timeSpawn = _timeBetweenSpawn;
        //Устанавливаем объект спавна
        _objSpawn = _obj;
        //Устанавливаем полученные координаты спавна объекта
        _spawnPos = _pos;
        StartCoroutine("Spawn");
    }

    */

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_timeSpawn);
        Instantiate(_objSpawn, _spawnPos, Quaternion.identity);
    }
}
