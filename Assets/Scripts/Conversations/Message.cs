using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Message
{
    public string text;
    public bool isPlayer;

    public void sendMessage (ChatManager manager)
    {
        if (this.isPlayer)
        {
            manager.addPlayerChatBubble(this.text);
        } else {
            manager.addOtherChatBubble(this.text);
        }
    }
}
