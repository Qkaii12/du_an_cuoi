using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpByKey : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private const string JumpParamName = "jump";
    [SerializeField] private Animator animator;
    [SerializeField] float jumpForce = 10.5f;
    [SerializeField] private Rigidbody2D rig2D;
    [SerializeField] private KeyCode jumpKey;
    public bool ground;

    private void CheckUpArrow()
    {
        if (Input.GetKey(jumpKey))
        {
            animator.SetTrigger(JumpParamName);
            if (ground)
            {
                rig2D.velocity = new Vector2(rig2D.velocity.x, jumpForce);
                ground = false;
            }
        }
    }
    void Update()
    {
        CheckUpArrow();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            ground = true;
        }
    }
}
