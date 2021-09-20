using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    #region Variables
    [SerializeField] private Rigidbody player;
    [SerializeField] private float powerForce = 100f;
    [SerializeField] private float powerJump = 100f;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform countTransform;
    [SerializeField] private Transform camera;
    [SerializeField] private Text textCount;
    private Animator playerAnimator;
    private int trigerCountWeight = 1;
    #endregion
    [Header("OnCollisionEvent!")]
    public UnityEvent onCollisionEnterEvent;
    private void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
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
    private void OnTriggerEnter(Collider collider)
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
    private void PlayerIncreaseCount()
    {
        int currentCount = Convert.ToInt32(textCount.text);
        int updateCount = currentCount + trigerCountWeight;
        textCount.text = Convert.ToString(updateCount);
    }
    private void PlayerDiscreaseCount()
    {
        int currentCount = Convert.ToInt32(textCount.text);
        int updateCount = currentCount - trigerCountWeight;
        textCount.text = Convert.ToString(updateCount);
    }
}

