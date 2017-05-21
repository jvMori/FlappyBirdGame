using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {


    public static bool turnOnOff = true;
    [SerializeField]
    private Text sound;
    

    private void Awake()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SoundOn()
    {
        sound.text = turnOnOff ? "sound off" : "sound on";
        turnOnOff = !turnOnOff;
    }
}
