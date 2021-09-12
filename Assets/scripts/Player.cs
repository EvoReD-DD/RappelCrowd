using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody player;
    [SerializeField] float powerForce = 80000f;
    [SerializeField] float powerJump = 100f;
    Animator playerAnimator;

    [Header("OnCollisionEvent!")]
    public UnityEvent onCollisionEnterEvent;
    private void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }
    void Update()
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

            Debug.Log("Enemy");
        }
    }

    void PlayerlookEnemy()
    {

    }
    public void AnimatorSet()
    {
        playerAnimator.SetTrigger("Fight");
    }
}
