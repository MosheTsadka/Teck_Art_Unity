using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private const string TAG = "Interactable";
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.CompareTag(TAG))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                interactable.Interact();
            }
        }
    }
}

//
/*          FOR MULTIPLE INTERACTABLES ON THE SAME OBJECT!!!! >>>>>

            if (hit.collider != null && hit.collider.CompareTag(TAG))
            {
                var interactables = hit.collider.GetComponents<IInteractable>();
                foreach (var i in interactables)
                {
                    i.Interact();
                }
            }

*/
//
