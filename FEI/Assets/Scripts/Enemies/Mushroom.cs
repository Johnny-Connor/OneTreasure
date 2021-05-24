using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField]
    private int HP = 100;
    [SerializeField]
    private int DMG = 10;
    [SerializeField]
    private float SPD = 3;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Player player = col.transform.GetComponent<Player>();
        if (col.gameObject.tag == "Player")
        {
            player.setHP(player.getHP() - DMG);
        }
        else if (col.gameObject.tag == "FurBall")
        {
            HP -= DMG;
        }
    }
}
