using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class StartingAgain : MonoBehaviour
    {
        public void StartAgain()
        {
            SceneManager.LoadScene(0);
        }
    }
}
