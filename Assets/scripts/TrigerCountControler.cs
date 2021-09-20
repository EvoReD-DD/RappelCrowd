using UnityEngine;


public class TrigerCountControler : MonoBehaviour
{
    #region variable
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject decal;
    [SerializeField] private GameObject ropePrefab;
    #endregion
    private void OnCollisionEnter(Collision collision)
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
    }
}
