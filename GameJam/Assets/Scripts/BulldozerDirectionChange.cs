using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulldozerDirectionChange : MonoBehaviour
{
    private GameObject bulldozer;
    private Vector3 spriteFacing;
    private bool direction;
    private float speedTimer;

    // Start is called before the first frame update
    void Start()
    {
        bulldozer = GameObject.Find("bulldozer_updated_0");
        spriteFacing = bulldozer.transform.localScale;
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
            // if its been that way for .75 seconds, flip direction
            if (speedTimer > .75f)
            {
                //print("Flipping direction because speed too low.");
                FlipDirection();
                speedTimer = 0;
            }
        }
        else
        {
            speedTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Moveable") | collision.CompareTag("Player") | collision.CompareTag("Hazard"))
        {

        }
        else
        {
            //print("hit wall, flipping");
            FlipDirection();
        }

        
    }

    private void FlipDirection()
    {
        // goes right if direction == true, otherwise left
        if (direction)
        {
            bulldozer.GetComponent<BulldozerMoveBehavior>().Left(false);
            bulldozer.GetComponent<BulldozerMoveBehavior>().Right(true);
            

            var x = spriteFacing.x;
            var y = spriteFacing.y;
            var z = spriteFacing.z;
            bulldozer.transform.localScale = new Vector3(x, y, z);
            //print("Bulldozer Going right");

            direction = false;
        }
        else
        {
            bulldozer.GetComponent<BulldozerMoveBehavior>().Left(true);
            bulldozer.GetComponent<BulldozerMoveBehavior>().Right(false);
            

            var x = spriteFacing.x;
            var y = spriteFacing.y;
            var z = spriteFacing.z;
            bulldozer.transform.localScale = new Vector3(-x, y, z);
            //print("Bulldozer Going left");

            direction = true;
        }
    }
}
