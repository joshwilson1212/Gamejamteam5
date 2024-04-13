using UnityEngine;

public class Player : MonoBehaviour
{
    public float appliedForce = 20;
    public float runForce = 3;
    public float damping;
    private Rigidbody2D rb;
    private bool goRight;
    private bool goLeft;
    private bool isGrounded;
    private int facing;

    public PlatformMonster plat;
    public float platOffsetX;
    public float platOffsetY;
    public Reaper reaper;
    public float reaperOffsetX;
    public pickupObject magpie;
    public float magpieOffsetX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goRight = false;
        goLeft = false;
        isGrounded = false;
        facing = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ( rb.velocity.y == 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded= false;
        }
        if (goLeft && !goRight)
        {
            facing = -1;
            rb.AddForce(Vector3.left * runForce * Time.deltaTime, ForceMode2D.Force);
        }
        else if (goRight && !goLeft)
        {
            facing = 1;
            rb.AddForce(Vector3.right * runForce * Time.deltaTime, ForceMode2D.Force);
        }
        else if (isGrounded)
        {
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, damping * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (isGrounded) 
        { 
            rb.AddForce(Vector2.up * appliedForce, ForceMode2D.Impulse);
        }
    }

    public void Left(bool act)
    {
        goLeft = act;
    }

    public void Right(bool act)
    {
        goRight = act;
    }

    public void SummonPlatform()
    {
        // print(plat.isActiveAndEnabled);
        if (!plat.isActiveAndEnabled)
        {
            plat.gameObject.SetActive(true);
            plat.Summon(transform.position,  facing * platOffsetX);
        }
    }

    public void SummonReaper()
    {
        // print(plat.isActiveAndEnabled);
        if (!reaper.isActiveAndEnabled)
        {
            reaper.gameObject.SetActive(true);
            reaper.Summon(transform.position, facing * reaperOffsetX);
        }
    }

    public void SummonMagpie()
    {
        // print(plat.isActiveAndEnabled);
        if (!magpie.isActiveAndEnabled)
        {
            magpie.gameObject.SetActive(true);
            magpie.Summon(transform.position, facing * magpieOffsetX);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
    }
}
