using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        string url = "http://localhost/sqlconnect/register.php";
     
        Debug.Log("this is name" + nameField.text);
        Debug.Log("this is password " + passwordField.text);

        var postRequest = UnityWebRequest.Post(url, form);
        Debug.Log(postRequest);
        //UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return postRequest.SendWebRequest();

        //WWW www = new WWW(url, form);
        //    yield return www;
        //if(www.text == "0")
        //if (string.IsNullOrEmpty(www.error))

        //if (!www.isNetworkError || !www.isHttpError)
        if(!postRequest.isNetworkError || !postRequest.isHttpError)
        {
            //Debug.Log("user created successfully" + www);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            //Debug.Log("this was not successful. Error" + www);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 4);

    }
    // Start is called before the first frame update

}
