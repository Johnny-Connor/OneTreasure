using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
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
        if(HP <= 0){
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
                HP = 25;
                DMG = 0.3f;
                SPD = 2.5f;
                break;
            case 1:
                HP = 50;
                DMG = 0.6f;
                SPD = 2.7f;
                break;
            case 2:
                HP = 75;
                DMG = 0.9f;
                SPD = 3f;
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