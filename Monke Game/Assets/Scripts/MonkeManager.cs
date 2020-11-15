using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonkeManager : MonoBehaviour
{
    private int myKoins;
    private string amount;
    private int playerTotal;
    private int dealerTotal;
    private int randIndex;
    private int randIndex2;
    private List<int> Cards = new List<int>();

    [SerializeField]
    public GameObject koinPanel;
    [SerializeField]
    public GameObject mainPanel;
    [SerializeField]
    public GameObject blackjackPanel;
    [SerializeField]
    public Text flipState;
    [SerializeField]
    public Text myBalance;
    [SerializeField]
    public Text jackBalance;
    [SerializeField]
    public Text pot;
    [SerializeField]
    public InputField bettingSum;
    [SerializeField]
    public Text playerSum;
    [SerializeField]
    public Text dealerSum;
    [SerializeField]
    public InputField wager;
    [SerializeField]
    public Button hitButton;
    [SerializeField]
    public Button stopButton;
    [SerializeField]
    private Text statusText;
    [SerializeField]
    private Image playerImage;
    [SerializeField]
    private Image dealerImage;
    
    //Cards 
    public Sprite Ace;
    public Sprite Two;
    public Sprite Three;
    public Sprite Four;
    public Sprite Five;
    public Sprite Six;
    public Sprite Seven;
    public Sprite Eight;
    public Sprite Nine;
    public Sprite Ten;
    public Sprite Jack;
    public Sprite Queen;
    public Sprite King;

    void Start()
    {
        bettingSum.contentType = InputField.ContentType.IntegerNumber;
        wager.contentType = InputField.ContentType.IntegerNumber;
        hitButton.interactable = false;
        stopButton.interactable = false;
        myKoins = PlayerPrefs.GetInt("coin");
        for (int i = 1; i < 14; i++)
        {
            Cards.Add(i);
        }

        
    }

    public void Back()
    {
        myKoins = PlayerPrefs.GetInt("coin");
        myBalance.text = myKoins.ToString();
        koinPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void BackAgain()
    {
        SceneManager.LoadScene("Title");
    }

    public void BackJack()
    {
        myKoins = PlayerPrefs.GetInt("coin");
        jackBalance.text = myKoins.ToString();
        blackjackPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void coinFlipActivate()
    {
        koinPanel.SetActive(true);
        mainPanel.SetActive(false);
        myKoins = PlayerPrefs.GetInt("coin");
        myBalance.text = myKoins.ToString();
        
    }
    public void blackjackActivate()
    {
        koinPanel.SetActive(false);
        mainPanel.SetActive(false);
        blackjackPanel.SetActive(true);
        myKoins = PlayerPrefs.GetInt("coin");
        jackBalance.text = myKoins.ToString();
        hitButton.interactable = false;
        stopButton.interactable = false;
        playerSum.text = "Player Total: " + playerTotal.ToString();
        dealerSum.text = "Dealer Total: " + dealerTotal.ToString();
    }
    void updateBalance()
    {
        myKoins = PlayerPrefs.GetInt("coin");
        myBalance.text = myKoins.ToString();
        jackBalance.text = myKoins.ToString();
        
    }

    public void Commit()
    {
        hitButton.interactable = true;
        stopButton.interactable = true;
        wager.readOnly = true;
        pot.text = "Pot: " + wager.text;
    }

    public void TriggerFlip()
    {
        if(bettingSum.text != "")
        {
            int amount = int.Parse(bettingSum.text);

            if (amount < myKoins && amount > 0)
            {
                float randomValue = Random.Range(0.00f, 1.00f);
                if(randomValue < 0.55)
                {
                    myKoins = PlayerPrefs.GetInt("coin");
                    PlayerPrefs.SetInt("coin", myKoins - amount);
                    flipState.text = "Tails.";
                    updateBalance();
                }
                else
                {
                    myKoins = PlayerPrefs.GetInt("coin");
                    PlayerPrefs.SetInt("coin", myKoins + amount);
                    flipState.text = "Heads.";
                    updateBalance();
                }
            }

            else{
                flipState.text = "Invalid amount.";
            }

        }

        
    }
    private void dealerHit()
    {
        randIndex2 = Random.Range(0, 12);
        int dealerCard = Cards[randIndex2];
        cardImage(dealerCard, dealerImage);
        dealerTotal += dealerCard;
        dealerSum.text = "Dealer Total: " + dealerTotal.ToString();
    }

        //Blackjack code
    public void Hit(int total){
        randIndex = Random.Range(0, 12);
        int myCard = Cards[randIndex];
        cardImage(myCard, playerImage);
        playerTotal += myCard;
        playerSum.text = "Player Total: " + playerTotal.ToString();
        if (dealerTotal < 17)
        {
            dealerHit();
        }
        else if(dealerTotal >= 17)
        {
            //Do nothing
        }
        if(playerTotal > 21)
        {
            endGame();
        }


    }
    private void DealerWin()
    {
        if(wager.text != "")
        {
            int myWager = int.Parse(wager.text);

            if (myWager < myKoins && myWager > 0)
            {
                myKoins = PlayerPrefs.GetInt("coin");
                statusText.text = "Dealer Wins!";
                PlayerPrefs.SetInt("coin", myKoins - myWager);
                updateBalance();
                resetNumbers();
            }
        }
    }
    public void resetNumbers()
    {
        wager.readOnly = false;
        hitButton.interactable = false;
        stopButton.interactable = false;
        playerTotal = 0;
        playerSum.text = "Player Total: " + playerTotal.ToString();
        dealerTotal = 0;
        dealerSum.text = "Dealer Total: " + dealerTotal.ToString();
        pot.text = "Pot: 0";   
    }

    private void PlayerWin()
    {
        if(wager.text != "")
        {
            int myWager = int.Parse(wager.text);

            if (myWager < myKoins && myWager > 0)
            {
                myKoins = PlayerPrefs.GetInt("coin");
                statusText.text = "Player Wins!";
                PlayerPrefs.SetInt("coin", myKoins + myWager);
                updateBalance();
                resetNumbers();
            }
        } 
        
    }

    public void Stand()
    {
        if(dealerTotal > 17)
        {
            endGame();
        }
        else
        {
            statusText.text = "The dealer must have over 17!";
        }
        
    }
    
    private void endGame()
    {
        if(dealerTotal <= 21)
        {
            if(dealerTotal > playerTotal)
            {
                DealerWin();
            }
            else if (dealerTotal == playerTotal)
            {
                statusText.text = "Tie!";
                resetNumbers();
            }
            else if(playerTotal > dealerTotal)
            {
                if (playerTotal <= 21)
                {
                    PlayerWin();
                }
                else
                {
                    DealerWin();
                }
            }

        }
        else if (dealerTotal > 21)
        {
            if(playerTotal > dealerTotal)
            {
                DealerWin();
            }
            else if (playerTotal == dealerTotal)
            {
                DealerWin();
            }
            else if (playerTotal > 21 && playerTotal < dealerTotal)
            {
                DealerWin();
            }
            else{
                PlayerWin();
            }
        }

        
    }

    private void cardImage(int cardNumber, Image card)
    {
        switch(cardNumber)
        {
            case 1:
                card.sprite = Ace;
                break;
            case 2:
                card.sprite = Two;
                break;
            case 3:
                card.sprite = Three;
                break;
            case 4:
                card.sprite = Four;
                break;
            case 5:
                card.sprite = Five;
                break;
            case 6:
                card.sprite = Six;
                break;
            case 7:
                card.sprite = Seven;
                break;
            case 8:
                card.sprite = Eight;
                break;
            case 9:
                card.sprite = Nine;
                break;
            case 10:
                card.sprite = Ten;
                break;
            case 11:
                card.sprite = Jack;
                break;
            case 12:
                card.sprite = Queen;
                break;
            case 13:
                card.sprite = King;
                break;
        }
    }


}
