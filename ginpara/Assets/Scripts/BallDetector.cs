using UnityEngine;
using System.Collections;

public class BallDetector : MonoBehaviour
{
    [SerializeField] GameObject Defender;

	void Start () {
        Defender.SetActive(false);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Defender.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Defender.SetActive(false);
    }
}
