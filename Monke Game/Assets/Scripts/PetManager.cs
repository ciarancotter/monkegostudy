using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PetManager : MonoBehaviour
{
    //Some UI variables 
    [SerializeField]
    private Toggle noneToggle;
    [SerializeField]
    private Toggle frogToggle;
    [SerializeField]
    private Toggle hogToggle;
    [SerializeField]
    private Toggle rockToggle;
    [SerializeField]
    private Toggle beeToggle;
    [SerializeField]
    private Toggle herbToggle;
    [SerializeField]
    private Toggle wombatToggle;
    [SerializeField]
    private Toggle dragonToggle;

    //Some other variables
    private int frogPref;
    private int hogPref;
    private int rockPref;
    private int beePref;
    private int herbPref;
    private int wombatPref;
    private int dragonPref;

    //Some streamlined logic
    private int nonePref;
    private string currentPet;



    void Start()
    {
        currentPet = PlayerPrefs.GetString("pet");
        frogPref = PlayerPrefs.GetInt("hasFrog");
        hogPref = PlayerPrefs.GetInt("hasHog");
        rockPref = PlayerPrefs.GetInt("hasRock");
        beePref = PlayerPrefs.GetInt("hasBee");
        herbPref = PlayerPrefs.GetInt("hasHerb");
        wombatPref = PlayerPrefs.GetInt("hasWombat");
        dragonPref = PlayerPrefs.GetInt("hasDragon");
        switch (frogPref)
        {
            case 0:
                frogToggle.interactable = false;
                break;
            case 1:
                frogToggle.interactable = true;
                break;
        }
        switch (hogPref)
        {
            case 0:
                hogToggle.interactable = false;
                break;
            case 1:
                hogToggle.interactable = true;
                break;
        }
        switch (rockPref)
        {
            case 0:
                rockToggle.interactable = false;
                break;
            case 1:
                rockToggle.interactable = true;
                break;
        }
        switch (beePref)
        {
            case 0:
                beeToggle.interactable = false;
                break;
            case 1:
                beeToggle.interactable = true;
                break;
        }
        switch (herbPref)
        {
            case 0:
                herbToggle.interactable = false;
                break;
            case 1:
                herbToggle.interactable = true;
                break;
        }
        switch (wombatPref)
        {
            case 0:
                wombatToggle.interactable = false;
                break;
            case 1:
                wombatToggle.interactable = true;
                break;
        }
        switch (dragonPref)
        {
            case 0:
                dragonToggle.interactable = false;
                break;
            case 1:
                dragonToggle.interactable = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectedFrog()
    {
        if(frogToggle.isOn)
        {
            PlayerPrefs.SetString("pet", "frog");
        }
        
    }
    public void selectedHog()
    {
        if(hogToggle.isOn)
        {
            PlayerPrefs.SetString("pet", "hog");
        }
        
    }
    public void selectedHerb()
    {
        if(herbToggle.isOn)
        {
            PlayerPrefs.SetString("pet", "herb");
        }
        
    }
    public void selectedBee()
    {
        if(beeToggle.isOn)
        {
            PlayerPrefs.SetString("pet", "bee");
        }
        
    }
    public void selectedRock()
    {
        if(rockToggle.isOn)
        {
            PlayerPrefs.SetString("pet", "rock");
        }
        
    }

    public void selectedWombat()
    {
        if(wombatToggle.isOn)
        {
            PlayerPrefs.SetString("pet", "wombat");
        }
    }

    public void selectedDragon()
    {
        if(dragonToggle.isOn)
        {
            PlayerPrefs.SetString("pet", "dragon");
        }
    }
    public void selectedNone()
    {
        if(noneToggle.isOn)
        {
            PlayerPrefs.SetString("pet", "none");
        }
       
    }

    public void goBack(){
        SceneManager.LoadScene("Title");
    }
}
