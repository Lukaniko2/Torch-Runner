using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeginningMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer renderer2D;
    public GameObject player;
    public float vel;
    public float XValueJump;
    public float jumpForce;

    public GameObject Two;
    public GameObject Three;
    public GameObject Four;
    public GameObject Five;

    private void Awake()
    {
        Two.SetActive(false);
        Three.SetActive(false);
        Four.SetActive(false);
        Five.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetInteger("animState", 0);
        Two.SetActive(true);
        Invoke("MovePlayer", 10f);
        Invoke("Other1", 2f);

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if(player.transform.position.x > XValueJump - 0.01f && player.transform.position.x < XValueJump + 0.01f)
        { 
            rb.velocity = new Vector2(0, jumpForce);
            animator.SetInteger("animState", 2);

            Invoke("MovePlayer", 0.1f);

        }
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(vel, rb.velocity.y);
        animator.SetInteger("animState", 1);
    }
    void Other1()
    {
        Three.SetActive(true);
        Invoke("Other2", 2f);
    }
    void Other2()
    {
        Four.SetActive(true);
        Invoke("Other3", 2f);
    }
    void Other3()
    {
        Five.SetActive(true);
        Invoke("changeScene", 5);
    }
    void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
