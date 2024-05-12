using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuntScript : MonoBehaviour
{
    private Rigidbody2D RidgidBody2D;
    public float speed;
    public float leftBound;
    public float rightBound;

    private int direction = 1;
    void Start()
    {
        RidgidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     float moveSpeed = speed * direction;

     RidgidBody2D.velocity = new Vector2(moveSpeed, RidgidBody2D.velocity.y);

     if( transform.position.x < leftBound ){
        
        direction = 1;
     } 
    else if ( transform.position.x > rightBound){
        
        direction = -1;
     }

     
    }
}
