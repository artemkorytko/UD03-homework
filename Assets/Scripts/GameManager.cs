using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject textComponent;
    
    private PlayersPool _pool;
    private GameObject _currentPlayer;

    private void Awake()
    {
        _pool = GetComponent<PlayersPool>();
        _currentPlayer = null;
    }

    public void StartUpdatePlayer()
    {
        BackCurrentPlayerToPool();
        _currentPlayer = _pool.GetPlayerByIndex(0);
        SetStartPlayerParams();
    }
    
    public void StartCoroutinePlayer()
    {
        BackCurrentPlayerToPool();
        _currentPlayer = _pool.GetPlayerByIndex(1);
        SetStartPlayerParams();
    }
    
    public void StartUniTaskPlayer()
    {
        BackCurrentPlayerToPool();
        _currentPlayer = _pool.GetPlayerByIndex(2);
        SetStartPlayerParams();
    }

    private void BackCurrentPlayerToPool()
    {
        if (_currentPlayer == null) 
            return;
        _currentPlayer.SetActive(false);
    }

    private void SetStartPlayerParams()
    {
        _currentPlayer.transform.position = Vector3.zero;
        _currentPlayer.transform.rotation = Quaternion.identity;
        _currentPlayer.SetActive(true);
        textComponent.SetActive(false);
    }
}
