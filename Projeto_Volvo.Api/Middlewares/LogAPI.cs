using System.Reflection;

namespace Projeto_Volvo.Api.Middlewares
{
    public class LogAPi
    {
        private static string m_exePath = string.Empty;

        public static void RegistraLog(string logMessage,string Loglogref,string hashTraceId)
        {
            String srtPath = Environment.CurrentDirectory + "\\Log";
            m_exePath = Path.GetFullPath(srtPath);
            //m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!File.Exists(m_exePath + "\\" + "log.txt"))
                File.Create(m_exePath + "\\" + "log.txt");

            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    AppendLog(logMessage, Loglogref, hashTraceId, w);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AppendLog(string logMessage,string Loglogref, string hashTraceId, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entrada : ");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{logMessage}");
                txtWriter.WriteLine(hashTraceId);
                txtWriter.WriteLine(Loglogref);
                txtWriter.WriteLine(logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
