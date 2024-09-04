using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private const int MinSpawnedInclusive = 2;
    private const int MaxSpawnedExclusive = 7;
    private const int ScaleDecreaseRatio = 2;

    [SerializeField] private ExplosiveCube _template;
    [SerializeField] private float _explodeForce = 5f;

    public void SpawnCubes(Vector3 position)
    {
        int spawnedAmount = Random.Range(MinSpawnedInclusive, MaxSpawnedExclusive);

        for (int i = 0; i < spawnedAmount; i++)
            Spawn(position);
    }

    private void Spawn(Vector3 position)
    {
        ExplosiveCube spawned = Instantiate(_template, position, Quaternion.identity);
        spawned.transform.localScale /= ScaleDecreaseRatio;
        spawned.GetComponent<MeshRenderer>().material.color = new(Random.value, Random.value, Random.value);

        Rigidbody body = spawned.GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.AddForce(GetRandomDirection() * _explodeForce);

        Destroy(spawned);
    }

    private Vector3 GetRandomDirection() =>
        new Vector3(Random.value, Random.value, Random.value).normalized;
}
