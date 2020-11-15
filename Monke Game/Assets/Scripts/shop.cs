using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shop : MonoBehaviour
{
    //UI
    public Text myBalance;
    public Text buyFrog;
    public Text buyHog;
    public Text buyRock;
    public Text buyBee;
    public Text buyHerb;
    public Text buyWombat;
    public Text buyDragon;
    public Text currentBalance;

    public Button frogButton;
    public Button hogButton;
    public Button rockButton;
    public Button beeButton;
    public Button herbButton;
    public Button wombatButton;
    public Button dragonButton;

    //Other variables
    private int currentKoin;
    private int ownsFrog;
    private int ownsHog;
    private int ownsRock;
    private int ownsBee;
    private int ownsHerb;
    private int ownsWombat;
    private int ownsDragon;
    private int myBal;

    void Start()
    {
        currentKoin = PlayerPrefs.GetInt("coin");
        myBalance.text = currentKoin.ToString();
        ownsFrog = PlayerPrefs.GetInt("hasFrog");
        ownsHog = PlayerPrefs.GetInt("hasHog");
        ownsRock = PlayerPrefs.GetInt("hasRock");
        ownsBee = PlayerPrefs.GetInt("hasBee");
        ownsHerb = PlayerPrefs.GetInt("hasHerb");
        ownsWombat = PlayerPrefs.GetInt("ownsWombat");
        ownsDragon = PlayerPrefs.GetInt("ownsDragon");

        if (ownsFrog == 1)
        {
            buyFrog.text = "Owned";
            frogButton.interactable = false;
        }
        if(ownsHog == 1)
        {
            buyHog.text = "Owned";
            hogButton.interactable = false;
        }
        if(ownsRock == 1)
        {
            buyRock.text = "Owned";
            rockButton.interactable = false;
        }
        if(ownsBee == 1)
        {
            buyBee.text = "Owned";
            beeButton.interactable = false;
        }
        if(ownsHerb == 1)
        {
            buyHerb.text = "Owned";
            herbButton.interactable = false;
        }
        if(ownsWombat == 1)
        {
            buyWombat.text = "Owned";
            wombatButton.interactable = false;
        }
        if(ownsDragon == 1)
        {
            buyDragon.text = "Owned";
            dragonButton.interactable = false;
        }


    }

    public void backToTitle()
    {
        SceneManager.LoadScene("title");
    }

    public void purchaseFrog()
    {
        currentKoin = PlayerPrefs.GetInt("coin");
        ownsFrog = PlayerPrefs.GetInt("hasFrog");
        if(ownsFrog == 0 && currentKoin > 1000)
        {
            PlayerPrefs.SetInt("hasFrog", 1);
            PlayerPrefs.SetInt("coin", currentKoin - 1000);
            buyFrog.text = "Owned";
            myBal = PlayerPrefs.GetInt("coin");
            currentBalance.text = myBal.ToString();
        }
        else
        {
            buyFrog.text = "1000";
        }
    }

    public void purchaseHog()
    {
        currentKoin = PlayerPrefs.GetInt("coin");
        ownsHog = PlayerPrefs.GetInt("hasHog");
        if(currentKoin > 1500 && ownsHog != 1)
        {
            PlayerPrefs.SetInt("hasHog", 1);
            PlayerPrefs.SetInt("coin", currentKoin - 1500);
            buyHog.text = "Owned";
            myBal = PlayerPrefs.GetInt("coin");
            currentBalance.text = myBal.ToString();
        }
        else
        {
            buyHog.text = "1500";
        }
    }

    public void purchaseRock()
    {
        currentKoin = PlayerPrefs.GetInt("coin");
        ownsRock = PlayerPrefs.GetInt("hasRock");
        if(currentKoin > 10000 && ownsRock != 1)
        {
            PlayerPrefs.SetInt("hasRock", 1);
            PlayerPrefs.SetInt("coin", currentKoin - 10000);
            buyRock.text = "Owned";
            myBal = PlayerPrefs.GetInt("coin");
            currentBalance.text = myBal.ToString();
        }
        else
        {
            buyRock.text = "10000";
        }
    }

    public void purchaseBee()
    {
        currentKoin = PlayerPrefs.GetInt("coin");
        ownsBee = PlayerPrefs.GetInt("hasBee");
        if(currentKoin > 5000 && ownsBee != 1)
        {
            PlayerPrefs.SetInt("hasBee", 1);
            PlayerPrefs.SetInt("coin", currentKoin - 5000);
            buyBee.text = "Owned";
            myBal = PlayerPrefs.GetInt("coin");
            currentBalance.text = myBal.ToString();
        }
        else
        {
            buyBee.text = "5000";
        }
    }
    public void purchaseHerb()
    {
        currentKoin = PlayerPrefs.GetInt("coin");
        ownsHerb = PlayerPrefs.GetInt("hasHerb");
        if(currentKoin > 2000 && ownsHerb != 1)
        {
            PlayerPrefs.SetInt("hasHerb", 1);
            PlayerPrefs.SetInt("coin", currentKoin - 2000);
            buyHerb.text = "Owned";
            myBal = PlayerPrefs.GetInt("coin");
            currentBalance.text = myBal.ToString();
        }
        else
        {
            buyHerb.text = "2000";
        }
    }

    public void purchaseWombat()
    {
        currentKoin = PlayerPrefs.GetInt("coin");
        ownsWombat = PlayerPrefs.GetInt("hasWombat");
        if(currentKoin > 15000 && ownsWombat != 1)
        {
            PlayerPrefs.SetInt("hasWombat", 1);
            PlayerPrefs.SetInt("coin", currentKoin - 15000);
            buyWombat.text = "Owned";
            myBal = PlayerPrefs.GetInt("coin");
            currentBalance.text = myBal.ToString();
        }
        else
        {
            buyWombat.text = "15000";
        }
    }

    public void purchaseDragon()
    {
        currentKoin = PlayerPrefs.GetInt("coin");
        ownsDragon = PlayerPrefs.GetInt("hasDragon");
        if(currentKoin > 50000 && ownsDragon != 1)
        {
            PlayerPrefs.SetInt("hasDragon", 1);
            PlayerPrefs.SetInt("coin", currentKoin - 50000);
            buyDragon.text = "Owned";
            myBal = PlayerPrefs.GetInt("coin");
            currentBalance.text = myBal.ToString();
        }
        else
        {
            buyDragon.text = "50000";
        }
    }


}
