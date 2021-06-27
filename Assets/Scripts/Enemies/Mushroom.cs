using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField]
    private float HP;
    [SerializeField]
    private float DMG;
    [SerializeField]
    private float SPD;
    [SerializeField]
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        DetectDif(PlayerPrefs.GetInt("dif"));
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
        Chase();
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
                HP = 50;
                DMG = 0.2f;
                SPD = 2f;
                break;
            case 1:
                HP = 100;
                DMG = 0.4f;
                SPD = 2.5f;
                break;
            case 2:
                HP = 150;
                DMG = 0.6f;
                SPD = 2.7f;
                break;
        }
    }

    public void Chase()
    {
        if (Vector2.Distance(transform.position, player.GetComponent<Transform>().position) < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<Transform>().position, SPD * Time.deltaTime);
        }
    }

}