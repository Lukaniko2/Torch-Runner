using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFlip : MonoBehaviour
{
    private ParticleSystemRenderer psr;
    private Vector3 up;

    // Start is called before the first frame update
    void Start()
    {
        psr = GetComponent<ParticleSystemRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Arius2DPlatMovement.isFlipped)
        {
            up = new Vector3(3, 0, 0); //setting the pivot to this
            psr.pivot = up; //the pivot = up
        }
        else
        {
            up = new Vector3(0, 0, 0); //setting the pivot to this
            psr.pivot = up; //the pivot = up
        }

    }
}
