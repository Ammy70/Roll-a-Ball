using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CubeSpawnConfig _cubeSpawnConfig;
     private int count;
    // UI text component to display count of "PickUp" objects collected.
    [SerializeField] public TextMeshProUGUI coinText;
    [SerializeField] public TextMeshProUGUI enemiesText;  
    // UI object to display winning text.
    [SerializeField] public GameObject winTextObject;
    // Start is called before the first frame update. 
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = ColorPicker.color;
        // Initialize count to zero.
        count = 0;
        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
        Bullets.OnBulletHit += AddCoin;
        EnemyHealthbar.OnEnemyKilled += SetCountText;
    }
    private void OnDestroy()
    {
        Bullets.OnBulletHit -= AddCoin;
        EnemyHealthbar.OnEnemyKilled -= SetCountText;
    }
    private void AddCoin()
    {
        coinText.text = " Score :" +count;
    }
    void SetCountText()
    {
        // Update the count text with the current count.
        count++;
        enemiesText.text = "Enemies Hit :" + count;
        // Check if the count has reached or exceeded the win condition.
        if (count >= _cubeSpawnConfig.numberOfPrefabsToCreate)
        {
           // Display the win text.
            winTextObject.gameObject.SetActive(true);
            SceneManager.LoadScene(2);
        }
    }      
}
