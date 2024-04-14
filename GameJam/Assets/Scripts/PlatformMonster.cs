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
    public float timeToAnim = 1;
    private float originalHeight;
    public float riseSpeed = 1.5f;
    private PlatformState state;
    private bool snapped;
    public GameObject snapArea;
    public float offsetX = 3;
    private Animator anim;
    private AudioSource audioSource;

    void Awake()
    {
        originalHeight = transform.position.y;
        state = PlatformState.IDLE;
        snapped = false;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (state == PlatformState.RISING && transform.position.y < originalHeight + riseHeight && !snapped)
        {
            // transform.position = new Vector3(transform.position.x, transform.position.y * riseSpeed * Time.deltaTime, transform.position.z);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, originalHeight + riseHeight, transform.position.z), riseSpeed * Time.deltaTime);
        }
        else if (state == PlatformState.FALLING)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, originalHeight, transform.position.z), riseSpeed * Time.deltaTime);
        }
        if (transform.position.y >= (originalHeight + riseHeight) - (originalHeight + riseHeight) * 0.05 && !snapped)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            Invoke("SnapAnim", timeToAnim);
            Invoke("Snap", timeToAttack);
        }
        if (transform.position.y == (originalHeight))
        {
            // print("Down");
            snapped = false;
            snapArea.SetActive(false);
            anim.Play("FlytrapOpen");
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

    public void SnapAnim()
    {
        if (!snapped)
        {
            soundManager.Instance.Play(SoundType.SNAPPERSNAP);
            anim.Play("Flytrap");
        }
    }

    public void Snap()
    {
        if (!snapped)
        { 
            snapArea.SetActive(true);
            // print("SNAPED");
            snapped = true;
            Lower();
        }
    }

    public void Summon(Vector3 playerLoc, float offset, float offsetY)
    {
        transform.position = playerLoc + new Vector3(offset, offsetY);
    }
}
