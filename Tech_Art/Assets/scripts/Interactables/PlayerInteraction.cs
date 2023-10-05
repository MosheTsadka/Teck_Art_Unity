using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private const string TAG = "Interactable";


    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        //    if (hit.collider != null)
        //    {
        //        Debug.Log("Hit");
        //        hit.collider.gameObject.SetActive(false);
        //    }
        //}
        InteractWithWiew();
    }

    private void InteractWithWiew()
    {
        //int layerMask = 7;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))if (hit.collider.CompareTag(TAG))
        {
            Debug.Log("Interact");
        }
        {
            var rayHitObject = hit.transform;
            rayHitObject.localScale = new Vector3(2,2,2);
            Debug.Log(rayHitObject.name);

            if (hit.collider != null && hit.collider.CompareTag(TAG))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                interactable.Interact();
                Debug.Log("Interact");
            }
        }
        
    }
}
