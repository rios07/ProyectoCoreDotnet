using System.Data.SqlClient;

namespace RepositoriosCore
{
    public interface IConexion
    {
        SqlConnection GetConexion();

        /*public static SqlConnection getConexion() {
            string PC = "";
            string DataSource = ""; "pc204\\SQLEXPRESS";
            string Database = "DB_ATI_PERMER";
            string User_ID = "User_Login_DB_ATI_PERMER";
            string Password = "l4PwdD3P3rm3r";

            PC = System.Environment.MachineName.ToUpper();

            switch (PC)
            {
                case "PC204":
                    PC = "PC204"; 
                    break;
                case "PC080":
                    PC = "PC204"; 
                    break;
                default:
                    PC = "inválida";
                    break;
            }

            DataSource = PC + "\\SQLEXPRESS";

            return new SqlConnection("Data Source=" + DataSource + "; Database=" + Database + ";User ID=" + User_ID + ";Password=" + Password);
        }*/
    }
}