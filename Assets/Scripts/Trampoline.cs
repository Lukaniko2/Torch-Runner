using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Trigger.tramp)
        {
            animator.SetInteger("animTramp", 1);
            Debug.Log("Animation");

            Invoke("Tramp", 1f);
        }
    }
    void Tramp ()
    {
        animator.SetInteger("animTramp", 0);
    }
}
