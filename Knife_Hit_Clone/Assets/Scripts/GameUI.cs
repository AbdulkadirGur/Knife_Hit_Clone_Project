using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartBTN;

    [Header("Knife Count Display")]
    [SerializeField]
    private GameObject panelKnives;
    [SerializeField]
    private GameObject iconKnife;
    [SerializeField]
    private Color usedKnifeIconColor;


    public void ShowRestartButton()
    {
        restartBTN.SetActive(true);
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
            

    }

}
