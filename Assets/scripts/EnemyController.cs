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
    [SerializeField] private Vector3[] offset;
    private Transform playerTransform;
    [SerializeField] private int prefabArrayVolume = 10;
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

        prefabEnemyArray = new GameObject[prefabArrayVolume];
        animationEnemy = new Animator[prefabArrayVolume];
        for (int i = 0; i < prefabEnemyArray.Length; i++)
        {
            var x = Random.Range(-5, 5);
            var z = Random.Range(-5, 5);
            Vector3 randomPosition = enemySpace.localPosition + new Vector3(x, 0, z);
            prefabEnemyArray[i] = Instantiate(prefabEnemy, randomPosition, Quaternion.identity, enemySpace);
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
            prefabEnemyArray[i].transform.position = Vector3.Slerp(prefabEnemyArray[i].transform.position, playerTransform.position + offset[i], Time.deltaTime);
        }
    }
}
