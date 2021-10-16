using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public LayerMask SolidObjectsLayer;
    public LayerMask LongGrassLayer;

    private bool isMoving = false;
    private Vector2 input;
    private Animator playerAnimator;

    public event Action OnEncounter;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

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

    private bool IsWalkable(Vector2 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, LongGrassLayer) != null)
        {
            if(UnityEngine.Random.Range(1,101) <= 10)
            {
                playerAnimator.SetBool("isMoving", false);
                OnEncounter();
            }
        }
    }

}
