using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadManage : MonoBehaviour
{
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(reloadS);
    }

    void reloadS()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
