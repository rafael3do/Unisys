using System;


namespace Create_database
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Now loading database");
            var configconection = @"Server=(localdb)\Unisys; Integrated Security=true; Initial Catalog=System;";//conexão com banco de dados local
            
            using (var db = new InJob(configconection))//função usada para aplicar a conexão com o banco de dados local e subir a os valores para a table job
            {
                Console.WriteLine("Working in Table jobs");
                db.System.Add(new Job() { id = 1, name = "Job1", active = true, parentJob = new Job { id = 2, name = "second job", active = true } });
                db.System.Add(new Job() { id = 2, name = "Job2", active = true, parentJob = new Job { id = 4, name = "four job", active = true } });
                db.System.Add(new Job() { id = 4, name = "Job4", active = true });
                db.System.Add(new Job() { id = 5, name = "Job3", active = true });
                db.System.Add(new Job() { id = 3, name = "Job3", active = true, parentJob = new Job { id = 1, name = "first job", active = true } });
                db.System.Add(new Job() { id = 2, name = "Job2", active = true, parentJob = new Job { id = 3, name = "third job", active = true } });
                db.System.Add(new Job() { id = 5, name = "Job5", active = true, parentJob = new Job { id = 3, name = "third job", active = true } });
               

                db.SaveChanges();

            }
            using (var db = new InTask(configconection))//função usada para aplicar a conexão com o banco de dados local e subir a os valores para a table Task
            {
                Console.WriteLine("Working in Table task");
                db.System.Add(new Task() { id = 1, name = "First task", weight = 5, completed = true, createdAt = new DateTime(2015, 12, 25) });
                db.System.Add(new Task() { id = 2, name = "Second task", weight = 2, completed = false, createdAt = new DateTime(2017,08, 04) });
                db.SaveChanges();
            }
            Console.WriteLine("Database updated!");
            Console.ReadKey();
        }
    }
}
