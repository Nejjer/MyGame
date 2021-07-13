using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObject : MonoBehaviour
{
    private float _timeSpawn;
    private GameObject _objSpawn;
    private Vector2 _spawnPos;

    //����� ��������������� ����������� ��� ������ ���������(�������, ������, �����)
    public void SpawnObject(GameObject _obj, float _timeBetweenSpawn)
    {
        //������������� ����� ����� ������� � ���
        _timeSpawn = _timeBetweenSpawn;
        //������������� ������ ������
        _objSpawn = _obj;
        //������������� ��������� ���������� ������ �������
        float _posX = Random.Range(-9.5f, 9.5f);
        float _posY = 7f;
        _spawnPos = new Vector2(_posX, _posY);


        StartCoroutine("Spawn");

    }
    /*
    // ���������� ������ ��� ��������� ��������� ������
    public void SpawnObject(GameObject _obj, float _timeBetweenSpawn, Vector2 _pos)
    {
        //������������� ����� ����� ������� � ���
        _timeSpawn = _timeBetweenSpawn;
        //������������� ������ ������
        _objSpawn = _obj;
        //������������� ���������� ���������� ������ �������
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
