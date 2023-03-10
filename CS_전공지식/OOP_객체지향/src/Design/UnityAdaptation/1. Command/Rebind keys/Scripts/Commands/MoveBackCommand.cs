using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class MoveBackCommand : Command
    {
        private MoveObject moveObject;


        public MoveBackCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }


        public void Execute() { moveObject.MoveBack(); }


        //Undo is just the opposite
        public void Undo() { moveObject.MoveForward(); }
    }
}
