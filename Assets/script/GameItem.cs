using System;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public Sprite Sprite;
    public string Name;
    private SpriteRenderer _spriteRenderer;
    public event Action<string> OnFind;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Name = _spriteRenderer.sprite.name;
        Sprite = _spriteRenderer.sprite;
    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        Debug.Log($"Find object {gameObject.name}");
        OnFind.Invoke(Name);
    }
}
