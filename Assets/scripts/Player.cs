using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    #region Variables
    [SerializeField] Rigidbody player;
    [SerializeField] float powerForce = 100f;
    [SerializeField] float powerJump = 100f;
    [SerializeField] Transform enemy;
    [SerializeField] Transform countTransform;
    [SerializeField] Transform camera;
    [SerializeField] Text textCount;
    Animator playerAnimator;
    int trigerCountWeight = 1;
    #endregion


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
        if (collider.tag == "CountIncrease")
        {
            PlayerIncreaseCount();
        }
        if (collider.tag == "CountDiscrease")
        {
            PlayerDiscreaseCount();
        }
    }
    public void PlayerlookEnemy()
    {
        player.transform.LookAt(enemy);
        countTransform.transform.rotation = camera.transform.rotation;
    }
    public void AnimatorSet()
    {
        playerAnimator.SetTrigger("Fight");
    }
    void PlayerIncreaseCount()
    {
        int currentCount = Convert.ToInt32(textCount.text);
        int updateCount = currentCount + trigerCountWeight;
        textCount.text = Convert.ToString(updateCount);
    }
    void PlayerDiscreaseCount()
    {
        int currentCount = Convert.ToInt32(textCount.text);
        int updateCount = currentCount - trigerCountWeight;
        textCount.text = Convert.ToString(updateCount);
    }
}
