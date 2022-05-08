using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAttack : MonoBehaviour
{

    scriptTest1 playerSpikes;

    public float knockBackPow = 1f;
    public float knockBackDur = 3f;


    void Start()
    {      
        playerSpikes = GameObject.FindGameObjectWithTag("Player").GetComponent<scriptTest1>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit!");
            StartCoroutine(playerSpikes.KnockBack(knockBackPow, knockBackDur, playerSpikes.transform.position));    
            //StartCoroutine(scriptTest1.instance.knockBack(knockBackDur, knockBackPow, this.transform));
        }
        
    }


}
