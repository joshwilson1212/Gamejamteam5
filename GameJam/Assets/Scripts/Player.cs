using System.Net;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    AudioSource step;
    public float appliedForce = 20;
    public float runForce = 3;
    public float maxSpeed = 4;
    public float damping;

    private Rigidbody2D rb;
    private bool goRight;
    private bool goLeft;
    private bool isGrounded;
    private int facing;
    private bool hasKey;

    //bellow is for summoning
    public PlatformMonster plat;
    public float platOffsetX;
    public float platOffsetY;
    public Reaper reaper;
    public float reaperOffsetX;
    public magpieBehavior magpie;
    public float magpieOffsetX;
    public BulldozerMoveBehavior bulldozer;
    public float bullOffsetX;
    public GameObject highlight;
    private int isHighlighting;

    public bool plantUnlocked;
    public bool bullUnlocked;
    public bool magpieUnlocked;
    public bool reaperUnlocked;

    public Image plant;
    public Image bull;
    public Image maggy;
    public Image reapy;

    private int plantUsed;
    private int bullUsed;
    private int magpieUsed;
    private int reaperUsed;

    // Start is called before the first frame update
    void Start(){
        step = GetComponent<AudioSource>();
        hasKey = false;
        rb = GetComponent<Rigidbody2D>();
        goRight = false;
        goLeft = false;
        isGrounded = false;
        facing = 1;
        isHighlighting = 0;
        plantUsed = 0;
        bullUsed = 0;
        magpieUsed = 0;
        reaperUsed = 0;

    }

    // Update is called once per frame
    void Update(){

        if (plantUnlocked == true && !(plant.gameObject == null)) {
            plant.gameObject.SetActive(true);
        }

        else if (bullUnlocked == true && !(bull.gameObject == null)) {
            bull.gameObject.SetActive(true);
        }
        else if (magpieUnlocked == true && !(maggy.gameObject == null)) {
            maggy.gameObject.SetActive(true);
        }

        else if (reaperUnlocked == true && !(reapy.gameObject == null)) {
            reapy.gameObject.SetActive(true);
        }
        

        if ( rb.velocity.y == 0){
            isGrounded = true;
        }
        else{
            isGrounded= false;
        }
        // print(rb.velocity.x);
        if (goLeft && !goRight && rb.velocity.x > -maxSpeed){
            facing = -1;
            rb.AddForce(Vector3.left * runForce * Time.deltaTime, ForceMode2D.Force);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            if (!step.isPlaying){
                step.Play();
            }
        }
        else if (goRight && !goLeft && rb.velocity.x < maxSpeed){
            facing = 1;
            rb.AddForce(Vector3.right * runForce * Time.deltaTime, ForceMode2D.Force);
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (!step.isPlaying){
                step.Play();
            }
        }
        else if (isGrounded){
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, damping * Time.deltaTime);
        }

        if (isHighlighting == 1){
            highlight.transform.position = transform.position + new Vector3(platOffsetX * facing, -0.3f);
        }
        if (isHighlighting == 2){
            highlight.transform.position = transform.position + new Vector3(magpieOffsetX * facing, 0);
        }
        if (isHighlighting == 3){
            highlight.transform.position = transform.position + new Vector3(bullOffsetX * facing, 0);
        }
        if (isHighlighting == 4){
            highlight.transform.position = transform.position + new Vector3(reaperOffsetX * facing, 0);
        }
    }

    public void Jump(){
        if (isGrounded){ 
            rb.AddForce(Vector2.up * appliedForce, ForceMode2D.Impulse);
        }
    }

    public void Left(bool act){
        goLeft = act;
    }

    public void Right(bool act){
        goRight = act;
    }

    public void SummonPlatform(){
        if (!plat.isActiveAndEnabled && plantUnlocked && plantUsed < 2){
            isHighlighting = 0;
            highlight.SetActive(false);
            plat.gameObject.SetActive(true);
            plat.Summon(transform.position,  facing * platOffsetX, platOffsetY);
            plantUsed++;
            plant.color = new Color(1f, 1f, 1f, 0.3f);
        }
    }

    public void HighlightPlatform(){
        if (!plat.isActiveAndEnabled && plantUnlocked && plantUsed < 2)
        {
            isHighlighting = 1;
            highlight.SetActive(true);
        }
    }

    public void SummonMagpie(){
        if (!magpie.isActiveAndEnabled && magpieUnlocked && magpieUsed < 2)
        {
            isHighlighting = 0;
            highlight.SetActive(false);
            magpie.gameObject.SetActive(true);
            magpie.Summon(transform.position, facing * magpieOffsetX);
            magpieUsed++;
            maggy.color = new Color(1f, 1f, 1f, 0.3f);
        }
    }

    public void HighlightMagpie(){
        if (!magpie.isActiveAndEnabled && magpieUnlocked && magpieUsed < 2)
        {
            isHighlighting = 2;
            highlight.SetActive(true);
        }
    }

    public void SummonBulldozer(){
        if (!bulldozer.isActiveAndEnabled && bullUnlocked && bullUsed < 2)
        {
            isHighlighting = 0;
            highlight.SetActive(false);
            bulldozer.gameObject.SetActive(true);
            bulldozer.Summon(transform.position, facing * reaperOffsetX, facing);
            bullUsed++;
            bull.color = new Color(1f, 1f, 1f, 0.3f);
        }
    }

    public void HighlightBulldozer()
    {
        if (!bulldozer.isActiveAndEnabled && bullUnlocked && bullUsed < 2)
        {
            isHighlighting = 3;
            highlight.SetActive(true);
        }
    }

    public void SummonReaper(){
        if (!reaper.isActiveAndEnabled && reaperUnlocked){
            isHighlighting = 0;
            highlight.SetActive(false);
            reaper.gameObject.SetActive(true);
            reaper.Summon(transform.position, facing * reaperOffsetX);
            reaperUsed++;
            reapy.color = new Color(1f, 1f, 1f, 0.3f);
        }
    }

    public void HighlightReaper(){
        if (!reaper.isActiveAndEnabled && reaperUnlocked)
        {
            isHighlighting = 4;
            highlight.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("shiny")){
            Destroy(collision.gameObject);
            hasKey = true;
            soundManager.Instance.Play(SoundType.DING);
        }

        if (collision.gameObject.CompareTag("Door")){
            if (hasKey){
                Destroy(collision.gameObject);
                soundManager.Instance.Play(SoundType.DOOR);
            }
        }
        if (collision.gameObject.CompareTag("PlantSpell"))
        {
            collision.gameObject.SetActive(false);
            plantUnlocked = true;
        }
        if (collision.gameObject.CompareTag("BullSpell"))
        {
            collision.gameObject.SetActive(false);
            bullUnlocked = true;
        }
        if (collision.gameObject.CompareTag("MagSpell"))
        {
            collision.gameObject.SetActive(false);
            magpieUnlocked = true;
        }
        if (collision.gameObject.CompareTag("ReapSpell"))
        {
            collision.gameObject.SetActive(false);
            reaperUnlocked = true;
        }
    }
}
