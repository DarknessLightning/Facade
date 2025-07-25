using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;
    private Vector2 input;

    private void Update()
    {
        if (isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
