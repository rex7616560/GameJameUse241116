using UnityEngine;

public class CardSelectionController : MonoBehaviour
{
    // 在卡牌物件上掛載這個腳本
    void Update()
    {
        // 檢查滑鼠點擊
        if (Input.GetMouseButtonDown(0))  // 按下左鍵 (0 代表左鍵)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // 從滑鼠位置發射射線
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);  // 設定射線可視化，長度為 10

            //Debug.Log("aaa");
            // 發射射線，檢查是否碰撞到卡牌
            if (Physics.Raycast(ray, out hit,100))
            {
                Debug.Log("bbb");
                // 檢查是否點擊到有 Card 腳本的物件
                Card card = hit.collider.GetComponent<Card>();
                if (card != null)
                {
                    Debug.Log("ccc");
                    card.OnCardClicked();  // 點擊卡牌後，觸發相應的效果
                }
            }
        }
    }
}
