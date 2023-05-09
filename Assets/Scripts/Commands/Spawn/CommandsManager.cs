using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RN.WIA.Commands.Spawn
{
    public class CommandsManager : MonoBehaviour
    {
        public static CommandsManager instance = null;

        
        [SerializeField] private Button commandBtn = null;
        [SerializeField] private Transform commandGroup = null;

        private List<Button> buttons = new List<Button>();

        private PlayerCommands commandsList = null;

        //list for time count
        public List<float> spawnCount = new List<float>();

        //list to store what units are going to spawn
        public List<GameObject> spawnOrder = new List<GameObject>();

        //stores strucutres spawn points
        public List<GameObject> spawnPoints = new List<GameObject>();

        //Stores the spawn point
        public GameObject spawnPoint = null;
        private void Awake()
        {
            // Singleton 
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            

        }

        //Sets the Buttons for spawning
        public void SetButtons(PlayerCommands commands, GameObject _spawnPoint)
        {
            commandsList = commands;
            spawnPoint = _spawnPoint;
            //checks if there are any units in the list
            if (commands.units.Count > 0)
            {//iterates thorugh all the units in the list 
                foreach (Units.Unit unit in commands.units)
                {
                    //sets the buttons for each unit, in the parent (commandGroup)
                    Button btn = Instantiate(commandBtn, commandGroup);
                    btn.name = unit.name;
                    GameObject img = Instantiate(unit.spawnImg, btn.transform);
                    buttons.Add(btn);
                }
            }

            //checks if there are any structures in the list
            if (commands.structures.Count > 0)
            {//iterates through all the structures in the list
                foreach (Structure.Structure structure in commands.structures)
                {
                    //sets the buttons for each structure, in the parent(commandGroup)
                    Button btn = Instantiate(commandBtn, commandGroup);
                    GameObject img = Instantiate(structure.spawnImg, btn.transform);
                    btn.name = structure.name;
                    buttons.Add(btn);
                }
            }
        }
            //emptyes the pannel (commandGroup)
            public void EmptyCommands()
            {
                foreach (Button btn in buttons)
                {
                   
                    Destroy(btn.gameObject);
                }
            buttons.Clear();
            }

        public void BeginSpawnTimer(string spawnableObj)
        {
            //sets the needed values to spawn a unit
            if (IsUnit(spawnableObj))
            {
                Units.Unit unit = IsUnit(spawnableObj);
                spawnCount.Add(unit.timeToSpawn);
                spawnOrder.Add(unit.bluePrefab);
                GameObject copySP = spawnPoint;
                spawnPoints.Add(copySP);
            }
            //sets the needed values to spawn a structure (not implemented yet)
            else if (IsStructure(spawnableObj))
            {
                Structure.Structure structure = IsStructure(spawnableObj);
                spawnCount.Add(structure.timeToSpawn);
                spawnOrder.Add(structure.bluePrefab);
                GameObject copySP = spawnPoint;
                spawnPoints.Add(copySP);
            }
            else
            {
                Debug.Log($"{spawnableObj} cannot be spawned!");
            }

            //starts timer
            if(spawnOrder.Count == 1)
            {
                Timer.instance.StartCoroutine(Timer.instance.SpawnTime());
            }
            //stops timer
            else if(spawnOrder.Count == 0)
            {
                Timer.instance.StopAllCoroutines();
            }
        }

        private Units.Unit IsUnit(string name)
        {
            //check if we have any commands
            if(commandsList.units.Count > 0)
            {
                foreach (Units.Unit unit in commandsList.units)
                {
                    if(unit.name == name)
                    {
                        return unit;
                    }
                }
            }
            return null;
        }

        private Structure.Structure IsStructure(string name)
        {
            //check if we have any commands
            if(commandsList.structures.Count > 0)
            {
                foreach(Structure.Structure structure in commandsList.structures)
                {
                    if(structure.name == name)
                    {
                        return structure;
                    }
                }
            }
            return null;
        }

        public void SpawnObj()
        {
            GameObject spawned = Instantiate(spawnOrder[0], new Vector3(spawnPoints[0].transform.position.x - 4, spawnPoints[0].transform.position.y,
                spawnPoints[0].transform.position.z), Quaternion.identity);

            Units.Player.PlayerUnits playerUnit = spawned.GetComponent<Units.Player.PlayerUnits>();
            //finds the partent in which the untis will be added based on their type
            //it adds an s at the end as the units are named Warrior, Mage, Catapult and the parent has the names at plural 
            playerUnit.transform.SetParent(GameObject.Find("P " + playerUnit.unitType.type.ToString() + "s").transform);


            spawnCount.Remove(spawnCount[0]);
            spawnOrder.Remove(spawnOrder[0]);
            spawnPoints.Remove(spawnPoints[0]);
        }
    }
}

