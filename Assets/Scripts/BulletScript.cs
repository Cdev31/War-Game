using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Vector2 Direction;
    private Rigidbody2D RigidBody2D;
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      RigidBody2D.velocity = Direction  * Speed;
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }
}
