using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minSpawnedInclusive = 2;
    [SerializeField] private int _maxSpawnedExclusive = 6;
    [SerializeField] private int _scaleDecreaseRatio = 2;


    public ExplosiveCube[] SpawnRandomAmount(ExplosiveCube cube)
    {
        int spawnedAmount = Random.Range(_minSpawnedInclusive, _maxSpawnedExclusive + 1);
        ExplosiveCube[] cubes = new ExplosiveCube[spawnedAmount];

        for (int i = 0; i < spawnedAmount; i++)
            cubes[i] = Spawn(cube);

        return cubes;
    }

    private ExplosiveCube Spawn(ExplosiveCube cube)
    {
        ExplosiveCube spawned = Instantiate(cube);
        spawned.Transform.localScale /= _scaleDecreaseRatio;
        spawned.MeshRenderer.material.color = new(Random.value, Random.value, Random.value);
        return spawned;
    }
}
