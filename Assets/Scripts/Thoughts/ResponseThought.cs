using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseThought : MonoBehaviour
{

    public GameObject textObject;
    public int id;
    public string text;

    public void updateText()
    {
        this.textObject.GetComponent<TMPro.TextMeshPro>().text = this.text;
    }

    void OnMouseDown()
    {
        var manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        manager.conversationManager.conversation.selectResponse(this.id);
    }
}
