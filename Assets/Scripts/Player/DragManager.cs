using UnityEngine;
/*
mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmddddddmmmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmmmmdddmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdy+/shhhyymmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmmdys/:/+oydmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmds:-/yhddddhsmmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmdsddhs+:---/sdmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmh/--ohhdhddddhsmmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmoddddddhs+:--:+hmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmo---+hhhhhhddddodmmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmoddddddhhhhs:---+hmmmmmmmmmmmmmmmmhhhhdddddddddhs----hhhhhhhhdddhymmmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmoddddddhhhhhhs:---/smmmmmmmmmmds/--hMMMMMMMMMMMMMh+:-+/+oshhhhhddommmmmmmmmmmmmmmmmmmmmm
mmmmmmmmmmmmhsddhdhhhhhhhhho----:ohyso+++/----/NMMMMMMMMMMMMMMMNmhyo///oyhdhdodddddhhhhhhhhhyyyyyyyy
dddddddddhddhohdddhhhhhhhhhhs-----:---------/sNMMMMMMMMMMMMMMMMMMN/-:-.:syyhh/++++++++++++++++oooooo
++++++////////+ddddhhhhhhhhhh:----------://+++oyNMMMMMMMMMMNmmdddmhhyso+sNNdy+yyhhhhhhhhhhhhddmmdddd
+oooooooosssssssdddhhhhhhhyys:------:/oys:s/.-/yNMMMMMMMMMNooooooyydMMMMMMMMNmyyhhdddddddddmmmmmdddh
hhhddddddddddddysddhhhhhhyhhhhysooshmNMm::/ohmNMMMMMMMMMMMMmdhs/syydmNMMMMMMMMMmyyhhdddddmmmmmdddhdd
dddddddddddddddhsshhhhhhhhhhmdmmmmNMMMMNmmNMMMMMMMMMMMNmdy/:--......-:osdNMMMMMMMd+yhhddddddddhddddd
ddddddddddddhhdddsyhhhhhhshmmhso++odMMMMMMMMMMMMMMMNdo:---.............../smMMMMMMh:sddhhddhhddmmmmm
ddddddddddddddddddoyhhhhhsmdo-...--:mMMMMMMMMMMNNdo:.......................:yNMMMMMh-+dhhhhhdddmmmmm
dddddddmmmmddddddddoyhhhyyy/.....---hMMMMMMMMNNh/............................/mNMMMMs-+ddddhhddddmmm
ddhhdmmmmmmmmmddddddohho:-.....-----dMMMMNNmmd+...............................:mNNMMN/-sddddddhddddm
ddddmmmmmmmmmmmmddddho+........-----NMMMNNmmh-................................./mNNMMd-:dmmmdddddddd
mmmdmmmmmmmmmmmmmmdddy.......------:NMNNmmmh--..................................hNNNNM+-ymmdddddddhh
mmmdmmmmmmmmmmmmmmmmdh/..----------/NNNmmmd::-..................................+NNNNNd-ommddddddddd
mmddmmmmmmmmmmmmmmmmmmh------------+Nmmmmmo::-..................................+mmmmNN:+mmddddddddd
mmdmmmmmmmmmmmmmmmmmmmms-----------smmmdmm/::--...............................-.ommmmmN:ommddddddddd
mmdmmmmmmmmmmmmmmmmmmmmh------....:dmmmmmm:::--.............................-.--dmmmmNN:smmddddddddd
dddddmmmmmmmmmmmmmmmmmmm/-.......-ymmmmmmm/:::---..........................----ommmmmNm-hddddddddddd
hhddddddddmmmmmmmmmmmmmmh-....../ymmmmmmmmy::::----........................---+dmmmmmmh/ddddddddddhh
ddhhhddddddddddddddddddddo...-/sdmmmmmmdmmms::::::-----................------odmdmmmmmoyddddddddhhdd
dddddhhdddddddddddddddddhh/:oydmmmmmmmmmmdmds:::::::------...........------:ymmmdmmmmhsdddddddhhdddd
dddddddhdddddddddddddhhdddhsmmmmmmmmmmmmmmmmmh+::::::::------------------:odmmmmmmmmhydddddhhhdddddd
ddddddddhhddddddddhhdddddddodmmmmmmmmmmmmmmmmmdy+/::::::::-------------:+hmmmmmmmmmyydddddhhdddddddd
mddddddddddddddhhdddddddddhommmmmmmmmmmmmmmmmmmmmhso///::::::::::::::+sdmmmmmmmmmhshddddhdddddddhhdd
ddddddddddddddhddddddddddhsdmdddmmmmmmmmmmmmmmmmmmmmdhyso++////++oshdmmmmmmmmmmdyydddhhdddddmmmmddhh
dddddddddddmmmmdddddddddsymmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdmmdshddhhddddddddmmmmmmd
ddddddddhhdmmmmmmddddddshmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdodddhdddddddddddddmmmm
ddddddhhddmmmmmmmmmdddsdmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmyydddddddddddddddddddmm
ddddhdmmdmmmmmmmmmmmdodmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmd+hddddddddddddddddmmmm
ddhddmmmmmmmmmmmmmmmshmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmshhhdddddddddddddmmmmm
hdddmmmmmmmmmmmmmmmhymmmmdmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdmmmdsddhhdddddddddddmmmmm
dddmmmmmmmmmmmmmmmdsmmmmmdddmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdmmmmmmmmmmmmmddmmsddddhhdddddddddmmmmm
dddmmmmmmmmmmmmmmmsdmmmmmmdmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdddmmmmmmmmmmmmmmmhsdddddhhdddddddmmmmm
ddddmmmmmmmmmmmmmdsmmmmmddmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdmmmmmmmmmmmmmmmmodddddddhhdddddmmmmm
hdddddmmmmmmmmmdhydmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmhyddddddddhhdddmmmmm
dhddddddddddddydMymmmmmmmmmmmmmmmmmmmmmmmmmdmmmdmmmmmmmmmmmdmddmmmmmmmmmmmmmmmmmmodddddddddhhdddmmmd
ddhdddddddddhyNMMymmmdmmdmmmmmmmmmmmmmmmmmmmmdmmmmmmmmmmmmmdmdmmmmmmmmmmmmmmmmmmmshdddddmdddddddmddd
dddddddddddhyNMMMdmmmdmddmmmmmmmmmmmmmmmmmmmmdmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdmmhsdddddddddddddhhdd
dddddddhddhyMMMMMNmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmddmmmmmmmmmmmmmmmmmmmmmmmmdmdoddddddddddddddhhd
 */

public class DragManager : MonoBehaviour
{
    private Player player;
    private bool isChangingDirection;
    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        isChangingDirection = (player.CurrentVelocity.x > 0f && player.InputHandler.MovementInput.x < 0f) || (player.CurrentVelocity.x < 0f && player.InputHandler.MovementInput.x > 0f);
    }
    private void FixedUpdate()
    {
        if (player.Collisions.onGround && player.CurrentVelocity.y <= 0 && !player.isDroppingFromPlatform)
        {
            ApplyGroundDrag();
        }
        else
        {
            ApplyAirDrag();
        }
    }

    public void ApplyGroundDrag()
    {
        if (Mathf.Abs(player.InputHandler.MovementInput.x) < 0.4f || isChangingDirection)
        {
            player.RB.drag = player.playerData.groundLinearDrag;
        }
        else
        {
            player.RB.drag = 0f;
        }
    }
    public void ApplyAirDrag()
    {
        player.RB.drag = player.playerData.airLinearDrag;
    }
}
