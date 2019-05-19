using UnityEngine;

public class UserMovement : MonoBehaviour
{
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
}
