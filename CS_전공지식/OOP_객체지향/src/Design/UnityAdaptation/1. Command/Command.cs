using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    //Base class for the commands
    //This class should always look like this to make it more general, so no constructors, parameters, etc!!!
    public interface Command
    {
        public abstract void Execute();

        public abstract void Undo();
    }
}
