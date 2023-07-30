using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraCheckPoint : MonoBehaviour
{

    public GameObject Player;
    public GameObject Camera;
    public GameObject VCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.activeSelf)

            VCamera.transform.position = new Vector3(Checkpoint.startPos.x, Checkpoint.startPos.y, transform.position.z);
            Camera.transform.position = new Vector3(Checkpoint.startPos.x, Checkpoint.startPos.y, transform.position.z);
        
    }
}
