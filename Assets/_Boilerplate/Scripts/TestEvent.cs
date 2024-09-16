using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BoilerplateRomi.Views;

public class TestEvent : MonoBehaviour
{
    [SerializeField] UISequencer sequencer;
    [SerializeField] bool reverse;
    [SerializeField] Button button;

    // Start is called before the first frame update
    void Start()
    {
        sequencer.Initialize();
        button.onClick.AddListener(delegate { sequencer.PlaySequence(reverse); });
        sequencer.onDisplayEnd += SequenceEnd;
    }

    void SequenceEnd()
    {
        Debug.Log("Sequence Ended");
    }
}
