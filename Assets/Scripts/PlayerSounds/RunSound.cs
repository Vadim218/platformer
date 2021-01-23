using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RunSound : MonoBehaviour
{
	[SerializeField] AudioClip[] sound;
	private AudioSource source;

    async void Awake()
    {
    	source = GetComponent<AudioSource>();
    	source.clip = sound[Mathf.RoundToInt(Random.Range(0, sound.Length))];
    	source.Play();

    	transform.Translate(0, -1, 0);
    	transform.SetParent(Arrows.arrowsTransform);

    	await Task.Delay(1000);
    	Destroy(gameObject);
    }
}