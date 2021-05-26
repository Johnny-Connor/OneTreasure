using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField]
    private int HP;
    [SerializeField]
    private int DMG;
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
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Player player = col.transform.GetComponent<Player>();
        if (col.gameObject.tag == "Player")
        {
            player.setHP(player.getHP() - DMG);
        }
        else if (col.gameObject.tag == "FurBall")
        {
            HP -= player.getDMG();
        }
    }
    public void DetectDif(int ID)
    {
        switch (ID)
        {
            case 0:
                HP = 25;
                DMG = 10;
                SPD = 2f;
                break;
            case 1:
                HP = 50;
                DMG = 20;
                SPD = 2.5f;
                break;
            case 2:
                HP = 100;
                DMG = 40;
                SPD = 3f;
                break;
        }
    }

}