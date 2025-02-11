using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    public bool attack = false;
    
    GameObject reference = null;
    int matrixX;
    int matrixY;

    private void Start() {
        if(attack){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
    }

    public void OnMouseUp(){
        controller = GameObject.FindWithTag("GameController");

        if(attack){
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixY, matrixY);
            Destroy(cp);
        }

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<ChessMan>().GetXBoard(), reference.GetComponent<ChessMan>().GetYBoard());

        reference.GetComponent<ChessMan>().SetXBoard(matrixX);
        reference.GetComponent<ChessMan>().SetYBoard(matrixY);
        reference.GetComponent<ChessMan>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);

        reference.GetComponent<ChessMan>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y){
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj){
        reference = obj;
    }

    public GameObject GetReference(){
        return reference;
    }
}
