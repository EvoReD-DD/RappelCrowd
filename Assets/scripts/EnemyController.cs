using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] GameObject[] prefabEnemyArray;
    [SerializeField] Transform enemySpace;
    [SerializeField] Animator[] animationEnemy;

    private void Start()
    {
        InstantiateEnemyPrefab();
    }
    public void FightTrigger()
    {
        for (int i = 0; i < animationEnemy.Length; i++)
        {
            animationEnemy[i].SetTrigger("fight");
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
