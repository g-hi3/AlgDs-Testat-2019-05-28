using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskBehaviour : MonoBehaviour
{
    private static readonly float animationTime = 3;

    internal GameObject targetTower;
    private int nextMarker = 1;
    private float startTime = -1;
    private Vector3 sourcePosition;

    internal bool isFinished { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (targetTower != null)
        {
            if (startTime == -1)
            {
                isFinished = false;
                startTime = Time.time;
                sourcePosition = transform.position;
                nextMarker = 1;
            }

            Vector3 endMarker = GetEndMarker();
            Vector3 startMarker = GetStartMarker();

            if (Vector3.Distance(transform.position, GetThirdMarker()) <= 0.0001f)
            {
                transform.parent = targetTower.transform;
                targetTower = null;
                startTime = -1;
                isFinished = true;
                return;
            }

            // Total distance for current journey.
            float journeyLength = Vector3.Distance(startMarker, endMarker);

            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * animationTime;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }
    }

    private Vector3 GetStartMarker()
    {
        if (nextMarker == 3 || Vector3.Distance(transform.position, GetSecondMarker()) <= 0.0001f)
        {
            return GetSecondMarker();
        }

        if (nextMarker == 2 || Vector3.Distance(transform.position, GetFirstMarker()) <= 0.0001f)
        {
            return GetFirstMarker();
        }

        if (nextMarker == 1 || Vector3.Distance(transform.position, sourcePosition) <= 0.0001f)
        {
            return sourcePosition;
        }

        return Vector3.zero;
    }

    private Vector3 GetEndMarker()
    {
        if (nextMarker == 3 || Vector3.Distance(transform.position, GetSecondMarker()) <= 0.0001f)
        {
            if (nextMarker != 3)
            {
                startTime = Time.time;
            }

            nextMarker = 3;
            return GetThirdMarker();
        }

        if (nextMarker == 2 || Vector3.Distance(transform.position, GetFirstMarker()) <= 0.0001f)
        {
            if (nextMarker != 2)
            {
                startTime = Time.time;
            }

            nextMarker = 2;
            return GetSecondMarker();
        }


        if (nextMarker == 1 || Vector3.Distance(transform.position, sourcePosition) <= 0.0001f)
        {
            if (nextMarker != 1)
            {
                startTime = Time.time;
            }

            nextMarker = 1;
            return GetFirstMarker();
        }

        return Vector3.zero;
    }

    private Vector3 GetFirstMarker()
    {
        return new Vector3(transform.parent.position.x, transform.parent.position.y * 4f, transform.parent.position.z);
    }

    private Vector3 GetSecondMarker()
    {
        return new Vector3(targetTower.transform.position.x, transform.parent.position.y * 4f, targetTower.transform.position.z);
    }

    private Vector3 GetThirdMarker()
    {
        float y = 0.02f * HanoiMaster.diskCount - 0.02f * (targetTower.transform.childCount - 10) - targetTower.transform.position.y;
        return new Vector3(targetTower.transform.position.x, y, targetTower.transform.position.z);
    }

}
