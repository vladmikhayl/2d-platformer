using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class CoinsGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] coins = new GameObject[3];

        private List<Vector3> coordsCoin1 = new List<Vector3>()
        {
            new Vector3(2.54f, 0.26f, 0),
            new Vector3(7.54f, 0.74f, 0),
            new Vector3(10.59f, -1.26f, 0),
            new Vector3(18.08f, -2.4f, 0),
            new Vector3(30.14f, -2.54f, 0),
            new Vector3(43.38f, -8.16f, 0)
        };

        private List<Vector3> coordsCoin2 = new List<Vector3>()
        {
            new Vector3(74.61f, -5.62f, 0),
            new Vector3(68.57f, -1.58f, 0),
            new Vector3(85.46f, -2.49f, 0),
            new Vector3(96.59f, -6.26f, 0),
            new Vector3(116.54f, -9.16f, 0)
        };

        private List<Vector3> coordsCoin3 = new List<Vector3>()
        {
            new Vector3(60.56f, 3.47f, 0),
            new Vector3(46.91f, 7.96f, 0),
            new Vector3(-2.85f, 6.85f, 0),
            new Vector3(-10.98f, 5.77f, 0),
            new Vector3(-18.23f, 5.64f, 0)
        };

        void Start()
        {
            int coinPos1 = Random.Range(0, 6);
            int coinPos2 = Random.Range(0, 5);
            int coinPos3 = Random.Range(0, 5);
            coins[0].transform.position = coordsCoin1[coinPos1];
            coins[1].transform.position = coordsCoin2[coinPos2];
            coins[2].transform.position = coordsCoin3[coinPos3];
        }
    }
}
