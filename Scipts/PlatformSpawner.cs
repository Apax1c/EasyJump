using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner Instance { get; private set; }

    [SerializeField] private GameObject platformPrefab;
    private float yOffset = 0.7f;
    private float radius = -0.5f;
    private float spacing = 0.7f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnPlatformAroundCylinder();
        }
    }

    public void SpawnPlatformAroundCylinder()
    {
        Vector3 parentPosition = transform.position;
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        Vector3 platformSpawnPosition = new Vector3(parentPosition.x + radius * Mathf.Cos(randomAngle), yOffset, parentPosition.z + radius * Mathf.Sin(randomAngle));
        Vector3 cylinderNormal = (platformSpawnPosition - parentPosition).normalized;

        GameObject spawnedPrefab = Instantiate(platformPrefab, platformSpawnPosition, Quaternion.identity, gameObject.transform);
        spawnedPrefab.transform.rotation = Quaternion.LookRotation(cylinderNormal, Vector3.up);

        // Reset x-axis rotation of the instantiated object
        Vector3 eulerRotation = spawnedPrefab.transform.rotation.eulerAngles;
        eulerRotation.x = 0f;
        spawnedPrefab.transform.rotation = Quaternion.Euler(eulerRotation);

        yOffset += spacing;
    }
}