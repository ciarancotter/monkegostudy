using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using Proyecto26;

public class GameManager : MonoBehaviour
{
    //Handle questions and answers
    public Question [] webdevquestions;
    public Question [] foundationsquestions;
    public Question [] DBquestions;
    public Question [] sysorgquestions;
    private static List<Question> unansweredQuestions;
    private static List<string> unselectedAnswers = new List<string>();
    private Question currentQuestion;

    //Some UI
    [SerializeField]
    private Text factText;
    [SerializeField]
    private Text op1Text1;
    [SerializeField]
    private Text op1Text2;
    [SerializeField]
    private Text op1Text3;
    [SerializeField]
    private Text op1Text4;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private Text timeScore;
    [SerializeField]
    private Text Monkoins;
    [SerializeField]
    private Text Banc;
    [SerializeField]
    private Text highText;
    [SerializeField]
    private Image petImage;
    [SerializeField]
    private GameObject Lead;
    [SerializeField]
    public AudioSource effectSource;

    //Some other variables
    private float delay = 1f;
    public float timeStart = 0;
    public bool timing;
    public Text timeTrack;
    private string myTime;
    private int roundTime;
    public static int playerScore;
    public static string playerName;
    public static bool existence;
    private int koinage;
    private int currentKoin;
    private int newBal;
    public bool allAnswered = false;
    private string selectedPet;
    private string chosenQuestionSet;
    private float high;
    private bool foundEmpty = false;
    private int names = 0;
    private int myID;
    private int qCount;
    const string webURL = "http://dreamlo.com/lb/";
    private string WDprivateCode = "2AVKVxuT2kCsSYGXzNn94g3-MWki3d_kKIcTxaZKWpWQ";
	private string IPprivateCode = "uxiU9T8WEkivp4XTXFL2LwjCbXeNTTCEutfjWGTDXj_w";
	private string FCprivateCode = "qoFe6rtxV0adfPa9rNpIag0p1imLIxr0aySTtP-XC4eA";
	private string SOprivateCode = "5S-jlo5yVkSNyJ1D36JZZAFaRei0A2Wkm1Mca_PJ9CNg";
    private string selectedPrivateCode;
    private string scoreType;

    //Sprites
    [SerializeField]
    private Sprite frogSprite;
    [SerializeField]
    private Sprite hogSprite;
    [SerializeField]
    private Sprite herbSprite;
    [SerializeField]
    private Sprite beeSprite;
    [SerializeField]
    private Sprite rockSprite;
    [SerializeField]
    private Sprite wombatSprite;
    [SerializeField]
    private Sprite dragonSprite;
    [SerializeField]
    private AudioClip happyOoh;
    [SerializeField]
    private AudioClip sadOoh;
    [SerializeField]
    private AudioClip earRapeOoh;
    
