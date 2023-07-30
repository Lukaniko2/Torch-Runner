using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndText : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Checkpoint.endFire)
        {
            Invoke("TextOne", 3);
            Invoke("TextTwo", 3);
            Invoke("TextThree", 3);
            Invoke("TextFour", 3);
        }
    }

    void TextOne()
    {
        text1.SetActive(true);

    }
    void TextTwo()
    {
        text2.SetActive(true);
        text1.SetActive(false);
    }
    void TextThree()
    {
        text3.SetActive(true);
        text2.SetActive(false);
    }
    void TextFour()
    {
        text4.SetActive(true);
        text3.SetActive(false);
    }
}
