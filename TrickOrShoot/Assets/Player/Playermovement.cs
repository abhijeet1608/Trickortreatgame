using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float rotatepumpkin = 100;
    public GameObject playerdeathanim;

    public void Start()
    {

    }


    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.right * Time.deltaTime * -moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotatepumpkin * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,  0, -rotatepumpkin * Time.deltaTime);
        }


        
    }
}
