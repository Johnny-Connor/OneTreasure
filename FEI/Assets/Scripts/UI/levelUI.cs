using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelUI : MonoBehaviour
{
    [SerializeField]
    private Text gameOver;
    [SerializeField]
    private Text victoryScreen;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Slider bossHealth;
    [SerializeField]
    private GameObject bossUI;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Boss boss;

    void Start()
    {
        bossHealth.maxValue = boss.getHP();
    }

    void Update()
    {
        healthBar.value = player.getHP();
        bossHealth.value = boss.getHP();
        if(player.transform.position.x < -49)
        {
            if (boss.getHP() > 0)
            {
                bossUI.SetActive(true);
            }
            else
            {
                bossUI.SetActive(false);
            }
        }
        if (player.getHP() <= 0)
        {
            gameOver.GetComponent<Animation>().Play("fadeIn3s");
        }
        if (boss.getHP() <= 0)
        {
            victoryScreen.GetComponent<Animation>().Play("fadeIn3s");
            StartCoroutine(win());
        }
    }
    public IEnumerator win()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("mainMenu");
    }

}