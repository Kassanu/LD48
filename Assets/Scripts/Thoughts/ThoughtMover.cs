using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtMover : MonoBehaviour
{

    public float directionChangeTime;
    private float nextDirectionChange = 0f;

    void Start()
    {
        this.nextDirectionChange = Time.time;
    }

    void Update()
    {
        if (Time.time > this.nextDirectionChange) {
            this.nextDirectionChange = Time.time + this.directionChangeTime;
            // impart random force
            var direction = new Vector2(Random.Range(0f, 360f),Random.Range(0f, 360f));
            this.GetComponent<Rigidbody2D>().AddForce(direction);
        }
    }
}
