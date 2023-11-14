using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batsfollow : MonoBehaviour
{
    public Transform player;
    public Animator playeranim;

    public PlayerHp hpplayer;
    public CameraShake cameraShake;

    public float StopDist;
    public float RetreatDist;

    public float speed;
    public bool follow = true;
    public int time = 1000000000;

    public GameObject collplayeranim;
    public GameObject collbulletanim;
    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playeranim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        hpplayer = GameObject.FindGameObjectWithTag("PlayerHp").GetComponent<PlayerHp>();
        StartCoroutine(Pausefollow());
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hpplayer = GameObject.FindGameObjectWithTag("PlayerHp").GetComponent<PlayerHp>();

        if (Vector2.Distance(transform.position, player.position) > StopDist && follow == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //else if (Vector2.Distance(transform.position, player.position) < StopDist && Vector2.Distance(transform.position, player.position) > RetreatDist && follow == true)
        //{
        //    transform.position = this.transform.position;
        //}
        //else if (Vector2.Distance(transform.position, player.position) < RetreatDist && follow == true)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hpplayer.PlayerTakeDamage(10);
            Instantiate(collplayeranim, transform.position, transform.rotation);
            StartCoroutine(cameraShake.Shake(.2f, .4f));
            playeranim.SetTrigger("damaged");
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("CandyBullet"))
        {
            //Singleton Used
            Instantiate(collbulletanim, transform.position, transform.rotation);
            Destroy(this.gameObject);
            playerscore.instance.AddScore();
        }
    }
    IEnumerator Pausefollow()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(2);
            follow = false;
            yield return new WaitForSeconds(0.5f);
            follow = true;
        }

    }
}
