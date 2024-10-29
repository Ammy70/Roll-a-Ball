using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCharacter :MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;
    // Start is called before the first frame update
    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        
    }

    // Update is called once per frame
    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("SelctedCharacter", selectedCharacter);
        
    }
}
