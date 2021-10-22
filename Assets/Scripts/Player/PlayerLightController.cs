using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    public Transform playerVisionLights;
    private Player player;
    private Vector3 targetLocalPosition;

    void Start()
    {
        player = GetComponent<Player>();

        targetLocalPosition = player.playerData.visionOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerVisionLights.localPosition != targetLocalPosition)
        {
            playerVisionLights.localPosition = Vector3.MoveTowards(playerVisionLights.localPosition, targetLocalPosition, player.playerData.visionFlipSpeed * Time.deltaTime);
        }
    }

    public void Flip()
    {
        targetLocalPosition.Set(targetLocalPosition.x * -1f, player.playerData.visionOffset.y, 0f);
    }
}
