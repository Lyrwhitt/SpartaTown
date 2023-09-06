using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    public List<GameObject> CharacterSelectBtnImgs = new List<GameObject>();

    public Button selectPenguinBtn;
    public Button selectHumanBtn;

    private void Start()
    {
        selectPenguinBtn.onClick.AddListener(SelectPenguinBtnClicked);
        selectHumanBtn.onClick.AddListener(SelectHumanBtnClicked);
    }

    private void SelectPenguinBtnClicked()
    {
        OffAllActiveSelectBtnImgs();
        PlayerSet.Instance.selectedCharacter = Character.Penguin;
        this.gameObject.SetActive(false);
        SetActiveSelectBtnImg(Character.Penguin);
    }

    private void SelectHumanBtnClicked()
    {
        OffAllActiveSelectBtnImgs();
        PlayerSet.Instance.selectedCharacter = Character.Human;
        this.gameObject.SetActive(false);
        SetActiveSelectBtnImg(Character.Human);
    }

    private void OffAllActiveSelectBtnImgs()
    {
        for(int i = 0; i < CharacterSelectBtnImgs.Count; i++)
        {
            CharacterSelectBtnImgs[i].SetActive(false);
        }
    }

    private void SetActiveSelectBtnImg(Character character)
    {
        CharacterSelectBtnImgs.Find(x => x.name == character.ToString()).SetActive(true);
    }
}
