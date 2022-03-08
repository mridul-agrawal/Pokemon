using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is responsible for Handling Game logic when game is in free-roam state. It Takes Player input to handle grid movement and animations.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Variables: 
    public float moveSpeed;
    private bool isMoving = false;
    private Vector2 input;
    private int encounterProbability = 6;

    // References:
    public LayerMask SolidObjectsLayer;
    public LayerMask LongGrassLayer;
    private Animator playerAnimator;

    // Events:
    public event Action OnEncounter;


    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Handles Input, Movement & Animation logic.
    public void HandleUpdate()
    {
        if(!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            playerAnimator.SetFloat("MoveX", input.x);
            playerAnimator.SetFloat("MoveY", input.y);

            var targetPosition = transform.position;
            targetPosition.x += input.x;
            targetPosition.y += input.y;

            if(IsWalkable(targetPosition) && targetPosition!=transform.position) StartCoroutine(Move(targetPosition));
        }
        playerAnimator.SetBool("isMoving", isMoving);
    }

    // This Coroutine is used to move towards the target position in a grid based fashion.
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while((targetPos-transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        CheckForEncounters();
    }

    // returns true if the target position is walkable else false.
    private bool IsWalkable(Vector2 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

    // This method checks if a wild encounter has occured or not.
    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, LongGrassLayer) != null)
        {
            if(UnityEngine.Random.Range(1,101) <= encounterProbability)
            {
                playerAnimator.SetBool("isMoving", false);
                OnEncounter();
            }
        }
    }

}
