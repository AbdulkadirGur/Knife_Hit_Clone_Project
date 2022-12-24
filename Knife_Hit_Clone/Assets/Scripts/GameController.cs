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

    public GameUI  GameUI { get; private set; }

    private void Awake()
    {
        Instance= this; 
        GameUI = GetComponent<GameUI>();
    }

    private void Start()
    {
        GameUI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife();
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
            RestartGame();
        }
        else
        {
            GameUI.ShowRestartButton();
        }
           
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
