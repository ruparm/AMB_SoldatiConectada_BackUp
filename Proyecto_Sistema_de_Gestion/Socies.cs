namespace Proyecto_Sistema_de_Gestion
{
    public class Socies
    {
        private int idSocie;
        private string apellido;
        private string nombre;
        private string plan;
        private string fechaAlta;

        public Socies()
        {

        }
        public Socies(int idSocie, string apellido, string nombre, string plan, string fechaAlta)
        {
            this.idSocie = idSocie;
            this.apellido = apellido;
            this.nombre = nombre;
            this.plan = plan;
            this.fechaAlta = fechaAlta;
        }

        public Socies(string apellido, string nombre, string plan, string fechaAlta)
        {
            
            this.apellido = apellido;
            this.nombre = nombre;
            this.plan = plan;
            this.fechaAlta = fechaAlta;
        }

        public int IdSocie { get => idSocie; set => idSocie = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Plan { get => plan; set => plan = value; }
        public string FechaAlta { get => fechaAlta; set => fechaAlta = value; }


        public override string ToString()
        {
            return $"ID: {idSocie} -  Apellido: {apellido} - Nombre: {nombre} - Plan: {plan} - Fecha de Alta_ {fechaAlta} ";
        }
        
    }

  
}
