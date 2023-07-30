using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Trigger : MonoBehaviour
{
    public float respawnDelay;
    public GameObject player;
    private Rigidbody2D rb; //for the player
    public float bounce;
    public static bool tramp;
    public AudioSource Gameover;
    public AudioSource TrampAD;
    private int Counter = 0;
    private float Tcounter = 0.0f;
    public AudioSource ChangeLevel;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "SceneChange")
        {
            ChangeLevel.Play();
            Invoke("changeScene", 1);
        }
        if(col.gameObject.tag == "FallDoom")
        {
            Gameover.Play();
            player.SetActive(false);
            Debug.Log("Yo g");
            Checkpoint.ResetTime = true;
            Invoke("Respawn", 0.25f);
           
        }
   

    }

    void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bounce")
        {
            TrampAD.Play();
            tramp = true;
            rb.velocity = Vector2.up * bounce;
            Invoke("Tramp", 1f);
           
        }
    }

    void Death()
    {
        Gameover.Play();
    }
    void Tramp()
    {
        tramp = false;
    }
    void Respawn()
    {
        player.transform.position = new Vector3(Checkpoint.startPos.x, Checkpoint.startPos.y, transform.position.z);
        Checkpoint.ResetTime = false;
        player.SetActive(true);
    }

    public IEnumerator RespawnCoroutine()
    {

        yield return new WaitForSeconds(respawnDelay);    
 
    }
}
