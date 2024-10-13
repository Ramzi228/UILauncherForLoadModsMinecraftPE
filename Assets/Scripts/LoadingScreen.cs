using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public Slider loadingSlider;
    public Text progressText;
    public Button reloadButton;
    public AsyncOperation asyncOperation;

    private Coroutine loadingCoroutine;
    private RectTransform progressTextRectTransform;


    
    public void StartLoading()
    {
        loadingCoroutine = StartCoroutine(LoadingRoutine());
    }

    public void StopLoading()
    {
        if (loadingCoroutine != null)
        {
            StopCoroutine(loadingCoroutine);
            loadingCoroutine = null;
        }
    }

    public void Reload()
    {
        StopLoading();
        StartLoading();
    }

    private void Start()
    {
        progressTextRectTransform = progressText.GetComponent<RectTransform>();
        reloadButton.onClick.AddListener(Reload);
        StartLoading(); // Автоматически запускаем загрузку при входе на сцену
    }

    private IEnumerator LoadingRoutine()
    {
        float startTime = Time.time;
        float endTime = startTime + 5f; // Время загрузки (в секундах)

        // Устанавливаем начальную позицию текста
        progressTextRectTransform.anchoredPosition = new Vector2(-557f, 377.2f);

        float textWidth = progressTextRectTransform.rect.width; // Объявляем переменную textWidth

        while (Time.time < endTime)
        {
            float progress = Mathf.Clamp01((Time.time - startTime) / 5f);
            loadingSlider.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

            // Перемещение текста вместе с загрузочной полосой от начальной позиции
            progressTextRectTransform.anchoredPosition = new Vector2(-557f + progress * (loadingSlider.GetComponent<RectTransform>().rect.width - textWidth), 377.2f);

            yield return null;
        }

        // Завершение загрузки
        loadingSlider.value = 1f;
        progressText.text = "100%";
        progressTextRectTransform.anchoredPosition = new Vector2((loadingSlider.GetComponent<RectTransform>().rect.width - textWidth) / 2, 377.2f);
    }
}