using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    private GameObject[] monsters;
    public float speed = 1f;
    public float offsetX = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var item in monsters)
        {
            // print(item.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (monsters.Length > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, monsters[0].transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.SetActive(false);
            monsters = GameObject.FindGameObjectsWithTag("Monster");
        }
    }

    public void Summon(Vector3 playerLoc, int facing)
    {
        transform.position = playerLoc + new Vector3(offsetX * facing, 0);
    }
}
