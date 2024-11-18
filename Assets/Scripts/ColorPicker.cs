
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColorPicker : MonoBehaviour
{
    [SerializeField] RectTransform _texture;
    [SerializeField] Texture2D _refSprite;
    [SerializeField] GameObject _player;
    public static Color color;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickSetColor();
        }
    }
    public void OnClickSetColor()
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_texture, Input.mousePosition, null, out localPoint))
        {
            float normalizedX = (localPoint.x + _texture.rect.width * 0.5f) / _texture.rect.width;
            float normalizedY = (localPoint.y + _texture.rect.height * 0.5f) / _texture.rect.height;

            int textureX = Mathf.Clamp(Mathf.RoundToInt(normalizedX * _refSprite.width), 0, _refSprite.width - 1);
            int textureY = Mathf.Clamp(Mathf.RoundToInt(normalizedY * _refSprite.height), 0, _refSprite.height - 1);

            Color c = _refSprite.GetPixel(textureX, textureY);
            SetActualColor(c);
        }
    }
    public void SetActualColor(Color c)
    {
        color = c;
        Debug.Log("Selected Color: " + c);
        _player.GetComponent<MeshRenderer>().material.color = c;
    }
    public void OnClickColorChanged()
    {
        SceneManager.LoadScene(3);
    }
}
