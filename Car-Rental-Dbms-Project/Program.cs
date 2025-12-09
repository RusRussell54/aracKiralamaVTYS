using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Dbms_Project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Veritabanýný kontrol et ve oluþtur
                DatabaseHelper.EnsureDatabaseExists();
                
                using (var context = new ApplicationDbContext())
                {
                    // Baðlantý testi
                    if (context.Database.CanConnect())
                    {
                        // Veritabanýný oluþtur ve migration'larý uygula
                        context.Database.EnsureCreated();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Veritabaný Hatasý:\n\n{ex.Message}\n\n" +
                    $"Ýç Hata: {ex.InnerException?.Message}\n\n" +
                    $"Stack Trace: {ex.StackTrace}",
                    "Baþlatma Hatasý",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}