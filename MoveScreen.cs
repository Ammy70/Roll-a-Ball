using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveScreen : MonoBehaviour
{
    
    
    public void Play(string CharacterSelector)
    {
        SceneManager.LoadScene(CharacterSelector);
    }

}
