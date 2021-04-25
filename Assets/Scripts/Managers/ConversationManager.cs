using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ConversationManager
{
    public ChatManager chatManager;
    public ThoughtsManager thoughtManager;
    public GameManager gameManager;

    public Conversation conversation;

    public List<Conversation> conversations;

    public Character speaker;

    public void Awake()
    {
        this.chatManager = GameObject.FindWithTag("chatmanager").GetComponent<ChatManager>();
        this.thoughtManager = GameObject.FindWithTag("thoughtcontainer").GetComponent<ThoughtsManager>();
        this.gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    public void Start()
    {
        GameObject.FindWithTag("convoname").GetComponent<TMPro.TextMeshPro>().text = this.speaker.name;
        this.changeConversation(0);
    }

    public void Update()
    {
        this.conversation.Update();
    }

    public void endConversation()
    {
        this.thoughtManager.removeAllThoughts();
        this.gameManager.EndConversation();
    }

    public void changeConversation(int id)
    {
        this.thoughtManager.removeAllThoughts();
        this.conversation = this.conversations[id];
        if (this.conversation.timeout > 0) {
            this.thoughtManager.spawnIntrusiveThoughts();
        }
        this.conversation.manager = this;
        this.conversation.Start();
    }
}
