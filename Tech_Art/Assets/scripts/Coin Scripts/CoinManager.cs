using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int coinAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(coinAmount);
            coinAmount++;
        }
    }

}
