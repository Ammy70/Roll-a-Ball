using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{ 
    // Start is called before the first frame update
   public  void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnClickColorPIck()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
}
