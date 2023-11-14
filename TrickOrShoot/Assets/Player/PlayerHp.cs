using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public GameObject Playerobj;
    public GameObject playerdeathanim;
    public GameObject spawnnerscript;
    public Animator gameoveranim;
    public TextMeshProUGUI currhptext;
    public int maxhp = 100;
    public int currenthp;

    public GameObject gameoverCanvas;   
    public TextMeshProUGUI finalscoretext;
    // Start is called before the first frame update
    void Start()
    {
        gameoverCanvas.SetActive(false);
        currenthp = maxhp;
        currhptext.text = currenthp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthp <= 0)
        {
            gameoverCanvas.SetActive(true);
            gameoveranim.SetBool("Shoot", true);
            Destroy(Instantiate(playerdeathanim, Playerobj.transform.position, Playerobj.transform.rotation), 5);
            finalscoretext.text = PlayerPrefs.GetInt("Score", playerscore.instance.score).ToString();
            //spawnnerscript.SetActive(false);
            Destroy(this.gameObject);
            Destroy(Playerobj);
        }
    }
    public void PlayerTakeDamage(int damage)
    {
        currenthp -= damage;
        currhptext.text = currenthp.ToString();
    }
}
