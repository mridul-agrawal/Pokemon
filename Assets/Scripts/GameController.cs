using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Enum used for various Game States.
/// </summary>
public enum GameState { FreeRoam, Battle }

/// <summary>
/// The responsibility of this class is to supervise various Game States and switch states when certain events are invoked.
/// </summary>
public class GameController : MonoBehaviour
{
    // Dependencies:
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera WorldCamera;

    // Variables:
    GameState currentGameState;


    private void Start()
    {
        AddEventListeners();
    }

    // This method is used to subscribe to events.
    private void AddEventListeners()
    {
        playerController.OnEncounter += StartBattle;
        battleSystem.OnBattleOver += StopBattle;
    }

    // Changes current state to Battle State.
    void StartBattle()
    {
        currentGameState = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        WorldCamera.gameObject.SetActive(false);

        battleSystem.StartBattle();
    }

    // Changes current state to Free-Roam State.
    void StopBattle(bool won)
    {
        currentGameState = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        WorldCamera.gameObject.SetActive(true);
    }

    // Based on the current state, appropriate game logic is executed.
    private void Update()
    {
        if(currentGameState == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        } else if (currentGameState == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
    }
}
