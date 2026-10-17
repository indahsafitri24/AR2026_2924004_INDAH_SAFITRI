using UnityEngine;

public class TouchDragMove : MonoBehaviour
{
    // Mengatur sensitivitas gerakan agar tidak terlalu cepat atau lambat
    public float dragSpeed = 0.01f;

    void Update()
    {
        // Mengecek apakah ada jari yang menyentuh layar
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Mengecek apakah jari sedang bergerak (mengusap/drag)
            if (touch.phase == TouchPhase.Moved)
            {
                // touch.deltaPosition.x membaca usapan horizontal (kiri/kanan)
                // touch.deltaPosition.y membaca usapan vertikal (atas/bawah di layar HP)
                
                float moveX = touch.deltaPosition.x * dragSpeed;
                float moveZ = touch.deltaPosition.y * dragSpeed;

                // Menggerakkan objek. 
                // Usapan atas/bawah di layar (Y) diubah menjadi gerakan maju/mundur di dunia 3D (Z)
                transform.Translate(new Vector3(moveX, 0, moveZ), Space.World);
            }
        }
    }
}