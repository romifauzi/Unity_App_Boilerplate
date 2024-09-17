using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoilerplateRomi.Enums
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
    public static class EStateName
    {
        public const string Main = "MAIN";
        public const string Start = "START";
        public const string Help = "HELP";
        public const string None = "NONE";
    }

    /// <summary>
    /// View name enum, to be used with UIView class
    /// </summary>
    public enum EViewName
    {
        
    }

    public enum IconType
    {
        EXCLAMATION,
        CHECKMARK,
        HELP
    }
}