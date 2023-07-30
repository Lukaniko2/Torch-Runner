using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject flame;
    public GameObject Player;
    public AudioSource TorchLit;


    public static Vector2 startPos; //get the position of the checkpoint so player can respawn there
    public int CheckpointNumber; //What checkpoint in the level is this one? the first, second, theird?
    public static int checkpoint = 0; //what checkpoint the player currently unlocked
    public float checkRadius; //it creates(radius) a circle at the bottom Shrine
    public LayerMask whatIsGround; //Default Layer (Where player is)
    public Transform playercheck; //Checks to see player's position and if it is within the radius
    private bool isActivated = false; //if the player hit the checkpoint, then it activates
    public static bool ResetTime;
    public static bool endFire;
    // Start is called before the first frame update

    void Awake()
    {
        ResetTime = false;
        flame.SetActive(false); //hides flame at start until they touch it 
        Timer.time = false;
        Debug.Log("Time" +Timer.time);
    }
 
    // Update is called once --per frame
    void Update()
    {
        isActivated = Physics2D.OverlapCircle(playercheck.position, checkRadius, whatIsGround); //checks to see if the player is in vacinity. If so, then isActivated == true
        Debug.Log("Player within vicinity" + isActivated);
        Debug.Log("Checkpoint" + CheckpointNumber + "Checkpoint:" + checkpoint);
        Debug.Log("Timer.Time" + Timer.time);
        //if they touch the checkpoint shrine and if it is a checkpoint other than the ones already gotten
        
        if(isActivated)
        {
            TorchLit.Play();
        }
        
        
        
        if(isActivated &&  !Timer.time) 
        {
            
            
            checkpoint = CheckpointNumber;
            flame.SetActive(true); //makes the flame visible when you touch checkpoint
            Checkpoint.ResetTime = true;
            startPos = new Vector2(transform.position.x, transform.position.y); //update position to the new checkpoint
            Debug.Log("You Reached Checkpoint # " + checkpoint);
            Invoke("RestartTheTime", 0.5f);
        }
        

    }
  
    void RestartTheTime()
    {
        ResetTime = false;
    }
}
