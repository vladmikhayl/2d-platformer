using TMPro;
using UnityEngine;
using Core;

namespace Visual
{
    public class PickupShoesVisual : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private PlayerScript playerScript;

        public void wearShoes()
        {
            text.text = "Jump Boost\nis ON";
            playerScript.jumpForse = 8;
        }
    }
}
