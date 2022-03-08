using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the HPBar for a Pokemon during battle.
/// </summary>
public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject Health;

    // Sets up initital HP for a Pokemon.
    public void SetHP(float normalizedHP) {
        Health.transform.localScale = new Vector3(normalizedHP, 1f);
    }

    // Sets up new HP Value with a smooth animation.
    public IEnumerator SetHPSmooth(float newHP)
    {
        float currHP = Health.transform.localScale.x;
        float changeAmt = currHP - newHP;

        while(currHP - newHP > Mathf.Epsilon)
        {
            currHP -= changeAmt * Time.deltaTime;
            Health.transform.localScale = new Vector3(currHP, 1f);
            yield return null;
        }
        Health.transform.localScale = new Vector3(newHP, 1f);
    }

}
