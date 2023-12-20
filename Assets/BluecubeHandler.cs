using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BluecubeHandler : MonoBehaviour
{
    //[SerializeField] Text resultText;
    [SerializeField] GameObject[] seats; // Unity Inspector���� �� Seat ������Ʈ�� �Ҵ�
    [SerializeField] InputField nameInput; // ����� �̸��� �Է¹޴� UI InputField
    [SerializeField] InputField phoneNumberInput; // ����� ��ȭ��ȣ�� �Է¹޴� UI InputField
    [SerializeField] InputField birthdateInput; // ����� ��������� �Է¹޴� UI InputField
    [SerializeField] GameObject[] shows;
    //[SerializeField] InputField showIDInput; // ����ڰ� �Է��ϴ� Show ID�� �޴� UI InputField

    [SerializeField] string url; // Lambda �Լ��� ��������Ʈ URL�� ���⿡ ��������

    private string selectedShowID;
    private string selectedSeatnumber;

    /*
    private void Start()
    {
        foreach (GameObject seat in seats)
        {
            seat.GetComponent<Button>().onClick.AddListener(() => OnSeatClick(seat.name));
        }
    }
    //*    /*
    private void OnSeatClick(string seatNumber)
    {
        selectedSeatnumber = seatNumber;
       //StartCoroutine(SendShowAndSeat(""));
    }
    */
    public void OnShowClick(string showID)
    {
        // ����ڰ� Show�� ������ ��, �Է¹��� Show ID�� ������
        selectedShowID = showID;
        //StartCoroutine(SendShowAndSeat());
    }

    public void OnSaveClick() => StartCoroutine(SendShowAndSeat("save"));

    public void Registerclick() => StartCoroutine(SendShowAndSeat("register"));

    IEnumerator SendShowAndSeat(string command)
    {
        // ����� �Է� ���� ��������
        string name = nameInput.text;
        string phoneNumber = phoneNumberInput.text;
        string birthdate = birthdateInput.text;

        WWWForm form = new WWWForm();
        form.AddField("command", command);
        form.AddField("showID", selectedShowID);
        form.AddField("seatNo", selectedSeatnumber);
        form.AddField("name", name);
        form.AddField("phonenumber", phoneNumber);
        form.AddField("birthdate", birthdate);

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        /*
        if (www.isNetworkError || www.isHttpError)
        {
            resultText.text = $"Error: {www.error}";
        }
        else
        {
            resultText.text = www.downloadHandler.text;
        }
        */
        print(www.downloadHandler.text);
    }
}
