using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class User
{

    public string userName;
    public float userTime;
    public int exists;

    public User()
    {
        userName = PlayerPrefs.GetString("Username");
        userTime = PlayerPrefs.GetFloat("Highscore");
        exists = 1;
    }

}