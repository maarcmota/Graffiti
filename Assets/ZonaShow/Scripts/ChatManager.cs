using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.InputSystem;

public class ChatManager : MonoBehaviour
{
    public static ChatManager Singleton;

    [SerializeField] ChatMessage chatMessagePrefab;
    [SerializeField] CanvasGroup chatContent;
    [SerializeField] TMP_InputField chatInput;

    public string playerName;

    /// ////////////////////RETURN KEY/////////////////////////////

    //public InputAction returnAction;

    //    void OnEnable() { returnAction.Enable(); }
    //    void OnDisable() { returnAction.Disable(); }

    /// /////////////////////////////////////////////////

    // Becomes a Singleton on Awake.
    private void Awake()
    {
        ChatManager.Singleton = this;
    }

    void Update()
    {
        // Checa se a ação acabou de ser disparada neste frame
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendChatMessage(chatInput.text, playerName);
            chatInput.text = "";
        }
    }


    /// /////////////////////////////////////////////////



    //1. Send Chat Message to 'ReceiveChatMessage'
    public void SendChatMessage(string _message, string _fromWho = null)
    {
        if (string.IsNullOrWhiteSpace(_message)) return;

        string S = _fromWho + " > " + _message;
        ReceiveChatMessage(S);
    }

    //3. Create Chat Message
    void AddMessage(string msg)
    {
        ChatMessage CM = Instantiate(chatMessagePrefab, chatContent.transform);
        CM.SetText(msg);
    }

    //2. Receives Chat Message and creates a message to method 'AddMessage'
    void ReceiveChatMessage(string message)
    {
        ChatManager.Singleton.AddMessage(message);
    }
}
