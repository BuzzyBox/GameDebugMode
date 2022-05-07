using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTest1 : MonoBehaviour
{

    Rigidbody2D placeHolderRB;
    Collider2D pHCollider;
    Animator pHAnimtor;
    Items item;
    enterShop shopping;
   // [SerializeField]
   // GameObject phBackpack;
    [SerializeField]
    float pHSpeed;
    float pHJump = 5;

    [HideInInspector] public int CoinCollected = 0;


    void Start()
    {
        placeHolderRB = GetComponent<Rigidbody2D>();
        pHCollider = GetComponent<Collider2D>();
        pHAnimtor = GetComponent<Animator>(); 
        shopping = GetComponent<enterShop>();
        item = GetComponent<Items>();
    }

    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            placeHolderRB.velocity = Vector2.zero;
            return;
        }


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

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            CoinCollected++;
            Destroy(collision.gameObject);
            Debug.Log("CoinCollected");

            if(CoinCollected > 0)
            {
                pHSpeed -= 1000;
                Debug.Log("Slowing down");
            }
            
                
            

        }
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

        }
    }
}
