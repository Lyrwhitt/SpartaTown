using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PlayerSet : Singleton<PlayerSet>
{
    public Character selectedCharacter = Character.Penguin;

    public List<GameObject> characters = new List<GameObject>();


    public void SetPlayer(Player player, Character character, string playerName)
    {
        SwitchPlayerCharacter(player, character);
        SwitchPlayerName(player, playerName);
    }

    public void SwitchPlayerCharacter(Player player, Character character)
    {
        GameObject playerCharacter = new GameObject();

        if (character == Character.Penguin)
        {
            playerCharacter = characters.Find(x => x.name == "Penguin");
        }
        else if (character == Character.Human)
        {
            playerCharacter = characters.Find(x => x.name == "Human");
        }

        GameManager.Instance.animationController.SetAnimator(playerCharacter.GetComponent<Animator>());

        if(player.playerCharacter != null)
        {
            player.playerCharacter.SetActive(false);
        }
        player.playerCharacter = playerCharacter;

        player.gameObject.SetActive(true);
        playerCharacter.SetActive(true);
    }

    public void SwitchPlayerName(Player player, string playerName)
    {
        player.playerName = playerName;
    }


    #region Check Invalid Name
    public bool NameCheck(string name)
    {
        if (name.Length < 2 || name.Length > 10)
            return false;
        else
            return true;
    }

    public IEnumerator ShowCheckNameTxt(GameObject showObject)
    {
        showObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        showObject.SetActive(false);
    }
    #endregion
}
