using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMonsterTigger : MonoBehaviour
{
    public PlatformMonster monster;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            monster.Rise();
        }
        if (collision.CompareTag("Map"))
        {
            monster.Snap();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // monster.Lower();
        }
    }
}
