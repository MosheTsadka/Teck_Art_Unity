using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private LayerMask mask;

    private void Start()
    {
        _cam = Camera.main;
        print(_cam.name);
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = _cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
