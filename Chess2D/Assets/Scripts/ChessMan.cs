using UnityEngine;

public class ChessMan : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;
    public Sprite blackKing, blackQueen, blackRook, blackKnight, blackBishop, blackPawn;
    public Sprite whiteKing, whiteQueen, whiteRook, whiteKnight, whiteBishop, whitePawn;

    int xBoard = -1;
    int yBoard = -1;

    string player;


    public void Activate(){
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch(this.name){
            case "black_queen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; break;
            case "black_king": this.GetComponent <SpriteRenderer>().sprite = blackKing; break;
            case"black_knight": this.GetComponent<SpriteRenderer>().sprite = blackKnight; break;
            case "black_bishop": this.GetComponent<SpriteRenderer>().sprite = blackBishop; break;
            case "black_pawn": this.GetComponent<SpriteRenderer>().sprite = blackPawn; break;
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = blackRook; break;

            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; break;
            case "white_king": this.GetComponent <SpriteRenderer>().sprite = whiteKing; break;
            case"white_knight": this.GetComponent<SpriteRenderer>().sprite = whiteKnight; break;
            case "white_bishop": this.GetComponent<SpriteRenderer>().sprite = whiteBishop; break;
            case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = whitePawn; break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = whiteRook; break;
        }
    }

    public void SetCoords(){
        float x = xBoard;
        float y = yBoard;

        x *= .66f;
        y *= .66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1f);
    }


    public int GetXBoard(){
        return xBoard;
    }
    public int GetYBoard(){
        return yBoard;
    }

    public void SetXBoard(int x){
        xBoard = x; 
    }
    public void SetYBoard(int y){
        yBoard = y;
    }


}
