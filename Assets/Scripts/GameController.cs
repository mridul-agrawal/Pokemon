using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera WorldCamera;

    GameState state;


    private void Start()
    {
        playerController.OnEncounter += StartBattle;
        battleSystem.OnBattleOver += StopBattle;
    }

    void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        WorldCamera.gameObject.SetActive(false);

        battleSystem.StartBattle();
    }

    void StopBattle(bool won)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        WorldCamera.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        } else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
    }
}
