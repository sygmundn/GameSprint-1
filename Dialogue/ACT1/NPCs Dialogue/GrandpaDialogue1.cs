using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class GrandpaDialogue1 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation grandpaConversation;
    private bool playerInRange = false;

    private void Start()
    {
        grandpaConversation = dialogueObject.GetComponent<NPCConversation>();
        if (grandpaConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (!GameManager.Instance.spokeToCousin2) && (!GameManager.Instance.spokeToCousin1) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(grandpaConversation);

            if (!GameManager.Instance.spokeToCousin2)
            {
                Debug.Log("Starting granpda conversation (not spoken to cousin2)");
            }
            else if (GameManager.Instance.spokeToCousin2)
            {
                Debug.Log("Starting grandpa conversation (spoken to cousin2)");
            }

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

        }
    }
}
