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
        None,
        Viewer,
        Initialize,
        AR,
        Disconnected,
        Menu,
        UserLogin,
        UserRegister,
        ScanState,
        AssetLibraryState,
        DomainList,
        LayersList,
        Settings,
        UserProfile,
        ForgotPassword,
        Halt,
        ManageWallet
    }

    /// <summary>
    /// View name enum, to be used with UIView class
    /// </summary>
    public enum EViewName
    {
        NavBar,
        Initialize,
        UserView,
        ScanView,
        DomainsList,
        LayersList,
        AssetsList,
        AssetsLibrary,
        AssetsPlacing,
        ARView,
        ProfileView,
        Settings
    }
    
    public enum EventId
    {
        AllowScanning,
        EventTest2
    }

    public enum AssetEnum
    {
        Notes = 0,
        Signage = 1,
        Glb = 2,
        Nft = 3
    }

    public enum MediaTypeEnum
    {
        Images = 0,
        Videos = 1,
        Glb = 2,
        Notes = 3,
        Nft = 4
    }

    public enum IconType
    {
        EXCLAMATION,
        CHECKMARK,
        HELP
    }
}