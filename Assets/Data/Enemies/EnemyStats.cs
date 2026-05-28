using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject{
    public float Speed;
    public int MaxHP;
    public int Bounty;
}
