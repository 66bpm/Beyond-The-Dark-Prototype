using System.Collections;
using UnityEngine;

/*
⣿⣿⣿⣿⣿⣿⣿⣿⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣿⣿⣿⣿⡏⣏⣿
⣿⣿⣿⣿⣿⣿⣿⢳⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣿⡽⣿⣿⣿⡸⣿
⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⣿⣧⡙⠻⣿⡇⣿
⣧⣿⣿⣿⣿⣷⣯⣿⣿⣿⣿⢟⣞⣿⣿⣿⣿⣿⣿⣿⣽⣿⣿⣿⣿⣿⣦⡈⠃⣿
⣿⣿⣿⣿⣿⣿⣾⣿⣟⣻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣴⡦⣴⣶⣶⣶⣶⡦⣿
⣿⣾⣿⡏⣠⠄⠈⣉⡙⡻⢷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⡿⠿⢿⣿⣿⣿⣿⡇⣿
⣿⣿⣿⣧⢿⡀⢀⣉⠉⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣶⠄⠄⢠⣤⣄⣀⡀⣿
⡻⣿⣿⣿⣿⣧⣿⣿⣧⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢀⣠⣀⠄⢸⣿⣇⣿
⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠾⣛⣿⣵⣿⣿⡟⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⣿
⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠄⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⣿
⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣀⣈⣉⡛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣿
⣿⣽⣿⣿⠊⢿⣿⣿⣿⣇⠿⠿⢿⣿⣦⡸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣿
⣿⣯⣿⣿⡇⠄⠙⠿⣿⣿⣿⣷⣶⣶⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠄⣿
 */

public class OnewayPlatformManager : MonoBehaviour
{
    private GameObject currentOnewayPlatform;

    private Player player;
    private Collider2D col;

    private void Start()
    {
        player = GetComponent<Player>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (player.CurrentVelocity.y <= 0 && player.InputHandler.MovementInput.y < 0 && currentOnewayPlatform != null) // && ps.canControl
        {
            StartCoroutine(DisableCollision());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OnewayPlatform"))
        {
            currentOnewayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OnewayPlatform"))
        {
            currentOnewayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        player.isDroppingFromPlatform = true;
        Collider2D platformCollider = currentOnewayPlatform.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(col, platformCollider);
        yield return new WaitForSeconds(player.playerData.oneWayPlatformResetTime);
        player.isDroppingFromPlatform = false;
        Physics2D.IgnoreCollision(col, platformCollider, false);
    }
}
