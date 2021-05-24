using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField]
    private int HP = 50;
    [SerializeField]
    private int DMG = 15;
    [SerializeField]
    private float SPD = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Player player = col.transform.GetComponent<Player>();
        if (col.gameObject.tag == "Player")
        {
            player.setHP(player.getHP() - DMG);
        }
        else if (col.gameObject.tag == "FurBall")
        {
            HP -= player.getDMG();
        }
    }
}
