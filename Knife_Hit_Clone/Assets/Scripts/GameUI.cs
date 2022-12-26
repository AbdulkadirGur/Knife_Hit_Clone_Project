using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartBTN;
    [SerializeField]
    private GameObject HomeBtn;
    [SerializeField]
    private GameObject Nextlvlbutton;
    [SerializeField]
    private GameObject Nextlvlbutton1;
    [SerializeField]
    private GameObject Nextlvlbutton2;
    [SerializeField]
    private GameObject Nextlvlbutton3;
    [SerializeField]
    private GameObject Nextlvlbutton4;
    
    


    [Header("Knife Count Display")]
    [SerializeField]
    private GameObject panelKnives;
    [SerializeField]
    private GameObject iconKnife;
    [SerializeField]
    private Color usedKnifeIconColor;


    

    public void ShowRestartButtonAndHome()
    {
        restartBTN.SetActive(true);
        HomeBtn.SetActive(true);
        

    }

    public void SetInitialDisplayedKnifeCount(int count )
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(iconKnife, panelKnives.transform);
        }
    }

    private int knifeIconIndexToChange = 0;
    public void DecrementDisplayedKnifeCount()
    {
        panelKnives.transform.GetChild(knifeIconIndexToChange++)
            .GetComponent<Image>().color = usedKnifeIconColor;


    }
    public void NextLVL()
    {
        FindObjectOfType<GameController>().Voices[6].Play();
        Nextlvlbutton.SetActive(true);
    }
    public void NextLVL1()
    {
        FindObjectOfType<GameController>().Voices[6].Play();
        Nextlvlbutton1.SetActive(true);
    }
    public void NextLVL2()
    {
        FindObjectOfType<GameController>().Voices[6].Play();
        Nextlvlbutton2.SetActive(true);
    }
    public void NextLVL3()
    {
        FindObjectOfType<GameController>().Voices[6].Play();
        Nextlvlbutton3.SetActive(true);
    }
    public void NextLVL4()
    {
        FindObjectOfType<GameController>().Voices[6].Play();
        Nextlvlbutton4.SetActive(true);
    }
    
    




}
