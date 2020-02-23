using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public int index;
    public bool start;
    public Player player;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (start)
            {
                player.playerData.direction = "goingBack";
                

            }
            else
            {
                player.playerData.direction = "goingForward";
            }
            Debug.Log(player.playerData.direction);
            OnFadeComplete();

        }
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(index);
    }
}
