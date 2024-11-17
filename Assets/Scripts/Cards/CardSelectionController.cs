using UnityEngine;

public class CardSelectionController : MonoBehaviour
{
    // �b�d�P����W�����o�Ӹ}��
    void Update()
    {
        // �ˬd�ƹ��I��
        if (Input.GetMouseButtonDown(0))  // ���U���� (0 �N����)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // �q�ƹ���m�o�g�g�u
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);  // �]�w�g�u�i���ơA���׬� 10

            //Debug.Log("aaa");
            // �o�g�g�u�A�ˬd�O�_�I����d�P
            if (Physics.Raycast(ray, out hit,100))
            {
                Debug.Log("bbb");
                // �ˬd�O�_�I���즳 Card �}��������
                Card card = hit.collider.GetComponent<Card>();
                if (card != null)
                {
                    Debug.Log("ccc");
                    card.OnCardClicked();  // �I���d�P��AĲ�o�������ĪG
                }
            }
        }
    }
}
