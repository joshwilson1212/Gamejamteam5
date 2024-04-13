using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BulldozerMoveBehavior : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private bool goRight;
    private bool goLeft;
    private bool isGrounded;

    public float appliedForce = 20;
    public float runForce = 3;
    public float damping;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GameObject.Find("bulldozer_updated_0").GetComponent<Rigidbody2D>();
        goRight = true;
        goLeft = false;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.y == 0)
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
            rigidbody.AddForce(Vector3.left * runForce * Time.deltaTime, ForceMode2D.Force);
        }
        else if (goRight && !goLeft)
        {
            //print("Bulldozer speeding right");
            rigidbody.AddForce(Vector3.right * runForce * Time.deltaTime, ForceMode2D.Force);
        }
        else if (isGrounded)
        {
            rigidbody.velocity = Vector2.MoveTowards(rigidbody.velocity, Vector2.zero, damping * Time.deltaTime);
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
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("DelPlayer",0.1f);
        }
    }

    private void DelPlayer()
    {
        
        GameObject.Find("Player").SetActive(false);
    }

}
