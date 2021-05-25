using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Boss boss;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseSwitch();
        }
    }

    public void pauseSwitch()
    {
        if (Time.timeScale == 1 && player.getHP() > 0 && boss.getHP() > 0)//rodando e o player e o boss estiverem vivos
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }
    public void retomar()
    {
        pauseSwitch();
    }

    public void menuPrincipal()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
