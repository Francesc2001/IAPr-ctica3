using UnityEngine;
using BTs;

public class CONDITION_NotEnoughForBouquet : Condition
{

    public CONDITION_NotEnoughForBouquet()  {
        /* Receive function parameters and set them */
    }

    // optional
    public override void OnInitialize()
    {
        
    }

    public override bool Check ()
    {
        return !(((BOB_Blackboard)blackboard).EnoughFlowers());
    }

}
