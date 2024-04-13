using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMonsterMagpie : MonoBehaviour
{
    public PlatformMonster monster;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") && collision.name == "Magpie")
        {
            monster.Rise();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") && collision.name == "Magpie")
        {
            monster.Lower();
        }
    }
}
