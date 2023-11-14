using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    //get videoplayer, next scenename
    public string sceneName;

    void Start()
    {
        //when video ends go to end reached function
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        //load next scene
        SceneManager.LoadScene(sceneName); 
    }
}