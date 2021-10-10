using System.Collections;
using UnityEngine;
/*
⣿⣿⣿⣿⠿⢋⣩⣤⣴⣶⣶⣦⣙⣉⣉⣉⣉⣙⡛⢋⣥⣶⣶⣶⣶⣶⣬⡙⢿⣿
⣿⣿⠟⣡⣶⣿⢟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⠙
⣿⢋⣼⣿⠟⣱⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⢿⣿⣿⣿⣿⣧
⠃⣾⣯⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣿⣿⡈⢿⣿⣿⣿⣿
⢰⣶⣼⣿⣷⣿⣽⠿⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡌⣿⣷⡀⠛⢿⣿⣿
⢃⣺⣿⣿⣿⢿⠏⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡾⣿⣿⣿⣷⢹⣿⣷⣄⠄⠈⠉
⡼⣻⣿⣷⣿⠏⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣞⣿⣿⣿⠸⣿⣿⣿⣿⣶⣤
⣇⣿⡿⣿⠏⣸⣎⣻⣟⣿⣿⣿⢿⣿⣿⣿⣿⠟⣩⣼⢆⠻⣿⡆⣿⣿⣿⣿⣿⣿
⢸⣿⡿⠋⠈⠉⠄⠉⠻⣽⣿⣿⣯⢿⣿⣿⡻⠋⠉⠄⠈⠑⠊⠃⣿⣿⣿⣿⣿⣿
⣿⣿⠄⠄⣰⠱⠿⠄⠄⢨⣿⣿⣿⣿⣿⣿⡆⢶⠷⠄⠄⢄⠄⠄⣿⣿⣿⣿⣿⣿
⣿⣿⠘⣤⣿⡀⣤⣤⣤⢸⣿⣿⣿⣿⣿⣿⡇⢠⣤⣤⡄⣸⣀⡆⣿⣿⣿⣿⣿⣿
⣿⣿⡀⣿⣿⣷⣌⣉⣡⣾⣿⣿⣿⣿⣿⣿⣿⣌⣛⣋⣴⣿⣿⢣⣿⣿⣿⣿⡟⣿
⢹⣿⢸⣿⣻⣶⣿⢿⣿⣿⣿⢿⣿⣿⣻⣿⣿⣿⡿⣿⣭⡿⠻⢸⣿⣿⣿⣿⡇⢹
⠈⣿⡆⠻⣿⣏⣿⣿⣿⣿⣿⡜⣭⣍⢻⣿⣿⣿⣿⣿⣛⣿⠃⣿⣿⣿⣿⡿⠄⣼
⣦⠘⣿⣄⠊⠛⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣼⣿⣿⣿⡿⠁⠄⠟
 */

public class LedgeClimb : MonoBehaviour
{
    private PlayerState ps;
    private PlayerController pc;
    private Collisions coll;
    private Rigidbody2D rb;
    private Coroutine climbingLedge;

    private Vector2 newPos;
    private bool lnml => coll.leftNormalLedgeTarget != null;
    private bool rnml => coll.rightNormalLedgeTarget != null;
    private bool lowl => coll.leftOnewayLedgeTarget != null;
    private bool rowl => coll.rightOnewayLedgeTarget != null;
    private bool mowl => coll.middleOnewayLedgeTarget != null;
    private bool onAnyLedge => lnml || rnml || lowl || rowl;
    private bool onAnyNormalLedge => lnml || rnml;
    private bool onAnyOnewayLedge => lowl || rowl;

    private void Awake()
    {
        ps = GetComponent<PlayerState>();
        pc = GetComponent<PlayerController>();
        coll = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float hDir = pc.horizontalDirection;
        if (onAnyLedge && coll.isHighEnoughToClimbLedge && pc.verticalDirection > 0 && hDir != 0 && !ps.isClimbingLedge) CheckLedgeClimb(hDir);
    }

