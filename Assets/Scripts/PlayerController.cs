using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


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
    public void Control()
    {
        if (useTorque)
        {
            rig.AddTorque(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")) * moveSpeed);
        }
    }
    void FixedUpdate()
    {
        Control();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

            // Increment the count of "PickUp" objects collected.
            count = count +1;

            // Update the count display.
            SetCountText();
        }
       

    }
    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();
        // Check if the count has reached or exceeded the win condition.
        if (count >= 3)
        {
            // Display the win text.
            winTextObject.gameObject.SetActive(true);
           

            // Destroy the enemy GameObject.
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}

