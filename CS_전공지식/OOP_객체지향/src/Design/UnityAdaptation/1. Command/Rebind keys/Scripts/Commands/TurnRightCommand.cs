using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class TurnRightCommand : Command
    {
        private MoveObject moveObject;
    

        public TurnRightCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }


        public void Execute()
        {
            moveObject.TurnRight();
        }


        //Undo is just the opposite
        public void Undo()
        {
            moveObject.TurnLeft();
        }
    }
}
