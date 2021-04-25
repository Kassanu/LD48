using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrusiveThought : MonoBehaviour
{

    public GameObject text;

    private string[] thoughts = new string[] {
        "No",
        "Don't do it",
        "I can't",
        "I wont",
        "Leave me alone"
    };

    // Start is called before the first frame update
    void Start()
    {
        this.text.GetComponent<TMPro.TextMeshPro>().text = this.thoughts[Random.Range(0,this.thoughts.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.addStress(1);
        // Destroy the gameObject after clicking on it
        Destroy(gameObject);
    }
}
