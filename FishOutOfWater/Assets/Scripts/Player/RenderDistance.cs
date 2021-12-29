using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderDistance : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DisableAnim") || collision.gameObject.CompareTag("StandingDolphin") || collision.gameObject.CompareTag("LayingDolphin") || collision.gameObject.CompareTag("FishNetDolphin"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;

            if(collision.gameObject.transform.GetChild(0) != null)
            {
                foreach (Transform child in collision.gameObject.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DisableAnim") || collision.gameObject.CompareTag("StandingDolphin") || collision.gameObject.CompareTag("LayingDolphin") || collision.gameObject.CompareTag("FishNetDolphin"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = false;

            if (collision.gameObject.transform.GetChild(0) != null)
            {
                foreach (Transform child in collision.gameObject.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
