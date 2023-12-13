using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
{
    //get videoplayer, next scenename
    public VideoPlayer videoPlayer;
    public string sceneName;

    void Start()
    {
        //get video for webgl
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"cutScene1.mp4"); 
        //when video ends go to end reached function
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        //load next scene
        SceneManager.LoadScene(sceneName); 
    }
}