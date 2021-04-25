using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Character> characters;

    public ConversationManager conversationManager;

    public Player player;

    public Character character;

    private bool convoLoaded = false;

    public GameObject nextConvoContainer;

    private int spamChance = 0;

    private int conversationsSeen = 0;

    public Character spam;
    public Character john;

    private bool johnEnding = false;

    private bool first = true;

    void Awake()
    {
        this.player.reset();
        this.createCharacters();
        this.player.characters = this.characters;
        this.LoadConversation();
    }

    public void LoadConversation()
    {
        this.nextConvoContainer.SetActive(false);
        var randomSpam = Random.Range(1, 101);
        var isSpam = this.spamChance >= randomSpam;

        if (isSpam)
        {
            this.character = this.spam;
            this.spamChance = 0;
        }
        else if (this.first)
        {
            this.character = this.characters[0];
            this.first = false;
        }
        else
        {
            this.character = this.getRandomCharacter();
            this.spamChance += Random.Range(1, 7);
        }

        CharacterConversation convo;

        if (isSpam)
        {
            convo = character.getRandomConversation();
        }
        else
        {
            convo = character.getNextConversation();
            convo.seen = true;
            this.conversationsSeen++;
        }

        var jsonTextFile = Resources.Load<TextAsset>("Conversations/" + convo.fileName);
        this.conversationManager = JsonUtility.FromJson<ConversationManager>(jsonTextFile.text);
        this.conversationManager.Awake();
        this.conversationManager.chatManager.removeAllChatBubbles();
        this.conversationManager.speaker = character;
        this.convoLoaded = true;
        if (this.player.stress == 100) {
            this.player.fullStressCount += 1;
        } else {
            this.player.fullStressCount = 0;
        }
        this.conversationManager.Start();
    }

    public void LoadJohnEndConversation()
    {
        this.nextConvoContainer.SetActive(false);
        this.character = this.john;
        var convo = character.conversations[0];
        convo.seen = true;
        this.conversationsSeen++;
        this.johnEnding = true;
        this.player.johnEnding = true;
        var jsonTextFile = Resources.Load<TextAsset>("Conversations/" + convo.fileName);
        this.conversationManager = JsonUtility.FromJson<ConversationManager>(jsonTextFile.text);
        this.conversationManager.Awake();
        this.conversationManager.chatManager.removeAllChatBubbles();
        this.conversationManager.speaker = character;
        this.convoLoaded = true;
        this.conversationManager.Start();
    }

    public void EndConversation()
    {
        this.convoLoaded = false;
        if (this.player.fullStressCount > 4) {
            this.EndGame();
        }
        this.nextConvoContainer.SetActive(true);
    }

    public void EndGame()
    {
        if (this.johnEndCondition())
        {
            this.LoadJohnEndConversation();
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public bool johnEndCondition()
    {
        return !this.johnEnding && this.player.stress >= 75 && this.player.negativeOpinions() > 2 && this.player.fullStressCount <= 4 && this.conversationsSeen > 8;
    }

    void Update()
    {
        if (this.convoLoaded)
        {
            this.conversationManager.Update();
        }
    }

    void createCharacters()
    {
        this.characters = new List<Character>();

        var john = new Character("John", 80);
        john.conversations.Add(new CharacterConversation("John/1", -100, 100));
        john.conversations.Add(new CharacterConversation("John/raid", -100, 100));
        john.conversations.Add(new CharacterConversation("John/newpatchannouncement", -100, 100));
        john.conversations.Add(new CharacterConversation("John/round", -100, 100));
        john.conversations.Add(new CharacterConversation("John/dungeon", -100, 100));
        john.conversations.Add(new CharacterConversation("John/newtrailer", -100, 100));
        john.conversations.Add(new CharacterConversation("John/raid", -100, 100));
        john.conversations.Add(new CharacterConversation("John/newpatch", -100, 100));
        john.conversations.Add(new CharacterConversation("John/convention", -100, 100));
        john.conversations.Add(new CharacterConversation("John/newgame", -100, 100));
        john.conversations.Add(new CharacterConversation("John/dungeon", -100, 100));
        this.characters.Add(john);

        var chris = new Character("Chris", 50);
        chris.conversations.Add(new CharacterConversation("Chris/1", 0, 100));
        chris.conversations.Add(new CharacterConversation("Chris/2", 0, 100));
        chris.conversations.Add(new CharacterConversation("Chris/3", 0, 100));
        chris.conversations.Add(new CharacterConversation("Chris/4", 0, 100));
        chris.conversations.Add(new CharacterConversation("Chris/5", 0, 100));
        chris.conversations.Add(new CharacterConversation("Chris/6", 0, 100));
        chris.conversations.Add(new CharacterConversation("Chris/high1", 65, 100));
        chris.conversations.Add(new CharacterConversation("Chris/low1", 0, 35));
        chris.conversations.Add(new CharacterConversation("Chris/low2", 0, 35));
        chris.conversations.Add(new CharacterConversation("Chris/negative1", -100, -1));
        this.characters.Add(chris);

        var sarah = new Character("Sarah", 35);
        sarah.conversations.Add(new CharacterConversation("Sarah/1", 0, 100));
        sarah.conversations.Add(new CharacterConversation("Sarah/birthday1", 0, 100));
        sarah.conversations.Add(new CharacterConversation("Sarah/ride", 0, 100));
        sarah.conversations.Add(new CharacterConversation("Sarah/print", 0, 100));
        sarah.conversations.Add(new CharacterConversation("Sarah/dinner1", 0, 100));
        sarah.conversations.Add(new CharacterConversation("Sarah/borrowcar", 0, 100));
        sarah.conversations.Add(new CharacterConversation("Sarah/negative1", -100, -1));
        this.characters.Add(sarah);

        var matt = new Character("Matt", 40);
        matt.conversations.Add(new CharacterConversation("Matt/1", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/2", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/3", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/4", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/5", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/6", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/7", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/8", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/9", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/10", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/11", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/12", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/13", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/14", 0, 100));
        matt.conversations.Add(new CharacterConversation("Matt/15", 0, 100));
        this.characters.Add(matt);

        // special characters

        this.john = new Character("John", 10);
        this.john.conversations.Add(new CharacterConversation("John/end", -100, 100));

        this.spam = new Character("Spam", 0);
        this.spam.conversations.Add(new CharacterConversation("Spam/1", -100, 100));
        this.spam.conversations.Add(new CharacterConversation("Spam/2", -100, 100));
        this.spam.conversations.Add(new CharacterConversation("Spam/3", -100, 100));
        this.spam.conversations.Add(new CharacterConversation("Spam/4", -100, 100));
    }

    public void changeOpinion(int delta)
    {
        this.character.addOpinion(delta);
    }

    private Character getRandomCharacter()
    {
        var validCharacters = this.characters.FindAll(character => character.hasValidConversation());

        if (validCharacters.Count == 0)
        {
            this.EndGame();
        }

        return validCharacters[Random.Range(0, validCharacters.Count)];
    }
}
