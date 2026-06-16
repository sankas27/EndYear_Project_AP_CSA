using System.Collections;
using UnityEngine;

public class HeartbeatCamera : MonoBehaviour
{
    public float pulseAmount = 0.15f;
    public float pulseSpeed = 0.08f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(Heartbeat());
    }

    IEnumerator Heartbeat()
    {
        while (true)
        {
            yield return StartCoroutine(Pulse());

            yield return new WaitForSeconds(0.15f);

            yield return StartCoroutine(Pulse());

            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator Pulse()
    {
        Vector3 pulsePos = originalPosition + transform.forward * pulseAmount;

        float t = 0f;

        while (t < pulseSpeed)
        {
            t += Time.deltaTime;
            transform.localPosition =
                Vector3.Lerp(originalPosition, pulsePos, t / pulseSpeed);
            yield return null;
        }

        t = 0f;

        while (t < pulseSpeed)
        {
            t += Time.deltaTime;
            transform.localPosition =
                Vector3.Lerp(pulsePos, originalPosition, t / pulseSpeed);
            yield return null;
        }
    }
}