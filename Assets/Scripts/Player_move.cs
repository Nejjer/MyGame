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

        //Get components
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();

        // Checking that the player himself is not assigned to the Ground layer
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
        
    }


    



    private bool _isGrounded
    {
        get
        {
            //created Vector eitn coordinate down center capsule collider
            var bottomCenterPoint = new Vector2(_collider.bounds.center.x, _collider.bounds.min.y);
            //_radiusChekedGroundCircle - radius sphere
            //create sphere and check crossing with objects in layer Groung(6)
            return Physics2D.OverlapCircle(bottomCenterPoint, _radiusChekedGroundCircle, GroundLayer);

        }
    }
    
    //Vector for movement
    private Vector2 _movementVector
    {
        get
        {

            var horizontal = Input.GetAxis("Horizontal");

            //checking the presence of an animator
            if (_animator) {
                // start running animation, when entering about movement

                _animator.SetBool("run", horizontal != 0);
            }
            //mirror player sprite
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

        // Checks if the player is alive
        if (GetComponent<PlayerHealth>().GetAlive())
        {
            Move();
            Jump();
        }

        //checking the presence of an animator
        if (_animator)
        {
            // animate the jump and fall, which depend on the horizontal speed
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
        // limit the speed
        if (_rb.velocity.x <= _limitSpeed && _rb.velocity.x >= - _limitSpeed)
        {
            _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);
        }
        else
        {
            // A little crutch.
            // Allows you to change the speed of the object, provided that it is exceeded and the player tries to move in the opposite direction
            if (_rb.velocity.x > _limitSpeed && _movementVector.x < 0)
                _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);
            if (_rb.velocity.x < - _limitSpeed && _movementVector.x > 0)
                _rb.AddForce(_movementVector * _speed, ForceMode2D.Impulse);

        }
    }



    public void BoostSpeed(float _size, float _time)  //Boost player
    {
        _speedBoost = _size;
        _timeBoost = _time;
        _speed += _speedBoost;
        
        StartCoroutine("Boost");
    }

    IEnumerator Boost()
    {
        yield return new WaitForSeconds(_timeBoost);
        //stoped boost
        _speed -= _speedBoost;
    }
}
