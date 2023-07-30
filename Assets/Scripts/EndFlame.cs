using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFlame : MonoBehaviour
{
    public GameObject fire;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Checkpoint.endFire)
        {
            fire.gameObject.SetActive(true);
            Debug.Log("OK IT IS");
        }
    }


}
