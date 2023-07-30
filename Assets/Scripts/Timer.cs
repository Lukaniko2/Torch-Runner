using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float respawnDelay;
    public AudioSource Gameover;
    Image timerBar;
    public float maxTime = 20;
    private float timeLeft;
    public GameObject timesUpText;
    public GameObject Player;
    public GameObject Fire;
    public static bool time = false;
    private int Counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        time = false;
        timesUpText.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        Debug.Log("Time" + time);
    }

    // Update is called once per frame
    void Update()
    {

        if(timeLeft > 0) //if there still is time left
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            time = false;
            Debug.Log("Time" + time);
        }
        else
        {
           
            timesUpText.SetActive(true);
            Fire.SetActive(false);
            time = true;
            Debug.Log("False");
            Invoke("endTimer", 2);
            Debug.Log("Time" + time);
        }

        if(Checkpoint.ResetTime)
        {
            timeLeft = maxTime;
        }
    }

    void endTimer()
    {
        timeLeft = maxTime;
        timesUpText.SetActive(false);
        Player.gameObject.SetActive(false);
        RespawnCoroutine();
        Player.transform.position = new Vector3(Checkpoint.startPos.x, Checkpoint.startPos.y, transform.position.z);
        Invoke("playerActive", 0.5f);
        Fire.SetActive(true);
    }

    void playerActive()
    {
        Player.SetActive(true);
    }
    public IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);

    }
}
