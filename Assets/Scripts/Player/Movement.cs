using UnityEngine;
/*
  _______   __        _______        _______       __        ________  ___________      ___      ___     ______  ___      ___  _______  ___      ___   _______  _____  ___  ___________  
 /"     "| /""\      /"      \      /"     "|     /""\      /"       )("     _   ")    |"  \    /"  |   /    " \|"  \    /"  |/"     "||"  \    /"  | /"     "|(\"   \|"  \("     _   ") 
(: ______)/    \    |:        |    (: ______)    /    \    (:   \___/  )__/  \\__/      \   \  //   |  // ____  \\   \  //  /(: ______) \   \  //   |(: ______)|.\\   \    |)__/  \\__/  
 \/    | /' /\  \   |_____/   )     \/    |     /' /\  \    \___  \       \\_ /         /\\  \/.    | /  /    ) :)\\  \/. ./  \/    |   /\\  \/.    | \/    |  |: \.   \\  |   \\_ /     
 // ___)//  __'  \   //      /      // ___)_   //  __'  \    __/  \\      |.  |        |: \.        |(: (____/ //  \.    //   // ___)_ |: \.        | // ___)_ |.  \    \. |   |.  |     
(:  (  /   /  \\  \ |:  __   \     (:      "| /   /  \\  \  /" \   :)     \:  |        |.  \    /:  | \        /    \\   /   (:      "||.  \    /:  |(:      "||    \    \ |   \:  |     
 \__/ (___/    \___)|__|  \___)     \_______)(___/    \___)(_______/       \__|        |___|\__/|___|  \"_____/      \__/     \_______)|___|\__/|___| \_______) \___|\____\)    \__| 
*/

public class Movement : MonoBehaviour
{
    private PlayerController pc;
    private PlayerState ps;
    private Collisions coll;
    private Rigidbody2D rb;

    [Header("Movement Variables")]
    [SerializeField] private float movementAcceleration = 70f;
    [SerializeField] public float maxMovementSpeed = 12f;
    [SerializeField] private float sneakMaxMovementSpeed = 6f;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        ps = GetComponent<PlayerState>();
        coll = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (ps.canMove && ps.canControl) Move();
        else if (!ps.canMove && ps.canControl)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(pc.horizontalDirection * maxMovementSpeed, rb.velocity.y), .5f * Time.fixedDeltaTime);
            return;
        }
    }

    private void Move()
    {
        if (pc.pressedShift && coll.onGround)
        {
            ps.isSneaking = true;
            rb.velocity = new Vector2(pc.horizontalDirection * sneakMaxMovementSpeed, rb.velocity.y);
        }
        else
        {
            ps.isSneaking = false;
            rb.AddForce(new Vector2(pc.horizontalDirection, 0f) * movementAcceleration);
            if (Mathf.Abs(rb.velocity.x) > maxMovementSpeed)
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMovementSpeed, rb.velocity.y);
            }
        }
    }
}
