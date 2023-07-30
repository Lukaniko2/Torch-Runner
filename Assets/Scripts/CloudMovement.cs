using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public GameObject clouds; //cloud object
    private Rigidbody2D rb;
    public float cloudSpeed = 1; //determines speed of clouds
    public float endX; //the end of the map so they can teleport back to the beginning
    public Vector2 start; //start of the map

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(cloudSpeed, rb.velocity.y); //makes the clouds move

        if (clouds.transform.position.x > endX)
        {
            clouds.gameObject.SetActive(false);
            RespawnCoroutine();
            clouds.transform.position = new Vector2 (start.x, Random.Range(start.y + 0.5f, start.y - 0.5f));
            cloudSpeed = Random.Range(1, 2);
            clouds.gameObject.SetActive(true);
        }
    }
    public IEnumerator RespawnCoroutine()
    {

        yield return new WaitForSeconds(1);

    }
}
