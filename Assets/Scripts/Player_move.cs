using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private float _radiusChekedGroundCircle = 1f;
    [SerializeField] private float _limitSpeed = 10f;
    [SerializeField] private float _airFriction = 2f;
    private Animator _animator;
    private float _speedBoost;
    private float _timeBoost;
    

    public LayerMask GroundLayer = 6;

    private Rigidbody2D _rb;
    private CapsuleCollider2D _collider;


    private void Start()
    {

        //получаем нужные компоненты
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        // Проверка, чтобы сам игрок не был назначен слою Ground
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
        //инициализируем аниматор
        _animator = GetComponent<Animator>();
    }


    



    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector2(_collider.bounds.center.x, _collider.bounds.min.y);
            //_radiusChekedGroundCircle - радиус сферы
            // создаем сферу и проверяем пересечение с объектами на слое Ground(6)
            return Physics2D.OverlapCircle(bottomCenterPoint, _radiusChekedGroundCircle, GroundLayer);

        }
    }
    
    //Вектор для пережвижения
    private Vector2 _movementVector
    {
        get
        {

            var horizontal = Input.GetAxis("Horizontal");

            //проверяем наличие аниматора
            if (_animator) {
                //запускаем анимацию бега, при вводе о движении

                _animator.SetBool("run", horizontal != 0);
            }
            //зеркалим игрока
            if (horizontal < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (horizontal > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;

            }
            return new Vector2(horizontal, 0.0f);
        }
    }



    private void FixedUpdate()
    {
        
        //Проверяет жив ли игрок
        if (GetComponent<PlayerHealth>().GetAlive())
        {
            Move();
            Jump();
        }
        
        //Проверяем надичие аниматора
        if (_animator)
        {
            //анимируем прыжок и падение, которые зависят от горизонтальной скорости
            _animator.SetBool("jump", _rb.velocity.y > 0.1f);
            _animator.SetBool("fall", _rb.velocity.y < -0.1f);

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
        //ограничиваем скорость
        if (_rb.velocity.x <= _limitSpeed && _rb.velocity.x >= - _limitSpeed)
        {
            _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);
        }
        else
        {
            //Небольшой костыль. 
            //Позволяет изменять скорость объекта при условии, что она превышена и игрок пытается двигаться в обратной направлении
            if (_rb.velocity.x > _limitSpeed && _movementVector.x < 0)
                _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);
            if (_rb.velocity.x < - _limitSpeed && _movementVector.x > 0)
                _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);

        }
    }



    public void BoostSpeed(float _size, float _time)
    {
        _speedBoost = _size;
        _timeBoost = _time;
        _speed += _speedBoost;
        
        StartCoroutine("Boost");
    }

    IEnumerator Boost()
    {
        yield return new WaitForSeconds(_timeBoost);
        _speed -= _speedBoost;
    }
}
