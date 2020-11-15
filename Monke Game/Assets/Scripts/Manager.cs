using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public InputField username;
    public GameObject namePanel;
    public Text welcomeText;
    public Text coinText;
    public GameObject creditPanel;
    



    void Start()
    {
        if(!PlayerPrefs.HasKey("Username")){
            namePanel.SetActive(true);
        }
        if(PlayerPrefs.HasKey("Username"))
        {   
            welcomeText.text = "Welcome, " + PlayerPrefs.GetString("Username");
            coinText.text = PlayerPrefs.GetInt("coin").ToString();
            
        }
    }

    
    public void quizLoad(){
        SceneManager.LoadScene("SubjectSelection");
    }

    public void shopLoad(){
        SceneManager.LoadScene("Shop");
    }

    public void leaderboardLoad(){
        SceneManager.LoadScene("Leaderboard");
    }

    public void gambleLoad(){
        SceneManager.LoadScene("Gambling");
    }

    public void petLoad(){
        SceneManager.LoadScene("PetSelection");
    }

    public void creditDisplay()
    {
        creditPanel.SetActive(true);
    }

    public void returnToMain()
    {
        creditPanel.SetActive(false);
    }

    public void submitUserName(){
        
        int randomID = Random.Range(0,1000000);
        PlayerPrefs.SetString("Username", username.text);
        namePanel.SetActive(false);
        PlayerPrefs.SetInt("coin", 0);
        PlayerPrefs.SetFloat("WDhighscore", 1000);
        PlayerPrefs.SetFloat("FOCShighscore", 1000);
        PlayerPrefs.SetFloat("DBhighscore", 1000);
        PlayerPrefs.SetFloat("SOhighscore", 1000);
        PlayerPrefs.SetString("scoretype", "WDhighscore");
        PlayerPrefs.SetInt("ID", randomID);
        PlayerPrefs.SetInt("hasFrog", 0);
        PlayerPrefs.SetInt("hasHog", 0);
        PlayerPrefs.SetInt("hasRock", 0);
        PlayerPrefs.SetInt("hasBee", 0);
        PlayerPrefs.SetInt("hasHerb", 0);
        PlayerPrefs.SetString("pet", "none");
        welcomeText.text = "Welcome, " + PlayerPrefs.GetString("Username");
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }


}
