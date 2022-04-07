using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField]
    Transform PlaceHolder;

    float cameraSmooth = 5f;


    [SerializeField]
    Vector3 cameraOffset;



    void Start()
    {

        cameraOffset = new Vector3(0.00f, 2.31f, -10f);



    }

    void Update()
    {
        Vector3 targetPosition = PlaceHolder.position + cameraOffset;
        Vector3 smoothVector = Vector3.Lerp(transform.position, targetPosition, cameraSmooth * Time.deltaTime);
        transform.position = smoothVector;


    }
}
