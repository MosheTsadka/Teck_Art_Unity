using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField] private int rotateSpeed;
    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
