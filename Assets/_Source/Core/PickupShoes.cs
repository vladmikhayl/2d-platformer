using UnityEngine;
using Visual;

namespace Core
{
    public class PickupShoes : MonoBehaviour
    {
        [SerializeField] private GameObject pickupShoesHandler;
        private PickupShoesVisual pickupShoesVisual;

        private void Start()
        {
            pickupShoesVisual = pickupShoesHandler.GetComponent<PickupShoesVisual>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                pickupShoesVisual.wearShoes();
                Destroy(gameObject);
            }
        }
    }
}
