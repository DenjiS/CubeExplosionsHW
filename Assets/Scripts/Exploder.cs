using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private float _explodeForce = 5f;

    public void Explode(ExplosiveCube cube)
    {
        ExplosiveCube[] spawnedCubes = new ExplosiveCube[0];

        if (Random.value < cube.GetSpawnProbability())
            spawnedCubes = _spawner.SpawnRandomAmount(cube);

        Destroy(cube.gameObject);

        foreach (ExplosiveCube spawnedCube in spawnedCubes)
        {
            spawnedCube.Rigidbody.isKinematic = false;
            spawnedCube.Rigidbody.AddForce(Random.insideUnitSphere.normalized * _explodeForce);
        }
    }
}
