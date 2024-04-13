using System.Collections;
using System.Collections.Generic;
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
        var x = transform.localScale.x;
        var y = transform.localScale.y;
        var z = transform.localScale.z;
        print("Before scale flip: " + transform.localScale);
        transform.localScale = new Vector3(-x, y, z);
        print("After scale flip: " + transform.localScale);
        goLeft = act;
    }

    public void Right(bool act)
    {
        var x = transform.localScale.x;
        var y = transform.localScale.y;
        var z = transform.localScale.z;
        transform.localScale = new Vector3(x, y, z);
        goRight = act;
    }

    
}
