
using UnityEngine;
using UnityEngine.UI;

public class DemageListener : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    public void UpdateHealthBar(float damage)
    {
        healthImage.fillAmount = damage;
    }
}
