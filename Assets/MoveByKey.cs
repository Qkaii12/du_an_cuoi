using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    private const string IsWalkingParamName = "isWalking";
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rig2D;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private Animator animator;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;

    private void CheckHorizontalInput()
    {
        var isWalking = Input.GetKey(leftKey) || Input.GetKey(rightKey);
        var direction = moveDirection;
        direction.y = rig2D.velocity.y;
        if (isWalking)
        {
            var isFlip = Input.GetKey(leftKey);
            //spriteRenderer.flipX = isFlip;
            var scale = transform.localScale;
            if (isFlip)
            {
                direction *= -1;
                scale.x = -1;
            }
            else
            {
                scale.x = 1;
            }
            transform.localScale = scale;
            rig2D.velocity = direction;
        }

        animator.SetBool(IsWalkingParamName, isWalking);
        if (isWalking)
            Debug.Log(IsWalkingParamName);
    }

    private void Update()
    {
        CheckHorizontalInput();
    }
}
