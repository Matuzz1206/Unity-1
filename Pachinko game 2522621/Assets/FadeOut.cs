using UnityEngine;
using TMPro;

public class FadeOutText : MonoBehaviour
{
    public float delay = 5f;
    public float fadeDuration = 1.5f;

    private TextMeshProUGUI text;
    private Color originalColor;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        originalColor = text.color;
        StartCoroutine(FadeOutRoutine());
    }

    private System.Collections.IEnumerator FadeOutRoutine()
    {
        yield return new WaitForSeconds(delay);

        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);

            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }
        gameObject.SetActive(false);
    }
}