using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    private bool isPlayerAlive;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("DelPlayer", 0.1f);
        }


    }

    private void DelPlayer()
    {   
        if (isPlayerAlive)
        {
            GameObject.Find("Player").SetActive(false);
            isPlayerAlive = false;
        }
        
    }
}
