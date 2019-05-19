using System;
using UnityEngine;

public class NumberBox : MonoBehaviour
{
    public GameObject Master;
    public GameObject TargetObject;
    [SerializeField] private float _maxDistanceDelta = 0.001f;
    private GameObject _sourceObject;
    private FibonacciMaster _fibonacciMaster;

    void Awake()
    {
        _sourceObject = transform.parent.gameObject;
        _fibonacciMaster = Master.GetComponent<FibonacciMaster>();

        var myText = GetComponentInChildren<TextMesh>();
        var parentText = _sourceObject.GetComponentInChildren<TextMesh>();

        myText.text = parentText.text;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetObject.transform.position, _maxDistanceDelta);
    }

    void OnTriggerEnter(Collider other)
    {
        if (TargetObject == null) return;
        if (other.gameObject != TargetObject) return;

        var myText = GetComponentInChildren<TextMesh>();
        var theirText = other.GetComponentInChildren<TextMesh>();
        var nextFibonacci = Convert.ToUInt16(myText.text) + Convert.ToUInt16(theirText.text);

        theirText.text = "" + nextFibonacci;

        if (_fibonacciMaster.ContinueExecution())
        {
            _fibonacciMaster.NextExecution();
        } else
        {
            _fibonacciMaster.FinishExecution();
        }
        
        Destroy(gameObject);
    }

}
