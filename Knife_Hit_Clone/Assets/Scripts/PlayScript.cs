using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public AudioSource sound;
   
    public void PlayBTN()
    {
        
        SceneManager.LoadScene(1);
        sound.Play();
        

    }
}
