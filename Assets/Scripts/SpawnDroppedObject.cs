using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDroppedObject : MonoBehaviour
{
    [SerializeField] GameObject _boost;
    [SerializeField] float _timeBetweenSpawnBoost = 5f;
    [SerializeField] GameObject _saw;
    [SerializeField] float _timeBetweenSpawnSaw = 5f;


    private Vector2 _spawnPos;







    private void Start()
    {
        //����� BOOST
        StartCoroutine("SpawnBoost");

        StartCoroutine("SpawnSaw");

    }

    /*
    //����� ��������������� ����������� ��� ������ ���������(�������, ������, �����)
    public void SpawnObject(GameObject _obj, float _timeBetweenSpawn)
    {
        //������������� ����� ����� ������� � ���
        _timeSpawn = _timeBetweenSpawn;
        //������������� ������ ������
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
    IEnumerator SpawnSaw()
    {

        yield return new WaitForSeconds(_timeBetweenSpawnSaw);
        //������� ��������� ���������� ������
        _spawnPos = new Vector2(Random.Range(-9.5f, 9.5f), 7f);

        Instantiate(_saw, _spawnPos, Quaternion.identity);
        RestartCouritineSaw();
    }

    IEnumerator SpawnBoost()
    {

        yield return new WaitForSeconds(_timeBetweenSpawnBoost);
        //������� ��������� ���������� ������
        _spawnPos = new Vector2(Random.Range(-9.5f, 9.5f), 7f);

        Instantiate(_boost, _spawnPos, Quaternion.identity);
        RestartCouritineBoost();
    }
}