    private void CheckLedgeClimb(float hDir)
    {
        if (climbingLedge != null)
        {
            StopCoroutine(climbingLedge);
        }

        if (onAnyOnewayLedge && !onAnyNormalLedge) // Only one way platform
        {
            // If only hits on the side
            if (hDir < 0)
            {
                if (lowl && !mowl && !rowl) climbingLedge = StartCoroutine(ClimbingLedge(coll.leftOnewayLedgeTarget, hDir));
            }
            else if (hDir > 0)
            {
                if (!lowl && !mowl && rowl) climbingLedge = StartCoroutine(ClimbingLedge(coll.rightOnewayLedgeTarget, hDir));
            }
        }
        else if (onAnyNormalLedge) // Only normal platform
        {
            if (hDir < 0)
            {
                if (lnml) climbingLedge = StartCoroutine(ClimbingLedge(coll.leftNormalLedgeTarget, hDir));
            }
            else if (hDir > 0)
            {
                if (rnml) climbingLedge = StartCoroutine(ClimbingLedge(coll.rightNormalLedgeTarget, hDir));
            }
        }
        else if (onAnyNormalLedge && onAnyOnewayLedge && !mowl)
        {
            if (hDir < 0)
            {
                if (lnml && !lowl && !rnml && rowl) climbingLedge = StartCoroutine(ClimbingLedge(coll.leftNormalLedgeTarget, hDir));
                else if (!lnml && lowl && rnml && !rowl) climbingLedge = StartCoroutine(ClimbingLedge(coll.leftOnewayLedgeTarget, hDir));
            }
            else if (hDir > 0)
            {
                if (lnml && !lowl && !rnml && rowl) climbingLedge = StartCoroutine(ClimbingLedge(coll.rightNormalLedgeTarget, hDir));
                else if (!lnml && lowl && rnml && !rowl) climbingLedge = StartCoroutine(ClimbingLedge(coll.rightOnewayLedgeTarget, hDir));
            }
        }
    }

    IEnumerator ClimbingLedge(GameObject target, float hDir)
    {
        if (hDir != 0)
        {
            yield return new WaitForFixedUpdate();

            rb.velocity = new Vector2(0, 0);
            ps.canControl = false;
            ps.isClimbingLedge = true;
            rb.isKinematic = true;

            Vector2 characterDimension = coll.GetCharacterDimension();
            Vector2 newPosition = new Vector2();

            Vector3 platformPosition = target.transform.position;
            Vector3 p1 = target.transform.TransformPoint(0, 0, 0);
            Vector3 p2 = target.transform.TransformPoint(1, 1, 0);
            float w = p2.x - p1.x;
            float h = p2.y - p1.y;

            if (hDir > 0)
            {
                // Snap to Platform to Make Consistent Animation
                transform.position = new Vector3(platformPosition.x - w / 2 - coll.characterDimension.x / 2 - 0.02f, platformPosition.y + h / 2 - coll.characterDimension.y / 2 + 0.02f, 0f);
                // Calulate Final Position
                newPosition = transform.position + new Vector3(coll.characterDimension.x, coll.characterDimension.y, 0f);
            }
            else if (hDir < 0)
            {
                // Snap to Platform to Make Consistent Animation
                transform.position = new Vector3(platformPosition.x + w / 2 + coll.characterDimension.x / 2 + 0.02f, platformPosition.y + h / 2 - coll.characterDimension.y / 2 + 0.02f, 0f);
                // Calulate Final Position
                newPosition = transform.position + new Vector3(-coll.characterDimension.x, coll.characterDimension.y, 0f);
            }

            // Fix this when animation is implemented
            Debug.Log("Play Climb Animation");
            yield return new WaitForSeconds(0.2f);

            rb.isKinematic = false;
            // Set New Position After Animation is Done
            transform.position = newPosition;

            ps.canControl = true;
            ps.isClimbingLedge = false;
        }
    }
}
