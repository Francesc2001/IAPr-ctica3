using UnityEngine;
using BTs;

public class CONDITION_EnoughForBouquet : Condition
{

    public CONDITION_EnoughForBouquet()  {
        /* Receive function parameters and set them */
    }

    // optional
    public override void OnInitialize()
    {

    }

    public override bool Check ()
    {
        return ((BOB_Blackboard)blackboard).EnoughFlowers();
    }

}
