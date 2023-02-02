using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class MoveForwardCommand : Command
    {
        private MoveObject moveObject;


        public MoveForwardCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }


        public void Execute()
        {
            moveObject.MoveForward();
        }


        //Undo is just the opposite
        public void Undo()
        {
            moveObject.MoveBack();
        }
    }
}
