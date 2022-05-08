using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scriptTest1 : MonoBehaviour
{
    public static scriptTest1 instance;
    Rigidbody2D placeHolderRB;
    Collider2D pHCollider;
    Animator pHAnimtor;
    Items item;
    enterShop shopping;
   [HideInInspector] public float resetSpeed;
   [HideInInspector] public int life = 2;
    bool isAlive = true;
    // [SerializeField]
    // GameObject phBackpack;
    float control;
    [SerializeField]
    public float pHSpeed = 8000f;
    public float pHJump = 5f;
    [SerializeField]
    BuyTest1 upgrades1;
    SpikesAttack spikes;

    public int CoinCollected;


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        placeHolderRB = GetComponent<Rigidbody2D>();
        pHCollider = GetComponent<Collider2D>();
        pHAnimtor = GetComponent<Animator>();
        shopping = GetComponent<enterShop>();
        item = GetComponent<Items>();
        upgrades1 = GetComponent<BuyTest1>();
        spikes = GetComponent<SpikesAttack>();
        resetSpeed = pHSpeed;
    }

    void Update()
    {

        if(isAlive)
        {
            if (DialogueManager.GetInstance().dialogueIsPlaying)
         {
            placeHolderRB.velocity = Vector2.zero;
            return;
          }

          Movement();
          Jumping();

         


        }
       

    }

    private void Movement()
    {
        control = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector2 phVelocity = new Vector2(control * pHSpeed, placeHolderRB.velocity.y);
        placeHolderRB.velocity = phVelocity;

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


       


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {

            CoinCollected++;
            Destroy(collision.gameObject);
            Debug.Log("CoinCollected");

            if (CoinCollected > 0)
            {
              
                pHSpeed -= 1000;
                Debug.Log("Slowing down");
            }
            

     

            //if(CoinCollected - upgrade1.coins > 0)
            //{

            //    BuyTest1.Instance.coins++;
            //    Destroy(gameObject);

            //}



        }  

        if(collision.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("is Hurt");
            life--;
            
          //  Destroy(collision.gameObject);
            if(life < 0)
            {
                isAlive = false;
                gameObject.SetActive(false);
                
            }
            if(isAlive == false)
            {
                Scene reloadscene;
                reloadscene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(reloadscene.name);
            }


            if(collision.gameObject.CompareTag("MovingPlatform"))
            {
               pHSpeed = resetSpeed;
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

    public IEnumerator KnockBack(float knockBackDur, float knockBackPow, Vector3 knockbackDir)
    {
        float minustime = -1.3f;

        float timer = 0;
       
        while( knockBackDur > timer)
             {
            timer += Time.deltaTime;
            placeHolderRB.AddForce(new Vector3(knockbackDir.x * minustime, knockbackDir.y * knockBackPow, transform.position.z));
           // Vector2 dir = (obj.transform.position - this.transform.position).normalized;
            //placeHolderRB.AddForce(-dir * knockBackPow);
           // placeHolderRB.AddForce(new Vector3(dir.x * -100, dir.y * knockBackPow, transform.position.z));
             }
        
        yield return 0;

    }



    //private void FixedUpdate()
    //{
    //    placeHolderRB.velocity = new Vector2(control, 0).normalized * pHSpeed * Time.deltaTime;
    //}




}
