using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbilitySelectionManager : MonoBehaviour
{
    [Header("Current Choose")]
    public Animator animator;
    public static string selectedAbility;
    public string goToScene = "SampleScene";
    public AudioSource playGame;

    public void SelectAbility(string ability)
    {
        selectedAbility = ability;
        playGame.Play();
        StartCoroutine(LoadLevel(goToScene));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
