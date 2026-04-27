using Defines;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : Singleton<SceneManagerEx>
{
    // 현재 씬에 배치된 BaseScene 상속 객체를 실시간으로 참조
    public BaseScene CurrentScene => Object.FindObjectOfType<BaseScene>();

    public void LoadScene(EScene type)
    {

        // 2. Enum 이름을 문자열로 변환하여 씬 로드
        string sceneName = System.Enum.GetName(typeof(EScene), type);
        SceneManager.LoadScene(sceneName);
    }
}
