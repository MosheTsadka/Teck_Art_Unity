using UnityEngine;

public class SizeEditor1 : MonoBehaviour, IInteractable
{
    private Vector3 RandomSize() => new Vector3(Random.Range(0.3f, 3), Random.Range(0.3f, 3), 0);
    
    public void Interact()
    {
        transform.localScale = RandomSize();
    }
}
