using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour
{
    public Transform newtarget;


    AIDestinationSetter initialtarget;



    public GameObject grabpoint;
    GameObject grabbable;


    private void Start()
    {
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



}
