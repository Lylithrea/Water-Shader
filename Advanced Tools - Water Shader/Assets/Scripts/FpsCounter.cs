using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{

	[SerializeField]
	Text max = default;
	[SerializeField]
	Text average = default;
	[SerializeField]
	Text min = default;

	[SerializeField, Range(0.1f, 2f)]
	float sampleDuration = 1f;

	int frames;

	float duration, bestDuration = float.MaxValue, worstDuration;
	float startDuration = 100;
	bool isStarting = true;
	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if (!isStarting)
		{
			float frameDuration = Time.unscaledDeltaTime;
			frames += 1;
			duration += frameDuration;

			if (frameDuration < bestDuration)
			{
				bestDuration = frameDuration;
			}
			if (frameDuration > worstDuration)
			{
				worstDuration = frameDuration;
			}

			if (duration >= sampleDuration)
			{
				float fps = frames / duration;
				max.text = "" + (1 / bestDuration);
				average.text = "" + fps;
				min.text = "" + (1 / worstDuration);
				frames = 0;
				duration = 0f;
			}
		}
        else
        {
			startDuration--;
			if(startDuration <= 0)
            {
				isStarting = false;
            }
        }
	}
}
