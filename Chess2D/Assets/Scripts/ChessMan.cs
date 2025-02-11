using System;
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
            case "black_queen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; player = "black"; break;
            case "black_king": this.GetComponent <SpriteRenderer>().sprite = blackKing; player = "black"; break;
            case"black_knight": this.GetComponent<SpriteRenderer>().sprite = blackKnight; player = "black"; break;
            case "black_bishop": this.GetComponent<SpriteRenderer>().sprite = blackBishop; player = "black"; break;
            case "black_pawn": this.GetComponent<SpriteRenderer>().sprite = blackPawn; player = "black"; break;
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = blackRook; player = "black"; break;

            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; player = "white"; break;
            case "white_king": this.GetComponent <SpriteRenderer>().sprite = whiteKing; player = "white"; break;
            case"white_knight": this.GetComponent<SpriteRenderer>().sprite = whiteKnight; player = "white"; break;
            case "white_bishop": this.GetComponent<SpriteRenderer>().sprite = whiteBishop; player = "white"; break;
            case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = whitePawn; player = "white"; break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = whiteRook; player = "white"; break;
        }
    }

    public void SetCoords(){
        float x = xBoard;
        float y = yBoard;

        x *= .66f;
        y *= .66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
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

    void OnMouseUp(){
        DestroyMovePlates();
        InitiateMovePlates();
    }


    public void DestroyMovePlates(){
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        foreach(GameObject movePlate in movePlates){
            Destroy(movePlate);
        }
    }

    public void InitiateMovePlates(){
        switch(this.name){
            case "black_queen":
            case "white_queen":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;
            case "black_knight":
            case "white_knight":
                LMovePlate();
                break;
            case "black_bishop":
            case "white_bishop":
                LineMovePlate(1,1);
                LineMovePlate(1,-1);
                LineMovePlate(-1,1);
                LineMovePlate(-1,-1);
                break;
            case "black_king":
            case "white_king":
                SurroundMovePlate();
                break;
            case "black_rook":
            case "white_rook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0 );
                LineMovePlate(0, -1);
                break;
            case "black_pawn":
                PawnMovePlate(xBoard, yBoard-1);
                break;
            case "white_pawn":
                PawnMovePlate(xBoard, yBoard+1);
                break;
        }
    }


    public void LineMovePlate(int xIncrement, int yIncrement){
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while(sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null) {
            MovePlateSpawn(x ,y);
            x += xIncrement;
            y += yIncrement;
        }

        if(sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<ChessMan>().player != player) {
            MovePlateAttackSpawn(x, y);
        }

    }

    public void LMovePlate(){
        PointMovePlate(xBoard+1, yBoard+2);
        PointMovePlate(xBoard-1, yBoard+2);
        PointMovePlate(xBoard+2, yBoard+1);
        PointMovePlate(xBoard+2, yBoard-1);
        PointMovePlate(xBoard+1, yBoard-2);
        PointMovePlate(xBoard-1, yBoard-2);
        PointMovePlate(xBoard-2, yBoard+1);
        PointMovePlate(xBoard-2, yBoard-1);
    }

    public void SurroundMovePlate(){
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }

    public void PointMovePlate(int x, int y){
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x, y)){
            GameObject cp = sc.GetPosition(x ,y);

            if(cp==null){
                MovePlateSpawn(x, y);
            }else if(cp.GetComponent<ChessMan>().player!=player){
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void PawnMovePlate(int x, int y){
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x,y)){
            if(sc.GetPosition(x,y) == null){
                MovePlateSpawn(x, y);
            }
            
            if(sc.PositionOnBoard(x+1, y) && sc.GetPosition(x+1,y) != null && sc.GetPosition(x+1,y).GetComponent<ChessMan>().player!=player){
                MovePlateAttackSpawn(x+1,y);
            }

            if(sc.PositionOnBoard(x-1, y) && sc.GetPosition(x-1,y) != null && sc.GetPosition(x-1,y).GetComponent<ChessMan>().player!=player){
                MovePlateAttackSpawn(x-1,y);
            }
        }
    }


    public void MovePlateSpawn(int matrixX, int matrixY){
        float x = matrixX;
        float y = matrixY;

        x *= .66f;
        y *= .66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY){
        float x = matrixX;
        float y = matrixY;

        x *= .66f;
        y *= .66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixY, matrixY);
    }

}
