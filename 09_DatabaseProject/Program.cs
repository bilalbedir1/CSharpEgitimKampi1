using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_DatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***** C# Veri Tabanlı Ürün-Kategori Bilgi Sistemi *****");
            Console.WriteLine();
            Console.WriteLine();


            string tableNumber;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1-Kategoriler");
            Console.WriteLine("2-Ürünler");
            Console.WriteLine("3-Siparişler");
            Console.WriteLine("4-Çıkış Yap");
            Console.Write("Lütfen getirmek istediğiniz tablo numarasını giriniz: ");
            tableNumber = Console.ReadLine();
            Console.WriteLine("--------------------------------");

            // Aşağıda sql sınıfından connection nesnesi ürettik ve bağlantıyı oluşturduk.
            SqlConnection connection = new SqlConnection("Data Source=BILAL;initial Catalog=EgitimKampiDb;integrated security=true");
            connection.Open();// bağlantıyı açtık
            SqlCommand command = new SqlCommand("Select * From TblCategory", connection);//kodumuzu veri tabanıyla ilişkilendirdik
            SqlDataAdapter adapter = new SqlDataAdapter(command);// C# taki kodlarımla sql sunucum arasında köprü görevi görüyor
            DataTable dataTable = new DataTable();// verileri rame almayı sağlıyor
            adapter.Fill(dataTable);

            connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.Read();
        }
    }
}
