using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class TurnLeftCommand : Command
    {
        private MoveObject moveObject;


        public TurnLeftCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }


        public void Execute()
        {
            moveObject.TurnLeft();
        }


        //Undo is just the opposite
        public void Undo()
        {
            moveObject.TurnRight();
        }
    }
}
