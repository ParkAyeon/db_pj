using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BluecubeHandler : MonoBehaviour
{
    //[SerializeField] Text resultText;
    [SerializeField] GameObject[] seats; // Unity Inspector에서 각 Seat 오브젝트를 할당
    [SerializeField] InputField nameInput; // 사용자 이름을 입력받는 UI InputField
    [SerializeField] InputField phoneNumberInput; // 사용자 전화번호를 입력받는 UI InputField
    [SerializeField] InputField birthdateInput; // 사용자 생년월일을 입력받는 UI InputField
    [SerializeField] GameObject[] shows;
    //[SerializeField] InputField showIDInput; // 사용자가 입력하는 Show ID를 받는 UI InputField

    [SerializeField] string url; // Lambda 함수의 엔드포인트 URL을 여기에 넣으세요

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
        // 사용자가 Show를 선택할 때, 입력받은 Show ID를 가져옴
        selectedShowID = showID;
        //StartCoroutine(SendShowAndSeat());
    }

    public void OnSaveClick() => StartCoroutine(SendShowAndSeat("save"));

    public void Registerclick() => StartCoroutine(SendShowAndSeat("register"));

    IEnumerator SendShowAndSeat(string command)
    {
        // 사용자 입력 정보 가져오기
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
