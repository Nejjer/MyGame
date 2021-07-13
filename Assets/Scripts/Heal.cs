using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    //�������, ����� OnTrigger �� ����������� 2 ����, ������ ��� �� ������ ��� �����������
    private bool _firstEnter = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��������� ����� �� ����� � ������
        if (collision.TryGetComponent(out PlayerHealth player) && _firstEnter)
        {
            Debug.Log("Try heal player");
            //����� ������
            player.Heal(0.5f);
            //���������� ����
            Destroy(gameObject);
            //����� ������ ��������� �� �����������
            _firstEnter = false;
        }
    }

    


    
}
