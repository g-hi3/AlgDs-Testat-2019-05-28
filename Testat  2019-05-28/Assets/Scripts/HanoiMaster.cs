using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HanoiMaster : MonoBehaviour
{
    public static readonly float MaxDistanceDelta = 0.04f;
    internal static int diskCount;

    [SerializeField] private GameObject _sourceTower;
    [SerializeField] private GameObject _auxTower;
    [SerializeField] private GameObject _targetTower;
    [SerializeField] private GameObject _diskPrefab;
    [SerializeField] private InputField _inputField;
    
    public int InputValue
    {
        get
        {
            int.TryParse(_inputField.text, out var diskCount);
            return diskCount;
        }
    }

    public void SetupTowers()
    {
        EmptyTower(_sourceTower);
        EmptyTower(_targetTower);
        EmptyTower(_auxTower);
        FillTower(_sourceTower, InputValue);
        TransformTower(_sourceTower, _sourceTower);
        TransformTower(_targetTower, _sourceTower);
        TransformTower(_auxTower, _sourceTower);
    }

    private void EmptyTower(GameObject tower)
    {
        while (0 < tower.transform.childCount)
        {
            Destroy(tower.transform.GetChild(0));
        } 
    }

    private void FillTower(GameObject tower, int diskCount)
    {
        HanoiMaster.diskCount = diskCount;
        for (int i = 0; i < diskCount; i++)
        {
            float diskVerticalPosition = 0.02f * diskCount - 0.02f * i - tower.transform.position.y;
            GameObject disk = Instantiate(_diskPrefab, new Vector3(tower.transform.position.x, diskVerticalPosition, tower.transform.position.z), Quaternion.identity, tower.transform);
            Renderer r = disk.GetComponent<Renderer>();
            r.material.color = Color.HSVToRGB(1f * i / diskCount, 1, 1);
            float diskWidth = 1f + 9f / diskCount * (i + 1);
            float diskHeight = 0.05f / diskCount;
            disk.transform.localScale = new Vector3(diskWidth, diskHeight, diskWidth);
        }
    }

    private void TransformTower(GameObject toTransform, GameObject diskParent)
    {
        int size = diskParent.transform.childCount;
        toTransform.transform.Translate(toTransform.transform.localScale.x, 0.1f * size, toTransform.transform.localScale.z);
    }

    public void ExecuteMove()
    {
        MoveTower(_sourceTower.transform.childCount, _sourceTower, _targetTower, _auxTower);
    }

    private void MoveTower(int n, GameObject sourceTower, GameObject targetTower, GameObject auxTower)
    {
        if (n == 1)
        {
            MoveDisk(sourceTower, targetTower);
        }
        else
        {
            MoveTower(n - 1, sourceTower, auxTower, targetTower);
            MoveTower(n - 1, auxTower, targetTower, sourceTower);
        }
    }

    private void MoveDisk(GameObject sourceTower, GameObject targetTower)
    {
        // move topmost disk
        GameObject disk = sourceTower.transform.GetChild(0).gameObject;
        DiskBehaviour diskBehaviour = disk.GetComponent<DiskBehaviour>();
        diskBehaviour.targetTower = targetTower;
        // I give up, this method just won't wait until the disk finishes moving, no matter what I do.
    }

}