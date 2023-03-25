using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_MakeBouquet", menuName = "Behaviour Trees/BT_MakeBouquet", order = 1)]
public class BT_MakeBouquet : BehaviourTree
{
    
    public BT_MakeBouquet()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        BOB_Blackboard bl = (BOB_Blackboard)blackboard;
        root = new Sequence(
            new LambdaAction(() => {
                bl.ActivateBouquet();
                return Status.SUCCEEDED;
            }));
    }
}
