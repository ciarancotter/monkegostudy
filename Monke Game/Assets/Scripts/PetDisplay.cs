using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetDisplay : MonoBehaviour
{
    public Pet pet;
    public Image petArt;
    void Start()
    {
    petArt.sprite = pet.artwork;
    }
}
