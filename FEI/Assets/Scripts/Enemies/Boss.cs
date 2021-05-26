using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
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

    public int getHP()
    {
        return HP;
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
                HP = 250;
                DMG = 15;
                SPD = 1.5f;
                break;
            case 1:
                HP = 500;
                DMG = 30;
                SPD = 2;
                break;
            case 2:
                HP = 1000;
                DMG = 60;
                SPD = 2.5f;
                break;
        }
    }

}
