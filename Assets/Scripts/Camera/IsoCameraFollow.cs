using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCameraFollow : MonoBehaviour {

    public Transform target; //player
    public float smoothing = 5f;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;

   
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
