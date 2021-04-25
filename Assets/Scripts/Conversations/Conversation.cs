using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Conversation
{
    public ConversationManager manager;
    public List<Message> messages;
    public List<Message> timeoutMessages;
    public List<Response> responses;

    public TMPro.TextMeshPro timeoutCountdown;

    public int timeout;

    public int timeoutConversationId;

    public bool timeoutEndConversation;

    private float timeoutTime;

    private int timeoutOpinionDelta;

    private bool timedOut = false;

    public void Start()
    {
        this.timeoutTime = Time.time + this.timeout;
        this.timeoutCountdown = GameObject.FindWithTag("timeoutcountdown").GetComponent<TMPro.TextMeshPro>();
        this.loadMessages(this.messages);
        this.loadResponseThoughts();
    }

    public void Update()
    {
        if (!this.timedOut && Time.time > this.timeoutTime)
        {
            this.timedOut = true;
            this.timeoutCountdown.text = "";
            this.loadMessages(this.timeoutMessages);
            this.manager.gameManager.changeOpinion(this.timeoutOpinionDelta);
            if (this.timeoutEndConversation)
            {
                this.manager.endConversation();
            }
            else
            {
                this.manager.changeConversation(this.timeoutConversationId);
            }
        } else {
            this.timeoutCountdown.text = Mathf.RoundToInt(this.timeoutTime - Time.time).ToString();
        }
    }

    public void selectResponse(int id)
    {
        this.responses[id].sendMessage(this.manager.chatManager);
        this.manager.gameManager.changeOpinion(this.responses[id].opinionDelta);
        this.manager.gameManager.player.addStress(this.responses[id].stressDelta);
        if (this.responses[id].endConversation)
        {
            this.manager.endConversation();
        }
        else
        {
            this.manager.changeConversation(this.responses[id].conversationId);
        }
    }

    private void loadMessages(List<Message> messages)
    {
        foreach (var message in messages)
        {
            message.sendMessage(this.manager.chatManager);
        }
    }

    private void loadResponseThoughts()
    {
        for (var i = 0; i < this.responses.Count; i++)
        {
            var response = this.responses[i];
            this.manager.thoughtManager.spawnResponse(i, response.text);
        }
    }
}
