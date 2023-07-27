using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReflection : MonoBehaviour
{
    [SerializeField] Vector3 velocity = new Vector3(0, 1, 0);
    [SerializeField] float ballSpeed = 5;
    public Transform originalObject;
    public Transform reflectedObject;

    void Start()
    {
        Debug.Log("Start");
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce(velocity, ForceMode.Impulse);
    }


    void Update()
    {
        transform.Translate(ballSpeed * Time.deltaTime * velocity, Space.World);
    }


    Vector3 newVelocity()
    {
        Vector3 newVector3;

        if (Mathf.Abs(Mathf.Atan(velocity.y / velocity.x)) < Mathf.PI / 6)
        {
            float newY = Mathf.Tan(Mathf.PI / 6);
            newVector3 = new Vector3(1, newY, 0).normalized;
            newVector3 *= velocity.magnitude;
            newVector3.x *= Mathf.Sign(velocity.x);
            newVector3.y *= Mathf.Sign(velocity.y);
        }
        else
        {
            newVector3 = velocity;
        }
        return newVector3;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        //originalObject.position = Vector3.Reflect(originalObject.position, Vector3.right);
    }
}
