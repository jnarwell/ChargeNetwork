//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KBVT_Trigger : MonoBehaviour
//{
//    public KBVT_Text kbvttext;

//    public KROC_Trigger kroctrigger;
//    public KPBG_Trigger kpbgtrigger;
//    //public KBVT_Trigger kbvttrigger;
//    public KRUT_Trigger kruttrigger;
//    public KJHW_Trigger kjhwtrigger;
//    public KCAK_Trigger kcaktrigger;
//    public KVBT_Trigger kvbttrigger;
//    public KRKD_Trigger krkdtrigger;
//    public KMHT_Trigger kmhttrigger;
//    public KGHG_Trigger kghgtrigger;
//    public KHPN_Trigger khpntrigger;
//    public KPNE_Trigger kpnetrigger;
//    public KFDK_Trigger kfdktrigger;
//    public KCHO_Trigger kchotrigger;
//    public KTTA_Trigger kttatrigger;
//    public KFLO_Trigger kflotrigger;
//    public KCHS_Trigger kchstrigger;
//    public KAYS_Trigger kaystrigger;
//    public KJAX_Trigger kjaxtrigger;
//    public KORL_Trigger korltrigger;
//    public KBAK_Trigger kbaktrigger;
//    public KPCD_Trigger kpcdtrigger;
//    public KUNO_Trigger kunotrigger;
//    public KTUL_Trigger ktultrigger;
//    public KOKC_Trigger kokctrigger;
//    public KAFW_Trigger kafwtrigger;
//    public KACT_Trigger kacttrigger;
//    public KAUS_Trigger kaustrigger;
//    public KABI_Trigger kabitrigger;
//    public KBLH_Trigger kblhtrigger;
//    public KSMX_Trigger ksmxtrigger;
//    public KSNS_Trigger ksnstrigger;
//    public KMHR_Trigger kmhrtrigger;
//    public KUKI_Trigger kukitrigger;
//    public KSLE_Trigger ksletrigger;


//    public int counter = 1;

//    public void OnMouseDown()
//    {
//        trigger();
//        if (kroctrigger.counter % 2 == 0)
//        {
//            kroctrigger.trigger();
//        }
//        //if (kbvttrigger.counter % 2 == 0)
//        //{
//        //    kbvttrigger.trigger();
//        //}
//        if (kpbgtrigger.counter % 2 == 0)
//        {
//            kpbgtrigger.trigger();
//        }

//        if (kjhwtrigger.counter % 2 == 0)
//        {
//            kjhwtrigger.trigger();
//        }
//        if (kcaktrigger.counter % 2 == 0)
//        {
//            kcaktrigger.trigger();
//        }
//        if (kvbttrigger.counter % 2 == 0)
//        {
//            kvbttrigger.trigger();
//        }
//        if (krkdtrigger.counter % 2 == 0)
//        {
//            krkdtrigger.trigger();
//        }
//        if (kmhttrigger.counter % 2 == 0)
//        {
//            kmhttrigger.trigger();
//        }
//        if (kghgtrigger.counter % 2 == 0)
//        {
//            kghgtrigger.trigger();
//        }
//        if (khpntrigger.counter % 2 == 0)
//        {
//            khpntrigger.trigger();
//        }
//        if (kpnetrigger.counter % 2 == 0)
//        {
//            kpnetrigger.trigger();
//        }
//        if (kfdktrigger.counter % 2 == 0)
//        {
//            kfdktrigger.trigger();
//        }
//        if (kchotrigger.counter % 2 == 0)
//        {
//            kchotrigger.trigger();
//        }
//        if (kttatrigger.counter % 2 == 0)
//        {
//            kttatrigger.trigger();
//        }
//        if (kflotrigger.counter % 2 == 0)
//        {
//            kflotrigger.trigger();
//        }
//        if (kchstrigger.counter % 2 == 0)
//        {
//            kchstrigger.trigger();
//        }
//        if (kaystrigger.counter % 2 == 0)
//        {
//            kaystrigger.trigger();
//        }
//        if (kjaxtrigger.counter % 2 == 0)
//        {
//            kjaxtrigger.trigger();
//        }
//        if (korltrigger.counter % 2 == 0)
//        {
//            korltrigger.trigger();
//        }
//        if (kbaktrigger.counter % 2 == 0)
//        {
//            kbaktrigger.trigger();
//        }
//        if (kpcdtrigger.counter % 2 == 0)
//        {
//            kpcdtrigger.trigger();
//        }
//        if (kunotrigger.counter % 2 == 0)
//        {
//            kunotrigger.trigger();
//        }
//        if (ktultrigger.counter % 2 == 0)
//        {
//            ktultrigger.trigger();
//        }
//        if (kokctrigger.counter % 2 == 0)
//        {
//            kokctrigger.trigger();
//        }
//        if (kafwtrigger.counter % 2 == 0)
//        {
//            kafwtrigger.trigger();
//        }
//        if (kacttrigger.counter % 2 == 0)
//        {
//            kacttrigger.trigger();
//        }
//        if (kaustrigger.counter % 2 == 0)
//        {
//            kaustrigger.trigger();
//        }
//        if (kabitrigger.counter % 2 == 0)
//        {
//            kabitrigger.trigger();
//        }
//        if (kblhtrigger.counter % 2 == 0)
//        {
//            kblhtrigger.trigger();
//        }
//        if (ksmxtrigger.counter % 2 == 0)
//        {
//            ksmxtrigger.trigger();
//        }
//        if (ksnstrigger.counter % 2 == 0)
//        {
//            ksnstrigger.trigger();
//        }
//        if (kmhrtrigger.counter % 2 == 0)
//        {
//            kmhrtrigger.trigger();
//        }
//        if (kukitrigger.counter % 2 == 0)
//        {
//            kukitrigger.trigger();
//        }
//        if (ksletrigger.counter % 2 == 0)
//        {
//            ksletrigger.trigger();
//        }
//        if (kruttrigger.counter % 2 == 0)
//        {
//            kruttrigger.trigger();
//        }
//    }

//    public void trigger()
//    {
//        kbvttext.yes = true;
//        counter++;
//    }

//}
