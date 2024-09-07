using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class ExplosiveCube : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private float _spawnProbability = 1f;
    [SerializeField] private int _probabilityDecreaseRatio = 2;

    public Transform Transform => _transform;
    public Rigidbody Rigidbody => _rigidbody;
    public MeshRenderer MeshRenderer => _meshRenderer;

    public float GetSpawnProbability()
    {
        float spawnProbability = _spawnProbability;
        _spawnProbability /= _probabilityDecreaseRatio;
        return spawnProbability;
    }
}
