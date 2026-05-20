using Unity.VisualScripting;
using UnityEngine;

public class TowerSocket : MonoBehaviour{
    public GameObject HeldTower;

    void OnDrawGizmos(){
        Gizmos.color = HeldTower ? Color.red : Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 0.8f);
    }
}
