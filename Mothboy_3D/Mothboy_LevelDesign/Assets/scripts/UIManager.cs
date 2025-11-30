using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for Image definition


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject Paused = null;
    [SerializeField] private GameObject controlsScreen = null;
    [SerializeField] private GameObject failScreen;
    [SerializeField] private GameObject clearScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void HideTitleScreen() {
        titleScreen.SetActive(false);
    }

    public void ShowTitleScreen() {
        titleScreen.SetActive(true);
    }

    public void HidePauseScreen(){
        Paused.SetActive(false);
        }
    public void ShowPauseScreen(){
        Paused.SetActive(true);
        }
    
    public void HideControlsScreen() {
        controlsScreen.SetActive(false);
    }

    public void ShowControlsScreen() {
        controlsScreen.SetActive(true);
    }

    public void HideGameOverScreen() {
        failScreen.SetActive(false);
    }

    public void ShowGameOverScreen() {
        failScreen.SetActive(true);
    }

    public void HideGameClearScreen() {
        clearScreen.SetActive(false);
    }

    public void ShowGameClearScreen() {
        clearScreen.SetActive(true);
    }
}
