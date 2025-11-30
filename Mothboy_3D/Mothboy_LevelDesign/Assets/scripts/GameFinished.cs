using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFInished : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    private UIManager UI;
    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>(); //dont set here
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {      
        if(other.CompareTag("Player")){
            Player P = other.GetComponent<Player>();
            Debug.Log("Woahhhh game cleared!");
            if(P != null){
                if(GM != null){
                    GM.gameClear = true;
                    GM.gameStart = true;
                    }
            }
            
        }
        
    }
}
