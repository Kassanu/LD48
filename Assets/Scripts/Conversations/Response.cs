using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Response
{
    public string text;

    public int conversationId;

    public bool endConversation;

    public int opinionDelta;

    public int stressDelta;

    public void sendMessage(ChatManager manager)
    {
        manager.addPlayerChatBubble(this.text);
    }
}
