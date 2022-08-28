using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] private GameObject textComponent;
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = textComponent.GetComponent<TextMeshProUGUI>();
        UpdateController.UpdatesFinished += ChangeText;
        CoroutineController.CoroutineFinished += ChangeText;
        UniTaskController.UniTaskFinished += ChangeText;
    }

    private void ChangeText(string text, Color color)
    {
        textComponent.SetActive(true);
        _text.text = text;
        _text.color = color;
    }
}
