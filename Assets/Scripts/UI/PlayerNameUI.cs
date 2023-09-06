using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    public Transform target;

    public Vector3 offset = Vector3.zero;

    private void FixedUpdate()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }
}
