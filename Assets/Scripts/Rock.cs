using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private ParticleSystem collisionParticleSystem;
    [SerializeField] private AudioSource boulderSmashAudioSource;
    [SerializeField] private float shakeModifier = 10f;
    [SerializeField] private float collisionCooldown = 1f;

    private CinemachineImpulseSource cinemachineImpulseSource;

    private float collisionTimer = 0f;

    private void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < collisionCooldown) return;

        FireImpulse();
        CollisionFX(other);

        collisionTimer = 0;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1 / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    private void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        boulderSmashAudioSource.Play();
    }
}