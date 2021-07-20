using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDroppedObject : MonoBehaviour
{

    //CHECK README

    [SerializeField] GameObject _boost;
    [SerializeField] float _timeBetweenSpawnBoost = 5f;
    [SerializeField] GameObject _saw;
    [SerializeField] float _timeBetweenSpawnSaw = 5f;
    [SerializeField] GameObject _addScore;
    [SerializeField] float _timeBetweenSpawnAddScore = 5f;


    private Vector2 _spawnPos;







    private void Start()
    {
        //Спавн BOOST
        StartCoroutine("SpawnBoost");

        StartCoroutine("SpawnSaw");

        StartCoroutine("SpawnAddScore");


    }

    /*
    //Метод устанавливающий необходимые для спавна параметры(позицию, объект, время)
    public void SpawnObject(GameObject _obj, float _timeBetweenSpawn)
    {
        //Устанавливаем время между спавном в сек
        _timeSpawn = _timeBetweenSpawn;
        //Устанавливаем объект спавна
        _objSpawn = _obj;


        StartCoroutine("Spawn");

    }
    */

    private void RestartCouritineSaw()
    {
        StartCoroutine("SpawnSaw");
    }
    private void RestartCouritineBoost()
    {
        StartCoroutine("SpawnBoost");
    }
    private void RestartCouritineAddScore()
    {
        StartCoroutine("SpawnAddScore");
    }

    IEnumerator SpawnSaw()
    {

        yield return new WaitForSeconds(_timeBetweenSpawnSaw);
        //Создаем случайные координаты спавна
        _spawnPos = new Vector2(Random.Range(-9.5f, 9.5f), 7f);

        Instantiate(_saw, _spawnPos, Quaternion.identity);
        RestartCouritineSaw();
    }

    IEnumerator SpawnBoost()
    {

        yield return new WaitForSeconds(_timeBetweenSpawnBoost);
        //Создаем случайные координаты спавна
        _spawnPos = new Vector2(Random.Range(-9.5f, 9.5f), 7f);

        Instantiate(_boost, _spawnPos, Quaternion.identity);
        RestartCouritineBoost();
    }


    IEnumerator SpawnAddScore()
    {

        yield return new WaitForSeconds(_timeBetweenSpawnAddScore);
        //Создаем случайные координаты спавна
        _spawnPos = new Vector2(Random.Range(-9.5f, 9.5f), 7f);

        Instantiate(_addScore, _spawnPos, Quaternion.identity);
        RestartCouritineAddScore();
    }

}