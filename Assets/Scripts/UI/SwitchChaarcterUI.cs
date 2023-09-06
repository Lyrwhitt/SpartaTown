using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchChaarcterUI : MonoBehaviour
{
    public Button selectPenguinBtn;
    public Button selectHumanBtn;

    private void Start()
    {
        selectPenguinBtn.onClick.AddListener(SelectPenguinBtnClicked);
        selectHumanBtn.onClick.AddListener(SelectHumanBtnClicked);
    }
    private void SelectPenguinBtnClicked()
    {
        PlayerSet.Instance.SwitchPlayerCharacter(GameManager.Instance.player, Character.Penguin);
        this.gameObject.SetActive(false);
    }

    private void SelectHumanBtnClicked()
    {
        PlayerSet.Instance.SwitchPlayerCharacter(GameManager.Instance.player, Character.Human);
        this.gameObject.SetActive(false);
    }
}
