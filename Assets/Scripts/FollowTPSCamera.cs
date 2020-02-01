using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTPSCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
       
       
        transform.LookAt(target.transform);
        //target.transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, 0));
    }
}
