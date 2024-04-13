using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [HideInInspector] public GameInput input;
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
            print("left");
        }
        if(input.Player.Left.WasPressedThisFrame())
        {
            print("right");
        }
        
    }
}
