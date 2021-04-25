using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColliision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "thought") {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((this.transform.localPosition.x * -1), (this.transform.localPosition.y * -1)) * 1f, ForceMode2D.Impulse);
        }
    }
}
