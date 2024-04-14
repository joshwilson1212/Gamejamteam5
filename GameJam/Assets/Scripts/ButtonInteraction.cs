using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    private GameObject door;
    private Animator animator;

    public int shutDelay;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("HD_Door");
        animator = GetComponent<Animator>();
        shutDelay = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.isActiveAndEnabled)
        {

        }
        //animator.Play("Not_Pressed");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") | collision.CompareTag("Player"))
        {
            soundManager.Instance.Play(SoundType.DOOR);
            animator.Play("ButtonPress");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") | collision.CompareTag("Player"))
        {
            door.SetActive(false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // await Task.Delay(shutDelay);
        door.SetActive(true);
        animator.speed = 1f;
    }

    public void Freeze()
    {
        animator.speed = 0f;
    }


   
}
