using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulldozerDirectionChange : MonoBehaviour
{

    private GameObject bulldozer;
    private bool direction;
    private float speedTimer;

    // Start is called before the first frame update
    void Start()
    {
        bulldozer = GameObject.Find("bulldozer_updated_0");
        direction = true;
        speedTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if bulldozer is just sitting there, check how long its been that way.
        if (Mathf.Abs(bulldozer.GetComponent<Rigidbody2D>().velocity.x) < .2)
        {
            //print(bulldozer.GetComponent<Rigidbody2D>().velocity.x);
            speedTimer += Time.deltaTime;
            // if its been that way for 2 seconds, flip direction
            if (speedTimer > .75)
            {
                FlipDirection();
                speedTimer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Moveable"))
        {

        }
        else
        {
            FlipDirection();
        }

        
    }

    private void FlipDirection()
    {
        // goes right if direction == true, otherwise left
        if (direction)
        {
            //print("Bulldozer going right");
            bulldozer.GetComponent<BulldozerMoveBehavior>().Left(true);
            bulldozer.GetComponent<BulldozerMoveBehavior>().Right(false);
            direction = false;
        }
        else
        {
            //print("Bulldozer going left");
            bulldozer.GetComponent<BulldozerMoveBehavior>().Left(false);
            bulldozer.GetComponent<BulldozerMoveBehavior>().Right(true);
            direction = true;
        }
    }
}
