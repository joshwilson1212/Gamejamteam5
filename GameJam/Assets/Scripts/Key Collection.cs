using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollection : MonoBehaviour
{
    public Image testimage;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Key")) {
            print("collided");
            testimage.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
