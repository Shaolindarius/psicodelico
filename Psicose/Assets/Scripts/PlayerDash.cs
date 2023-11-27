using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5.0f; // Distância do dash
    public float dashDuration = 0.2f; // Duração do dash em segundos

    private bool isDashing = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;

        Vector2 dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Vector2 dashTarget = (Vector2)transform.position + dashDirection * dashDistance;

        float startTime = Time.time;
        float journeyLength = Vector2.Distance(transform.position, dashTarget);

        while (Time.time < startTime + dashDuration)
        {
            float distanceCovered = (Time.time - startTime) * dashDistance / dashDuration;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector2.Lerp(transform.position, dashTarget, fractionOfJourney);
            yield return null;
        }

        isDashing = false;
    }
}
