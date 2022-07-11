using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
