using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class ExplosiveCube : MonoBehaviour
{
    private const int MinSpawnedInclusive = 2;
    private const int MaxSpawnedExclusive = 6;
    private const int ScaleDecreaseRatio = 2;

    [SerializeField] private float _explodeForce = 5f;
 
    public void Explode(float probability)
    {
        Destroy(gameObject);

        if (Random.value > probability)
            return;

        int spawnedAmount = Random.Range(MinSpawnedInclusive, MaxSpawnedExclusive);

        for (int i = 0; i < spawnedAmount; i++)
        {
            SpawnCopy();
        }
    }

    private void SpawnCopy()
    {
        ExplosiveCube copy = Instantiate(this, null);
        copy.enabled = false;
        copy.transform.localScale /= ScaleDecreaseRatio;
        copy.GetComponent<MeshRenderer>().material.color = new(Random.value, Random.value, Random.value);

        Rigidbody body = copy.GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.AddForce(GetRandomDirection() * _explodeForce);
    }

    private Vector3 GetRandomDirection() =>
        new Vector3(Random.value, Random.value, Random.value).normalized;
}
