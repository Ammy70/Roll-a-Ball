using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private CubeSpawnConfig _cubeSpawnConfig;
   
   
    private int count;
    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;
    // UI object to display winning text.
    public GameObject winTextObject;
    // Start is called before the first frame update.
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = ColorPicker.color;
        
        // Get and store the Rigidbody component attached to the player.
      // rig = GetComponent<Rigidbody>();
        // Initialize count to zero.
        count = 0;
        // Update the count display.
        SetCountText();
        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);

    }
    private void Update()
    {
        countText.text = "Enemies Hit: " + Bullets.enemyCount;
    }




    // public void Jump()
    // {
    //  Debug.Log("jump Input");
    // }



    public void AddCoin(int countValue)
    {
        count += countValue;
        SetCountText();
    }
    void SetCountText()
    {
        // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();
        // Check if the count has reached or exceeded the win condition.
        if (count >= _cubeSpawnConfig.numberOfPrefabsToCreate)
        {
           // Display the win text.
            winTextObject.gameObject.SetActive(true);
            SceneManager.LoadScene(2);


        }
    }
     
    
}
