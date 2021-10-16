using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Locglo.Boilerplate
{
    public class Enums
    {
        //[System.Serializable]
        public enum ESequenceType
        {
            PARALLEL,
            SERIAL,
            STAGGERED
        }

        public enum EInitCondition
        {
            NO,
            YES
        }

        /// <summary>
        /// State name enum, to be used with state machine
        /// </summary>
        public enum EStateName
        {
            NONE,
            START,
            MAIN,
            HELP
        }

        /// <summary>
        /// View name enum, to be used with UIView class
        /// </summary>
        public enum EViewName
        {
            START,
            MAIN,
            HELP
        }
    }
}