using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("UI")]
    public SimpleHUD hud;

    [Header("Audio Feedback")]
    public AudioClip targetClip;
    public AudioClip obstacleClip;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    [Header("Custom Font")]
    public Font poppinsFont;

    private string screenMessage = "";
    private float displayTimer = 0f;
    private Color messageColor = Color.yellow;

    private void OnTriggerEnter(Collider other)
    {
        HandleContact(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleContact(collision.gameObject);
    }

    private void HandleContact(GameObject touchedObject)
    {
        if (touchedObject.CompareTag("Target"))
        {
            const string message = "Target tersentuh. Praktikum berhasil.";
            Debug.Log(message);

            screenMessage = message;
            displayTimer = 4f;
            messageColor = new Color32(46, 204, 113, 255); 

            if (hud != null)
                hud.SetStatus(message);

            PlayClip(targetClip, touchedObject.transform.position);
            touchedObject.SetActive(false);
        }
        else if (touchedObject.CompareTag("Obstacle"))
        {
            string message = "Obstacle tersentuh: " + touchedObject.name;
            Debug.Log(message);

            screenMessage = message;
            displayTimer = 3f;
            messageColor = new Color32(231, 76, 60, 255); 

            if (hud != null)
                hud.SetStatus(message);

            PlayClip(obstacleClip, touchedObject.transform.position);
        }
    }

    private void PlayClip(AudioClip clip, Vector3 position)
    {
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, position, sfxVolume);
    }

    private void Update()
    {
        if (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
        }
        else
        {
            screenMessage = "";
        }
    }

    private void OnGUI()
    {
        if (!string.IsNullOrEmpty(screenMessage))
        {
            GUIStyle messageStyle = new GUIStyle(GUI.skin.box);
            messageStyle.fontSize = 13; 
            messageStyle.fontStyle = FontStyle.Bold;
            messageStyle.alignment = TextAnchor.MiddleCenter;
            messageStyle.normal.textColor = messageColor; 

            if (poppinsFont != null)
            {
                messageStyle.font = poppinsFont;
            }

            float boxWidth = 380f;
            float boxHeight = 35f;

            float posX = (Screen.width - boxWidth) / 2f;
            
            float posY = 140f; 

            GUI.Box(new Rect(posX, posY, boxWidth, boxHeight), screenMessage, messageStyle);
        }
    }
}