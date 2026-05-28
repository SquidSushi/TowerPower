using UnityEngine;

[CreateAssetMenu(fileName = "TowerStats", menuName = "Scriptable Objects/TowerStats")]
public class TowerStats : ScriptableObject{
    public int Price = 100;
    public float FireRate = 1;
    public float Range = 1;
    public GameObject Projectile = null;
    public float Spread = 0;
}
