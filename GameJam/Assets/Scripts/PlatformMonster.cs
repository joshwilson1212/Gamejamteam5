using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformState {
    IDLE,
    RISING,
    FALLING,
}

public class PlatformMonster : Charater
{
    public float riseHeight = 10;
    public float timeToAttack = 2;
    private float originalHeight;
    public float riseSpeed = 1.5f;
    private PlatformState state;
    private bool snapped;
    public GameObject snapArea;

    void Awake()
    {
        originalHeight = transform.position.y;
        state = PlatformState.IDLE;
        snapped = false;
    }

    void Update()
    {
        if (state == PlatformState.RISING && transform.position.y < originalHeight + riseHeight)
        {
            // transform.position = new Vector3(transform.position.x, transform.position.y * riseSpeed * Time.deltaTime, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, originalHeight + riseHeight, transform.position.z), riseSpeed * Time.deltaTime);
        }
        else if (state == PlatformState.FALLING)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, originalHeight, transform.position.z), riseSpeed * Time.deltaTime);
        }
        if (transform.position.y >= (originalHeight + riseHeight) - (originalHeight + riseHeight) * 0.05 && !snapped)
        {
            Invoke("Snap", timeToAttack);
        }
        if (transform.position.y == (originalHeight))
        {
            // print("Down");
            snapped = false;
            snapArea.SetActive(false);
        }
    }

    public void Rise()
    {
        state = PlatformState.RISING;
    }

    public void Lower()
    {
        state = PlatformState.FALLING;
    }

    public void Snap()
    {
        if (!snapped)
        {
            snapArea.SetActive(true);
            // print("SNAPED");
            snapped = true;
        }
    }
}
