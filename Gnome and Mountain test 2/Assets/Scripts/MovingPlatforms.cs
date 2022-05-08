using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    scriptTest1 playermovement;

    //public List<Transform> platformPoints;
    //public Transform platformTransform;
    //int goalPoint = 0;
    //public float platformSpeed = 2;


    [SerializeField] public float platformSpeed;
    [SerializeField] public int startingpoint;
    [SerializeField]
    public Transform[] platformPoints;

    public float playerspeed;
    int iArry;
    float platformDistance = 0.02f;

    void Start()
    {
        transform.position = platformPoints[startingpoint].position;
        playermovement = GetComponent<scriptTest1>();
    }

    void Update()
    {
        //playerspeed = playermovement.resetSpeed;

        if (Vector2.Distance(transform.position, platformPoints[iArry].position) < platformDistance)
        {
            iArry++;

            if (iArry == platformPoints.Length)
            {
                iArry = 0;
            }

        }

        transform.position = Vector2.MoveTowards(transform.position, platformPoints[iArry].position, platformSpeed * Time.deltaTime);

        //platformMovement();

    }

    //void platformMovement()
    //{
    //    platformTransform.position = Vector2.MoveTowards(platformTransform.position, platformPoints[goalPoint].position, Time.deltaTime * platformSpeed);

    //    if (Vector2.Distance(platformTransform.position, platformPoints[goalPoint].position) < 0.1f)
    //    {
    //        if (goalPoint == platformPoints.Count - 1)
    //        {
    //            goalPoint = 0;
    //        }
    //        else
    //        {
    //            goalPoint++;
    //        }
    //    }

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            collision.transform.SetParent(transform);
       
        //  collision.transform.SetParent(transform);  

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
            collision.transform.SetParent(null);
        
    }



}

