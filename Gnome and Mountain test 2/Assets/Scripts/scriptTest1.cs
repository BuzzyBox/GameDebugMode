using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTest1 : MonoBehaviour
{

    Rigidbody2D placeHolderRB;
    Collider2D pHCollider;
    Animator pHAnimtor;
    [SerializeField]
    float pHSpeed;
    float pHJump = 5;

    void Start()
    {
        placeHolderRB = GetComponent<Rigidbody2D>();
        pHCollider = GetComponent<Collider2D>();
        pHAnimtor = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Jumping();

    }

    private void Movement()
    {
        float control = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector2 phVelocity = new Vector2(control * pHSpeed, placeHolderRB.velocity.y);
        placeHolderRB.velocity = phVelocity; 

        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }


        //bool placeholderHorizontalMove = Mathf.Abs(placeHolderRB.velocity.y) > 0;

        //if(placeholderHorizontalMove)
        //{
        //    phAnimationChange(placeholderHorizontalMove);
        //}



    }

    //private void phAnimationChange(bool placeholderHorizontalMove)
    //{
    //    pHAnimtor.SetBool("CanWalk", placeholderHorizontalMove);
    //}

    private void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            bool touchGround = pHCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));
            if (touchGround)
            {

               
                Vector2 jumpVelocity = new Vector2(0, pHJump);
                placeHolderRB.velocity += jumpVelocity;

            }

        }
    }
}
