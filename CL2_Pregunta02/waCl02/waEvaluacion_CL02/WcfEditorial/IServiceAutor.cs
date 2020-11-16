using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfEditorial
{
    [ServiceContract]
    public interface IServiceAutor
    {
        [OperationContract]
        List<Autor> listadoAutores();

        [OperationContract]
        List<AutorO> listadoAutoresO();

        [OperationContract]
        List<Pais> listadoPais();

        [OperationContract]
        String nuevoAutor(AutorO objA);

        [OperationContract]
        String actualizaAutor(AutorO objA);

        [OperationContract]
        void eliminaAutor(AutorO objA);
    }

    [DataContract]
    public class Autor
    {
        [DataMember]public int codigo { get; set; }
        [DataMember]public String nombre { get; set; }
        [DataMember]public String pais { get; set; }
        [DataMember]public String correo { get; set; }
        [DataMember]public String telefono { get; set; }
    }

    [DataContract]
    public class AutorO
    {
        [DataMember] public int codigo { get; set; }
        [DataMember] public String nombre { get; set; }
        [DataMember] public int pais { get; set; }
        [DataMember] public String correo { get; set; }
        [DataMember] public String telefono { get; set; }
    }

    [DataContract]
    public class Pais
    {
        [DataMember] public int codigo { get; set; }
        [DataMember] public String nombre { get; set; }
    }
}
