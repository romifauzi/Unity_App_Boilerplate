using BoilerplateRomi;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventController.AddListener(EventId.EventTest, DebugArgLess);
        EventController.AddListener<string>(EventId.EventTest, DebugSomething);
        EventController.AddListener<string>(EventId.EventTest, DebugSomethingElse);
        EventController.AddListener<Vector3>(EventId.EventTest, DebugVector);
        EventController.AddListener<Vector3, string>(EventId.EventTest, Debug2Vectors);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventController.TriggerActions(EventId.EventTest, "Test 1 2 3");
            EventController.RemoveListener<string>(EventId.EventTest, DebugSomething);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EventController.TriggerActions(EventId.EventTest, Vector3.one);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EventController.TriggerActions(EventId.EventTest, 2f * Vector3.one);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EventController.TriggerActions(EventId.EventTest, Vector3.zero, "gokilllll");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EventController.TriggerActions(EventId.EventTest);
        }
    }

    private void DebugArgLess()
    {
        Debug.Log("Invoked argument less callback");
    }

    void DebugSomething(string text)
    {
        Debug.Log(text);
    }

    void DebugSomethingElse(string text)
    {
        Debug.Log(text + " another");
    }

    void DebugVector(Vector3 someVector)
    {
        Debug.Log(someVector);
    }

    void Debug2Vectors(Vector3 vecA, string vecB)
    {
        Debug.Log($"{vecA} {vecB}");
    }
}
