using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Character
{
    Penguin, Human
}

public class GameManager : Singleton<GameManager>
{
    public List<Player> players = new List<Player>();

    public PlayerAnimationController animationController;

    public Player player;

    private PlayerUIManager _playerUIManager;

    private void Awake()
    {
        _playerUIManager = this.GetComponent<PlayerUIManager>();
    }


    public Player dummy;
    public void TestPlayerList()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player newPlayer = Instantiate(dummy);
            _playerUIManager.OnPlayerEnter(newPlayer);
        }
    }

    private void Update()
    {
        TestPlayerList();
    }
}
