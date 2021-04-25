using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressBar : MonoBehaviour
{
    Player player;
    public int minStress;
    public int maxStress;

    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (this.player.stress > maxStress) {
            this.GetComponent<Renderer>().enabled = false;
        } else {
            this.GetComponent<Renderer>().enabled = true;
        }
    }
}
