using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsManager : MonoBehaviour
{
    public Player player;

    public IntrusiveThought intrusivePrefab;

    public ResponseThought responsePrefab;

    // Start is called before the first frame update
    public void spawnIntrusiveThoughts()
    {
        for (var i = 0; i < this.player.intrusiveThoughtsCount(); i++) {
            var thought = Instantiate(this.intrusivePrefab, this.transform);
            thought.transform.localPosition = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-4f, 4f), 0f);
        }
    }

    public void spawnResponse(int id, string text)
    {
        var response = (ResponseThought) Instantiate(this.responsePrefab, this.transform);
        response.transform.localPosition = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-4f, 4f), 0f);
        response.text = text;
        response.id = id;
        response.updateText();
    }

    public void removeAllThoughts()
    {
        while (this.transform.childCount > 0) {
            DestroyImmediate(this.transform.GetChild(0).gameObject);
        }
    }
}
