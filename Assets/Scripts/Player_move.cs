using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private float _radiusChekedGroundCircle = 1f;
    [SerializeField] private float _limitSpeed = 10f;
    [SerializeField] private float _airFriction = 2f;
    

    public LayerMask GroundLayer = 6;

    private Rigidbody2D _rb;
    private CapsuleCollider2D _collider;


    private void Start()
    {
        //�������� ������ ����������
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        // ��������, ����� ��� ����� �� ��� �������� ���� Ground
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
    }


    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector2(_collider.bounds.center.x, _collider.bounds.min.y);
            //_radiusChekedGroundCircle - ������ �����
            // ������� ����� � ��������� ����������� � ��������� �� ���� Ground(6)
            return Physics2D.OverlapCircle(bottomCenterPoint, _radiusChekedGroundCircle, GroundLayer);

        }
    }
    
    //������ ��� ������������
    private Vector2 _movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            

            return new Vector2(horizontal, 0.0f);
        }
    }



    private void FixedUpdate()
    {
        //��������� ��� �� �����
        if (GetComponent<PlayerHealth>().GetAlive())
        {
            Move();
            Jump();
        }
        
        
    }

    private void Jump()

    {
        if (_isGrounded && Input.GetAxis("Jump") > 0)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        if (_isGrounded)
            _rb.drag = _airFriction;
        else
            _rb.drag = 0f;
        //������������ ��������
        if (_rb.velocity.x <= _limitSpeed && _rb.velocity.x >= - _limitSpeed)
        {
            _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);
        }
        else
        {
            //��������� �������. 
            //��������� �������� �������� ������� ��� �������, ��� ��� ��������� � ����� �������� ��������� � �������� �����������
            if (_rb.velocity.x > _limitSpeed && _movementVector.x < 0)
                _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);
            if (_rb.velocity.x < - _limitSpeed && _movementVector.x > 0)
                _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);

        }
    }

}
