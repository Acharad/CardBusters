using System;
using System.Threading.Tasks;
using Assets.Gameplay.Scripts.SceneSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class LoadingScreenController : MonoBehaviour
{
    //public float AnimationDuration => animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;

    [Inject] private SceneLoader _sceneLoader;
    
    #region Inspector Fields

    [SerializeField] private GameObject parentAnimationObject;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip openAnimationClip;
    [SerializeField] private AnimationClip closeAnimationClip;

    #endregion

    #region Private Fields

    private readonly int _closeHash = Animator.StringToHash("Close");
    private readonly int _openHash = Animator.StringToHash("Open");

    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    #region Public Methods

    [Button]
    public async Task CloseAnimationAsync()
    {
        animator.SetTrigger(_closeHash);
        await Task.Delay(TimeSpan.FromSeconds(closeAnimationClip.length));
    }

    [Button]
    public async Task OpenAnimationAsync()
    {
        animator.SetTrigger(_openHash);
        await Task.Delay(TimeSpan.FromSeconds(openAnimationClip.length));
        //parentAnimationObject.SetActive(false);
    }

    [Button]
    public async void TestSceneLoad(string scene)
    {
        await _sceneLoader.LoadSceneAsync(scene);
        await OpenAnimationAsync();
    }
    
    #endregion
}