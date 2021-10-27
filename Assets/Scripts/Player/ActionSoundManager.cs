using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSoundManager : MonoBehaviour
{
    [SerializeField] private ActionSound prefab;
    [SerializeField] private ActionSoundGameManager actionSoundGameManager;
    private Player player;
    
    public Vector3 TopSoundPosition { get; private set; }
    public Vector3 BottomSoundPosition { get; private set; }
    public Vector3 LeftSoundPosition { get; private set; }
    public Vector3 RightSoundPosition { get; private set; }
    public Vector3 TargetSoundPosition { get; set; }

    private void Start()
    {
        player = GetComponent<Player>();
        Vector2 characterDimension = player.playerData.characterDimension;
        TopSoundPosition.Set(0f, characterDimension.y/2, 0f);
        BottomSoundPosition.Set(0f, -characterDimension.y/2, 0f);
        LeftSoundPosition.Set(-characterDimension.x/2, 0f, 0f);
        RightSoundPosition.Set(characterDimension.x/2, 0f, 0f);
    }

    public void SpawnActionSound(float radius, float duration, Vector3 playerPosition, Vector3 localPosition, string layerName = "LowActionSound")
    {
        ActionSound actionSound = Instantiate(prefab);
        actionSound.Initialize(radius, playerPosition + localPosition, layerName, actionSoundGameManager);
        actionSoundGameManager.actionSounds.Add(actionSound);
        Destroy(actionSound.gameObject, duration);
    }
}
