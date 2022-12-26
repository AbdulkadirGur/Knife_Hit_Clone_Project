using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    
    public static GameController Instance { get; private set; }

    [SerializeField]
    private int knifeCount;

    [Header("Knife Swapning")]
    [SerializeField]
    private Vector2 knifeSpawnPosition;
    [SerializeField]
    private GameObject knifeObject;

    public AudioSource[] Voices;
    [SerializeField]
    





    public GameUI  GameUI { get; private set; }



    private void Awake()
    {
        Instance= this; 
        GameUI = GetComponent<GameUI>();
    }

    public void Start()
    {
        
        GameUI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife();
    }
    public void Update()
    {
        
    }

    public void OnSuccessfulKnifeHit()
    {
        if(knifeCount > 0) 
        {
            SpawnKnife();
           

        }
        else
        {
            StartGameOverSequance(true);
        }
    }

    private void SpawnKnife()
    {
        knifeCount--;                
        Instantiate(knifeObject, knifeSpawnPosition, transform.rotation * Quaternion.Euler(180, 0, 0));
        


    }

    public void StartGameOverSequance(bool win)
    {
        StartCoroutine("GameOverSequanceCoroutine", win  );
        
    }

    private IEnumerator  GameOverSequanceCoroutine(bool win)
    {
        if(win) 
        {
            yield return new WaitForSecondsRealtime(0.3f);
            GameUI.NextLVL();

            
            
        }
        else
        {
            GameUI.ShowRestartButtonAndHome();
            
        }
           
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        FindObjectOfType<GameController>().Voices[7].Play();
    }
    public void HomeBTN()
    {
        FindObjectOfType<GameController>().Voices[7].Play();
        SceneManager.LoadScene(1);


    }
    public void Nextlvlbutton()
    {
        FindObjectOfType<GameController>().Voices[6].Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        
    }
    public void Nextlvlbutton1()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(3);

    }
    public void Nextlvlbutton2()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(4);

    }
    public void Nextlvlbutton3()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(5);

    }
    public void Nextlvlbutton4()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(6);

    }
    

}
