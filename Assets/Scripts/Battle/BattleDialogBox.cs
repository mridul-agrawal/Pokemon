using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText;

    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }
}
