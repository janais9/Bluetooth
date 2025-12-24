using System;
using System.Linq;
using System.Windows;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;

namespace Bluetootth
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DevicesList.Items.Clear();

            BluetoothClient client = new BluetoothClient();

            var devices = client.DiscoverDevices();

            foreach (var device in devices)
            {
                DevicesList.Items.Add(
                    $"{device.DeviceName} | {device.DeviceAddress}"
                );
            }

            if (!devices.Any())
            {
                DevicesList.Items.Add("No Bluetooth devices found.");
            }
        }
    }
}
