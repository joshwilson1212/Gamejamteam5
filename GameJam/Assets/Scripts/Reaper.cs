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
    // Start is called before the first frame update
    void Awake()
    {
        state = ReaperState.Monster;
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var item in monsters)
        {
            // print(item.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        if (monsters.Length > 0)
        {
            state = ReaperState.Monster;
            transform.position = Vector3.MoveTowards(transform.position, monsters[0].transform.position, speed * Time.deltaTime);
        }
        else if (monsters.Length == 5)
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
