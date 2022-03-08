using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for handling any changes in the dialog box during Battles.
/// </summary>
public class BattleDialogBox : MonoBehaviour
{
    // References:
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;
    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;
    [SerializeField] Text ppText;
    [SerializeField] Text typeText;

    // Variables:
    [SerializeField] int lettersPerSecond;
    [SerializeField] Text dialogText;
    [SerializeField] Color highlightedColor;

    // Used to set dialog text.
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    // This method is used to create a typing effect for dialogs.
    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach(var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        yield return new WaitForSeconds(1f);
    }

    // Toggles Dialog Text.
    public void EnableDialogText(bool enable)
    {
        dialogText.enabled = enable;
    }

    // Toggles Action Selector Menu.
    public void EnableActionSelector(bool enable)
    {
        actionSelector.SetActive(enable);
    }

    // Toggles Move Selector Menu.
    public void EnableMoveSelector(bool enable)
    {
        moveSelector.SetActive(enable);
        moveDetails.SetActive(enable);
    }

    // Updates color of the selected action.
    public void UpdateActionSelection(int currentAction)
    {
        for(int i=0; i<actionTexts.Count; i++)
        {
            if (currentAction == i)
                actionTexts[i].color = highlightedColor;
            else
                actionTexts[i].color = Color.black;
        }
    }

    // Updates color of the selected move.
    public void UpdateMoveSelection(int currentMove, Move move)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            if (currentMove == i)
                moveTexts[i].color = highlightedColor;
            else
                moveTexts[i].color = Color.black;
        }

        ppText.text = $"PP {move.PP}/{move.Base.PP}";
        typeText.text = move.Base.MoveType.ToString();
    }

    // This Method Sets up Move names to choose from.
    public void SetMoveNames(List<Move> moves)
    {
        for(int i=0; i<moveTexts.Count; i++)
        {
            if(i<moves.Count)
            {
                moveTexts[i].text = moves[i].Base.Name;
            }
            else
            {
                moveTexts[i].text = "--";
            }
        }
    }

}
