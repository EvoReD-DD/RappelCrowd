using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    #region variable
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject[] prefabEnemyArray;
    [SerializeField] private Transform enemySpace;
    [SerializeField] private Animator[] animationEnemy;
    [SerializeField] private Vector3 offset;
    private Transform playerTransform;
    #endregion
    private void Start()
    {
        InstantiateEnemyPrefab();
        playerTransform = player.GetComponent<Transform>();
    }
    public void RunToPlayer()
    {
        for (int i = 0; i < animationEnemy.Length; i++)
        {
            animationEnemy[i].SetTrigger("Run");
        }
    }
    public void OnTriggerEnter(Collider player)
    {
        if (player.tag == "FightStart")
        {
            for (int i = 0; i < animationEnemy.Length; i++)
            {
                animationEnemy[i].SetTrigger("fight");
            }
        }
    }
    private void InstantiateEnemyPrefab()
    {
        prefabEnemyArray = new GameObject[10];
        animationEnemy = new Animator[10];
        for (int i = 0; i < prefabEnemyArray.Length; i++)
        {
            prefabEnemyArray[i] = Instantiate(prefabEnemy, enemySpace);
            var enemy = prefabEnemyArray[i];
        }
        for (int y = 0; y < prefabEnemyArray.Length; y++)
        {
            animationEnemy[y] = prefabEnemyArray[y].GetComponent<Animator>();
        }
    }
    public void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < animationEnemy.Length; i++)
        {
            animationEnemy[i].transform.LookAt(playerTransform);
            prefabEnemyArray[i].transform.position = Vector3.Slerp(prefabEnemyArray[i].transform.position, playerTransform.position + offset, Time.deltaTime);
        }
    }
}
