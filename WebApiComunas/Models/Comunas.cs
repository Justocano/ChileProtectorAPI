using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;

namespace WebApiComunas.Models
{
    public class Comunas
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required string Calificacion { get; set; }
        public required string Vigilancia { get; set; }
        public required string Imagen {  get; set; }
        public required int RegionId { get; set; }

    }
}
