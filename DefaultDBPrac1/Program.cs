using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DefaultDBPrac1
{
    class Program
    {
        // cadena de conexión. Cambiar el valor según la configuración de su máquina de trabajo
        public static SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBPrac1;Integrated Security=True");
        
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido!\n");
            Console.WriteLine("Espere un momento mientras se reestablece la base de datos...\n");

            SqlCommand command;
            string sqlstring = "";
            
            // borrando la base de datos
            try
            {
                con.Open();

                //
                Console.Write("Borrando la tabla INSCRITO...");

                sqlstring = "DELETE FROM INSCRITO";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" reestableciendo auto-increment...");
                sqlstring = "DBCC CHECKIDENT('INSCRITO', RESEED, 0)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" listo!\n");

                //
                Console.Write("Borrando la tabla APODERADO...");

                sqlstring = "DELETE FROM APODERADO";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" reestableciendo auto-increment...");
                sqlstring = "DBCC CHECKIDENT('APODERADO', RESEED, 0)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" listo!\n");

                //
                Console.Write("Borrando la tabla ALUMNO...");

                sqlstring = "DELETE FROM dbo.ALUMNO";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" reestableciendo auto-increment...");
                sqlstring = "DBCC CHECKIDENT('ALUMNO', RESEED, 0)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" listo!\n");

                //
                Console.Write("Borrando la tabla CURSO...");
                sqlstring = "DELETE FROM CURSO";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" reestableciendo auto-increment...");
                sqlstring = "DBCC CHECKIDENT('CURSO', RESEED, 0)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" listo!\n");

                Console.WriteLine("\nBase de datos limpiada exitosamente!");
                con.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Se produjo un error al vaciar las tablas de la base de datos... la aplicación terminará en este punto");
                Console.WriteLine(ex.Message);
                con.Close();
                Environment.Exit(0);
            }

            Console.WriteLine("\n\nEspere un momento mientras se reestablece la base de datos...\n");

            // poblando la base de datos
            try
            {
                con.Open();

                //
                Console.Write("Poblando la tabla ALUMNO...");

                sqlstring = "SET IDENTITY_INSERT ALUMNO ON";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO ALUMNO (ID,Nombre,Ciudad,Edad) VALUES (1,'Pedro','Santiago',14)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();
                
                sqlstring = "INSERT INTO ALUMNO (ID,Nombre,Ciudad,Edad) VALUES (11,'Juan','Buenos Aires',18)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO ALUMNO (ID,Nombre,Ciudad,Edad) VALUES (21,'Diego','Lima',12)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO ALUMNO (ID,Nombre,Ciudad,Edad) VALUES (31,'Rosita','Concepcion',15)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO ALUMNO (ID,Nombre,Ciudad,Edad) VALUES (41,'Manuel','Lima',17)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "SET IDENTITY_INSERT ALUMNO OFF";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" listo!\n");

                //
                Console.Write("Poblando la tabla CURSO...");

                sqlstring = "SET IDENTITY_INSERT CURSO ON";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO CURSO (Cod,Nombre,Fecha_Inicio,Duracion,Valor) VALUES (01142,'Psicologia','13-01',15,3000)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO CURSO (Cod,Nombre,Fecha_Inicio,Duracion,Valor) VALUES (02145,'Biologia','15-02',12,2500)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO CURSO (Cod,Nombre,Fecha_Inicio,Duracion,Valor) VALUES (03547,'Matematicas','01-03',30,4000)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO CURSO (Cod,Nombre,Fecha_Inicio,Duracion,Valor) VALUES (04578,'Musia','05-04',10,1500)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO CURSO (Cod,Nombre,Fecha_Inicio,Duracion,Valor) VALUES (05478,'Fisica','20-04',15,3200)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "SET IDENTITY_INSERT CURSO OFF";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" listo!\n");

                //
                Console.Write("Poblando la tabla APODERADO...");

                sqlstring = "SET IDENTITY_INSERT APODERADO ON";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO APODERADO (Id,Nombre,Telefono,Id_Alumno) VALUES (54,'Victor','654644',21)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO APODERADO (Id,Nombre,Telefono,Id_Alumno) VALUES (457,'Jose','454654',11)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO APODERADO (Id,Nombre,Telefono,Id_Alumno) VALUES (354,'Maria','997455',31)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO APODERADO (Id,Nombre,Telefono,Id_Alumno) VALUES (444,'Paz','747423',1)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "SET IDENTITY_INSERT APODERADO OFF";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" listo!\n");

                //
                Console.Write("Poblando la tabla INSCRITO...");

                sqlstring = "INSERT INTO INSCRITO (Id_Alumno,Cod_Curso) VALUES (1,5478)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO INSCRITO (Id_Alumno,Cod_Curso) VALUES (1,2145)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO INSCRITO (Id_Alumno,Cod_Curso) VALUES (11,3547)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO INSCRITO (Id_Alumno,Cod_Curso) VALUES (21,2145)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                sqlstring = "INSERT INTO INSCRITO (Id_Alumno,Cod_Curso) VALUES (41,3547)";
                command = new SqlCommand(sqlstring, con);
                command.ExecuteNonQuery();

                Console.Write(" listo!\n");

                //
                Console.WriteLine("\nBase de datos poblada exitosamente!");
                con.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Se produjo un error al poblar las tablas de la base de datos... la aplicación terminará en este punto");
                Console.WriteLine(ex.Message);
                con.Close();
                Environment.Exit(0);
            }

            Console.WriteLine("\n\nPresione la tecla ENTER dos veces para salir");
            Console.Read();
        }
    }
}
