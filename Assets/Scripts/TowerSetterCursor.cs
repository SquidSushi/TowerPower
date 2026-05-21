using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSetterCursor : MonoBehaviour{
    public GameObject TowerToPlace;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);

        if (Physics.Raycast(ray, out hit)){
            Transform objectHit = hit.transform;

            float lerpFactor = 40;
            transform.position = Vector3.Lerp(transform.position, objectHit.position, Time.deltaTime * lerpFactor);
            if (Mouse.current.leftButton.wasPressedThisFrame){
                AttemptPlacingTower(objectHit);
            }
        }
    }

    private void AttemptPlacingTower(Transform objectHit){
        var socket = objectHit.GetComponent<TowerSocket>();
        if (socket){
            if (!socket.HeldTower){
                socket.HeldTower = Instantiate(TowerToPlace, socket.transform.position, Quaternion.identity);
            }
            else{
                Debug.Log("Tower placement failed because socket is occupied.");
            }
        }
    }
}
