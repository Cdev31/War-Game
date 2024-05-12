using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhonMovement : MonoBehaviour
{
    public GameObject Bullet;
    public float JumpForce;
    public float Speed;
    private bool Grounded;
    private Animator animator;
    private Rigidbody2D RigidBody2D;
    private float Horizontal;
    private float LastShoot;
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if( Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if ( Horizontal > 0.0f ) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        animator.SetBool("Running", Horizontal != 0.0f);

        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded = true;
        }
        
        else Grounded = false;

        if( Input.GetKeyDown(KeyCode.UpArrow) && Grounded){
            Jump();
        }
        if( Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f){
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot(){

        Vector3 direction;
        if(transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(Bullet, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection( direction );
    }

    private void Jump(){
       RigidBody2D.velocity = Vector2.up * JumpForce;
    }
    private void FixedUpdate(){
        RigidBody2D.velocity = new Vector2(Horizontal, RigidBody2D.velocity.y);
    }
}
