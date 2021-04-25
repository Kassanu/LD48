using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextConvo : MonoBehaviour
{
    public GameManager manager;

    void OnMouseDown()
    {
        this.manager.LoadConversation();
    }
}
