using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement;

public class SisterDialogue2 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation sisterConversation;
    private bool playerInRange = false;

    private void Start()
    {
        sisterConversation = dialogueObject.GetComponent<NPCConversation>();
        if (sisterConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (GameManager.Instance.spokeToKid2) && (!GameManager.Instance.spokeToSister2) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(sisterConversation);

            if (!GameManager.Instance.spokeToCousin2)
            {
                Debug.Log("Starting kid conversation (not spoken to kid2)");
            }
            else if (GameManager.Instance.spokeToCousin2)
            {
                Debug.Log("Starting kid conversation (spoken to kid2)");
            }

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

            GameManager.Instance.spokeToSister2 = true;

            // Check if the conversation is over
            if (!ConversationManager.Instance.IsConversationActive && GameManager.Instance.spokeToSister2)
            {
                // Load the next scene
                SceneManager.LoadScene("CutSceneAct1To2");
            }

        }
    }

}
