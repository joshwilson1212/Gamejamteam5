using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [HideInInspector] public GameInput input;
    public Player player;
    // Start is called before the first frame update
    void Awake()
    {
        print("start");
        input = new GameInput();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.Player.Right.WasPressedThisFrame())
        {
            // print("left");
            player.Right(true);
        }
        if(input.Player.Left.WasPressedThisFrame())
        {
            // print("right");
            player.Left(true);
        }
        if(input.Player.Right.WasReleasedThisFrame())
        {
            player.Right(false);
        }
        if (input.Player.Left.WasReleasedThisFrame())
        {
            player.Left(false);
        }
        if (input.Player.Space.WasPressedThisFrame())
        {
            // print("jump");
            player.Jump();
        }
        
    }
}
