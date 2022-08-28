using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersPool : MonoBehaviour
{
    [SerializeField] private GameObject[] playersCollection;
    private GameObject[] _players;

    private void Awake()
    {
        _players = new GameObject[playersCollection.Length];
        for (int i = 0; i < _players.Length; i++)
        {
            _players[i] = Instantiate(playersCollection[i]);
            _players[i].SetActive(false);
        }
    }

    public GameObject GetPlayerByIndex(int arrayIndex)
    {
        GameObject player = null;

        player = _players[arrayIndex];
        return player;
    }
}
