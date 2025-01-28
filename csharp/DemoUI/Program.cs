/* SPDX-License-Identifier: MIT
 *
 * Copyright (C) 2019-2022 WireGuard LLC. All Rights Reserved.
 */

using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DemoUI
{
    static class Program
    {
        private static IHost apiHost;
        private static CancellationTokenSource cancellationTokenSource;

        [STAThread]
        static void Main(string[] args)
        {
            if (HandleServiceMode(args))
                return;

            StartApiServer();
            RunWinFormsApp();
            StopApiServer();
        }

        private static bool HandleServiceMode(string[] args)
        {
            if (args.Length != 3 || args[0] != "/service")
                return false;

            var t = new Thread(() =>
            {
                try
                {
                    var currentProcess = Process.GetCurrentProcess();
                    var uiProcess = Process.GetProcessById(int.Parse(args[2]));
                    if (uiProcess.MainModule.FileName != currentProcess.MainModule.FileName)
                        return;
                    uiProcess.WaitForExit();
                    Tunnel.Service.Remove(args[1], false);
                }
                catch { }
            });
            t.Start();
            Tunnel.Service.Run(args[1]);
            t.Interrupt();
            return true;
        }

        private static void StartApiServer()
        {
            cancellationTokenSource = new CancellationTokenSource();

            apiHost = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:5000");
                })
                .Build();

            // Start the API host in a background task
            Task.Run(async () =>
            {
                try
                {
                    await apiHost.RunAsync(cancellationTokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    // Normal shutdown, no action needed
                }
            });
        }

        private static void RunWinFormsApp()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Handle application exit
            Application.ApplicationExit += (sender, e) => StopApiServer();

            Application.Run(new MainWindow());
        }

        private static void StopApiServer()
        {
            try
            {
                cancellationTokenSource?.Cancel();
                apiHost?.StopAsync().Wait(TimeSpan.FromSeconds(5));
                apiHost?.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error stopping API server: {ex.Message}");
            }
            finally
            {
                cancellationTokenSource?.Dispose();
            }
        }
    }
}
