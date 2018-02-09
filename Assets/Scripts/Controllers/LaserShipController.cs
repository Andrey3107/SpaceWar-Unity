using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserShipController : CommonShipController {



	private enum GunState
	{
		Idle,
		Fire
	}

	[SerializeField] private const float BULLET_SPAWN_DISTANCE = 0.5f;
	private const int CHAIN_FIRE_NUMBERS = 1;

	private const float gunPosx = 0.25f;
	private Vector3 rightGunPosition = new Vector3(gunPosx, -0.276f, 2.3f);
	private Vector3 leftGunPosition = new Vector3(-gunPosx, -0.276f, 2.3f);

	private float startChainTime;
	private int chainFireNumber;
	private GunState gunState = GunState.Idle;

	private void Update()
	{	

		if (Input.GetMouseButtonDown(0)) {
			gunState = GunState.Fire;
		}
		if (Input.GetMouseButtonUp(0)) {
			gunState = GunState.Idle;
		}
		ProcessActions();

	}


	private void ProcessActions() {
		if (GunState.Fire == gunState) {
				
			if (Time.time - startChainTime > 0.5f) {

				if (++chainFireNumber == CHAIN_FIRE_NUMBERS) {
					gunState = GunState.Idle;
					return;
				}

				startChainTime = Time.time;
				Fire(leftGunPosition, rightGunPosition);
			}
		}
	}

}
