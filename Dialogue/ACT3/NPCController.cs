using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour
{
    public string moveToScene; // The scene to move to

    public Transform targetPositionAuntLR;
    public Transform targetPositionAuntK;

    private void Update()
    {
        // Check the game manager variables to determine when to move
        if (GameManager3.Instance.spokeToAunt2)
        {
            // Check which scene to move to
            string sceneToLoad = moveToScene;

            // Set the target position based on the scene to move to
            Transform targetPosition = targetPositionAuntK;
            if (moveToScene == "LivingRoom3")
            {
                targetPosition = targetPositionAuntLR;
            }

            // Move the NPC to the target position
            if (targetPosition != null)
            {
                transform.position = targetPosition.position;
            }

            // Load the new scene
            SceneManager.LoadScene(sceneToLoad);
        }

    }
}
