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
        //Experiment experiment;

        List<Request> requests;

        public Schedue(string fileName, Random rnd, int StartTime)
        {
            this.rnd = rnd;
            requests = new List<Request>();
            //StartTime - для создания списка 
            // FileStream f = new FileStream()
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

                if (cols != 5)//у меня столько колонок
                {
                    Console.Write("Incorrect count collumns");
                   // return;
                }
                int time = -1;
                string airplineName = "", companyName = "";
                Direction dir = Direction.Takeoff;
                //string ddir;
                AirType airType = AirType.Passenger;
                string forAirType;
                for (int i = 2; i <= rows; i++)
                {
                    if (excelRange.Cells[i, 1] != null && excelRange.Cells[i, 1].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 1].Value.ToString() + "\t");
                        time = -1;
                        time = (int)Math.Round(excelRange.Cells[i, 1].Value2*24*60);
                        if (time == -1)
                            break;
                    }

                    if (excelRange.Cells[i, 2] != null && excelRange.Cells[i, 2].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 2].Value.ToString() + "\t");
                        airplineName = "";
                        airplineName = excelRange.Cells[i, 2].Value2;
                        if (airplineName.Equals(""))
                            break;
                    }
                    if (excelRange.Cells[i, 3] != null && excelRange.Cells[i, 3].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 3].Value.ToString() + "\t");
                        companyName = excelRange.Cells[i, 3].Value2;
                    }

                    if (excelRange.Cells[i, 4] != null && excelRange.Cells[i, 4].Value2 != null)
                    {
                        //Console.Write(excelRange.Cells[i, 4].Value.ToString() + "\t");                       
                        dir = excelRange.Cells[i, 4].Value2.Equals("Посадка") ? Direction.Landing : Direction.Takeoff;
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

                    requests.Add(new Request(time, airplineName, companyName, dir, airType, 
                        time + (int)Math.Round(GenerateNormalDistribution(60,20)) ));
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
        public void Tick()
        {
            //requests[i].Tick(experiment.CurrentTime)
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
    }
}
