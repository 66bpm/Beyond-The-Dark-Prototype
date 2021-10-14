using UnityEngine;
/*

                                            `.....``          `                                     
                                        -.:://///////::::.-::-::::::`:.                             
                                      `.++ooosssssoooooosoosssyyysoo/+/--``                         
                              .-....`-+oosssssssssssssssssssssyyhhdddhsso++/+.                      
                         .-/+::::::/+ossssssssssssssssssssssssssssssyhdddhsooo/-`                   
                     -:://o+oooooooossssssssssssssssssssssssssssssssssssyhdmhso++:-`                
                  `-:/++oossssssssssssssssssssssssssssssssssssssssssssssyhhhdmdyooo-.               
                .::+ooossssssssssssssssssssssssssssssssssssssssssssssssssyhmmNMNmyo+:`              
               -//+yhyssssssssssssssssssssssssssssssssssssssssssssyhysshdddmNMMMMNdso/..            
             ..:ohmMMdssssssssssssssssossssssssssssssssssshdhyyddddmhssyyyyyyhhdNNdhyo+-.`          
           .:/+smMMMMdyyhssssssssssssssoossssssssssyyyhdmmmdyysyysssssssssssssssyddsyso+/:-         
         `-/oshNMMMNdysdmyssssssssssssssossssssyyhmmdhhhyyyssosssssssssossssssssssyysssoo:/+        
        --:+ssydddhysssssssssssssssssossshhssshdhsosssssssssssossossssssosssssssssssssssoo+``       
       -/+ossssssssssssssssssssssssysoososhyoossssoosssssssssssosooooooooosssssssssssssssooo`-      
      .+oossssssssssssssssssssssshdhsoososdmmyoosssoossssssssssoooosssssoooooossssssssosss+++-`     
    `./+ossssssssssssssssssssshhsssssoosssdNNNhssssoosssssssssssooossssssoossooosssssssosssoo-:     
    .+sosssssssssssssssssssyyssoossssoosssdNNNNhosssoossssssssssooossssssoosssossssssssoossohdo     
    `+ossssssssssssossssssssssoosssssossssmNNNNmyossoossssssssssyyoossssssysssosssssssssossos+.     
  .:/osssssssssoosssoossssssssossssssysooyNNNNNNdsssossssssssssoyhsossssoymhosossssssssssoso+/.-    
  `:+osssssssssssssssssssssssossssssyhsosdNNNNNNmyossysssssssssoyhyoossoymMdsoossssssssssooo+/.:    
  .+osssssssosssssssssssssssoossssoyddooyddhhdmmNhooyhsssssssoosdmdsoooshdmmsoossssssssssoooo/``    
  .oosssssoosssssssssssssssoossssoyhyoooooo+oosshyosddsoydNNmhhdNNmhsoooo+oysosssssssssssoooo/`     
  .oosssssosssssssssssssssoosssssysso+oooo+oymNmmhhmNmddNNNNNNNNNmyysoooooooooossssssssssooo/`.     
 `/oossssosssssssssssssssosssoyhyohdo+oosssssyysdNNNNNNNNNNNNNNNNdmms+oooosdmyoosssssssss+/+/       
 `+osssssosssssssssssssoosssydmyomNy++osssssso++yNNNNNNNNNNNNNNNNNMdo+osssssssoosssssssso/.``       
 `+osssssosssssssssssoossoymNNyodMNs+osssssssso+yNNNNNNNNNNNNNNNNNMdo+osssssooysssssssso+.:         
 `+oossssoosssssssooosssosmNNmysNMNs+oosssssyyo+yNNNNNNNNNNNNNNNNNMms+sssssso+yyssssssooo/.:/`      
  .oossssssoooooosssssssodNNNmyhNMNy+osyyssydNhohNNNNNNNNNNNNNNNNNNNyohmdyymhohhossssssssoo+::-`    
  .oosssssssssssssssssssoydNNmyhNMNdosmNNdhmNmssmNNNNNNNNNNNNNNNNNNMmsodNNNhoyNNhsssssssssso+://`   
  .oosssssssssssssssssssossshNdydMMNhoshNNNmhsymNNNNNNNNNNNNNNNNNNNNNmyossssdNNNNdsosssssyysoo+--   
  .oosssssssssssssssssssossssymmhmMNNmyoooosydNNNNNNNNNNNNNNmdNNNNNNNNNmmdmNNNNmmmdhhhysymNmsos:`   
  .oosssssssssssssssssssssssssymNNNNNNNmmdmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmmdhyydNmsos/:.  
 `:oosssssssssssssssssssssssssoyNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmdhyssshhsoo+o+:`
 `//sssssssssssssssssssssssyddyhmmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNdsssssssssoo:/oo+
 .oosssssssssssssssssshmmhsdNNmmmmmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNMdoosssssso++-:soo
 -+ssssssssssssssssssymNmNmmdmmdmmmmmmmNNNNNNNNNNNNdhyyyssssssyyhmNNNNNNNNNNNNNNNNNhosssssssso/-:+oo
`:osssssssssssssssysyhdyshdhydhydNmmNNNNNNNNNNNNNNmsossssssooo+sdNNNNNNNNNNNNNNNNNdoosssssssssoooooo
+oossssssssssssssssssssssssssyssdNNNNNNNNNNNNNNNNNNhosyssssssoodNNNNNNNNNNNNNNNNNdsosssooosssssssosy
oossssssssssssssssssssssssssssssdNNNNNNNNNNNNNNNNNNmyosysssysshNNNNNNNNNNNNNNNNmyosssssssoooooso+:..
oosssssssssssssssssssssssssssssosmNNNmdNNNNNNNNNNNNNNdsossssshNNNNNNNNNNNNNNNmyoossssssssssssss/.`  
osssssssssssssssssssssosssssosssssyhysdNNNNNNNNNNNNNNNNmdhhhmNNNNNNNNNNNNNNdyosssssssssssssoo/+:    
osssssssssssssssssssssosssssssssssoosdNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmdyssssssssssssssoos+.``     
oossssssssssssssssssssoosssssssssoooydmNNNNNNNNNNNNNNNNNNNNNNNNNNNmdhysssssssssssssossso+-.`        
oosssssssssssssssssssssoosssssoooooooosshhdmmNNNNNNNNNNNNNmmmddhyssssssssssssssssssoo+o+/`          
+osssossossssssssssssssssossssssssoosydmNNdhsydNNNNNNNNdhhddddhsosssssssssssssssssoo/..`            
.o+ooossoossssssssssssssssssssssooo+smMMMMMNmyhmNNNNNNNhhNMMMMdo//ossssssssssssssoo+`.              
 /:-/+ooo-+oossssssssssssssssssso+///ohNMMMMMNdhydNNNNdymMMMMNy+://+sssssssssoos++:`                
   `---/+.-/oooooooosssssssssoymh/:////ohNMMMMMNmhyhmdydNMMMNy+//+:+ddsssssoo+so/.                  
      `   `:/y+:::ooss+/ossssosmNh+:////+oymNMMMMMNdysshdNMNy+///::omMNhsoo/----`                   
             .....//+:` //oooymMMNy+///::++/oydmNMMmhhddhyhs+//++//omMMMdo/.                        
                         +oydNMMMMNs///+/:/::+++shhyhmddmms+/://:::yNMMMMdo/ .                      
                         :/oyhhhhhyo/:::-.-:-::::/++ssssss+:-------+hhhhhy/-                        

██████  ███████ ███    ███ ██████  ███████ ██████      ██   ██  █████  ██████  ██████  ██    ██     ██████   █████  ██    ██ 
██   ██ ██      ████  ████ ██   ██ ██      ██   ██     ██   ██ ██   ██ ██   ██ ██   ██  ██  ██      ██   ██ ██   ██  ██  ██  
██████  █████   ██ ████ ██ ██████  █████   ██████      ███████ ███████ ██████  ██████    ████       ██   ██ ███████   ████   
██   ██ ██      ██  ██  ██ ██   ██ ██      ██   ██     ██   ██ ██   ██ ██      ██         ██        ██   ██ ██   ██    ██    
██   ██ ███████ ██      ██ ██████  ███████ ██   ██     ██   ██ ██   ██ ██      ██         ██        ██████  ██   ██    ██    
 */

