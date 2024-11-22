using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIContoller : MonoBehaviour
{
    [Header("Challenge Panel")]
    [SerializeField] private GameObject challengePanel;

    [Header("Option Panel")]
    [SerializeField] private GameObject optionPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Challenge Panel On/Off
    public void ChallengePanelOn()
    {
        challengePanel.SetActive(true);
    }
    public void ChallengePanelOff()
    {
        challengePanel.SetActive(false);
    }


    // Option Panel On/Off
    public void OptionPanelOn()
    {
        optionPanel.SetActive(true); 
    }
    public void OptionPanelOff()
    {
        optionPanel.SetActive(false);
    }
}
