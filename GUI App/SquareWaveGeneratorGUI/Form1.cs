using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SquareWaveGeneratorGUI
{
    partial class Form1 : Form
    {
        private SerialPort port;

        public Form1()
        {
            InitializeComponent();

            port = new SerialPort();
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
        }

        ~Form1()
        {
            if (port.IsOpen) port.Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                port.Write(new byte[] { (byte)DutyRatio.Value }, 0, 1);
                port.Write(new byte[] { (byte)((int)SignalDuration.Value & 0xFFFFFFFF) }, 0, 1);
                port.Write(new byte[] { (byte)(((int)SignalDuration.Value >> 8) & 0xFFFFFFFF) }, 0, 1);
                port.Write(new byte[] { (byte)(((int)SignalDuration.Value >> 16) & 0xFFFFFFFF) }, 0, 1);
                port.Write(new byte[] { (byte)(((int)SignalDuration.Value >> 24) & 0xFFFFFFFF) }, 0, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PortsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen) port.Close();
                port.PortName = PortsList.SelectedItem as string;
                port.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PortsList_Click(object sender, EventArgs e)
        {
            PortsList.Items.Clear();
            foreach(string portName in SerialPort.GetPortNames()) PortsList.Items.Add(portName);
        }
    }
}
