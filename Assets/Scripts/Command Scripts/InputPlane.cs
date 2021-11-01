using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    public ActiveButton buttonCheck;

    public Transform platformPrefab;
    public Transform jumpPadPrefab;
    public Transform hazardPrefab;

    private int shapesPlaced;

    private Transform activePrefab;

    // Start is called before the first frame update
    void Awake()
    {
        //maincam = Camera.main;

        buttonCheck.GetComponent<ActiveButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonCheck.isPlatformActive)
        {
            activePrefab = platformPrefab;
            //Debug.Log("Active Cube");
        }
        else if (buttonCheck.isJumpPadActive)
        {
            activePrefab = jumpPadPrefab;
            //Debug.Log("Active Jump");
        }
        else if (buttonCheck.isHazardActive)
        {
            activePrefab = hazardPrefab;
        }
        else
        {
            activePrefab = null;
        }

        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldSpacePos = Camera.main.ScreenToWorldPoint(screenPos);

        if (Input.GetMouseButtonDown(0) && buttonCheck.isPlatformActive)
        {
            
            Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
            //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

            ICommand command = new PlaceCubeCommand(worldSpacePos, c, platformPrefab);
            CommandInvoker.AddCommand(command);

            //CubePlace cube = new CubePlace();
            //cube.PlaceShape(hitInfo.point, c, cubePrefab);
            shapesPlaced++;
            //Debug.Log("Shapes Placed: " + shapesPlaced);

            buttonCheck.isPlatformActive = false;
            //Debug.Log("Deactivated");
        }


        if (Input.GetMouseButtonDown(0) && buttonCheck.isJumpPadActive)
        {

            Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
            //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

            ICommand command = new PlaceCubeCommand(worldSpacePos, c, jumpPadPrefab);
            CommandInvoker.AddCommand(command);

            //CubePlace cube = new CubePlace();
            //cube.PlaceShape(hitInfo.point, c, cubePrefab);
            shapesPlaced++;
            //Debug.Log("Shapes Placed: " + shapesPlaced);

            buttonCheck.isJumpPadActive = false;
            //Debug.Log("Deactivated");
        }

        if (Input.GetMouseButtonDown(0) && buttonCheck.isHazardActive)
        {

            Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
            //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

            ICommand command = new PlaceCubeCommand(worldSpacePos, c, hazardPrefab);
            CommandInvoker.AddCommand(command);

            //CubePlace cube = new CubePlace();
            //cube.PlaceShape(hitInfo.point, c, cubePrefab);
            shapesPlaced++;
            //Debug.Log("Shapes Placed: " + shapesPlaced);

            buttonCheck.isHazardActive = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));

            ICommand command2 = new PlaceCubeCommand(worldSpacePos, c, hazardPrefab);
            CommandInvoker.AddCommand(command2);

            //CapsulePlace capsule = new CapsulePlace();
            //capsule.PlaceShape(hitInfo2.point, c, capsulePrefab);
            shapesPlaced++;
            Debug.Log("Shapes Placed: " + shapesPlaced);
            
        }

    }
}
