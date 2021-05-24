using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelUI : MonoBehaviour
{
    [SerializeField]
    private Text gameOver;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Player player;

    void Start()
    {

    }

    void Update()
    {
        healthBar.value = player.getHP();
        if (player.getHP() <= 0)
        {
            gameOver.GetComponent<Animation>().Play("fadeIn3s");
        }
    }

}