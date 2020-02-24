using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public int sceneToLoad;
    public Player player;
    public bool goingRight;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {

            //Saves the player direction to decide where to spawn the player
            if (goingRight)
                player.playerData.direction = "goingRight";
            else
                player.playerData.direction = "goingLeft";

            PlayerPersistence.StoreData(player);

            Debug.Log(player.playerData);
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log("Changed Scene!");
        }
    }
}
