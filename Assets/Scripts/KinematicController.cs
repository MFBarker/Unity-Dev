using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField, Range(0,40)] float speed = 1f;
    [SerializeField] float maxDistance = 5;
    [SerializeField,Range(1,180)] float rotateAngle = 20;
    [SerializeField,Range(1,40)] float rotateSpeed = 5;


    // Update is called once per frame
    void Update()
    {

        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;
        transform.localPosition += force;

        transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);
        Quaternion qYaw = Quaternion.AngleAxis(direction.x * rotateAngle, Vector3.up);
        Quaternion qPitch = Quaternion.AngleAxis(-direction.y * rotateAngle, Vector3.right);
        
        Quaternion rotation = qYaw * qPitch;
        transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
