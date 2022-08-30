using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject textComponent;

    private PlayersPool _pool;
    private GameObject _currentPlayer;
    private CoroutineController _coroutineController;
    private UniTaskController _uniTaskController;

    private void Awake()
    {
        _pool = GetComponent<PlayersPool>();
        _currentPlayer = null;
        _coroutineController = FindObjectOfType<CoroutineController>(true);
        _uniTaskController = FindObjectOfType<UniTaskController>(true);
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
        _coroutineController.StartMoving();
    }
    
    public void StartUniTaskPlayer()
    {
        BackCurrentPlayerToPool();
        _currentPlayer = _pool.GetPlayerByIndex(2);
        SetStartPlayerParams();
        _uniTaskController.StartMoving();
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
