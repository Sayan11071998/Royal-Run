using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float collisionCooldown = 1f;

    private const string hitString = "Hit";

    private float cooldownTimer = 0f;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }
}