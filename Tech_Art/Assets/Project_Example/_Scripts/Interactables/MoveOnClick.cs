using System.Collections;
using UnityEngine;

public class MoveOnClick : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        StartCoroutine(OutAndBack());
    }

    private IEnumerator OutAndBack()
    {
        while(transform.position.y < 15)
        {
            transform.position += Vector3.up * 1f * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        transform.position = Vector3.zero;
    }
}
