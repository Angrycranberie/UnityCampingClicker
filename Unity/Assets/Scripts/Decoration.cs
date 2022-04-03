using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**Unfinished program
    my algorithm works by finding and put every tile in a array and I couldn't found how to do that. Indeed, I need to get every component per rows and the methods i used does not allow that.
    But I can detail it : 
    - put every tile in an array and create a second array of int that store for each tile is there is a tree and wich one.
    - When a tree is buy, a tile is picked randomly from the available tiles, and the tree is placed.
    - To save every tree, we need to create a new table called 'tree' and store each tree in it with their  postition x,y, their type and the save code
    - To load it, we need to look in the tree table wich tree match with the save code. Then we load every tree found in the game with their x,y position and their type
**/
namespace clicker{
    public class Decoration : MonoBehaviour
    {
        
        public int[,] _tilesOk = new int[8,8];
        GameObject[] _rows = new GameObject[8];

        void OnEnable(){
            
            GameObject _ground = GameObject.Find("Ground");
            GameObject row = _ground.GetComponent<GameObject>();
            //GameObject tile = row.GetComponent<>();
            //Debug.Log(tile.GetType());
            
            
        }

        public void test(){
            
            Debug.Log(_rows[1]);

        }


    }

}