public class PlayerStateOld : MonoBehaviour
{
    private Rigidbody2D rb;
    private CollisionsOld coll;
    private PlayerControllerOld pc;
    private JumpOld jump;

    // Values
    public float lightExposure = 0f;


    // RB Booleans
    public bool isChangingDirection => (rb.velocity.x > 0f && pc.horizontalDirection < 0f) || (rb.velocity.x < 0f && pc.horizontalDirection > 0f);

    // Can Booleans
    public bool canControl = true;
    public bool canMove = true;
    public bool canJump => jump.jumpBufferCounter > 0f && (jump.hangTimeCounter > 0f || jump.extraJumpsValue > 0 || coll.onWall);

    // Action Booleans
    public bool directionAgainstTheWall => (((pc.horizontalDirection > 0f) && coll.onRightWall) || ((pc.horizontalDirection < 0f) && coll.onLeftWall));
    public bool canWallClimb => coll.onWall && pc.verticalDirection > 0 && directionAgainstTheWall && coll.onWallClimbCheck;
    public bool canWallSlide => coll.onWall && !coll.onGround && pc.verticalDirection <= 0 && directionAgainstTheWall && rb.velocity.y < 0f && !canWallClimb;
    //public bool ledgeClimb => pc.verticalDirection > 0 && coll.onLedge;

    // Is Doing or Has Done Something
    public bool isJumping = false;
    public bool isDroppingFromOnewayPlatform = false;
    public bool isClimbingLedge = false;

    public bool isSneaking = false;

    public bool wallJumped = false;
    public bool extraJumped = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CollisionsOld>();
        pc = GetComponent<PlayerControllerOld>();
        jump = GetComponent<JumpOld>();
    }
}
