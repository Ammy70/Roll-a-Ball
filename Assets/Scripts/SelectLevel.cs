using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour
{
    [SerializeField] public CubeSpawner _cubeSpawner;
   
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = ColorPicker.color;
    }
    public void OnClickLevelOne()
    {
        LoadLevel(1);
    }
    public void OnClickLevelTwo()
    {
        LoadLevel(2);
    }
    public void OnClickLevelThree()
    {
        LoadLevel(3);
    }

    private void LoadLevel(int levelNumber)
    {
        CubeSpawner.LevelNumber =levelNumber; 
        SceneManager.LoadScene( 2); 
    }
    
}
