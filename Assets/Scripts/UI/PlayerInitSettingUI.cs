using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInitSettingUI : MonoBehaviour
{
    private Coroutine _runningCoroutine = null;

    [Header("Buttons")]
    public Button joinBtn;
    public Button characterSelectBtn;

    [Header("Name Input Set")]
    public TMP_InputField nameInput;
    public TextMeshProUGUI playerNameTxt;

    [Header("Setting Objects")]
    public GameObject settingObj;
    public GameObject characterSelectObj;

    [Header("In Game UI Objects")]
    public GameObject inGameUiObj;

    [Header("Checking Text Object")]
    public GameObject checkNameObj;

    private void Start()
    {
        joinBtn.onClick.AddListener(JoinBtnClicked);
        characterSelectBtn.onClick.AddListener(CharacterSelectBtnClicked);
    }

    #region Button Set
    public void JoinBtnClicked()
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

        this.gameObject.SetActive(false);
        inGameUiObj.SetActive(true);
        PlayerSet.Instance.SetPlayer(GameManager.Instance.player, PlayerSet.Instance.selectedCharacter, nameInput.text);
    }

    public void CharacterSelectBtnClicked()
    {
        characterSelectObj.SetActive(true);
    }

    #endregion
    
}
