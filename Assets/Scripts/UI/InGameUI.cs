using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    private Coroutine _runningCoroutine = null;

    [Header("Time")]
    public TextMeshProUGUI timeTxt;

    [Header("Player List")]
    public Button playerListBtn;
    public Button playerListCloseBtn;
    public GameObject playerListObj;

    [Header("Switch Character")]
    public Button switchCharacterBtn;
    public GameObject switchCharacterObj;

    [Header("Switch Name")]
    public Button switchNameBtn;
    public Button switchNameConfirmBtn;
    public GameObject switchNameObj;
    public GameObject checkNameObj;
    public TMP_InputField nameInput;
    public TextMeshProUGUI playerNameTxt;

    private void Start()
    {
        playerListBtn.onClick.AddListener(PlayerListBtnClicked);
        playerListCloseBtn.onClick.AddListener(PlayerListCloseBtnClicked);

        switchCharacterBtn.onClick.AddListener(SwitchCharacterBtnClicked);

        switchNameBtn.onClick.AddListener(SwitchNameBtnClicked);
        switchNameConfirmBtn.onClick.AddListener(SwitchNameConfirmBtnClicked);
    }

    private void Update()
    {
        timeTxt.text = DateTime.Now.ToString(("HH : mm"));
    }

    public void PlayerListBtnClicked()
    {
        playerListObj.SetActive(true);
    }

    public void PlayerListCloseBtnClicked()
    {
        playerListObj.SetActive(false);
    }

    public void SwitchCharacterBtnClicked()
    {
        switchCharacterObj.SetActive(true);
    }


    public void SwitchNameBtnClicked()
    {
        switchNameObj.SetActive(true);
    }

    
    public void SwitchNameConfirmBtnClicked()
    {
        if (!PlayerSet.Instance.NameCheck(nameInput.text))
        {
            if (_runningCoroutine != null)
            {
                StopCoroutine(_runningCoroutine);
            }
            _runningCoroutine = StartCoroutine(PlayerSet.Instance.ShowCheckNameTxt(checkNameObj));

            return;
        }

        playerNameTxt.text = nameInput.text;

        switchNameObj.SetActive(false);

        PlayerSet.Instance.SwitchPlayerName(GameManager.Instance.player, playerNameTxt.text);
    }
}
