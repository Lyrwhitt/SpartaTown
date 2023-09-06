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

    public PlayerUIManager playerUIManager;


    private void Start()
    {
        InitSet();
    }

    public void InitSet()
    {
        for (int i = 0; i < players.Count; i++)
        {
            playerUIManager.OnPlayerEnter(players[i]);
            players[i].playerNameUI.offset = new Vector3(0f, 3f, 0f);
        }
    }


    // Test
    public Player dummy;
    public void TestPlayerList()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player newPlayer = Instantiate(dummy);
            playerUIManager.OnPlayerEnter(newPlayer);
            newPlayer.playerNameUI.offset = new Vector3(0f, 3f, 0f);
        }
    }

    private void Update()
    {
        TestPlayerList();
    }
}
