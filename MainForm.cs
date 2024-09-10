/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 9/10/2024
 * Time: 3:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;



namespace performanceMonitoring
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private PerformanceCounter hddCounter;
        private PerformanceCounter gpuCounter;
        public  System.Windows.Forms.Timer timer;
        
        
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            InitializeCounters();
            InitializeTimer();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void InitializeCounters()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            hddCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
           // gpuCounter = new PerformanceCounter("GPU Engine", "Utilization Percentage", "engtype_3D");
        }

        private void InitializeTimer()
        {
            timer = new  System.Windows.Forms.Timer();
            timer.Interval = 1000; // Update every second
          //  timer.Tick += Timer_Tick;
            timer.Start();
        }

        
        
        
		void MainFormLoad(object sender, EventArgs e)
		{
			this.Top = 0;
			this.Left=0;
			this.Width=1500;
			this.Height=25;
		}
		public void Timer1Tick(object sender, EventArgs e)
		{
	 
            float cpuUsage = cpuCounter.NextValue();
            float ramUsage = ramCounter.NextValue();
            float hddUsage = hddCounter.NextValue();
           // float gpuUsage = gpuCounter.NextValue();

           Text = "CPU Usage: " +cpuUsage.ToString();
            Text += " ," + "Available RAM: " +ramUsage.ToString() + "MB";
            Text += " ," + "HDD Usage: "+ hddUsage.ToString();
           // Text += " ," + "GPU Usage: " + gpuUsage.ToString();
       
		}
		
	}
}


