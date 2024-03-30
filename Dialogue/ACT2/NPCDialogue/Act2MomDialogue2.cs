using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act2MomDialogue2 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation momConversation;
    private bool playerInRange = false;

    private void Start()
    {
        momConversation = dialogueObject.GetComponent<NPCConversation>();
        if (momConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (GameManager2.Instance.spokeToBrother2)
            && ((GameManager2.Instance.spokeToCousin3 < 1) || (GameManager2.Instance.spokeToMom2 < 1) || (GameManager2.Instance.spokeToAunt3 < 1))
            && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");

            ConversationManager.Instance.StartConversation(momConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
                GameManager2.Instance.spokeToMom2 += 1;
                Debug.Log("Spoke to Mom2: " + GameManager2.Instance.spokeToMom2); // Display the count


            }

        }
    }
}
