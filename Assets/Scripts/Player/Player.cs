using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Character> characters;
    public int stress = 50;

    public bool johnEnding = false;
    public int fullStressCount = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void reset()
    {
        this.stress = 50;
    }

    public int endingNumber()
    {
        if (this.johnEnding) {
            return 0;
        } else if (this.fullStressCount > 4) {
            return 1;
        } else if (this.stress <= 50 && this.positiveOpinions() == this.negativeOpinions()) {
            return 2;
        } else if (this.positiveOpinions() < this.negativeOpinions()) {
            return 3;
        } else if (this.stress < 50 && this.positiveOpinions() > this.negativeOpinions()) {
            return 4;
        }

        return 5;
    }

    public int positiveOpinions()
    {
        var validCharacters = this.characters.FindAll(character => character.opinion >= 0);
        return validCharacters.Count;
    }

    public int negativeOpinions()
    {
        var validCharacters = this.characters.FindAll(character => character.opinion < 0);
        return validCharacters.Count;
    }

    public int intrusiveThoughtsCount()
    {
        if (this.stress >= 0 && this.stress <= 24)
        {
            return 1;
        }
        else if (this.stress >= 25 && this.stress <= 49)
        {
            return 2;
        }
        else if (this.stress >= 50 && this.stress <= 74)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }

    public void addStress(int stress)
    {
        if (this.stress + stress < 0)
        {
            this.stress = 0;
        }
        else if (this.stress + stress > 100)
        {
            this.stress = 100;
        }
        else
        {
            this.stress += stress;
        }
    }
}
