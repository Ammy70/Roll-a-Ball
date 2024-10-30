using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCharacter: MonoBehaviour
{
	public GameObject[] characterPrefebs;
	public Transform spawnpoint;
    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefeb = characterPrefebs[selectedCharacter];
        GameObject clone = Instantiate(prefeb, spawnpoint.position, Quaternion.identity);
      
    } 
    public void PlayGame()
    {

    }

}
