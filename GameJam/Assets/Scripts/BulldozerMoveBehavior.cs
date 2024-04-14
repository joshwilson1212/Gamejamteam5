using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BulldozerMoveBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool goRight;
    private bool goLeft;
    private bool isGrounded;

    public float appliedForce = 20;
    public float runForce = 3;
    public float damping;
    public BulldozerDirectionChange bullDirChange;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = GameObject.Find("Bulldozer").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        goRight = false;
        goLeft = false;
        isGrounded = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (goLeft && !goRight)
        {
            //print("Bulldozer speeding left");
            GetComponent<Rigidbody2D>().AddForce(Vector3.left * runForce * Time.deltaTime, ForceMode2D.Force);
        }
        else if (goRight && !goLeft)
        {
            //print("Bulldozer speeding right");
            GetComponent<Rigidbody2D>().AddForce(Vector3.right * runForce * Time.deltaTime, ForceMode2D.Force);
        }
        else if (isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.MoveTowards(GetComponent<Rigidbody2D>().velocity, Vector2.zero, damping * Time.deltaTime);
        }
    }

    public void Left(bool act)
    {
        goLeft = act;
    }

    public void Right(bool act)
    {
        goRight = act;
        
    }

    // when bulldozer hits the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            collision.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            Invoke("DelPlayer",0.1f);
        }
    }

    private void DelPlayer()
    {
        
        player.SetActive(false);
        //player.SetActive(false);
    }

    public void Summon(Vector3 playerLoc, float offset, int direction)
    {
        if (direction == -1)
        {
            goLeft = true;
            goRight = false;
            bullDirChange.direction = false;
            print(bullDirChange.direction);
        }
        else
        {
            bullDirChange.direction = true;
            goRight = true;
            goLeft = false;
        }
        transform.position = playerLoc + new Vector3(offset, 0f);
    }

}
