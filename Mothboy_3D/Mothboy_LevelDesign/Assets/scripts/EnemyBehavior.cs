using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FEnemyBehavior : MonoBehaviour
{
    private Transform target;
    [SerializeField] public GameObject Player;
    private UIManager UI;
    private GameManager GM;

    public NavMeshAgent getout;

    public float speed;
    
    [SerializeField] private AudioClip deathClip;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>(); //dont set here
        //Jump to start position
        transform.position = new Vector3(5, 2, -75);

        
    }

    // Update is called once per frame
    void Update()
    {
        getout.SetDestination(target.position);
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {      
        if(other.CompareTag("Player")){
            Player P = other.GetComponent<Player>();
            Debug.Log("Poke poke");
            AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, .8f);
            if(P != null){
                Destroy(gameObject); //enemy 
                if(GM != null){
                    GM.gameOver = true;
                    GM.gameStart = true;
                    }
            }
            
        }
        
    }
}