    void Start()
    {   
        selectedPet = PlayerPrefs.GetString("pet");
        //Set the pet
        if(selectedPet == "frog")
        {
            petImage.sprite = frogSprite;
            Lead.SetActive(true);
        }
        if(selectedPet == "hog")
        {
            petImage.sprite = hogSprite;
            Lead.SetActive(true);
        }
        if(selectedPet == "herb")
        {
            petImage.sprite = herbSprite;
            Lead.SetActive(true);
        }
        if(selectedPet == "bee")
        {
            petImage.sprite = beeSprite;
            petImage.enabled = true;
            Lead.SetActive(true);
        }
        if(selectedPet == "rock")
        {
            petImage.sprite = rockSprite;
            petImage.enabled = true;
            Lead.SetActive(true);
        }
        if(selectedPet == "wombat")
        {
            petImage.sprite = wombatSprite;
            petImage.enabled = true;
            Lead.SetActive(true);
        }
        if(selectedPet == "dragon")
        {
            petImage.sprite = dragonSprite;
            petImage.enabled = true;
            Lead.SetActive(true);
        }

        if(selectedPet == "none")
        {
            Lead.SetActive(false);
        }



        gameOver.SetActive(false);
        timeStart = 0;
        timing = true;
        timeTrack.text = timeStart.ToString();
        chosenQuestionSet = PlayerPrefs.GetString("module");
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            if(chosenQuestionSet == "webdevelopment")
            {
                unansweredQuestions = webdevquestions.ToList<Question>();
                qCount = webdevquestions.Count();
                PlayerPrefs.SetString("scoretype", "WDhighscore");
                high = PlayerPrefs.GetFloat("WDhighscore");
            }
            else if(chosenQuestionSet == "foundationsofcomputerscience")
            {
                unansweredQuestions = foundationsquestions.ToList<Question>();
                qCount = foundationsquestions.Count();
                PlayerPrefs.SetString("scoretype", "FOCShighscore");
                high = PlayerPrefs.GetFloat("FOCShighscore");
            }
            else if(chosenQuestionSet == "relationaldatabases")
            {
                unansweredQuestions = DBquestions.ToList<Question>();
                qCount = DBquestions.Count();
                PlayerPrefs.SetString("scoretype", "DBhighscore");
                high = PlayerPrefs.GetFloat("DBhighscore");
            }
            else
            {
                unansweredQuestions = sysorgquestions.ToList<Question>();
                qCount = sysorgquestions.Count();
                PlayerPrefs.SetString("scoretype", "SOhighscore");
                high = PlayerPrefs.GetFloat("SOhighscore");
            }


            
        }
        SetCurrentQuestion();
        unselectedAnswers.Add(currentQuestion.correctAnswer);
        unselectedAnswers.Add(currentQuestion.incorrectAnswer1);
        unselectedAnswers.Add(currentQuestion.incorrectAnswer2);
        unselectedAnswers.Add(currentQuestion.incorrectAnswer3);
        SetAnswers();
    }

    void Update(){
        if(timing){
            timeStart += Time.deltaTime;
            timeTrack.text = timeStart.ToString("F2");
        }
        
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact; 
    }

    
    void SetAnswers(){
        
        int randomAnswerIndex = Random.Range(0, unselectedAnswers.Count);
        string selectedAnswer = unselectedAnswers[randomAnswerIndex];
        op1Text1.text = selectedAnswer;
        unselectedAnswers.RemoveAt(randomAnswerIndex);

        int randomAnswerIndex2 = Random.Range(0, unselectedAnswers.Count);
        string selectedAnswer2 = unselectedAnswers[randomAnswerIndex2];
        op1Text2.text = selectedAnswer2;
        unselectedAnswers.RemoveAt(randomAnswerIndex2);

        int randomAnswerIndex3 = Random.Range(0, unselectedAnswers.Count);
        string selectedAnswer3 = unselectedAnswers[randomAnswerIndex3];
        op1Text3.text = selectedAnswer3;
        unselectedAnswers.RemoveAt(randomAnswerIndex3);

        int randomAnswerIndex4 = Random.Range(0, unselectedAnswers.Count);
        string selectedAnswer4 = unselectedAnswers[randomAnswerIndex4];
        op1Text4.text = selectedAnswer4;
        unselectedAnswers.RemoveAt(randomAnswerIndex4);
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(delay);
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            setGameOver();
        }
        SetCurrentQuestion();
        unselectedAnswers.Add(currentQuestion.correctAnswer);
        unselectedAnswers.Add(currentQuestion.incorrectAnswer1);
        unselectedAnswers.Add(currentQuestion.incorrectAnswer2);
        unselectedAnswers.Add(currentQuestion.incorrectAnswer3);
        SetAnswers();
    }


    void setGameOver(){
        gameOver.SetActive(true);
        timing = false;
        float myTime = float.Parse(timeTrack.text);
        int roundTime = (int)Mathf.Round(myTime);

        

        koinage = (qCount/5) * ((qCount * 7) - roundTime);
        if(koinage < 0){
            koinage = 0;
        }
        //Round to two decimal places
        string myTime2 = myTime.ToString("F2");
        float myTime3 = float.Parse(myTime2);
        int myMultiTime = (int)Mathf.Round(myTime3 * 100);

        //Earn monkoins
        currentKoin = PlayerPrefs.GetInt("coin");
        PlayerPrefs.SetInt("coin", currentKoin + koinage);
        newBal = PlayerPrefs.GetInt("coin");

        //Display data
        timeScore.text = "Your time was " + myTime.ToString() + " seconds.";
        Monkoins.text = "You earned " + koinage.ToString() + " Monkoins.";
        Banc.text = "You have " + newBal.ToString() + " Monkoins.";
        highText.text = "Your highscore is "+ high.ToString();
        playerName = PlayerPrefs.GetString("Username");
        

        if(chosenQuestionSet == "webdevelopment")
        {
            selectedPrivateCode = WDprivateCode;
            high = PlayerPrefs.GetFloat("WDhighscore");
            highText.text = "Your highscore is "+ high.ToString();
        }
        else if(chosenQuestionSet == "foundationsofcomputerscience")
        {
            selectedPrivateCode = FCprivateCode;
            high = PlayerPrefs.GetFloat("FOCShighscore");
            highText.text = "Your highscore is "+ high.ToString();
        }
        else if(chosenQuestionSet == "relationaldatabases")
        {
            selectedPrivateCode = IPprivateCode;
            high = PlayerPrefs.GetFloat("DBhighscore");
            highText.text = "Your highscore is "+ high.ToString();
        }
        else if(chosenQuestionSet == "systemsorganisation")
        {
            selectedPrivateCode = SOprivateCode;
            high = PlayerPrefs.GetFloat("SOhighscore");
            highText.text = "Your highscore is "+ high.ToString();
        }

        if(myTime < high){
            int sentTime = 1000000-myMultiTime;
            AddNewHighscore(playerName, sentTime);
            scoreType = PlayerPrefs.GetString("scoretype");
            if(scoreType == "WDhighscore")
            {
                PlayerPrefs.SetFloat("WDhighscore", myTime);
            }
            else if (scoreType == "FOCShighscore")
            {
                PlayerPrefs.SetFloat("FOCShighscore", myTime);
                
            }
            else if (scoreType == "DBhighscore")
            {
                PlayerPrefs.SetFloat("DBhighscore", myTime);
            }
            else if(scoreType == "SOhighscore")
            {
                PlayerPrefs.SetFloat("SOhighscore", myTime);   
            }
        }
        
        


       
        
    }

    
    
	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + selectedPrivateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			print ("Upload Successful");
		else {
			print ("Error uploading: " + www.error);
		}
	}

    public void AddNewHighscore(string username, int score) {
		StartCoroutine(UploadNewHighscore(username,score));
	}
    
    public void PlayAgain(){
        Start();
    }

    public void Back()
    {
        SceneManager.LoadScene("title");
    }

    IEnumerator WrongAnswer()
    {
        yield return new WaitForSeconds(delay);
        timeStart += 1;
    }
    public void audioEffect()
    {
        int randomNumber = Random.Range(1, 10);
        if(randomNumber == 3)
        {
            effectSource.PlayOneShot(earRapeOoh);
            
        }
        else
        {
            effectSource.PlayOneShot(happyOoh);
        }
    }
    public void chooseAnswer1(){
        
        if(op1Text1.text == currentQuestion.correctAnswer){
            op1Text1.text = "Correct!";
            StartCoroutine(TransitionToNextQuestion());
            audioEffect();
            
        }
        else{
            op1Text1.text = "Incorrect!";
            StartCoroutine(WrongAnswer());
            effectSource.PlayOneShot(sadOoh);
        }
    }

    public void chooseAnswer2(){
        if(op1Text2.text == currentQuestion.correctAnswer){
            op1Text2.text = "Correct!";
            StartCoroutine(TransitionToNextQuestion());
            audioEffect();
        }
        else{
            op1Text2.text = "Incorrect!";
            StartCoroutine(WrongAnswer());
            effectSource.PlayOneShot(sadOoh);
        }
    }

    public void chooseAnswer3(){
        if(op1Text3.text == currentQuestion.correctAnswer)
        {
            op1Text3.text = "Correct!";
            StartCoroutine(TransitionToNextQuestion());       
            audioEffect();
        }
        else{
            op1Text3.text = "Incorrect!";
            StartCoroutine(WrongAnswer());
            effectSource.PlayOneShot(sadOoh);
            
            
        }
    }

    public void chooseAnswer4(){
        var temp4 = op1Text4.text;
        if(op1Text4.text == currentQuestion.correctAnswer){
            op1Text4.text = "Correct!";
            StartCoroutine(TransitionToNextQuestion());
            audioEffect();
        }
        else{
            
            op1Text4.text = "Incorrect!";
            StartCoroutine(WrongAnswer());
            effectSource.PlayOneShot(sadOoh);
        }
    }

    
}
