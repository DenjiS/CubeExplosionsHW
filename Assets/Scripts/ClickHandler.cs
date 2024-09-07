using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out ExplosiveCube cube))
                {
                    _exploder.Explode(cube);
                }
            }
        }
    }
}
