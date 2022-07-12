
using TMPro;
using UnityEngine;

public class BtnClick : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    private string addText;

    private void Start()
    {
        addText = GetComponentInChildren<TextMeshProUGUI>().text = name;
        
    }

    public void ClickBtn()
    {
        _inputField.text += addText;
    }
}
