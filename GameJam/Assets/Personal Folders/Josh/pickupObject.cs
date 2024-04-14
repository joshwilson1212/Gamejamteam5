using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour
{
    public Transform newtarget;
    Rigidbody2D rb;

    AIDestinationSetter initialtarget;
    AudioSource flap;

    public GameObject grabpoint;
    GameObject grabbable;
    public AIPath aipath;
    private void Update()
    {
        print(transform.position.magnitude - newtarget.position.magnitude);
        if (!flap.isPlaying && (transform.position.magnitude - newtarget.position.magnitude) > 7.1)
        {
            
            flap.Play();
        }
    }
    private void Start()
    {
        aipath = GetComponent<AIPath>();
        rb = GetComponent<Rigidbody2D>();
        flap = GetComponent<AudioSource>();
        initialtarget = GetComponent<AIDestinationSetter>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        //if the bird collides with the 
        if (collision.CompareTag("shiny")){
            grabbable = collision.gameObject;
            grabbable.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbable.transform.position = grabpoint.transform.position;
            grabbable.transform.SetParent(transform);

            //Destroy(grabbable);

            
            initialtarget.target = newtarget;
            
            
        }


        if (collision.CompareTag("Player"))
        {
            print(grabbable.gameObject);
            grabbable.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbable.transform.SetParent(null);
            grabbable = null;
            print("player has hit the bird");
        }
    }

    public void Summon(Vector3 playerLoc, float offset)
    {
        transform.position = playerLoc + new Vector3(offset, 0);
    }
}
