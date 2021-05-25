using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    [SerializeField]
    private AudioClip gameOverBGM;
    [SerializeField]
    private AudioClip bossBGM;
    [SerializeField]
    private AudioClip victoryBGM;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Boss boss;
    private bool defeat;
    private bool bossActive;
    private bool bossDefeated;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeBGM();
    }
    public void ChangeBGM()
    {
        if (player.getHP() <= 0 && defeat == false)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = gameOverBGM;
            GetComponent<AudioSource>().Play();
            defeat = true;
        }
        else if (player.transform.position.x < -49 && bossActive == false)//alterar para quando atravessar a porta do boss
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = bossBGM;
            GetComponent<AudioSource>().Play();
            bossActive = true;
        }
        else if (boss.getHP() <= 0 && bossDefeated == false)//alterar para quando atravessar a porta do boss
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = victoryBGM;
            GetComponent<AudioSource>().Play();
            bossDefeated = true;
        }
    }
}
