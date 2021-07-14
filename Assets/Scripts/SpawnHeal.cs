using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeal : MonoBehaviour
{
    [SerializeField] GameObject _healObject;
    [SerializeField] float _timeBetweenSpawn;
    //�������, ����� ���������� ������ ���� ������
    private bool _firstObj = true;

    // Update is called once per frame
    void Update()
    {
        //��������� ������� ���������� ��������
        if (transform.childCount == 0 && _firstObj)
        {
            StartCoroutine("Spawn");
            //false, ����� ������ ������ �� ���������
            _firstObj = false;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_timeBetweenSpawn);
        //������� HEAL �� ����� �������� � ����� ������ �������� ���������
        Instantiate(_healObject, transform.position, Quaternion.identity, transform);
        //true, ����� ������ ��� ���������� �����
        _firstObj = true;
    }
}
