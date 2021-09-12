using UnityEngine;


public class TrigerCountControler : MonoBehaviour
{
    #region variable
    [SerializeField] Collider positiveCountTriger;
    [SerializeField] Collider negativeCountTriger;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform player;
    [SerializeField] GameObject decal;
    [SerializeField] GameObject ropePrefab;
    #endregion
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Vector3 pos = contact.point;
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
        Instantiate(decal, pos, rot);
        //Instantiate(prefab, player.position, prefab.transform.rotation);
        ropePrefab.transform.position = pos;
    }
    public void RopeDestroyEvent()
    {
        Destroy(ropePrefab);
        Debug.Log("destroyrope");
    }
}
