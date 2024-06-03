using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    public GameObject loadingScreenPrefab;
    private GameObject loadingScreenInstance;
    private Slider progressBar;
    private Text progressText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        if (loadingScreenInstance == null)
        {
            loadingScreenInstance = Instantiate(loadingScreenPrefab);
            DontDestroyOnLoad(loadingScreenInstance);
            progressBar = loadingScreenInstance.GetComponentInChildren<Slider>();
            progressText = loadingScreenInstance.GetComponentInChildren<Text>();
        }

        loadingScreenInstance.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false; // Prevent the scene from activating immediately

        float fakeLoadingTime = 3.0f; // Minimum loading time in seconds
        float elapsedTime = 0f;

        while (!operation.isDone)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (progressBar != null)
            {
                progressBar.value = progress;
            }

            if (progressText != null)
            {
                progressText.text = (progress * 100f).ToString("F0") + "%";
            }

            // Check if the loading is done and the minimum time has passed
            if (operation.progress >= 0.9f && elapsedTime >= fakeLoadingTime)
            {
                operation.allowSceneActivation = true; // Allow the scene to activate
            }

            yield return null;
        }

        loadingScreenInstance.SetActive(false);
    }
}
