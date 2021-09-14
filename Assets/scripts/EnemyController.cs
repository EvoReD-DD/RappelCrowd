using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] GameObject[] prefabEnemyArray;
    [SerializeField] Transform enemySpace;
    [SerializeField] Animator[] animationEnemy;
    Transform playerTransform;

    private void Start()
    {
        InstantiateEnemyPrefab();
        playerTransform = player.GetComponent<Transform>();
    }
    public void FightTrigger()
    {
        for (int i = 0; i < animationEnemy.Length; i++)
        {
            animationEnemy[i].SetTrigger("fight");
            animationEnemy[i].transform.LookAt(playerTransform);
            prefabEnemyArray[i].transform.position = playerTransform.position;
        }
    }
    void InstantiateEnemyPrefab()
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
}
