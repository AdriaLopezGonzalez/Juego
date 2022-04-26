using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forces : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AddForceToPlayer();
    }

    void AddForceToPlayer()
    {
        Vector2 dir = Player.position - transform.position;
        var magnitud = dir.magnitude;
        dir = dir.normalized;
        dir *= magnitud;
        // _rigidbody.AddForce(dir);
        _rigidbody.velocity = dir;
    }
}
