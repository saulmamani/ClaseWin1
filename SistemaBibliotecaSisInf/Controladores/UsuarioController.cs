using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBibliotecaSisInf.Modelos;

namespace SistemaBibliotecaSisInf.Controladores
{
    internal class UsuarioController
    {
        bibliotecabdEntitiesSis _db = new bibliotecabdEntitiesSis();

        public bool login(string cuenta, string password)
        {
            var usuario =
                _db.Usuario.Where(q => q.Cuenta == cuenta && q.Password == password).SingleOrDefault();

            if (usuario != null)
            {
                App.usuarioAuth = usuario;
                return true;
            }

            return false;
        }
    }

}
