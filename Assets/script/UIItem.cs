using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI countText;

    private int _count;

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetCount(int count)
    {
        _count = count;
        countText.text = _count.ToString();
    }

    public void Decrease()
    {
        _count--;
        if (_count > 0)
        {
            countText.text = _count.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}