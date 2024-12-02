using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animation1;
    private float directionx=0f;
    private SpriteRenderer sprite1;
    private float movevelocity = 8f;
    private float jumpvelocity = 12f;
    private enum movements {idle,running,jumping,falling};
    private BoxCollider2D collider1;
    [SerializeField] private LayerMask groundcheck2;
    [SerializeField] private AudioSource jumpSound;





    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animation1 = GetComponent<Animator>();
        sprite1 = GetComponent<SpriteRenderer>();
        collider1 = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionx = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(directionx * movevelocity, rigid.velocity.y);
        
        if (Input.GetButtonDown("Vertical") && (groundcheck())){
            rigid.velocity = new Vector3(rigid.velocity.x,jumpvelocity);
            jumpSound.Play();
        }

        UpdateAnimation();
    }

    private void UpdateAnimation(){
        movements state;

        if (directionx>0f){
            state = movements.running;
            sprite1.flipX=false;
        }
        else if (directionx<0f){
            state = movements.running;
            sprite1.flipX=true;
        } 
        else{
            state = movements.idle;
        }

        if (rigid.velocity.y>0.1f){
            state = movements.jumping;
        }
        else if (rigid.velocity.y<-0.1f){
            state = movements.falling;
        }
        animation1.SetInteger("state", (int)state);

    }

    private bool groundcheck(){
        return Physics2D.BoxCast(collider1.bounds.center, collider1.bounds.size, 0f, Vector2.down, .1f, groundcheck2);
    }
}
