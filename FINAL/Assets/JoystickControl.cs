using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    SerialPort serialPort;
    public string portName = "/dev/cu.usbserial-110";
    public int baudRate = 9600;
    void Start()
    {
        try
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                serialPort = new SerialPort(portName, baudRate);
                serialPort.Open();
                serialPort.ReadTimeout = 1000;
                Debug.Log("Serial Port Connected!");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening Serial Port: " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                string[] values = data.Split(',');
                int sensor1 = int.Parse(values[0]);
                int sensor2 = int.Parse(values[1]);
                Debug.Log("Sensor 1: " + sensor1 + ", Sensor 2: " + sensor2);
            }
            catch (TimeoutException)
            {
                Debug.Log("Cant read");
            }
        }
        else
        {
            Debug.Log(serialPort + ":" + serialPort.IsOpen);
        }
    }
    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
