using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float HP;
    [SerializeField]
    private float MHP;
    [SerializeField]
    private float DMG;
    [SerializeField]
    private float SPD;
    [SerializeField]
    private Player player;
    private float teleportTime = 7.5f;
    private bool dontRepeat;

    // Start is called before the first frame update
    void Start()
    {
        DetectDif(PlayerPrefs.GetInt("dif"));
        MHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < MHP / 2 && dontRepeat == false)
        {
            StartCoroutine(teleport());
            dontRepeat = true;
            StartCoroutine(waitTeleportCoroutine());
        }
        if (HP <= 0){
            Destroy(this.gameObject);
        }
        Chase();
    }

    public IEnumerator waitTeleportCoroutine()
    {
        yield return new WaitForSeconds(teleportTime);
        dontRepeat = false;
    }

    public IEnumerator teleport()
    {
        int x = Random.Range(1, 4);
        switch (x)
        {
            case 1:
                transform.position = new Vector2(-60.2f, 47.8f);
                break;
            case 2:
                transform.position = new Vector2(-60.2f, 42.3f);
                break;
            case 3:
                transform.position = new Vector2(-51.7f, 47.8f);
                break;
            case 4:
                transform.position = new Vector2(-51.7f, 42.3f);
                break;
        }
        yield return new WaitForSeconds(teleportTime);
    }

    public float getHP()
    {
        return HP;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "FurBall")
        {
            HP -= player.getDMG();
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        //Player player = col.transform.GetComponent<Player>();
        if (col.gameObject.tag == "Player")
        {
            player.setHP(player.getHP() - DMG);
        }
    }

    public void DetectDif(int ID)
    {
        switch (ID)
        {
            case 0:
                HP = 250;
                DMG = 0.5f;
                SPD = 1.5f;
                break;
            case 1:
                HP = 500;
                DMG = 1f;
                SPD = 2f;
                break;
            case 2:
                HP = 750;
                DMG = 1.5f;
                SPD = 2.5f;
                break;
        }
    }

    public void Chase()
    {
        if (Vector2.Distance(transform.position, player.GetComponent<Transform>().position) < 12)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<Transform>().position, SPD * Time.deltaTime);
        }
    }

}