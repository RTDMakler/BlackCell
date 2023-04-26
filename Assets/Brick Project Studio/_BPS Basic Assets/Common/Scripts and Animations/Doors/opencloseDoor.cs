using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace x2

{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		Transform Player;

		void Start()
		{
			Player = GameObject.Find("Player").transform;
			open = false;
		}

		void Update()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 4)
					{
						if (open == false)
						{
							if (/*Input.GetMouseButtonDown(0)*/Input.GetKeyDown(KeyCode.E))
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetKeyDown(KeyCode.E))
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}