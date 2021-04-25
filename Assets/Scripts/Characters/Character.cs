using System.Collections;
using System.Collections.Generic;

public class Character
{
    public string name;

    public int opinion;

    public List<CharacterConversation> conversations;

    public Character (string name, int opinion) {
        this.name = name;
        this.opinion = opinion;
        this.conversations = new List<CharacterConversation>();
    }

    public void addOpinion(int opinion)
    {
        if (this.opinion + opinion < -100)
        {
            this.opinion = -100;
        }
        else if (this.opinion + opinion > 100)
        {
            this.opinion = 100;
        }
        else
        {
            this.opinion += opinion;
        }
    }

    public CharacterConversation getNextConversation()
    {
        return this.conversations.Find(this.validConversation);
    }

    public CharacterConversation getRandomConversation()
    {
        return this.conversations[UnityEngine.Random.Range(0, this.conversations.Count)];
    }

    public bool hasValidConversation() {
        var found = this.conversations.FindAll(this.validConversation);
        return found.Count > 0;
    }

    private bool validConversation (CharacterConversation convo)
    {
        return convo.seen == false && this.opinion >= convo.minOpinion && this.opinion <= convo.maxOpinion;
    }
}
