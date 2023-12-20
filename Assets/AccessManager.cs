using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Windows;
using UnityEngine.UIElements;

public class AccessManager : MonoBehaviour
{
    [SerializeField] InputField nameinput;
    [SerializeField] InputField phonenumberinput;
    [SerializeField] InputField birthdateinput;

    [SerializeField] InputField showInput;
    [SerializeField] InputField seatInput;
    [SerializeField] InputField audIDInput;
    [SerializeField] InputField ticketIDInput;

    [SerializeField] string url;

    public void EntranceClick() => StartCoroutine(AccountCo("entrance"));

    public void RegisterClick() => StartCoroutine(AccountCo("register"));

    public void AllocateTicketClick() => StartCoroutine(AccountCo("allocate"));

    public void JoinClick() => StartCoroutine(AccountCo("join"));

    IEnumerator AccountCo(string command)
    {
        WWWForm form = new WWWForm();
        form.AddField("command", command);
        form.AddField("name", nameinput.text);
        form.AddField("phonenumber", phonenumberinput.text);
        form.AddField("birthdate", birthdateinput.text);
        form.AddField("audID", audIDInput.text);
        form.AddField("showID", showInput.text);
        form.AddField("seatNo", seatInput.text);
        form.AddField("check_ticketID", ticketIDInput.text);

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        print(www.downloadHandler.text);
    }
}
