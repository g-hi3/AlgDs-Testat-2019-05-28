using System;
using UnityEngine;
using UnityEngine.UI;

public class FibonacciMaster : MonoBehaviour
{
    public GameObject NumberBoxPrefab;
    public Transform FirstBox;
    public Transform SecondBox;
    public Transform TargetPosition;
    public InputField InputField;
    [SerializeField] private int _targetIndex;
    [SerializeField] private int _index;

    public bool ContinueExecution()
    {
        if (_targetIndex < 2) return false;
        return _targetIndex - 2 > _index;
    }

    public void StartExecution()
    {
        _targetIndex = Convert.ToInt32(InputField.text);
        _index = 0;

        NumberBox prefabScript = NumberBoxPrefab.GetComponent<NumberBox>();
        prefabScript.Master = gameObject;
        prefabScript.TargetObject = ContinueExecution() ? SecondBox.gameObject : TargetPosition.gameObject;
        Instantiate(NumberBoxPrefab, FirstBox);
    }

    public void NextExecution()
    {
        _index++;

        NumberBox prefabScript = NumberBoxPrefab.GetComponent<NumberBox>();
        prefabScript.Master = gameObject;
        prefabScript.TargetObject = _index % 2 == 1 ? FirstBox.gameObject : SecondBox.gameObject;
        Transform nextObject = _index % 2 == 0 ? FirstBox : SecondBox;
        Instantiate(NumberBoxPrefab, nextObject);
    }

    public void FinishExecution()
    {
        NumberBox prefabScript = NumberBoxPrefab.GetComponent<NumberBox>();
        prefabScript.Master = gameObject;
        prefabScript.TargetObject = TargetPosition.gameObject;
        Transform nextObject = _index % 2 == 1 ? FirstBox : SecondBox;
        Instantiate(NumberBoxPrefab, nextObject);
    }

}
