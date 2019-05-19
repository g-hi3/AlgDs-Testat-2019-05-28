using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Aufgabe1 : MonoBehaviour
{

    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private GameObject letterBoxPrefab;
    [SerializeField]
    private GameObject[] letterBoxes;

    public void DisplayString()
    {
        InitializeString();
    }

    private void InitializeString()
    {
        DestroyLetterboxes();
        string original = inputField.text;
        letterBoxes = new GameObject[original.Length];
        for (int i = 0, max = original.Length; i < max; i++)
        {
            letterBoxes[i] = Instantiate(letterBoxPrefab);
            letterBoxes[i].transform.position = new Vector3((-original.Length / 2 + i) * 1.1f, 0, 0);
            TextMesh letter = letterBoxes[i].GetComponentInChildren<TextMesh>();
            letter.text = "" + original[i];
        }
    }

    private void DestroyLetterboxes()
    {
        foreach (GameObject letterbox in letterBoxes)
        {
            Destroy(letterbox);
        }
        letterBoxes = new GameObject[0];
    }

    public void Reverse()
    {
        if (letterBoxes.Length < 2)
            return;

        StartCoroutine(MoveLetterBoxUp(0, Vector3.up * 1.5f, 0.1f));
    }

    private IEnumerator MoveLetterBoxUp(int index, Vector3 direction, float maxDelta)
    {
        GameObject letterbox = letterBoxes[index];
        Vector3 targetPosition = letterbox.transform.position + direction;
        while (letterbox.transform.position != targetPosition)
        {
            letterbox.transform.position = Vector3.MoveTowards(letterbox.transform.position, targetPosition, maxDelta);
            yield return null;
        }
        for (int i = index + 1; i < letterBoxes.Length; i++)
        {
            StartCoroutine(MoveLetterBoxLeft(i, Vector3.left * 1.1f, 0.1f));
        }
        float remainder = (letterBoxes.Length - index - 1);
        StartCoroutine(MoveLetterBoxDown(index, Vector3.right * 1.1f * remainder, 0.1f * remainder));
    }

    private IEnumerator MoveLetterBoxLeft(int index, Vector3 direction, float maxDelta)
    {
        GameObject letterbox = letterBoxes[index];
        Vector3 targetPosition = letterbox.transform.position + direction;
        while (letterbox.transform.position != targetPosition)
        {
            letterbox.transform.position = Vector3.MoveTowards(letterbox.transform.position, targetPosition, maxDelta);
            yield return null;
        }
    }

    private IEnumerator MoveLetterBoxDown(int index, Vector3 direction, float maxDelta)
    {
        GameObject letterbox = letterBoxes[index];
        Vector3 targetPosition = letterbox.transform.position + direction;
        while (letterbox.transform.position != targetPosition)
        {
            letterbox.transform.position = Vector3.MoveTowards(letterbox.transform.position, targetPosition, maxDelta);
            yield return null;
        }
        if (index < letterBoxes.Length - 1)
        {
            StartCoroutine(MoveLetterBoxUp(index + 1, Vector3.up * 1.5f, 0.1f));
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float heightInput = Input.GetAxis("Fire3") - Input.GetAxis("Fire1");
        transform.Translate(new Vector3(horizontalInput, heightInput, verticalInput) * Time.deltaTime * 3.5f);

        if (Input.GetMouseButton(2))
        {
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            Debug.unityLogger.Log("X: " + mouseInputX + ", Y: " + mouseInputY);
            transform.eulerAngles += new Vector3(-mouseInputY, mouseInputX, 0) * 2f;
        }
    }

    public static string ReverseRecursive(string original)
    {
        if (original.Length < 2)
            return original;

        char firstCharacter = original[0];
        string restOfTheString = original.Substring(1, original.Length - 1);

        return ReverseRecursive(restOfTheString) + firstCharacter;
    }

}
