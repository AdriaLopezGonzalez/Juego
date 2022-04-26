using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputFisics : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    float _horizontal;
    float _vertical;

    public float Speed = 3;
    public float ForceSpeed = 1;

    public float MaxSpeed;

    [Range(0, 1)]
    public float Responsifness;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(_horizontal + " / " + _vertical);
    }

    void MoveWithVelocity()
    {
        Vector2 dir = new Vector2(_horizontal, -_vertical) * Speed;
        
        Vector2 targetVelocity = dir;

        _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, targetVelocity, Responsifness);
    }

    void MoveWithForce()
    {
        Vector2 dir = new Vector2(_horizontal, -_vertical) * ForceSpeed;
        _rigidbody.AddForce(dir);

        Vector2 vel = _rigidbody.velocity;
        Vector2 normVelocity = vel.normalized;

        float speed = Mathf.Min(vel.magnitude, MaxSpeed);

        _rigidbody.velocity = normVelocity * speed;
    }
    private void OnMove(InputValue inputValue)
    {
        _horizontal = inputValue.Get<Vector2>().x;
        _vertical = inputValue.Get<Vector2>().y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
