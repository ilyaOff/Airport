using System;
using System.Collections.Generic;
using System.IO;//work to stream
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exel = Microsoft.Office.Interop.Excel;

namespace Airoport
{
    class Schedue
    {
        Random rnd;
        //для генерации числа из нормального распределения и для значения мирового времени
        int StartRequest = 0;

        public List<Request> requests { get; private set; }

        public Schedue(string fileName, Random rnd, int StartTime, int DelayMin, int DelayMax)
        {
            this.rnd = rnd;
            requests = new List<Request>();
            //StartTime - для создания списка 
            TextFileCreateSchedue(fileName, StartTime, DelayMin, DelayMax);

        }
        public void Tick(int WorldTime, Airport airport)
        {
            /*
            foreach (Request req in requests)
            {
                req.Tick(WorldTime, airport);
            }*/
            for (int i = StartRequest; i < requests.Count(); i++)
            {
                requests[i].Tick(WorldTime, airport);
                //сортировка расписания
                if (requests[i].TimeReal != -1)
                {
                    int k = 0;
                    for (; i + k > 0; k--)
                    {
                        if (requests[i + k - 1].TimeReal != -1) break;
                    }
                    if (k != 0)
                    {
                        Request req = requests[i];
                        requests.RemoveAt(i);
                        requests.Insert(i + k, req);
                        StartRequest++;
                    }
                }
                else if (requests[i].TimeEvent == WorldTime)
                {
                    int k = 0;
                    for (; i + k > 0; k--)
                    {                        
                        if (requests[i + k - 1].TimeEvent < requests[i].TimeEvent)
                        {
                            break;
                        }
                    }
                    if (k != 0)
                    {
                        Request req = requests[i];
                        requests.RemoveAt(i);
                        requests.Insert(i + k, req);
                    }
                }
            }
        }

        private double GenerateNormalDistribution(double a, double sigm)
        {
            double res = 0.0;
            for (int i = 0; i < 12; i++)
            {
                res += rnd.NextDouble();                
            }
            res -= 6.0;
            return sigm*res + a;
        }

        void TextFileCreateSchedue(string fileName, int StartTime, int DelayMin, int DelayMax)
        {
            // FileStream f = new FileStream()
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(@fileName))
                {
                    string line;
                    string[] paramRequest;
                    // Read and display lines from the file until the end of
                    // the file is reached.

                    int time = -1, timeEvent = -1;
                    string airplineName = "", companyName = "";
                    Direction dir = Direction.Takeoff;
                    AirType airType = AirType.Passenger;
                    double a = 60.0, sigm = 20.0;
                    //чтение названий
                    line = sr.ReadLine();
                    //чтение расписания
                    while ((line = sr.ReadLine()) != null)
                    {
                        paramRequest = line.Split('\t', ':');

                        time = int.Parse(paramRequest[0]) * 60 + int.Parse(paramRequest[1]);
                                                  
                        airplineName = paramRequest[2];                        
                        companyName = paramRequest[3];
                        
                        //Console.Write(excelRange.Cells[i, 4].Value.ToString() + "\t");  
                        if (paramRequest[4].Equals("Посадка"))
                        {
                            dir = Direction.Landing;
                            a = (DelayMax + DelayMin) / 2.0;
                        }
                        else
                        {
                            dir = Direction.Takeoff;
                            //не раньше расписания
                            a = (DelayMax + Math.Max(0, DelayMin)) / 2.0;
                        }
                        sigm = (DelayMax - a) / 3.0;                        
                        
                        if (paramRequest[5].Equals("Пассажирский"))
                        {
                            airType = AirType.Passenger;
                        }
                        else if (paramRequest[5].Equals("Грузовой"))
                        {
                            airType = AirType.Cargo;
                        }
                        else
                        {
                            airType = AirType.Jet;
                        }

                        timeEvent = time + (int)Math.Round(GenerateNormalDistribution(a, sigm));
                        timeEvent = timeEvent >= 0 ? timeEvent : -timeEvent;
                        requests.Add(new Request(time, airplineName, companyName, dir, airType, timeEvent));
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        void ExelCreateSchedue(string fileName,int StartTime, int DelayMin, int DelayMax)
        {
            //--------------------------------------------------------------------
            //Create COM Objects.
            exel.Application excelApp = new exel.Application();
            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

            try
            {
                //"D:\Users\Илья\Desktop\Dd1.xlsx"
                exel.Workbook excelBook = excelApp.Workbooks.Open(@fileName);
                exel.Worksheet excelSheet = excelBook.Sheets[1];
                exel.Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                //rows = 0;//для отладки
                //rows = 50;//для отладки
                if (cols != 5)//у меня столько колонок
                {
                    Console.Write("Incorrect count collumns");
                    return;
                }
                int time = -1;
                string airplineName = "", companyName = "";
                Direction dir = Direction.Takeoff;
                //string ddir;
                AirType airType = AirType.Passenger;
                string forAirType;
                double a = 60.0, sigm = 20.0;
                for (int i = 2; i <= rows; i++)
                {
                    if (excelRange.Cells[i, 1] != null && excelRange.Cells[i, 1].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 1].Value.ToString() + "\t");                        
                        time = (int)Math.Round(excelRange.Cells[i, 1].Value2 * 24 * 60);
                    }

                    if (excelRange.Cells[i, 2] != null && excelRange.Cells[i, 2].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 2].Value.ToString() + "\t");
                        airplineName = "";
                        airplineName = excelRange.Cells[i, 2].Value2;
                        if (airplineName.Equals(""))
                        {
                            System.Windows.Forms.MessageBox.Show("Пустая строка", "Error");
                            break;
                        }
                    }
                    if (excelRange.Cells[i, 3] != null && excelRange.Cells[i, 3].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 3].Value.ToString() + "\t");
                        companyName = excelRange.Cells[i, 3].Value2;
                    }

                    if (excelRange.Cells[i, 4] != null && excelRange.Cells[i, 4].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 4].Value.ToString() + "\t");  
                        if (excelRange.Cells[i, 4].Value2.Equals("Посадка"))
                        {
                            dir = Direction.Landing;
                            a = (DelayMax + DelayMin) / 2.0;
                        }
                        else
                        {
                            dir = Direction.Takeoff;
                            //не раньше расписания
                            a = (DelayMax + Math.Max(0, DelayMin)) / 2.0;
                        }
                        sigm = (DelayMax - a) / 3.0;
                    }
                    if (excelRange.Cells[i, 5] != null && excelRange.Cells[i, 5].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 5].Value.ToString() + "\t");
                        forAirType = excelRange.Cells[i, 5].Value2;
                        if (forAirType.Equals("Пассажирский"))
                        {
                            airType = AirType.Passenger;
                        }
                        else if (forAirType.Equals("Грузовой"))
                        {
                            airType = AirType.Cargo;
                        }
                        else
                        {
                            airType = AirType.Jet;
                        }
                    }

                    time = time + (int)Math.Round(GenerateNormalDistribution(a, sigm));
                    time = time >= 0 ? time : -time;
                    requests.Add(new Request(time, airplineName, companyName, dir, airType, time));
                }

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                //Console.Write(errorMessage);
                System.Windows.Forms.MessageBox.Show(errorMessage, "Error");
            }
            //after reading, relaase the excel project
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            //Console.ReadLine();
            //----------------------------------------------------------------------------
        }
    }
}
