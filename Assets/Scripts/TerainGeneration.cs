using UnityEngine;
using System.Collections;

public class TerainGeneration : MonoBehaviour {

	public GameObject target;
	Transform botTransform;
	BotMove botMove;

	CollectibleGeneration colGenerator;

	public GameObject tile;
	public int totalTiles = 25;
	public float tileSpawnProb = 0.9F;
	PoolManager pool;
	int tileIndex;
	int maxVoid;
	int currentVoid;

	ObjectGeneration[] generators;

	int posThreshold;

	float posX, posY = 0f;
	Vector3 pos;

	int bot_previous_action = 0;

	int currentGen = 0;
	public int weatherGenRate = 100;

	void Start () {

		botTransform = target.GetComponent<Transform> ();
		botMove = target.GetComponent<BotMove> ();

		colGenerator = FindObjectOfType<CollectibleGeneration> ();

		pool = PoolManager.instance;
		pool.CreatePool (tile, totalTiles);

		currentVoid = 0;
		maxVoid = 3;

		pos = Vector3.zero;

		generators = FindObjectsOfType<ObjectGeneration> ();

		posX = botTransform.position.x - 3.0F;
		// create initiale stage
		for (int i = 0; i < totalTiles; i++) {

			pos.x = posX;
			// tile generation
			pool.SpawnObject(tile, pos);

			foreach (ObjectGeneration generator in generators)
			{
				generator.Generate(pos);
			}

			posX += 1F;
		}
		tileIndex = totalTiles-1;
	}
	
	void Update () {
		if (botTransform.position.x > posX) {

			bool generated = true;

			// update tile index
			tileIndex++;
			if (tileIndex == totalTiles)
				tileIndex = 0;

			// generate Bot move
			int move = botMove.generateChoice();
			// get previously generated tile index height 
			int index = tileIndex - 1;
			if(index == -1)
				index = totalTiles - 1;

			switch(move){
			case 2:
				posY += Random.Range (0.3F, 1F);
				pos = new Vector3 (posX, posY, 0);
				break;
			case 3:
				posY -= Random.Range (0.3F, 2F);
				pos = new Vector3 (posX, posY, 0);
				break;
			case 1:
				pos = new Vector3 (posX, posY, 0);
				if(bot_previous_action == move){
					if(Random.value > tileSpawnProb && currentVoid < maxVoid){
						currentVoid++;
						generated = false;
						tileIndex = index;
					}
					else{
						currentVoid = 0;
					}
				}
				break;
			default:
				break;
			}

			bot_previous_action = move;

			if(generated){

				// relocate tile
				pool.SpawnObject(tile, pos);
				
				foreach (ObjectGeneration generator in generators)
				{
					generator.Generate(pos);
				}

				currentGen++;
				if(currentGen == weatherGenRate){
					colGenerator.GenerateWeatherCube(pos);
					currentGen = 0;
				} else {
					colGenerator.Generate(pos);
				}
			
			}

			// increase x position
			posX += 1F;
		}

	}

}
