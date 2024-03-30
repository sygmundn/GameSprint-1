using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CousinDialogue1 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation cousinConversation;
    private bool playerInRange = false;

    private void Start()
    {
        cousinConversation = dialogueObject.GetComponent<NPCConversation>();
        if (cousinConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (!GameManager.Instance.spokeToMom2) && (!GameManager.Instance.spokeToMom3) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");
            Debug.Log("Cousin Dialogue1 triggered");

            ConversationManager.Instance.StartConversation(cousinConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
            }

            GameManager.Instance.spokeToCousin1 = true;

        }
    }
}
