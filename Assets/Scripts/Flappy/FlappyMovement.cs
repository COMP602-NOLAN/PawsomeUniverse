using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public bool isAlive = true;
    public Animator flap_animator;

    [SerializeField] int jumpMultiplier = 5;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isAlive)
        {
            myRigidbody.velocity = Vector2.up * jumpMultiplier;
            flap_animator.SetTrigger("Flap");
        }

        if (transform.position.y >= 20 || transform.position.y <= -20)
        {
            kill();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        kill();
    }

    private void kill()
    {
        logic.gameOver();
        isAlive = false;
    }
}
