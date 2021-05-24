using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurBallW : MonoBehaviour
{
    [SerializeField]
    private float ballSPD = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = ballSPD * new Vector2 (0,1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
