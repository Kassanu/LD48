using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject text;
    public GameObject letter;

    public string[] endings = new string[] {
        "Your true friends will always reach out.",
        "The most important thing is taking care of yourself.",
        "Balancing your relationship is hard but rewarding.",
        "Isolating yourself isn't a good idea.",
        "Surrounding yourself with others can help.",
        "Connections are important.",
    };

    public string[] endingsLetter = new string[] {
        "A",
        "B",
        "C",
        "D",
        "E",
        "F"
    };

    public void Start() {
        var player = GameObject.FindWithTag("Player").GetComponent<Player>();
        this.text.GetComponent<TMPro.TextMeshProUGUI>().text = this.endings[player.endingNumber()];
        this.letter.GetComponent<TMPro.TextMeshProUGUI>().text = this.endingsLetter[player.endingNumber()];
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(0);
    }
}
