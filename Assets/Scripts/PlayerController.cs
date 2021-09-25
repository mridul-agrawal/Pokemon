using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public LayerMask SolidObjectsLayer;

    private bool isMoving = false;
    private Vector2 input;
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
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

            if(IsWalkable(targetPosition)) StartCoroutine(Move(targetPosition));
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
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjectsLayer) != null ? false : true;
    }

}
