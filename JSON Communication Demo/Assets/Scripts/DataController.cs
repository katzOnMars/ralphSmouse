using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{

    // Use this for initialization
    public string url;
    public WWW www;

    public Player player1;

    void Start()
    {
        //player1.name = "no name";
        url = "http://tea-125.herokuapp.com/";
        www = new WWW(url);
        StartCoroutine(GetData(www));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Load Initial Player Data
    IEnumerator GetData(WWW www)
    {

        //Wait for request to complete...
        yield return www;

        // Check if www response is null or empty
        if (!string.IsNullOrEmpty(www.error))
            Debug.Log(www.error);

        // save www response
        string jsonText = www.text;

        // DEBUG: print www response
        Debug.Log("www:   " + www.text);

        //Data is in json format, we need to parse the Json.
        player1 = Player.CreateFromJSON(jsonText);

        // DEBUG: print player attributes
        // Debug.Log(player1.name);
        Debug.Log(player1._id);

        StartCoroutine(SaveData(www));
    }


    // Save Player Data
    IEnumerator SaveData(WWW www)
    {
        // Create a form object for sending high score data to the server
        WWWForm form = new WWWForm();

        // Assuming the perl script manages high scores for different games
        //form.AddField("game", "MyGameName");

        // The name of the player submitting the scores
        form.AddField("_id", "Hello World!");

        // The score
        //form.AddField("score", score);

        WWW wwwSave = new WWW(url, form);
        //Wait for request to complete...
        yield return wwwSave;
        Debug.Log("SaveData(): " + wwwSave.text);
    }


}