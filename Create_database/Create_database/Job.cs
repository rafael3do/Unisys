using System.Collections.Generic;
using System.Data.Entity;


namespace Create_database
{   
    public class InJob : DbContext{//classe para gerenciar a operação com banco de dados
        public InJob(string connectionString) : base(connectionString) { }
        public DbSet<Job> System { get; set; }
       
    }
   public class Job //classe job conforme especificações
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public List<Task> tasks { get; set; }
        public Job parentJob { get; set; }

    }
   
}
