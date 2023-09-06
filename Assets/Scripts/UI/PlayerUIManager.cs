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
    //private List<GameObject> playerListItems = new List<GameObject>();

    private void Start()
    {
        //SetPlayerListUI();
    }

    public void SetPlayerListUI()
    {
        for (int i = 0; i < GameManager.Instance.players.Count; i++)
        {
            GameObject newListItem = Instantiate(playerListItemPrefab);
            newListItem.transform.parent = playerListParent;
            newListItem.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.players[i].name;

            //playerListItems.Add(newListItem);
        }
    }

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

        //playerListItems.Add(newListItem);
    }
    public void OnPlayerExit(Player exitPlayer)
    {
        //GameObject removeListItem = playerListItems.Find(x => x.GetComponent<TextMeshProUGUI>().text == exitPlayer.name);
        //playerListItems.Remove(removeListItem);
        Destroy(exitPlayer.playerNameListUI);
        Destroy(exitPlayer.playerNameUI);
    }
}
