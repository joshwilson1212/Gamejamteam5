using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollection : MonoBehaviour
{
    public Image testimage;
    public GameObject key;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Key")) {
            print("collided");
            testimage.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
