using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
    public GameObject flame;
    public GameObject flame2;
    public GameObject flame3;
    public GameObject flame4;
    public GameObject Player;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
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
    private float respawnDelay = 1;
    // Start is called before the first frame update

    private void Awake()
    {
        flame.SetActive(false); //hides flame at start until they touch it 
        flame2.SetActive(false);
        flame3.SetActive(false);
        flame4.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isActivated = Physics2D.OverlapCircle(playercheck.position, checkRadius, whatIsGround); //checks to see if the player is in vacinity. If so, then isActivated == true

        //if they touch the checkpoint shrine and if it is a checkpoint other than the ones already gotten
        if (isActivated && CheckpointNumber > checkpoint && !Timer.time)
        {
            ResetTime = true;
            checkpoint = CheckpointNumber;
            flame.SetActive(true);
            Invoke("TheFlame", 1f);
            TorchLit.Play();
            startPos = new Vector2(transform.position.x, transform.position.y); //update position to the new checkpoint
            Debug.Log(startPos);
            Debug.Log("You Reached Checkpoint # " + checkpoint);
            endFire = true;
            Invoke("TextOne", 3f);
            
           
           
        }
       

    }

    void endApp()
    {
        Application.Quit();
    }
    void TheFlame()
    {
        flame2.SetActive(true);
        TorchLit.Play();
        flame3.SetActive(true);
        TorchLit.Play();
        flame4.SetActive(true);
        TorchLit.Play();
    }
    void TextOne()
    {
        text1.SetActive(true);
        RespawnCoroutine();
        Invoke("TextTwo", 4f);
    }
    void TextTwo()
    {
        text2.SetActive(true);
        text1.SetActive(false);
        RespawnCoroutine();
        Invoke("TextThree", 4f);
    }
    void TextThree()
    {
        text3.SetActive(true);
        text2.SetActive(false);
        RespawnCoroutine();
        Invoke("TextFour", 4f);
    }
    void TextFour()
    {
        text4.SetActive(true);
        text3.SetActive(false);
        RespawnCoroutine();
        Invoke("endApp", 6);

    }
    public IEnumerator RespawnCoroutine()
    {

        yield return new WaitForSeconds(respawnDelay);

    }
}
