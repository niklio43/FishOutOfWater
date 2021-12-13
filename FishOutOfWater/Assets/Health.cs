using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfBubbles;

    public Image[] bubbles;
    public Sprite fullBubble;
    public Sprite emptyBubble;

    void Update()
    {

        if (health > numOfBubbles)
        {
            health = numOfBubbles;
        }

        for (int i = 0; i < bubbles.Length; i++)
        {

            if (i < health)
            {
                bubbles[i].sprite = fullBubble;
            }

            else
            {
                bubbles[i].sprite = emptyBubble;
            }

            if (i < numOfBubbles)
            {
                bubbles[i].enabled = true;
            }

            else
            {
                bubbles[i].enabled = false;
            }
        }
    }
}
