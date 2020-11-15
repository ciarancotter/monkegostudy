using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{

    public Text statusMessage;

    public void SelectWebDev()
    {
        PlayerPrefs.SetString("module", "webdevelopment");
        statusMessage.text = "Selected Module: Web Development";

    }

    public void SelectDB()
    {
        PlayerPrefs.SetString("module", "relationaldatabases");
        statusMessage.text = "Selected Module: Relational Databases";
    }

    public void SelectFoundations()
    {
        PlayerPrefs.SetString("module", "foundationsofcomputerscience");
        statusMessage.text = "Selected Module: Foundations of Computer Science";
    }

    public void SelectSysOrg()
    {
        PlayerPrefs.SetString("module", "systemsorganisation");
        statusMessage.text = "Selected Module: Systems Organisation";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Title");
    }
}
