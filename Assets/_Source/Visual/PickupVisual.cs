using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Visual
{
    public class PickupVisual : MonoBehaviour
    {
        private int amount = 0;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GameObject congratsScreen;
        [SerializeField] private int sceneNumber;

        public void updateAmount()
        {
            ++amount;
            text.text = "x" + amount;
            if (amount == 3 && sceneNumber == 0)
            {
                SceneManager.LoadScene(1);
            }
            if (amount == 3 && sceneNumber == 1)
            {
                congratsScreen.gameObject.SetActive(true);
            }
        }
    }
}
