using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemyflyweight : MonoBehaviour
{
    public Transform[] spawnpos1;
    public int randposx;
    public GameObject primeenemy;
    public MenuScripts menu;
    public PlayerHp playercurrhp;
    public float primetimeBtwSpawns;
    public float primestartTBS;
    public float minTime;
    public float timedecrease;
    public bool anyKeyPressed = false;

    public bool oneatatime = false;

    public float wavecountdown = 3;

    public GameObject CountPanel;
    public Animator counteranim;
    public TextMeshProUGUI readycounttext;
    public TextMeshProUGUI wavenametext;

    

    void Start()
    {
        primetimeBtwSpawns = primestartTBS;
        CountPanel.SetActive(true);
        readycounttext.text = "Press Any Key When You Are Ready!";
        
        
        
    }

    private void Update()
    {
        SpawnerFactory spawner = new SpawnerFactory();
        if (wavecountdown <= 0 && primetimeBtwSpawns <= 0.15 && !oneatatime)
        {
            spawner.Spawn(EnemyType.Minion, primeenemy, spawnpos1,randposx);
            oneatatime = true;
            if (primestartTBS > minTime)
            {
                primestartTBS -= timedecrease;
            }
            wavecountdown = 0;
            Debug.LogError("main if done");
        }

        if (Input.anyKey && !anyKeyPressed && menu.readyscreen && !menu.readyonce)
        {
            anyKeyPressed = true;
            menu.readyonce = true;
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
            //counteranim.SetBool("countonce", true);
            Debug.LogError("panel False");
            wavecountdown -= Time.deltaTime;
        }

        if (wavecountdown <= 0 && primetimeBtwSpawns > 0)
        {
            primetimeBtwSpawns -= Time.deltaTime;
            Debug.LogError("time negating");
        }


        if (menu.readyscreen && !menu.readyonce)
        {
            anyKeyPressed = false;
        }

        if (primetimeBtwSpawns <= 0.1)
        {
            primetimeBtwSpawns = primestartTBS;
        }
        if (primetimeBtwSpawns >= 1)
        {
            oneatatime = false;
        }
    }
}

//FlyWeight Interface
public interface IEnemyUnits
{
    void SpawnEnemy(GameObject enemy, Transform[] spawnpos,int randpos);
}

//ConcreteFlyweight
public class Minion : enemyflyweight, IEnemyUnits
{

    public void SpawnEnemy(GameObject enemy, Transform[] spawnpos, int randpos)
    {
            Debug.LogError("bat");
            randpos = Random.Range(0, spawnpos.Length - 1);
            Debug.LogError(spawnpos[randpos]);
            Instantiate(enemy, spawnpos[randpos].position, Quaternion.identity);
         
    }
}

//ConcreteFlyweight
public class Boss : IEnemyUnits
{
    public void SpawnEnemy(GameObject enemy, Transform[] spawnpos, int randposx)
    {
        Debug.Log("Spawned BOSS");
    }
}

public enum EnemyType
{
    Minion,
    Boss
}

//FlyweightFactory
public class SpawnerFactory
{
    private Dictionary<EnemyType, IEnemyUnits> enemyUnits = new Dictionary<EnemyType, IEnemyUnits>();

    private IEnemyUnits GetEnemy(EnemyType enemyType)
    {
        if (!enemyUnits.ContainsKey(enemyType))
        {
            switch (enemyType)
            {
                case EnemyType.Minion:
                    enemyUnits.Add(EnemyType.Minion, new Minion());
                    break;
                case EnemyType.Boss:
                    enemyUnits.Add(EnemyType.Boss, new Boss());
                    break;
            }
        }
        return enemyUnits[enemyType];
    }

    public void Spawn(EnemyType enemyType,GameObject enemy, Transform[] spawnpos, int randposx)
    {
        GetEnemy(enemyType).SpawnEnemy(enemy,spawnpos,randposx);
    }
}

    




