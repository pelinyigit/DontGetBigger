using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        offSet = (transform.position - target.position);
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z) + offSet, Time.deltaTime * 3);
    }
}
