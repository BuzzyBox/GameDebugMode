using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTest1 : MonoBehaviour
{

    Rigidbody2D placeHolderRB;
    Collider2D pHCollider;
    [SerializeField]
    float pHSpeed;
    float pHJump = 5;

    void Start()
    {
        placeHolderRB = GetComponent<Rigidbody2D>();
        pHCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        float control = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector2 phVelocity = new Vector2(control * pHSpeed, placeHolderRB.velocity.y);
        placeHolderRB.velocity = phVelocity;

        Jumping();

    }

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

            //   bool touchGround = pHCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));
            // bool isTouchingGround = gnomeCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));
            //if (touchGround)
            //{


            // placeHolderRB.velocity = new Vector2(placeHolderRB.velocity.x, pHJump);
            //}

        }
    }
}
