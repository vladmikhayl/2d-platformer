using UnityEngine;
using Visual;

namespace Core
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private GameObject pickupHandler;
        private PickupVisual pickupVisual;

        private void Start()
        {
            pickupVisual = pickupHandler.GetComponent<PickupVisual>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                pickupVisual.updateAmount();
                Destroy(gameObject);
            }
        }
    }
}
