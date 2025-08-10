using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// 名前でシーン遷移
    /// </summary>
    /// <param name="name"></param>
    public static void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }
    /// <summary>
    /// シーンの番号でシーン遷移
    /// </summary>
    /// <param name="num"></param>
    public static void SceneChange(int num)
    {
        SceneManager.LoadScene(num);
    }
}
