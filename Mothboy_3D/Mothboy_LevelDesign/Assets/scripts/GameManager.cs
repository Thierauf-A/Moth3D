using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for image definition

public class GameManager : MonoBehaviour
{
     [SerializeField] private GameObject player;
     [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject titleScreen; //it is image but go generic

    private UIManager UI;
    public bool gameOver = false;
    public bool paused = false;
    public bool controls = false;
    public bool gameClear = false;
    public bool gameStart = true;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused == false){ // pause
                Time.timeScale = 0; // % of fps, pauses game
                paused = true;
                UI.ShowPauseScreen();
                Cursor.visible = true;                  //turn on cursor
                Cursor.lockState = CursorLockMode.None; //release the cursor
        }
        
        else{ // resume
            Time.timeScale = 1; // resume the game
            paused = false;
            UI.HidePauseScreen();
            //hide the cursor
            Cursor.visible = false;

            //lock cursor into game window
            Cursor.lockState = CursorLockMode.Locked;
        }
        }

        if(paused == true){ //Options in pause menu
            if(Input.GetKeyDown(KeyCode.C)){ //Controls  
                if(controls == false){ // Check if showing
                    controls = true;
                    UI.ShowControlsScreen();
                }
                else{
                controls = false;
                UI.HideControlsScreen();
                }   
            }

            if(Input.GetKeyDown(KeyCode.Q)){ //Quit Game  
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;  
            }

            if(Input.GetKeyDown(KeyCode.T)){ //Title Screen
                gameStart = true;
                Time.timeScale = 1; // resume the game
                paused = false;
                UI.HidePauseScreen();

                //hide the cursor
                Cursor.visible = false;
                //lock cursor into game window
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else{
            UI.HideControlsScreen();
            //UI.HideTitleScreen();
        }

        if(gameStart == true){
            if(gameOver == true){
                UI.ShowGameOverScreen();
                Debug.Log("A");
            }
            else if(gameClear == true){
                UI.ShowGameClearScreen();
                Debug.Log("B");
            }
            else{
                UI.ShowTitleScreen();
                Debug.Log("C");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(gameOver == true){
                    gameOver = false;
                    UI.HideGameOverScreen();
                    UI.ShowTitleScreen();
                    Debug.Log("1");

                    if(Input.GetKeyDown(KeyCode.Space) && gameStart){
                        //Instantiate(player, new Vector3(0,1,-5), Quaternion.identity);
                        player.transform.position = new Vector3(0, 1, -5);
                        gameStart = false;
                        if(UI != null){
                            UI.HideTitleScreen();
                        }
                        Instantiate(enemy, new Vector3(5, 2, -75), Quaternion.identity);
                    }
                }
                else if(gameClear == true){
                    gameClear = false;
                    UI.HideGameClearScreen();
                    UI.ShowTitleScreen();
                    Debug.Log("2");

                    if(Input.GetKeyDown(KeyCode.Space) && gameStart){
                        //Instantiate(player, new Vector3(0,1,-5), Quaternion.identity);
                        player.transform.position = new Vector3(0, -5, -5);
                        gameStart = false;
                        if(UI != null){
                            UI.HideTitleScreen();
                        }
                        Instantiate(enemy, new Vector3(5, 2, -75), Quaternion.identity);
                    }
                }
                else{
                    player.transform.position = new Vector3(0, 1, -5); 
                    gameStart = false;
                    Debug.Log("3");
                    if(UI != null){
                        UI.HideTitleScreen();
                    }
                    Instantiate(enemy, new Vector3(5, 2, -75), Quaternion.identity);
                }
            }
        }

    /*    if(Input.GetKeyDown(KeyCode.Space) && gameStart){
            //Instantiate(player, new Vector3(0,1,-5), Quaternion.identity);

            gameStart = false;

            if(UI != null){
                UI.HideTitleScreen();
            }
        } */
    }
}
