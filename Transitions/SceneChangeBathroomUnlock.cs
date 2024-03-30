using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneChangeBathroomUnlock : MonoBehaviour
{
    public PlayableDirector timeline; // Assign your Timeline in the Inspector

    private void Start()
    {
        timeline.stopped += OnTimelineFinished;
    }

    private void OnTimelineFinished(PlayableDirector director)
    {
        if (director == timeline)
        {
            // Trigger your scene change logic here
            // You can use SceneManager.LoadScene to load the new scene.
            SceneManager.LoadScene("Hallway2.1");
        }
    }
}