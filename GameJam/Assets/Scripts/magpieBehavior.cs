using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magpieBehavior : MonoBehaviour{
    public Transform newtarget;
    public GameObject grabpoint;
    public AIPath aipath;

    Rigidbody2D rb;
    AIDestinationSetter initialtarget;
    AudioSource flap;
    GameObject grabbable;
    

    private void Update(){
        //if this is causing errors or not working might need to ABS the difference
        if (!flap.isPlaying && (newtarget.position.x - transform.position.x) > 1){
            flap.Play();
        }
    }
    private void Start(){
        aipath = GetComponent<AIPath>();
        rb = GetComponent<Rigidbody2D>();
        flap = GetComponent<AudioSource>();
        initialtarget = GetComponent<AIDestinationSetter>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("shiny")){
            grabbable = collision.gameObject;
            grabbable.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbable.transform.position = grabpoint.transform.position;
            grabbable.transform.SetParent(transform);
            initialtarget.target = newtarget;
        }
        if (collision.CompareTag("Player")){
            print(grabbable.gameObject);
            grabbable.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbable.transform.SetParent(null);
            grabbable = null;
            print("player has hit the bird");
        }
    }
    public void Summon(Vector3 playerLoc, float offset){
        transform.position = playerLoc + new Vector3(offset, 0);
    }
}
