using UnityEngine;

public class SizeEditor : MonoBehaviour, IInteractable
{
    private Vector3 RandomSize() => new Vector3(Random.Range(0.3f, 3f), Random.Range(0.3f, 3f), 0);

    public void Interact()
    {
        transform.localScale = RandomSize();
    }
}