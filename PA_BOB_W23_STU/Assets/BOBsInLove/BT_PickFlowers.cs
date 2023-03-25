using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_PickFlowers", menuName = "Behaviour Trees/BT_BOB", order = 1)]
public class BT_PickFlowers : BehaviourTree
{
    
    public BT_PickFlowers()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        BOB_Blackboard bl = (BOB_Blackboard)blackboard;
        DynamicSelector flower = new DynamicSelector();

        flower.AddChild(
            new CONDITION_InstanceNear("flowerDetectionRadius", "flowersTag", "true", "theFlower"),
            new Sequence(
                new ACTION_Arrive("thePark"),
                new ACTION_Deactivate("theFlower"),
                new LambdaAction(() => {
                    bl.CountFlower();
                    return Status.SUCCEEDED;
                })));

        flower.AddChild(
            new CONDITION_AlwaysTrue(),
            new ACTION_CWander("thePark", "80", "40", "0.2", "0.8"));

        root = new RepeatForeverDecorator(flower);

    }
}
