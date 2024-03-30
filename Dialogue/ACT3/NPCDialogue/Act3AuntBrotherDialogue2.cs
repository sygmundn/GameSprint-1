using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act3AuntBrotherDialogue2 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation auntBrotherConversation;
    private bool playerInRange = false;

    private void Start()
    {
        auntBrotherConversation = dialogueObject.GetComponent<NPCConversation>();
        if (auntBrotherConversation == null)
        {
            Debug.LogError("NPCConversation component not found on " + dialogueObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {

        // Check player interaction
        if (playerInRange && Input.GetKeyDown(KeyCode.Return) && (GameManager3.Instance.spokeToAunt2) && (!GameManager3.Instance.spokeToAuntBrother3))
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(auntBrotherConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
                GameManager3.Instance.spokeToAuntBrother3 = true;


            }

        }
    }
}
