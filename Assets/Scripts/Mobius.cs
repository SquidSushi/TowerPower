using Unity.Mathematics;
using UnityEngine;

public class Mobius : MonoBehaviour{
    void Update(){
        transform.Translate(Mathf.Sin(Time.time) * Time.deltaTime,0,Mathf.Cos(Time.time*2)*Time.deltaTime);
    }
}