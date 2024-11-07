using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rig;
    float moveSpeed = 10f;
    bool useTorque = true;

    private int count;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;

    // UI object to display winning text.
    public GameObject winTextObject;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rig = GetComponent<Rigidbody>();

        // Initialize count to zero.
        count = 0;
        // Update the count display.
        SetCountText();
        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }

    public void Jump()
    {
        Debug.Log("jump Input");
    }
    
    public void Control(Vector3 inputVector)
    {
        if (useTorque)
        {
            rig.AddForce(inputVector * moveSpeed);
        }
    }

    public void AddCoin(int countValue)
    {
        // Increment the count of "PickUp" objects collected.
        count += countValue;
        SetCountText();
    }

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();
        // Check if the count has reached or exceeded the win condition.
        if (count >= 4)
        {
            // Display the win text.
            winTextObject.gameObject.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // Destroy the enemy GameObject.
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
        
    }
   
}
