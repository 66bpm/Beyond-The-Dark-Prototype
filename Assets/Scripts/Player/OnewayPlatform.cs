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

public class OnewayPlatform : MonoBehaviour
{
    private GameObject currentOnewayPlatform;
    private CapsuleCollider2D cc;
    private PlayerController pc;
    private PlayerState ps;
    private Rigidbody2D rb;
    private GravityManager gm;

    [Header("One-way Platform Variables")]
    [SerializeField] private float oneWayPlatformResetTime;

    private void Awake()
    {
        cc = GetComponent<CapsuleCollider2D>();
        pc = GetComponent<PlayerController>();
        ps = GetComponent<PlayerState>();
        rb = GetComponent<Rigidbody2D>();
        gm = GetComponent<GravityManager>();
    }

    private void Update()
    {
        if (rb.velocity.y <= 0 && pc.verticalDirection < 0 && currentOnewayPlatform != null && ps.canControl)
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
        ps.isDroppingFromOnewayPlatform = true;
        Collider2D platformCollider = currentOnewayPlatform.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(cc, platformCollider);
        yield return new WaitForSeconds(oneWayPlatformResetTime);
        ps.isDroppingFromOnewayPlatform = false;
        Physics2D.IgnoreCollision(cc, platformCollider, false);
    }
}
