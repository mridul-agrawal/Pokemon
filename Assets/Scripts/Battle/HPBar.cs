using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject Health;

    public void SetHP(float normalizedHP) {
        Health.transform.localScale = new Vector3(normalizedHP, 1f);
    }

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
