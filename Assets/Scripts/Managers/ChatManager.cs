using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public List<GameObject> chatBubbles = new List<GameObject>();
    public GameObject playerChatBubble;
    public GameObject otherChatBubble;

    public void addPlayerChatBubble(string text)
    {
        this.addChatBubble(this.playerChatBubble, text);
    }

    public void addOtherChatBubble(string text)
    {
        this.addChatBubble(this.otherChatBubble, text);
    }

    private void addChatBubble(GameObject prefab, string text)
    {
        this.shiftAllChatBubblesUp();
        GameObject bubble = Instantiate(prefab, this.transform);
        bubble.transform.localPosition = new Vector3(0f, -3.5f, 0f);
        bubble.GetComponentInChildren<TMPro.TextMeshPro>().text = text;
        this.chatBubbles.Insert(0, bubble);
    }

    private void shiftAllChatBubblesUp()
    {
        foreach (var bubble in this.chatBubbles)
        {
            bubble.transform.localPosition = new Vector3(0f, bubble.transform.localPosition.y + 1.25f, 0f);
        }
    }

    public void removeAllChatBubbles()
    {
        while (this.transform.childCount > 0)
        {
            DestroyImmediate(this.transform.GetChild(0).gameObject);
        }
        this.chatBubbles = new List<GameObject>();
    }
}
