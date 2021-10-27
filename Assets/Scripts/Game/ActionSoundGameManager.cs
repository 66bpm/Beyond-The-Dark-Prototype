using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSoundGameManager : MonoBehaviour
{
    public List<ActionSound> actionSounds;

    private void Awake()
    {
        actionSounds = new List<ActionSound>();
    }

    public void RemoveActionSound(ActionSound actionSound)
    {
        actionSounds.RemoveAt(actionSounds.IndexOf(actionSound));
    }
}
