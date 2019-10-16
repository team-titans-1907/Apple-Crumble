
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;
    public GameObject emailValidator;
    public GameObject passwordValidator;
    public const string MatchEmailPattern =
     @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";



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
        emailValidator.SetActive(false);
        passwordValidator.SetActive(false);
        if (passwordField.text.Length < 4)
        {
            passwordValidator.SetActive(true);
        }
        if (Regex.IsMatch(nameField.text, MatchEmailPattern) == false)
        {
            emailValidator.SetActive(true);
        }
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 4);

    }

}