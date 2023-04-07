using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereBounce : MonoCache
{
    public static SphereBounce Instance { get; private set; }

    public event EventHandler OnGameOvered;

    private float jumpForce = 10f;
    private float jumpHeight = 1.5f;
    private Vector3 velocity;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Resume();
        velocity = GetComponent<Rigidbody>().velocity;
    }

    public override void OnTick()
    {
        Defeated();
    }

    private void OnTriggerEnter(Collider platform)
    {
        float velocity = Mathf.Sqrt(2f * jumpForce * jumpHeight);
        this.velocity = Vector3.up * velocity;
    }

    public void Defeated()
    {
        if (velocity.y < -6)
        {
            OnGameOvered?.Invoke(this, EventArgs.Empty);
            
            Time.timeScale = 0;
        }
    }

    private void Resume()
    {
        Time.timeScale = 1;
    }
}