using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunByKey : MonoBehaviour
{
    private const string IsRunningParaName = "run";
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rig2D;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private Animator animator;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private JumpByKey jump;
    [SerializeField] private float movespeed;

    private void CheckHorizontalInput()
    {
        var run = Input.GetKey(leftKey) || Input.GetKey(rightKey);
        var direction = moveDirection;
        direction.y = rig2D.velocity.y;
        if (run)
        {
            var isFlip = Input.GetKey(leftKey);
            var scale = transform.localScale;
            if (isFlip)
            {
                direction *= -1;
                scale.x = (float)-0.1;
            }
            else
            {
                scale.x = (float)0.1;
            }
            transform.localScale = scale;
            rig2D.velocity = direction;
        }
        animator.SetBool(IsRunningParaName, run);
        if (run)
            Debug.Log(IsRunningParaName);
    }

    void Update()
    {
        CheckHorizontalInput();
    }
}
