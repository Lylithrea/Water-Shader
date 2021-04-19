using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    string filename = "";
    public Material waterShader;
    public GameObject waterPlane;

    [SerializeField, Range(0.1f, 2f)]
    float sampleDuration = 1f;
    int frames;
    float duration;

    float fps = 0;



    [System.Serializable]
    public class Data
    {
        public float Metallic;
        public float Smoothness;
        public float ShallowWaterDepth;
        public float DeepWaterDepth;

        public float RefractionScale;
        public float RefractionSpeed;
        public float RefractionStrength;

        public float FoamScale;
        public float FoamAmount;
        public float FoamCutoff;
        public float FoamSpeed;

        public float NormalWaveBias;
        public float BigNormalWaveTiling;
        public float SmallNormalWaveTiling;

        public float WaveBias;
        public float BigWaveMovementScale;
        public float SmallWaveMovementScale;

        public float WaveSpeed;
        public float WaveStrength;
        public float WaveColourSharpness;
        public float WaveFoamCutoff;
    }

    // Start is called before the first frame update
    void Start()
    {
       filename = Application.dataPath + "/result.csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("Fps,Vertices," +
            "Metallic,Smoothness,ShallowWaterDepth,DeepWaterDepth," +
            "RefractionScale,RefractionSpeed,RefractionStrength," +
            "FoamScale,FoamAmount,FoamCutoff,FoamSpeed," +
            "NormalWaveBias,BigNormalWaveTiling,SmallNormalWaveTiling," +
            "WaveBias,BigWaveMovementScale,SmallWaveMovementScale," +
            "WaveSpeed,WaveStrength,WaveColourSharpness,WaveFoamCutoff");
        tw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        FPSCounter();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetShaderValues();
            WriteCSV();
        }
    }

    public void WriteCSV()
    {
        TextWriter tw = new StreamWriter(filename, true);
        Data currentData = GetShaderValues();
        tw.WriteLine(fps + "," + waterPlane.GetComponent<MeshFilter>().mesh.vertices.Length + "," +
            currentData.Metallic + "," + currentData.Smoothness + "," + currentData.ShallowWaterDepth + "," + currentData.DeepWaterDepth + "," +
            currentData.RefractionScale + "," + currentData.RefractionSpeed + "," + currentData.RefractionStrength + "," +
            currentData.FoamScale + "," + currentData.FoamAmount + "," + currentData.FoamCutoff + "," + currentData.FoamSpeed + "," +
            currentData.NormalWaveBias + "," + currentData.BigNormalWaveTiling + "," + currentData.SmallNormalWaveTiling + "," +
            currentData.WaveBias + "," + currentData.BigWaveMovementScale + "," + currentData.SmallWaveMovementScale + "," +
            currentData.WaveSpeed + "," + currentData.WaveStrength + "," + currentData.WaveColourSharpness + "," + currentData.WaveFoamCutoff);
        tw.Close();
    }

    public Data GetShaderValues()
    {
        Data newData = new Data();

        newData.Metallic = waterShader.GetFloat("Vector1_9CE5BB32");
        newData.Smoothness = waterShader.GetFloat("Vector1_4BDFAB09");
        newData.ShallowWaterDepth = waterShader.GetFloat("Vector1_C29C4BAE");
        newData.DeepWaterDepth = waterShader.GetFloat("Vector1_1F0B8FE1");

        newData.RefractionScale = waterShader.GetFloat("Vector1_66559080");
        newData.RefractionSpeed = waterShader.GetFloat("Vector1_E74BD6B5");
        newData.RefractionStrength = waterShader.GetFloat("Vector1_4BD63ADA");

        newData.FoamScale = waterShader.GetFloat("Vector1_A5886A16");
        newData.FoamAmount = waterShader.GetFloat("Vector1_B8E275C9");
        newData.FoamCutoff = waterShader.GetFloat("Vector1_296466D");
        newData.FoamSpeed = waterShader.GetFloat("Vector1_39E63E9D");

        newData.NormalWaveBias = waterShader.GetFloat("Vector1_2B9F00EC");
        newData.BigNormalWaveTiling = waterShader.GetFloat("Vector1_5E7CB4AC");
        newData.SmallNormalWaveTiling = waterShader.GetFloat("Vector1_7F333F56");

        newData.WaveBias = waterShader.GetFloat("Vector1_FA09FA56");
        newData.BigWaveMovementScale = waterShader.GetFloat("Vector1_E5FFDB07");
        newData.SmallWaveMovementScale = waterShader.GetFloat("Vector1_3B65B7A5");

        newData.WaveSpeed = waterShader.GetFloat("Vector1_6EB1F02");
        newData.WaveStrength = waterShader.GetFloat("Vector1_A81C3C11");
        newData.WaveColourSharpness = waterShader.GetFloat("Vector1_EA72D90F");
        newData.WaveFoamCutoff = waterShader.GetFloat("Vector1_339DE3BC");

        return newData;
    }

    public void FPSCounter()
    {
        float frameDuration = Time.unscaledDeltaTime;
        frames += 1;
        duration += frameDuration;

        if (duration >= sampleDuration)
        {
            fps = frames / duration;
            frames = 0;
            duration = 0f;
        }
    }

}
