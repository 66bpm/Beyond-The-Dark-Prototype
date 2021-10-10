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
    private PlayerState ps;
    private PlayerController pc;
    private Collisions coll;
    private Rigidbody2D rb;

    [SerializeField] private float groundLinearDrag = 10f;
    [SerializeField] private float airLinearDrag = 2.5f;

    private void Awake()
    {
        ps = GetComponent<PlayerState>();
        pc = GetComponent<PlayerController>();
        coll = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (coll.onGround && !ps.isDroppingFromOnewayPlatform && rb.velocity.y <= 0)
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
        if (Mathf.Abs(pc.horizontalDirection) < 0.4f || ps.isChangingDirection)
        {
            rb.drag = groundLinearDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }
    public void ApplyAirDrag()
    {
        rb.drag = airLinearDrag;
    }
}
