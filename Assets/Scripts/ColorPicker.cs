
using UnityEngine;
using UnityEngine.SceneManagement;




public class ColorPicker : MonoBehaviour
{
    public FlexibleColorPicker _fcp;
    public Material material;
    private void Update()
    {
        material.color = _fcp.color;
        
    }
    public void OnClickColorChanged()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
