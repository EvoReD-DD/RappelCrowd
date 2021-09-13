using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody player;
    [SerializeField] float powerForce = 100f;
    [SerializeField] float powerJump = 100f;
    [SerializeField] Transform enemy;
    [SerializeField] Transform countTransform;
    [SerializeField] Transform camera;
    Animator playerAnimator;

    [Header("OnCollisionEvent!")]
    public UnityEvent onCollisionEnterEvent;
    private void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetMouseButton(0))
        {
            player.AddForce(-Vector3.right * powerForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetMouseButtonUp(0))
        {
            player.AddForce(Vector3.right * powerJump * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            onCollisionEnterEvent.Invoke();
        }
    }
    public void PlayerlookEnemy()
    {
        player.transform.LookAt(enemy);
        countTransform.transform.rotation=camera.transform.rotation;
    }
    public void AnimatorSet()
    {
        playerAnimator.SetTrigger("Fight");
    }
}
