using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject Health;

    public void SetHP(float normalizedHP) {
        Health.transform.localScale = new Vector3(normalizedHP, 1f);
    }
}
