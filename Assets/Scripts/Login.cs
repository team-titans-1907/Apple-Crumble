
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }
    IEnumerator LoginPlayer()
    {

        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);


        var postRequest = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        Debug.Log("this is the post request" + postRequest);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();
        if (!postRequest.isNetworkError || !postRequest.isHttpError)
        {
            DBManager.username = nameField.text;
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);

        }
        else
        {
            Debug.Log("login fail. Error #");
        }
    }
    public void VerifyInputs() { 
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 4);

    }

}