using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player  {

    //public string name;
    public string _id;

    public static Player CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Player>(jsonString);
    }

}
