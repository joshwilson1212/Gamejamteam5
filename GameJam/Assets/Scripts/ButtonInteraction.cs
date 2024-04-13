using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    private GameObject door;

    public int shutDelay;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Triangle");
        shutDelay = 500;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") | collision.CompareTag("Player"))
        {
            door.SetActive(false);
        }
        
    }

    private async void OnTriggerExit2D(Collider2D collision)
    {
        await Task.Delay(shutDelay);
        door.SetActive(true);
    }

   
}
