using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Aufgabe2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tmpFibonacci;
    [SerializeField]
    private InputField inputField;
    [SerializeField] private GameObject numberBoxPrefab;

    // Update is called once per frame
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
            transform.eulerAngles += new Vector3(-mouseInputY, mouseInputX, 0) * 2f;
        }
    }

    public void ExecuteFibonacci()
    {
        for (int i = 1; i < Convert.ToInt16(inputField.text); i++)
        {
            tmpFibonacci[i % 2].GetComponentInChildren<TextMesh>().text = ""
                    + (Convert.ToInt16(tmpFibonacci[0].GetComponentInChildren<TextMesh>().text)
                    + Convert.ToInt16(tmpFibonacci[1].GetComponentInChildren<TextMesh>().text));
        }

        GameObject result = Instantiate(tmpFibonacci[0]);
        result.transform.Translate(Vector3.right * 6);
        TextMesh text = result.GetComponentInChildren<TextMesh>();
        text.text = ""
            + (Convert.ToInt16(tmpFibonacci[0].GetComponentInChildren<TextMesh>().text)
            + Convert.ToInt16(tmpFibonacci[1].GetComponentInChildren<TextMesh>().text));
    }

}
