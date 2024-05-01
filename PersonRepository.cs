using dgalvezS5.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dgalvezS5
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public string statusMessage {  get; set; }

        public void Init()
        { 
            if (conn == null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona> ();       
        }
        public PersonRepository (string dbPath)
        { 
            _dbPath = dbPath;
        }

        public void addNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona persona = new () { Name = name };
                result = conn.Insert (persona);
                statusMessage = string.Format("Dato agreagado", result, name);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error no se inserto ", name, ex.Message);
            }
        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error al Mostrar los datos", ex.Message);
            }
            return new List<Persona>();
        }
    }
}
