using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float appliedForce = 20;
    public float runForce = 3;
    private Rigidbody2D rb;
    private bool goRight;
    private bool goLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goRight = false;
        goLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goLeft && !goRight)
        {
            rb.AddForce(Vector3.left * runForce * Time.deltaTime, ForceMode2D.Force);
        }
        else if (goRight && !goLeft)
        {
            rb.AddForce(Vector3.right * runForce * Time.deltaTime, ForceMode2D.Force);
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * appliedForce, ForceMode2D.Impulse);
    }

    public void Left(bool act)
    {
        goLeft = act;
    }

    public void Right(bool act)
    {
        goRight = act;
    }
}
