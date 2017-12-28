using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DatabaseManager : MonoBehaviour {

	public static DatabaseManager sharedInstance = null;
	
	// 
	void Awake () {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        } else if (sharedInstance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://cats-on-mars.firebaseio.com/");
        Debug.Log (Router.Players());
        Router.Players().SetValueAsync("testing 1, 2, 3");
	}


}
