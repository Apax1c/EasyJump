using UnityEngine;

public class Platform : MonoCache
{
    [SerializeField] private Collider platformCollider;
    private bool isBounded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (platformCollider.bounds.Intersects(collision.collider.bounds))
        {
            if (!isBounded)
            {
                for (int i = 0; i < 2; i++)
                {
                    PlatformSpawner.Instance.SpawnPlatformAroundCylinder();
                }
                isBounded = true;
            }
            else
            {
                return;
            }
        }
    }

    public override void OnTick()
    {
        if (SphereBounce.Instance.gameObject.transform.position.y > this.gameObject.transform.position.y + 5)
        {
            Destroy(this.gameObject);
        }
    }
}
