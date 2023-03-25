using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_Pee", menuName = "Behaviour Trees/BT_Pee", order = 1)]
public class BT_Pee : BehaviourTree
{
    
    public BT_Pee()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        BOB_Blackboard bl = (BOB_Blackboard)blackboard;

        root = new Sequence(
            new ACTION_Speak("Gotta take\na leak..."),
            new ACTION_Arrive("theToilet"),
            new ACTION_Quiet(),
            new LambdaAction(() => {
                bl.CloseDoor();
                return Status.SUCCEEDED;
            }
            ),
            new ACTION_WaitForSeconds("4"),
            new LambdaAction(() => {
                bl.OpenDoor();
                return Status.SUCCEEDED;
            }),
            new ACTION_Speak("“Oh!!! I\nneeded this"),
            new ACTION_WaitForSeconds("2"),
            new ACTION_Quiet(),
            new LambdaAction(() => {
                bl.PeeAlarmOff();
                return Status.SUCCEEDED;
            }
            ));

    }
}
