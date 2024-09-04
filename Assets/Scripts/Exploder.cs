using UnityEngine;

public class Exploder : MonoBehaviour
{
    private const float MaxProbability = 1f;
    private const int ProbabilityDecreaseRatio = 2;

    private float _probability = MaxProbability;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out ExplosiveCube cube))
                {
                    cube.Explode(_probability);
                    _probability /= ProbabilityDecreaseRatio;
                }
            }
        }
    }
}
