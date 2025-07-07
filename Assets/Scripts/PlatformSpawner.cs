using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject speedBoostPrefab;
    public GameObject coinPrefab;
    public int numPlatforms = 50;
    public float ySpacing = 2f;

    void Start()
    {
        int speedBoostIndex = numPlatforms / 2;
        for (int i = 0; i < numPlatforms; i++)
        {
            GameObject pf = platformPrefab;
            if (i == speedBoostIndex) pf = speedBoostPrefab;
            Instantiate(pf, new Vector3(0, -i * ySpacing, 0), Quaternion.identity, transform);

            // 30% chance to spawn coin (except on speed boost)
            if (Random.value < 0.3f && i != speedBoostIndex)
                Instantiate(coinPrefab, new Vector3(Random.Range(-1.5f, 1.5f), -i * ySpacing + 1f, 0), Quaternion.identity, transform);
        }
    }
}
