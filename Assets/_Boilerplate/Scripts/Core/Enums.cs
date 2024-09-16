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
    public enum EStateName
    {
        MAIN,
        START,
        HELP,
        NONE
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