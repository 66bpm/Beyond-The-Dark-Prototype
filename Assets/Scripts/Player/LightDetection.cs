using System.Collections;
using UnityEngine;

/*
⠄⠄⠄⣰⣿⠄⠄⠄⠄⠄⢠⠄⠄⢀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⢰⣿⠿⠄⡀⠄⠄⠄⠘⣷⡀⠄⠢⣄⠄⠄⠄⠄⠄⠄⠄⣠⠖⠁⠄⠄⠄⠄
⠄⣤⢸⣿⣿⣆⠣⠄⠄⠄⠄⠸⣿⣦⡀⠙⢶⣦⣄⡀⠄⡠⠞⠁⢀⡴⠄⠄⠄⠄
⢰⣿⣎⣿⣿⣿⣦⣀⠄⠄⠄⠄⠹⣿⣿⣦⢄⡙⠻⠿⠷⠶⠤⢐⣋⣀⠄⠄⠄⠄
⢸⣿⠛⠛⠻⠿⢿⣿⣧⢤⣤⣄⣠⡘⣿⣿⣿⡟⠿⠛⠂⠈⠉⠛⢿⣿⠄⠄⠄⠄
⠄⡇⢰⣿⣇⡀⠄⠄⣝⣿⣿⣿⣿⣿⣿⣿⣿⣶⣿⡄⠄⠈⠄⣷⢠⡆⠄⠄⠄⠄
⢹⣿⣼⣿⣯⢁⣤⣄⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⣴⠶⣲⣵⠟⠄⠄⠄⠄⠸
⠄⢿⣿⣿⣿⣷⣮⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣾⣟⣡⡴⠄⠄⠄⠄⠁
⠄⠰⣭⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⡀⠄⠄⠄⠄
⠄⠄⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣭⣶⡞⠄⠄⠄⠄⠄
⠄⠄⠐⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠈⠻⣿⣿⣿⣿⣿⣿⣯⣿⣯⣿⣾⣿⣿⣿⣿⣿⡿⠋⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠙⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣵⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⢀⣿⣯⣟⣿⣿⣿⡿⣟⣯⣷⣿⣿⡏⣤⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⣞⢸⣿⣿⣿⣾⣷⣿⣿⣿⣿⣿⣿⣇⣿⡆⠄⠄⠄⠄⠄⠄⠄
 */

public class LightDetection : MonoBehaviour
{
    [SerializeField] private Player player;

    [Header("Light Detection Variables")]
    [SerializeField] private Camera lightDetectionCamera;

    public float waitTime = 0.1f;


    private const int textureSize = 1;

    private Texture2D lightT;
    private RenderTexture tempRT;
    private Rect lightRect;
    private Color lightPixel;

    private void Awake()
    {
        lightT = new Texture2D(textureSize, textureSize, TextureFormat.RGB24, false);
        tempRT = new RenderTexture(textureSize, textureSize, 24);
        lightRect = new Rect(0f, 0f, textureSize, textureSize);
        tempRT.Create();
    }
    private void Start()
    {
        StartLightDetection();
    }
    
    private void StartLightDetection()
    {
        StartCoroutine(LightDetectionUpdate(waitTime));
    }

    private IEnumerator LightDetectionUpdate(float waitTime)
    {
        while (true)
        {
            lightDetectionCamera.targetTexture = tempRT;
            lightDetectionCamera.Render();
            RenderTexture.active = tempRT;
            lightT.ReadPixels(lightRect, 0, 0);
            lightPixel = lightT.GetPixel(0, 0);
            player.lightExposure = (lightPixel.r + lightPixel.g + lightPixel.b) / 3f;
            lightDetectionCamera.targetTexture = null;
            RenderTexture.active = null;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
