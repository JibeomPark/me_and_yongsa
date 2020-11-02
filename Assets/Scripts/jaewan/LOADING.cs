using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LOADING : MonoBehaviour
{
    static string nextScene;

    [SerializeField]
    Image progressBar;
    public static void changeGameScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("loading");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadsceneProcess());
        
    }

    IEnumerator LoadsceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}
