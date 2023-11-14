using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfire : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Bullet;
    public float bullSpeed;
    public Animator panimation;
    public bool onceshot = false;
    float firerate = 0.5f;
    float nextfire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Mouse0)) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            var bull = Instantiate(Bullet, firepoint.position,firepoint.rotation);
            Rigidbody2D bulletrb = bull.GetComponent<Rigidbody2D>();
            bulletrb.AddForce(firepoint.right * bullSpeed);
            onceshot = true;
            panimation.SetBool("Shoot", true);
        }
        if (onceshot == false)
        {
            panimation.SetBool("Shoot", false);
        }
        if ((Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Mouse0)))
        {
            onceshot = false;
            //panimation.SetBool("Shoot", false);
        }
    }
}
