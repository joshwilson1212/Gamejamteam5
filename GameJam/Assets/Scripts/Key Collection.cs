using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollection : MonoBehaviour
{
    public Image keyImage;
    public GameObject key;
    public Image circleImage;  // drag collection circle here from gameplayUI -> key collected
    private Animator animator;

    private void Start() {
        animator = circleImage.GetComponent<Animator>();
    }

    private void Update() {
        animator.Play("circleSpin");
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Key")) {
            print("collided");
            keyImage.color = new Color(1f, 1f, 1f, 1f);
            circleImage.transform.localScale += new Vector3(2.094982f, 1.410473f, 1.426031f);
        }
    }
}
