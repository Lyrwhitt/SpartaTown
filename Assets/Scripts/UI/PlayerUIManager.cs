using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerUIManager : MonoBehaviour
{
    [Header("Player List UI")]
    public Transform playerListParent;
    public GameObject playerListItemPrefab;

    [Header("Player Name UI")]
    public Transform playerNameParent;
    public PlayerNameUI playerNamePrefab;

    public void OnPlayerEnter(Player enterPlayer)
    {
        GameObject newListItem = Instantiate(playerListItemPrefab);
        PlayerNameUI newPlayerName = Instantiate(playerNamePrefab);

        newListItem.transform.SetParent(playerListParent);
        newPlayerName.transform.SetParent(playerNameParent);

        enterPlayer.playerNameListUI = newListItem.GetComponent<TextMeshProUGUI>();
        enterPlayer.playerNameUI = newPlayerName;
        enterPlayer.playerNameListUI.text = enterPlayer.playerName;

        newPlayerName.target = enterPlayer.transform;
        newPlayerName.GetComponentInChildren<TextMeshProUGUI>().text = enterPlayer.playerName;
    }
    public void OnPlayerExit(Player exitPlayer)
    {
        Destroy(exitPlayer.playerNameListUI);
        Destroy(exitPlayer.playerNameUI);
    }
}
