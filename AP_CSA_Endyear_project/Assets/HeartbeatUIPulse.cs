using System.Collections;
using UnityEngine;

public class HeartbeatUIPulse : MonoBehaviour
{
    public float pulseScale = 1.08f;
    public float pulseSpeed = 0.08f;
    public float pauseBetweenBeats = 0.15f;
    public float pauseAfterDoubleBeat = 1.0f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(Heartbeat());
    }

    IEnumerator Heartbeat()
    {
        while (true)
        {
            yield return StartCoroutine(Pulse());
            yield return new WaitForSeconds(pauseBetweenBeats);
            yield return StartCoroutine(Pulse());
            yield return new WaitForSeconds(pauseAfterDoubleBeat);
        }
    }

    IEnumerator Pulse()
    {
        Vector3 biggerScale = originalScale * pulseScale;

        float t = 0f;
        while (t < pulseSpeed)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, biggerScale, t / pulseSpeed);
            yield return null;
        }

        t = 0f;
        while (t < pulseSpeed)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(biggerScale, originalScale, t / pulseSpeed);
            yield return null;
        }
    }
}