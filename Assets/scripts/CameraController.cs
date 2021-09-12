using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] Transform player;
    [SerializeField] Vector3 Offset;
    [SerializeField] float SmoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Offset = camera.position - player.position;
    }

    private void LateUpdate()
    {
        // update position
        Vector3 targetPosition = player.position + Offset;
        camera.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        // update rotation
        transform.LookAt(player);
    }
}
