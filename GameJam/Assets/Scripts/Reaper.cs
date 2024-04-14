using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReaperState
{
    Monster,
    Player
}

public class Reaper : MonoBehaviour
{
    private GameObject[] monsters;
    public float speed = 1f;
    public Player player;
    private ReaperState state;
    private int closestObjectPlace;
    private int tempLength;
    private bool hasTarget;

    // Start is called before the first frame update
    void Awake()
    {
        state = ReaperState.Monster;
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        tempLength = monsters.Length;
        hasTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject closestObject = null;
        // tempLength = monsters.Length;
        // monsters = GameObject.FindGameObjectsWithTag("Monster");
        print("Length: " + monsters.Length);
        if (!hasTarget && monsters.Length != 0)// if (tempLength != monsters.Length || gameObject == null || closestObjectPlace > monsters.Length - 1)
        {
            float shortestDist = Vector3.Distance(monsters[0].transform.position, transform.position);
            closestObjectPlace = 0;
            // foreach (GameObject obj in monsters)
            for (int i = 1; i < monsters.Length; i++)
            {
                GameObject obj = monsters[i];
                float dist = Vector3.Distance(obj.transform.position, transform.position);
                if (dist < shortestDist)
                {
                    shortestDist = dist;
                    closestObjectPlace = i;
                }
            }
            hasTarget = true;
        }
        //}
        if (monsters.Length > 0)
        {
            print(closestObjectPlace);
            state = ReaperState.Monster;
            transform.position = Vector3.MoveTowards(transform.position, monsters[closestObjectPlace].transform.position, speed * Time.deltaTime);
        }
        else if (monsters.Length == 0)
        {
            state = ReaperState.Player;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public ReaperState GetState()
    {
        return state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if(collision.CompareTag("Monster"))
        {
            collision.gameObject.SetActive(false);
            monsters = GameObject.FindGameObjectsWithTag("Monster");
            hasTarget = false;
        }
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    public void Summon(Vector3 playerLoc, float offset)
    {
        transform.position = playerLoc + new Vector3(offset, 0);
    }
}
