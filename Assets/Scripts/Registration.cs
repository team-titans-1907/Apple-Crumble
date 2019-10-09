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
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);
        //string url = "http://localhost/sqlconnect/register.php";
     

        var postRequest = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        Debug.Log("this is thes post request" + postRequest);
        //UnityWebRequest www = UnityWebRequest.Post(url, form);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        //yield return postRequest.SendWebRequest();
        yield return www.SendWebRequest();
        if (!postRequest.isNetworkError || !postRequest.isHttpError)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            Debug.Log("this is name" + nameField.text + passwordField.text);
        }
        else
        {
            Debug.Log("this was not successful. Error" + www);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 4);

    }
    // Start is called before the first frame update

}
