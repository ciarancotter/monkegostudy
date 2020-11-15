using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Highscores : MonoBehaviour {


	private string SOpublicCode = "5faf41f4eb371a09c4fbc331";
	private string WDpublicCode = "5fa7ee39eb371a09c4bda9bb";
	private string FCpublicCode = "5faf449aeb371a09c4fbe91b";
	private string IPpublicCode = "5faf37faeb371a09c4fb3a84";
	private string selectedPublicCode;
	const string webURL = "http://dreamlo.com/lb/";

	DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;
	static Highscores instance;
	
	void Awake() {
		highscoreDisplay = GetComponent<DisplayHighscores> ();
		instance = this;
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + selectedPublicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
            username = username.Replace("+", " ");
			int score = int.Parse(entryInfo[1]);
            float fixedScore = (1000000 - score)/100f;
			highscoresList[i] = new Highscore(username,fixedScore);
		}
	}

	public void BackToHome()
	{
		SceneManager.LoadScene("Title");
	}

	public void webdevLeaderboard()
	{
		selectedPublicCode = WDpublicCode;
	}

	public void foundationsLeaderboard()
	{
		selectedPublicCode = FCpublicCode;
	}

	public void programmingLeaderboard()
	{
		selectedPublicCode = IPpublicCode;
	}

	public void sysorgLeaderboard()
	{
		selectedPublicCode = SOpublicCode;
	}

}

public struct Highscore {
	public string username;
	public float score;

	public Highscore(string _username, float _score) {
		username = _username;
		score = _score;
	}

}