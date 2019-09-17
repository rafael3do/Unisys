using System;
using System.Data.Entity;



namespace Create_database
{
    public class InTask : DbContext
    {//classe para gerenciar a operação com banco de dados
        public InTask(string connectionString) : base(connectionString) { }
        public DbSet<Task> System { get; set; }

    }
    public class Task //classe tasks conforme especificações
    {
        public int id { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public bool completed { get; set; }
        public DateTime createdAt { get; set; }

       
    }
}
