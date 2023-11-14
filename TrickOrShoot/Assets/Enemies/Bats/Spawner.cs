using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum SpawnState { 
        Spawning, 
        Counting, 
        Finished
    };
    //[System.Serializable]
    //public class Wave
    //{
        public string wavename;
        public GameObject enemy;
        public int enemyCounter = 0;
        public float spawnrate;
    //}
    // coded now
    public PlayerHp playercurrhp;
    public float timeBtwSpawns;
    public float startTBS;
    public bool anyKeyPressed = false;

    //not coded now
    //public Wave waves;
    public int nxtWave = 0;
    public int timebetweenwaves = 5;
    public int changingtype;
    public float wavecountdown;
    public float searchcounter = 1f;
    public SpawnState state = SpawnState.Counting;

    public bool firstenemy;
    public bool firstboss;

    public Transform[] spawnpos;

    //public GameObject bossHpBar;
    public GameObject CountPanel;
    public Animator counteranim;
    public TextMeshProUGUI readycounttext;
    public TextMeshProUGUI wavenametext;

    public float introtime;


    public void Start()
    {
        
        timeBtwSpawns = startTBS;
        firstenemy = false;
        firstboss = false;
        wavecountdown = 3;
        //changingtype = Mathf.RoundToInt(wavecountdown);
        CountPanel.SetActive(true);
        readycounttext.text = "Press Any Key When You Are Ready!";
        //bossHpBar.SetActive(false);
        //readycounttext.text = changingtype.ToString();
        //StartCoroutine(Wavename(waves[0]));
    }
    private void Update()
    {

        if (Input.anyKey && !anyKeyPressed)
        {
            anyKeyPressed = true;
        }
        else
        {
            //
        }
        if (anyKeyPressed == false)
        {
            CountPanel.SetActive(true);
        }
        if (anyKeyPressed == true)
        {
            CountPanel.SetActive(false);
            StateCheck();
            //counteranim.Play("Controlpanelfade");

            //if (state == SpawnState.Counting)
            //{
            //CountPanel.SetActive(true);
            //StartCoroutine(Wavename(waves[nxtWave]));
            //}
            
            /*if (state == SpawnState.Waiting)
            {
                CountPanel.SetActive(false);
                if (firstboss == true)
                {
                    FullWaveCompleted();
                    Debug.Log("Bosskilled");


                }
                else if (!Enemyisalive() && firstenemy == true)
                {
                    EnemyWaveCompleted();
                }
                else
                {
                    return;
                }

            }*/
            
        }

    }

    IEnumerator SpawnEnemy(GameObject enemies)
    {
        if (timeBtwSpawns <= 0)
        {
            int randpos = Random.Range(0, spawnpos.Length - 1);
            Instantiate(enemies, spawnpos[randpos].position, Quaternion.identity);
            timeBtwSpawns = startTBS;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
        yield break;
    }

    public void StateCheck()
    {
        if (wavecountdown <= 0 && playercurrhp.currenthp > 0)
        {
            state = SpawnState.Spawning;
            CountPanel.SetActive(false);
            if (state == SpawnState.Spawning)
            {
                StartCoroutine(SpawnEnemy(enemy));
                wavecountdown = 0;
            }
        }
        if (state != SpawnState.Finished)
        {
            Debug.Log("enemies left");
            //CountPanel.SetActive(true);
        }

        if (state == SpawnState.Finished)
        {
            StopCoroutine(SpawnEnemy(enemy));
            Debug.Log("You Have Died");
            //CountPanel.SetActive(false);
            return;

        }

        if (state == SpawnState.Counting)
        {
            wavecountdown -= Time.deltaTime;
        }
    }
    

   
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(introtime);
        introtime -= Time.deltaTime;
    }
    //IEnumerator Wavename(Wave waves2)
    //{
    //  wavenametext.text = waves2.wavename;
    //   yield break;
    //}
}
