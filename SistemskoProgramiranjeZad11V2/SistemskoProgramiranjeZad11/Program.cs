using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SistemskoProgramiranjeZad11V2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string rootFolder = "C:\\Images\\";
            const string baseUrl = "http://localhost:5050/";

            Console.WriteLine("Web server for converting a picture to grayscale is running...");
            Console.WriteLine($"Listening on {baseUrl}");

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(baseUrl);

            try
            {
                listener.Start();

                while (true)
                {
                    var context = await listener.GetContextAsync();
                    _ = RequestHandling.HandleRequestAsync(context, rootFolder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
