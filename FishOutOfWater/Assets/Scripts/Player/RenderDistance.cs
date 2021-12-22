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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DisableAnim") || collision.gameObject.CompareTag("StandingDolphin") || collision.gameObject.CompareTag("LayingDolphin") || collision.gameObject.CompareTag("FishNetDolphin"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}
