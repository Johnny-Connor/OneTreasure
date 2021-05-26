using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class ConfigMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider vol;
    [SerializeField]
    private TMP_Dropdown dif;
    [SerializeField]
    private Toggle cheat1;
    [SerializeField]
    private Toggle cheat2;
    [SerializeField]
    private Toggle cheat3;

    void Start()
    {
        vol.value = PlayerPrefs.GetFloat("volpref");
        dif.value = PlayerPrefs.GetInt("dif");
        CheatsSaver();
    }

    void Update()
    {
        SetVolume(vol.value);
        SetDifficulty(dif.value);
        CheatsManager();
        PlayerPrefs.Save();
    }

    public void SetVolume(float volume)
    {
        if (volume > -40)
        {
            audioMixer.SetFloat("volume", volume);
            PlayerPrefs.SetFloat("volpref", volume);
        }
        else
        {
            audioMixer.SetFloat("volume", -80);
            PlayerPrefs.SetFloat("volpref", -80);
        }
    }

    public void SetDifficulty(int ID)
    {
        switch(ID)
        {
            case 0:
                PlayerPrefs.SetInt("dif", ID);
                break;
            case 1:
                PlayerPrefs.SetInt("dif", ID);
                break;
            case 2:
                PlayerPrefs.SetInt("dif", ID);
                break;
        }
    }
    public void CheatsManager()
    {
        if (cheat1.isOn)
        {
            PlayerPrefs.SetInt("HPCheat", 1);
        }
        else
        {
            PlayerPrefs.SetInt("HPCheat", 0);
        }
        if (cheat2.isOn)
        {
            PlayerPrefs.SetInt("DMGCheat", 1);
        }
        else
        {
            PlayerPrefs.SetInt("DMGCheat", 0);
        }
        if (cheat3.isOn)
        {
            PlayerPrefs.SetInt("SPDCheat", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SPDCheat", 0);
        }
    }

    public void CheatsSaver()
    {
        if (PlayerPrefs.GetInt("HPCheat") == 1)
        {
            cheat1.isOn = true;
        }
        else
        {
            cheat1.isOn = false;
        }
        if (PlayerPrefs.GetInt("DMGCheat") == 1)
        {
            cheat2.isOn = true;
        }
        else
        {
            cheat2.isOn = false;
        }
        if (PlayerPrefs.GetInt("SPDCheat") == 1)
        {
            cheat3.isOn = true;
        }
        else
        {
            cheat3.isOn = false;
        }
    }

}
