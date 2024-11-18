using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour
{
    [SerializeField] public CubeSpawner _cubeSpawner;
    [SerializeField] public GameObject _player;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = ColorPicker.color;
    }
    public void OnClickLevelOne()
       
    {
        
        SceneManager.LoadScene( 2);
    }
    public void OnClickLevelTwo()
    {
      
        SceneManager.LoadScene( 2);
    }
    public void OnClickLevelThree()
    {
       
        SceneManager.LoadScene( 2);
    }
}
