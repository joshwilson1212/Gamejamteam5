using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISummonKeys : MonoBehaviour
{
    public Image plant;
    public Image bull;
    public Image magPie;
    public Image reaper;

    public Player p;

    // Start is called before the first frame update
    void Start()
    {
        if (p.plantUnlocked == true) {
            plant.enabled = true;
        }

        if (p.bullUnlocked == true) {
            bull.enabled = true;
        }
        if (p.magpieUnlocked == true) {
            magPie.enabled = true;
        }

        if (p.reaperUnlocked == true) {
            reaper.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
