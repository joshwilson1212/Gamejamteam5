using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

//this script is reponsible for swaping the orientation of the sprite depending on the direction its travling in
public class MagpiGraphics : MonoBehaviour
{
    //takes in the aipath of the bird
    public AIPath aipath;

   
    void Update()
    {
        
        if (aipath.desiredVelocity.x >= .01f)
        {
            transform.localScale = new Vector3(-1f,1f, 1f);
        }else if (aipath.desiredVelocity.x <= -.01f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }
}
