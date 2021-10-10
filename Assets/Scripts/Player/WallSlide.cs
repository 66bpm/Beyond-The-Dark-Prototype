using UnityEngine;
/*
---------....`.``..-:::///:-/+shhddmmmmmmmmddddddmmdys+/:::::::::://///////++////++++ooo/----:::::::
--....--------....```./:.-+hdmNNNNNNNNNNNNNNNNNNNNNNNmmdhys++/:::::///////////+++ooooo/---::::::::::
......------:-----.```.-smNNNmNNNNNNNNNNmmmmmNNNNNMMMMNNNNmdhhyso/////++++++++ooooooo/-:::::::::::::
........------:+yds``.+mNNNNNNmdhhhdmNNNNNNmmdhhhhddmmmNNNmmddyhhhho+/++++ooooooooooo:-:::::--------
........````../yhy.`-sNNNNNNNNNNNmdhyyyhdmNNNNNNmdhyhhhhyhhhhysssyyhho+oooooooooooooo:--:::::-------
....----..`````...`-sNNNNNNNNNNNNNNNmdhhyyhhddmNmdhddhdhhhyhhhhhhysooooooooooooooooo+--::::::::-----
-....---..+o/-````-smNNNNNNNNNNNNNNNNNmdhhhyyhhhhhdddmdhddhyyhhhhhhhs++ooooooooo+oo+---:::::::::::::
mdyo/::--shdNmy-`.odNNmNNNNNNNNNNNNNNNNNmdhydmdddmmmddhosssyoyhdddhhooossssyyyyhhhysooo++/::::::::::
dmNNNmdhydhNNNN-`+hNNNNhNNNNNNmNNNNNNNNNmdhhdmmmmmmdy:oyhyo:`.shmNNmNNNNNNNNmmmddddmmNNNNmmhs+/:::::
+oydNNNNNymNNNm`/ymNNNNdhNNNNNNdddNNNNmdhdmmNNNNNNNd-ysssshNs+yyyhdNNMMNNNNMMNNmmy+///+oshhdmmdy+:::
../ymNNNNdmNNNhomdNNNNNNyhmNNNNNmhyhmdhdmNNNNNNNNNN+h/++oo/MNhmhhhdddmNNNNNMMMMMMMNmy/:---:/+oyhdho:
--oyNNNNNNdddmdNNmNNNNNNmyydNNNNNNmyhddNNNNNNNNNNNNyNmsoosdMNNmddmmdhddddmNNMMMMMMMMMMmy/------:/oyy
-:yyNNNNNNNNNdNNmNNmNNNNNdsyhNNNNNddmdNNNNNNNNNNNmmmNNNNNNNNmdddddddmNmmmdddmmNNNNNMMMMMNd+:------:+
-/yyNNNNNNNNmmNNmNNdNNNNNNdsyydNdssssyhdmNNNmmmmmmmmmmdddmmmmmmmmmmdhhhddhdddhhhdddddmmNNMMd+-------
.oyhNNNNNNNNdNNmmNNhmNNNNNNdyy+//sso+oysohmmmmmmdmmdhhdddddmmmmmmmmmmmhhddddddhhhhhhhhhhddmNNh:-----
.yyhNNNNNNNdNNNmNNNhhNNNNNNNds-hm+/++:yMMmmmmmmddmmmddhdmmmmmmmmmmmNNNNhhhhhhhdddddddhhhhhhhdmm+----
-yyydmmNNNNmNNmmNNNyyNNNNNNNd+mN/+//+/NMMmdhdmdddmmmmmNNNNmysymNNNNNNNNNhhhhhhhhhhhddddddhhhhhdmo.--
-yyyyyyyyhhNNNmNNmNyydNNNNmd-hNNs++oyNNNmdhdmddmmmmmNNhsyh+://omNNNNNNNNNyhhhhhhhddmdhhddmmdhhhhdo.-
./osyyyyyyyNNmmNNhdydyNNNmh:`hNNNNNNNNNmdddmdd+::::+oy/:::+ooo++mNNNNNNNNysyhhhddmdddNmdhhdmmmdhyo+.
..shhsssssyNNmNNmhhymdhNNhyysosmNNmddddddddddd::::::::::+hdddddhodNNNNNNNs--.-/+sydmmhdNNmdhhdmmdy:.
.odmhmNNddhNmNNNhdsymNyhyyhdhyyhdddhddddddddmm::::::::+hhdddddddo/yNNNNNNo........-+ymdyhNMNdhhdmmy.
/hhdNNNNdNdNNNNdyhyyNmmhdhdmmdysyhdddddddddmmm+::::::ohdddddhhy+/:/sNNNNN+...........-+yy:+ydNdhhdNy
yymNNNNmmmmmmhhyyyydNNmmmmhyhdmdhyyddddddmmmmNs:::::/hhhhyysosso/:::+mNNm:........-.....:+:.-:sddhhm
ymNNNNNdmdNddyyyyydNmmmmmmmmdhhhddyyyhdmmmmmNNd:::::shhsooossssso+/::/hNd...............---....-+hdh
NNNNNNdmhmNhNmhyyhdNmmmmNNNNmmmdhhhhyyyhdmmmNNNo::::hysooooosssssso+/:/sm..........-----------...-/h
NNNNNdmyyNNddNNhyyhddmNNNNNNNNNmmmmmmmmmmmNNmmmdoo++hoooooooooossssso+::h:`.........-----------....-
NNNNmdyhyNNNymmmysyyhddmNNNNNNNNNNmmmmmmmmNNNNNNNNNmmmdhyssooooooososssss:-................----.---.
NNNNdyhhhNNNhymmmyssyydddmNNNNNNNNNNNNmmmdddmNNNNNNNNNNNNmmdhssooshddmdo-:::---::::::--------...----
NNNdyydyhNNddsymNNdsoyyhdmmmNNNNNNNNNNNNNNmmdhddmNNNNNNNNNNNmmdhhdNNNNdy-::::-------:::::-::::---..-
NNdyyhdyhNdymyssdNNmyyyssyhmmmmNNNNNNNNNNNNNNmddhhdmNNNNNNNNNNmmmmmmmdyh:-::::::::--------::-::::-..
NmyyydyyhNyymyyssyhdyosssssoyhdmmhdmmNNNddNNNddyyyyyhhmdmNNNNNNNmddhsyhh+-.--:::://::-----::-:::::-.
myyyymyyhdsymyyyys+ysyoyo+o+hossoysosyhyosymmsysyoysysosyhmNhyhNNNNydoyhy.-y`.-::oo:--::-::::::::::-
yyyyhmyyhhyyNyyyyy+hoooysyoshoyyooos+ydss++ss+hoooyhhyososhdosymNNNNohs:.`.+..`--::--:::::::::::::::
syyyddyyhyyymhyyyyoo+oyoohy+syyysoossosooossyos/ososhhyssyyssosyNNNmhdmo.`-/....-:::::::::::::::::::
yyyymdyyyhyymdyyyyyysNdyysssssyyyyysssyyyssssssyyyo-:/oyyhhyyyyhmNNNNNNNs`......`.-:::::::::::::::::
yyyymhyysNsyhNyyyyyyyymNdyyyyssssssyyyysssyyyssoso-.....:/oyyyyyyhmNNNNNN:`....```..--::::::::::::::
 */

public class WallSlide : MonoBehaviour
{
    private Movement mm;
    private PlayerState ps;
    private Rigidbody2D rb;
    private Collisions coll;

    [Header("Wall Slide Variables")]
    [SerializeField] private float wallSlideModifier = 0.5f;

    private void Awake()
    {
        mm = GetComponent<Movement>();
        ps = GetComponent<PlayerState>();
        coll = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (ps.canWallSlide && ps.canControl) DoWallSlide();
    }

    private void DoWallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, -mm.maxMovementSpeed * wallSlideModifier);
    }
}
