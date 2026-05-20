using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSetterCursor : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);

        if (Physics.Raycast(ray, out hit)){
            Transform objectHit = hit.transform;
            transform.position = Vector3.Lerp(transform.position, objectHit.position, Time.deltaTime*40);
            //transform.position = objectHit.position;
            
        }
    }
}
