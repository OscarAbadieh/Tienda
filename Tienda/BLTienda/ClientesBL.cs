using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
    public class ClientesBL
    {
        Contexto _contexto;
        public BindingList<Cliente> ListaClientes{ get; set; }
        public ClientesBL()
        {
            _contexto = new Contexto();
            ListaClientes = new BindingList<Cliente>();

        }
            public BindingList<Cliente> ObtenerClientes()
        {
            _contexto.Clientes.Load();
            ListaClientes = _contexto.Clientes.Local.ToBindingList();
            return ListaClientes;
        }

        public Resultado GuardarCliente(Cliente Cliente)

        {
            var resultado = Validar(Cliente);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }
        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            ListaClientes.Add(nuevoCliente);
        }
        public bool EliminarCliente(int id)
        {
            foreach (var Cliente in ListaClientes)
            {
                if (Cliente.Id == id)
                {
                    ListaClientes.Remove(Cliente);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }
        private Resultado Validar(Cliente Cliente)
        {
            var resultado = new Resultado();

        resultado.Exitoso = true;

            if (string.IsNullOrEmpty(Cliente.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese Nombre ";
                resultado.Exitoso = false;
            }

            return resultado;

        }
        }
    
   }

public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public Cliente()
        {
            Activo = true;

        }
    }
}
