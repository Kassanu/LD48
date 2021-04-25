using System.Collections;
using System.Collections.Generic;

public class CharacterConversation
{
    public string fileName;

    public bool seen = false;

    public int minOpinion, maxOpinion;

    public CharacterConversation(string fileName, int minOpinion, int maxOpinion)
    {
        this.fileName = fileName;
        this.minOpinion = minOpinion;
        this.maxOpinion = maxOpinion;
    }
}
